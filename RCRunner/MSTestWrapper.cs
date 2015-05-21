using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RCRunner
{
    /// <summary>
    /// Defines an Interface to comunicate with different test frameworks, such as mstest, nunit, etc
    /// </summary>
    public interface ITestFrameworkRunner
    {
        /// <summary>
        /// Executes a test case specified by the testcase param
        /// </summary>
        /// <param name="testCase">The test case to run</param>
        void RunTest(string testCase);
        /// <summary>
        /// Returns the assembly that contains the test cases to run
        /// </summary>
        /// <returns>Returns the assembly path</returns>
        string GetAssemblyPath();
        /// <summary>
        /// Sets the assembly that contains the test cases to run
        /// </summary>
        /// <param name="assemblyPath">The assembly that contains the test cases to run</param>
        void SetAssemblyPath(string assemblyPath);
        /// <summary>
        /// Retuns the folder which the tests results will be stored
        /// </summary>
        /// <returns>The folder which the tests results will be stored</returns>
        string GetTestResultsFolder();
        /// <summary>
        /// Sets the folder which the tests results will be stored
        /// </summary>
        /// <param name="folder">The folder which the tests results will be stored</param>
        void SetTestResultsFolder(string folder);
        /// <summary>
        /// Returns the name of the attribute that defines a test method
        /// </summary>
        /// <returns>The name of the attribute that defines a test method</returns>
        string GetTestMethodAttribute();
        /// <summary>
        /// Returns the name of the attribute that defines a description for a test method
        /// </summary>
        /// <returns>The name of the attribute that defines description for a test method</returns>
        string GetTestMethodDescriptionAttribute();
    }

    /// <summary>
    /// A test wrapper that implements the ITestFrameworkRunner as an adapter for the MSTest test framework
    /// </summary>
    public class MSTestWrapper : ITestFrameworkRunner
    {
        private string _assemblyPath;
        private string _resultFilePath;

        /// <summary>
        /// Returns the assembly that contains the test cases to run
        /// </summary>
        /// <returns>Returns the assembly path</returns>
        public string GetAssemblyPath()
        {
            return _assemblyPath;
        }

        /// <summary>
        /// Sets the assembly that contains the test cases to run
        /// </summary>
        /// <param name="assemblyPath">The assembly that contains the test cases to run</param>
        public void SetAssemblyPath(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
        }

        /// <summary>
        /// Retuns the folder which the tests results will be stored
        /// </summary>
        /// <returns>The folder which the tests results will be stored</returns>
        public string GetTestResultsFolder()
        {
            return _resultFilePath;
        }

        /// <summary>
        /// Sets the folder which the tests results will be stored
        /// </summary>
        /// <param name="folder">The folder which the tests results will be stored</param>
        public void SetTestResultsFolder(string folder)
        {
            _resultFilePath = folder;
        }

        /// <summary>
        /// Returns the name of the attribute that defines a test method
        /// </summary>
        /// <returns>The name of the attribute that defines a test method</returns>
        public string GetTestMethodAttribute()
        {
            return typeof(TestMethodAttribute).FullName;
        }

        /// <summary>
        /// Executes a test case specified by the testcase param
        /// </summary>
        /// <param name="testCase">The test case to run</param>
        public void RunTest(string testCase)
        {
            var msTestPath = Properties.Settings.Default.MSTestExeLocation;
            if (!File.Exists(msTestPath)) throw new FileNotFoundException("MSTest app not found on the specified path", msTestPath);
            if (!File.Exists(_assemblyPath)) throw new FileNotFoundException("Test Assembly not found on the specified path", _assemblyPath);
            var testContainer = "/testcontainer:" + "\"" + _assemblyPath + "\"";
            var testParam = "/test:" + testCase;
            var resultFilePath = Path.Combine(_resultFilePath, testCase);
            Directory.CreateDirectory(resultFilePath);
            var resultFile = Path.Combine(resultFilePath, testCase + ".trx");
            File.Delete(resultFile);
            var resultParam = "/resultsfile:" + "\"" + resultFile + "\"";
            try
            {
                var p = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        FileName = msTestPath,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = testContainer + " " + testParam + " " + resultParam
                    }
                };

                if (!p.Start())
                {
                    throw new Exception("Error starting the MSTest process", new Exception(p.StandardError.ReadToEnd()));
                }

                p.WaitForExit();

                var errorMsg = "";

                var testResult = GetTestStatusFromTrxFile(resultFile, ref errorMsg);

                if (!testResult)
                {
                    throw new Exception(errorMsg);
                }
            }
            finally
            {
                CleanUpDirectories(resultFilePath);
            }
        }

        /// <summary>
        /// Gets the result outcome and, in case of a failed test case, returns the test case execution error
        /// </summary>
        /// <param name="fileName">TRX file to read from</param>
        /// <param name="errorMsg">The error message pointer to return the error when the test fails</param>
        /// <returns>Returns true if the test ran successfuly or false if the test failed</returns>
        static bool GetTestStatusFromTrxFile(string fileName, ref string errorMsg)
        {
            var fileStreamReader = new StreamReader(fileName);
            var xmlSer = new XmlSerializer(typeof(TestRunType));
            var testRunType = (TestRunType)xmlSer.Deserialize(fileStreamReader);

            var resultType = testRunType.Items.OfType<ResultsType>().FirstOrDefault();

            if (resultType == null) throw new Exception("Cannot get the ResultsType from the TRX file");

            var unitTestResultType = resultType.Items.OfType<UnitTestResultType>().FirstOrDefault();

            if (unitTestResultType == null) throw new Exception("Cannot get the UnitTestResultType from the TRX file");

            var testResult = unitTestResultType.outcome;

            if (!testResult.ToLower().Equals("failed")) return true;

            errorMsg = ((System.Xml.XmlNode[])(((OutputType)(unitTestResultType.Items[0])).ErrorInfo.Message))[0].Value;

            return false;
        }

        /// <summary>
        /// Cleans up all folder directories in the TestResults folder
        /// </summary>
        public void CleanUpDirectories(string resultFilePath)
        {
            try
            {
                var filePaths = Directory.GetDirectories(resultFilePath);

                foreach (var folder in filePaths)
                {
                    CleanDirectory(new DirectoryInfo(folder));
                    Directory.Delete(folder);
                }

            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                
            }
        }

        /// <summary>
        /// Returns the name of the attribute that defines a description for a test method
        /// </summary>
        /// <returns>The name of the attribute that defines description for a test method</returns>
        public string GetTestMethodDescriptionAttribute()
        {
            return typeof (DescriptionAttribute).FullName;
        }

        /// <summary>
        /// Cleans a single directory content
        /// </summary>
        /// <param name="directory"></param>
        private static void CleanDirectory(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (var subDirectory in directory.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }

    }
}
