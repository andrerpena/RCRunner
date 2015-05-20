using System;
using System.Threading;

namespace RCRunner
{
    public delegate void TestMethodEventHandler(TestMethod testcaseMethod);

    public delegate void ActionMachine(string machineName);

    public class TestCaseTaskThread
    {
        private readonly TestMethod _testCase;
        private readonly ITestFrameworkRunner _testFrameworkRunner;

        public event TestMethodEventHandler Finished;

        protected virtual void OnFinished(Exception exception)
        {
            var handler = Finished;

            if (exception != null)
            {
                _testCase.TestExecutionStatus = TestExecutionStatus.Failed;
                _testCase.LastExecutionErrorMsg = exception.ToString();
            }
            else
            {
                _testCase.TestExecutionStatus = TestExecutionStatus.Passed;
                _testCase.LastExecutionErrorMsg = string.Empty;
            }

            if (handler != null) handler(_testCase);
        }

        public TestCaseTaskThread(TestMethod testCase, ITestFrameworkRunner testFrameworkRunner)
        {
            _testCase = testCase;
            _testFrameworkRunner = testFrameworkRunner;
        }

        public void DoWork()
        {
            var t = new Thread(DoWorkCore);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void DoWorkCore()
        {
            try
            {
                _testFrameworkRunner.RunTest(_testCase.DisplayName);
                OnFinished(null);

            }
            catch (Exception exception)
            {
                OnFinished(exception);
            }
        }
    }
}