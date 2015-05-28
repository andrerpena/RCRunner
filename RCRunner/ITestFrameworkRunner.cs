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

        /// <summary>
        /// Returns the name of the test runner
        /// </summary>
        /// <returns></returns>
        string GetDisplayName();
    }
}

    