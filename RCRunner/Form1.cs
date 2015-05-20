using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RCRunner
{
    public partial class Form1 : Form
    {
        private readonly RCRunnerAPI _rcRunner;
        private delegate void SetTextCallback(TestMethod testcaseMethod);
        private delegate void SetEnabledCallback(bool enabled);

        private readonly Color _testActive = Color.FloralWhite;
        private readonly Color _testFailed = Color.Red;
        private readonly Color _testPassed = Color.GreenYellow;
        private readonly Color _testRunning = Color.Blue;
        private readonly Color _testWaiting = Color.DarkOrange;
        private readonly ITestFrameworkRunner _testFrameworkRunner;
        private int _totFailedTestScripts;
        private int _totPassedTestScripts;
        private int _totRunningTestScripts;
        private int _totWaitingTestScripts;

        public Form1()
        {
            InitializeComponent();

            _testFrameworkRunner = new MSTestWrapper();

            _rcRunner = new RCRunnerAPI(_testFrameworkRunner);
            _rcRunner.OnTestFinished += OnTaskFinishedEvent;
            _rcRunner.MethodStatusChanged += OnMethodStatusChanged;

            lblFailedScripts.ForeColor = _testFailed;
            lblPassedScripts.ForeColor = _testPassed;
            lblRunningScripts.ForeColor = _testRunning;
            lblWatingScripts.ForeColor = _testWaiting;

            ResetTestExecution();

            DisableOrEnableControls(true);
        }

        private void ResetTestExecution()
        {
            _totFailedTestScripts = 0;
            _totPassedTestScripts = 0;
            _totRunningTestScripts = 0;
            _totWaitingTestScripts = 0;
            prgrsbrTestProgress.Maximum = 0;
            lblPassedScripts.Text = @"Passed scripts: " + _totPassedTestScripts;
            lblFailedScripts.Text = @"Failed scripts: " + _totFailedTestScripts;
            lblRunningScripts.Text = @"Running scripts: " + _totRunningTestScripts;
            lblWatingScripts.Text = @"Waiting scripts: " + _totWaitingTestScripts;
        }

        private static void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    CheckTreeViewNode(item, isChecked);
                }
            }
        }

        private void PaintTreeNodeBasedOnTestStatus(TestMethod testcaseMethod, TreeNode node)
        {
            switch (testcaseMethod.TestExecutionStatus)
            {
                case TestExecutionStatus.Active:
                    node.ForeColor = _testActive;
                    break;
                case TestExecutionStatus.Failed:
                    node.ForeColor = _testFailed;
                    break;
                case TestExecutionStatus.Passed:
                    node.ForeColor = _testPassed;
                    break;
                case TestExecutionStatus.Running:
                    node.ForeColor = _testRunning;
                    break;
                case TestExecutionStatus.Waiting:
                    node.ForeColor = _testWaiting;
                    break;
            }

            

        }

        private TreeNode FindNodebyTest(TestMethod testcaseMethod)
        {
            TreeNode nodeFound = null;

            foreach (TreeNode node in trvTestCases.Nodes)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Tag == testcaseMethod)
                    {
                        nodeFound = child;
                    }
                }
            }
            return nodeFound;
        }

        private TreeNode FindNodebyClassName(TestMethod testcaseMethod)
        {
            TreeNode nodeFound = null;

            foreach (TreeNode node in trvTestCases.Nodes)
            {
                if (node.Text.Equals(testcaseMethod.ClassName))
                {
                    nodeFound = node;
                }
                
            }
            return nodeFound;
        }

        private void OnMethodStatusChanged(TestMethod testcasemethod)
        {
            OnTaskFinishedEvent(testcasemethod);
        }

        private void UpdateLblTestScripts(TestMethod testcaseMethod)
        {
            if (lblPassedScripts.InvokeRequired)
            {
                var d = new SetTextCallback(UpdateLblTestScripts);
                Invoke(d, new object[] { testcaseMethod });
            }
            else
            {
                lblPassedScripts.Text = @"Passed scripts: " + _totPassedTestScripts;
                lblFailedScripts.Text = @"Failed scripts: " + _totFailedTestScripts;
                lblRunningScripts.Text = @"Running scripts: " + _totRunningTestScripts;
                lblWatingScripts.Text = @"Waiting scripts: " + _totWaitingTestScripts;
            }
        }

        private void UpdateTreeview(TestMethod testcaseMethod)
        {
            if (trvTestCases.InvokeRequired)
            {
                var d = new SetTextCallback(UpdateTreeview);
                Invoke(d, new object[] { testcaseMethod });
            }
            else
            {
                var nodeFound = FindNodebyTest(testcaseMethod);
                if (nodeFound == null) return;
                PaintTreeNodeBasedOnTestStatus(testcaseMethod, nodeFound);
                if (trvTestCases.SelectedNode != null)
                {
                    trvTestCases_AfterSelect(trvTestCases.SelectedNode, null);
                }
            }
        }

        private void OnTaskFinishedEvent(TestMethod testcaseMethod)
        {
            UpdateTreeview(testcaseMethod);

            var status = testcaseMethod.TestExecutionStatus;

            if (status == TestExecutionStatus.Failed || status == TestExecutionStatus.Passed)
            {
                _totRunningTestScripts--;
                if (prgrsbrTestProgress.InvokeRequired)
                {
                    Action d = prgrsbrTestProgress.PerformStep;
                    Invoke(d);
                }
                else
                {
                    prgrsbrTestProgress.PerformStep();
                }
            }

            if (status == TestExecutionStatus.Running)
            {
                _totRunningTestScripts++;
                _totWaitingTestScripts--;
            }

            if (status == TestExecutionStatus.Failed) _totFailedTestScripts++;
            if (status == TestExecutionStatus.Passed) _totPassedTestScripts++;
            
            if (status == TestExecutionStatus.Waiting) _totWaitingTestScripts++;

            UpdateLblTestScripts(testcaseMethod);

            if (_totRunningTestScripts > 0 || _totWaitingTestScripts > 0) return;

            DisableOrEnableControls(true);
            _testFrameworkRunner.CleanUpDirectories();
        }

        private static string CreateTestResultsFolder()
        {
            var folderName = DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace("/", "").Replace(":", "");
            var resultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", folderName);
            Directory.CreateDirectory(resultFilePath);
            return resultFilePath;
        }

        private void trvTestCases_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }

        private void trvTestCases_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = trvTestCases.SelectedNode;
            if (node == null) return;
            if (!(node.Tag is TestMethod)) return;

            var testMethod = node.Tag as TestMethod;
            txtbxTestDescription.Text = testMethod.TestDescription;
            lblTestStatus.Text = @"Test Status: " + testMethod.TestExecutionStatus;
            switch (testMethod.TestExecutionStatus)
            {
                case TestExecutionStatus.Active:
                    lblTestStatus.ForeColor = _testActive;
                    break;
                case TestExecutionStatus.Failed:
                    lblTestStatus.ForeColor = _testFailed;
                    break;
                case TestExecutionStatus.Passed:
                    lblTestStatus.ForeColor = _testPassed;
                    break;
                case TestExecutionStatus.Running:
                    lblTestStatus.ForeColor = _testRunning;
                    break;
                case TestExecutionStatus.Waiting:
                    lblTestStatus.ForeColor = _testWaiting;
                    break;
            }

            txtbxTestError.Text = testMethod.LastExecutionErrorMsg;
        }

        private void lblLoadAssembly_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetTestExecution();
            DisableOrEnableControls(false);
            try
            {
                trvTestCases.Nodes.Clear();
                trvTestCases.CheckBoxes = true;

                var fileDialog = new OpenFileDialog {DefaultExt = ".dll", CheckFileExists = true, Multiselect = false};

                var foundAssembly = fileDialog.ShowDialog();

                if (foundAssembly != DialogResult.OK) return;

                var assemblyFile = fileDialog.FileName;

                _testFrameworkRunner.SetAssemblyPath(assemblyFile);

                _rcRunner.LoadAssembly();


                foreach (var testMethod in _rcRunner.TestClassesList)
                {
                    var classNode = FindNodebyClassName(testMethod);

                    if (classNode == null)
                    {
                        classNode = trvTestCases.Nodes.Add(testMethod.ClassName);    
                    }
                    
                    var methodNode = classNode.Nodes.Add(testMethod.Method.Name);
                    methodNode.Tag = testMethod;
                    PaintTreeNodeBasedOnTestStatus(testMethod, methodNode);

                }
            }
            finally
            {
                DisableOrEnableControls(true);
            }
        }

        private static int TreeviewCountCheckedNodes(IEnumerable treeNodeCollection)
        {
            var countchecked = 0;
            
            if (treeNodeCollection == null) return countchecked;

            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Nodes.Count == 0 && node.Checked)
                {
                    countchecked++;
                }
                else if (node.Nodes.Count > 0)
                {
                    countchecked += TreeviewCountCheckedNodes(node.Nodes);
                }
            }

            return countchecked;
        }

        private void lblExecuteTestScripts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetTestExecution();

            DisableOrEnableControls(false);

            prgrsbrTestProgress.Maximum = TreeviewCountCheckedNodes(trvTestCases.Nodes);

            var testCasesList = new List<TestMethod>();

            foreach (TreeNode node in trvTestCases.Nodes)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    if (!child.Checked) continue;
                    if (!(child.Tag is TestMethod)) continue;

                    var testMethod = child.Tag as TestMethod;

                    testCasesList.Add(testMethod);

                }
            }

            if (testCasesList.Any())
            {
                var testResultsFolder = CreateTestResultsFolder();
                _testFrameworkRunner.SetTestResultsFolder(testResultsFolder);
                _rcRunner.RunTestCases(testCasesList);
            }
            else
            {
                DisableOrEnableControls(true);
            }
            
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            _rcRunner.Cancel();
        }

        private void DisableOrEnableControls(bool enable)
        {
            if (lblLoadAssembly.InvokeRequired)
            {
                SetEnabledCallback d = DisableOrEnableControls;
                Invoke(d, new object[] { enable });
            }
            else
            {
                lblCancel.Enabled = !enable;
                lblLoadAssembly.Enabled = enable;
                lblExecuteTestScripts.Enabled = enable;
            }
        }

    }

}
