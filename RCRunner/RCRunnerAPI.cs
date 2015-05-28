using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RCRunner
{
    public enum TestExecutionStatus
    {
        Failed,
        Passed,
        Active,
        Waiting,
        Running,
    }
    
    public class TestMethod
    {
        public string ClassName;
        public MethodInfo Method;
        public string DisplayName;
        public string LastExecutionErrorMsg;
        public TestExecutionStatus TestExecutionStatus;
        public string TestDescription;
    }
    
    public delegate bool CheckCanceled();

    public class RCRunnerAPI
    {
        public readonly List<TestMethod> TestClassesList;

        private readonly TestCasesThreadRunner _testCasesThreadRunner;

        public event TestMethodEventHandler OnTestFinished;

        public event TestMethodEventHandler MethodStatusChanged;

        private ITestFrameworkRunner _testFrameworkRunner;

        private bool _canceled;

        private bool CheckTasksCanceled()
        {
            return _canceled;
        }

        public void Cancel()
        {
            _canceled = true;
        }

        protected virtual void StatusChanged(TestMethod testcasemethod)
        {
            var handler = MethodStatusChanged;
            if (handler != null) handler(testcasemethod);
        }

        protected virtual void OnOnTestFinished(TestMethod testcasemethod)
        {
            var handler = OnTestFinished;
            if (handler != null) handler(testcasemethod);
        }

        protected virtual void OnMethodStatusChanged(TestMethod testcasemethod)
        {
            StatusChanged(testcasemethod);
        }

        public RCRunnerAPI()
        {
            _testCasesThreadRunner = new TestCasesThreadRunner();
            TestClassesList = new List<TestMethod>();
            _testCasesThreadRunner.Finished += OnTaskFinishedEvent;
            _testCasesThreadRunner.MethodStatusChanged += OnMethodStatusChanged;
            _testCasesThreadRunner.Canceled += CheckTasksCanceled;
            _canceled = false;
        }

         public void SetTestRunner(ITestFrameworkRunner testFrameworkRunner)
        {
            _testFrameworkRunner = testFrameworkRunner;
            _testCasesThreadRunner.SetTestRunner(testFrameworkRunner);
        }

        private string GetDescriptionAttributeValue(MemberInfo methodInfo)
        {
            var descriptionAttributeName = _testFrameworkRunner.GetTestMethodDescriptionAttribute();

            var descriptionAttr = Attribute.GetCustomAttributes(methodInfo).FirstOrDefault(x => x.GetType().FullName == descriptionAttributeName);

            var description = string.Empty;

            if (descriptionAttr == null) return description;

            var descriptionProperty = descriptionAttr.GetType().GetProperty("Description");

            if (descriptionProperty != null)
            {
                description = descriptionProperty.GetValue(descriptionAttr, null) as string;    
            }

            return description;
        }

        private IList<MethodInfo> GetTestMethodsList(Type classObject)
        {
            var testAttributeName = _testFrameworkRunner.GetTestMethodAttribute();

            var rawMethods = classObject.GetMethods().Where(x => x.GetCustomAttributes().Any(y => y.GetType().FullName == testAttributeName));

            var methodInfos = rawMethods as IList<MethodInfo> ?? rawMethods.ToList();

            return methodInfos;
        }

        public void LoadAssembly()
        {
            var assembly = Assembly.LoadFrom(_testFrameworkRunner.GetAssemblyPath());

            TestClassesList.Clear();

            foreach (var classes in assembly.GetTypes())
            {
                if (!classes.IsClass && !classes.IsPublic) continue;

                var methodInfos = GetTestMethodsList(classes);

                if (!methodInfos.Any()) continue;

                var className = classes.Name;

                foreach (var testMethod in methodInfos.Select(methodInfo => new TestMethod
                {
                    ClassName = className,
                    Method = methodInfo,
                    DisplayName = methodInfo.Name,
                    TestExecutionStatus = TestExecutionStatus.Active,
                    LastExecutionErrorMsg = string.Empty,
                    TestDescription = GetDescriptionAttributeValue(methodInfo)
                }))

                    TestClassesList.Add(testMethod);
            }
        }

        public void RunTestCases(List<TestMethod> testCasesList)
        {

            _canceled = false;
            _testCasesThreadRunner.DoWork(testCasesList);
        }

        private void OnTaskFinishedEvent(TestMethod testcaseMethod)
        {
            OnOnTestFinished(testcaseMethod);
        }

    }
}
