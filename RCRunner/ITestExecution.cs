namespace RCRunner
{
    /// <summary>
    /// Defines an interface for plugins that needs to be called when a test execution happens
    /// </summary>
    public interface ITestExecution
    {
        /// <summary>
        /// Called when a test script finishes its executions
        /// </summary>
        /// <param name="idTestCase">Name of the test case</param>
        void AfterTestExecution(string idTestCase);
    }
}
