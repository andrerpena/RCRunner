using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RCRunner
{
    public class PluginLoader
    {
        /// <summary>
        /// List of all the test runners plugins
        /// </summary>
        public List<ITestFrameworkRunner> TestRunnersPluginList;

        /// <summary>
        /// List of test plugins
        /// </summary>
        public List<ITestExecution> TestExecutionPlugiList; 

        /// <summary>
        /// Loads an assembly that contains a test runner
        /// </summary>
        /// <param name="file"></param>
        private void LoadTestRunnerAssembly(string file)
        {
            try
            {
                var assembly = Assembly.LoadFrom(file);

                var classes = from type in assembly.GetTypes()
                              where typeof(ITestFrameworkRunner).IsAssignableFrom(type) && type.IsPublic
                              select type;

                foreach (var testRunnerObj in classes.Select(@class => (ITestFrameworkRunner)Activator.CreateInstance(@class)))
                {
                    TestRunnersPluginList.Add(testRunnerObj);
                }

            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Loads all test runners plugins from a folder
        /// </summary>
        public void LoadTestRunnersPlugins()
        {
            var resultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", "TestRunners");

            if (!Directory.Exists(resultFilePath)) return;

            var filePaths = Directory.GetFiles(resultFilePath, "*.dll");

            foreach (var file in filePaths)
            {
                LoadTestRunnerAssembly(file);
            }
        }

        /// <summary>
        /// Loadas all test plugins from a folder
        /// </summary>
        public void LoadTestExecutionPlugins()
        {
            var resultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", "TestExecution");

            if (!Directory.Exists(resultFilePath)) return;

            var filePaths = Directory.GetFiles(resultFilePath, "*.dll");

            foreach (var file in filePaths)
            {
                LoadTestExecutionAssembly(file);
            }
        }

        /// <summary>
        /// Loadas an assembly that contatis a test plugin
        /// </summary>
        /// <param name="file"></param>
        private void LoadTestExecutionAssembly(string file)
        {
            try
            {
                var assembly = Assembly.LoadFrom(file);

                var classes = from type in assembly.GetTypes()
                              where typeof(ITestExecution).IsAssignableFrom(type) && type.IsPublic
                              select type;

                foreach (var testExecutionObj in classes.Select(@class => (ITestExecution)Activator.CreateInstance(@class)))
                {
                    TestExecutionPlugiList.Add(testExecutionObj);
                }

            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Basic constructor
        /// </summary>
        public PluginLoader()
        {
            TestRunnersPluginList = new List<ITestFrameworkRunner>();
            TestExecutionPlugiList = new List<ITestExecution>();
        }
    }
}
