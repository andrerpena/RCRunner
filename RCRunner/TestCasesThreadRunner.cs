using System.Collections.Generic;
using System.Threading;

namespace RCRunner
{

    public class TestCasesThreadRunner
    {
        private List<TestMethod> _testCasesList;

        public event TestMethodEventHandler Finished;

        public event TestMethodEventHandler MethodStatusChanged;

        private readonly ITestFrameworkRunner _testFrameworkRunner;

        public event CheckCanceled Canceled;

        private int _totRunningScripts;

        protected virtual bool OnCanceled()
        {
            var handler = Canceled;
            return handler != null && handler();
        }

        protected virtual void OnMethodStatusChanged(TestMethod testcasemethod)
        {
            var handler = MethodStatusChanged;
            if (handler != null) handler(testcasemethod);
        }

        protected virtual void OnFinished(TestMethod testcasemethod)
        {
            var handler = Finished;
            if (handler != null) handler(testcasemethod);
        }

        public TestCasesThreadRunner(ITestFrameworkRunner testFrameworkRunner)
        {
            _testFrameworkRunner = testFrameworkRunner;
        }

        private void OnTaskFinishedEvent(TestMethod testcaseMethod)
        {
            _totRunningScripts--;
            OnFinished(testcaseMethod);
        }

        private void DoWorkCore()
        {
            _totRunningScripts = 0;

            foreach (var testClass in _testCasesList)
            {
                testClass.TestExecutionStatus = TestExecutionStatus.Waiting;
                testClass.LastExecutionErrorMsg = string.Empty;
                OnMethodStatusChanged(testClass);
            }

            foreach (var testMethod in _testCasesList)
            {
                while (_totRunningScripts >= Properties.Settings.Default.MaxThreads)
                {
                    if (OnCanceled()) return;
                }

                _totRunningScripts++;
                if (OnCanceled()) return;
                testMethod.TestExecutionStatus = TestExecutionStatus.Running;
                OnMethodStatusChanged(testMethod);
                var task = new TestCaseTaskThread(testMethod, _testFrameworkRunner);
                task.Finished += OnTaskFinishedEvent;
                task.DoWork();
            }
        }

        public void DoWork(List<TestMethod> testCasesList)
        {
            _testCasesList = testCasesList;
            var t = new Thread(DoWorkCore);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
    }
}