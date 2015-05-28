namespace RCRunner
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTestRunners = new System.Windows.Forms.ComboBox();
            this.lblCancel = new System.Windows.Forms.LinkLabel();
            this.lblExecuteTestScripts = new System.Windows.Forms.LinkLabel();
            this.lblLoadAssembly = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblPassedScripts = new System.Windows.Forms.Label();
            this.lblFailedScripts = new System.Windows.Forms.Label();
            this.lblWatingScripts = new System.Windows.Forms.Label();
            this.lblRunningScripts = new System.Windows.Forms.Label();
            this.prgrsbrTestProgress = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtbxTestError = new System.Windows.Forms.TextBox();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxTestDescription = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trvTestCases = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbTestRunners);
            this.panel1.Controls.Add(this.lblCancel);
            this.panel1.Controls.Add(this.lblExecuteTestScripts);
            this.panel1.Controls.Add(this.lblLoadAssembly);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 47);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 11);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Test framework";
            // 
            // cmbTestRunners
            // 
            this.cmbTestRunners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTestRunners.FormattingEnabled = true;
            this.cmbTestRunners.Location = new System.Drawing.Point(110, 14);
            this.cmbTestRunners.Name = "cmbTestRunners";
            this.cmbTestRunners.Size = new System.Drawing.Size(301, 21);
            this.cmbTestRunners.TabIndex = 7;
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancel.ForeColor = System.Drawing.Color.White;
            this.lblCancel.LinkColor = System.Drawing.Color.White;
            this.lblCancel.Location = new System.Drawing.Point(708, 14);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(116, 17);
            this.lblCancel.TabIndex = 5;
            this.lblCancel.TabStop = true;
            this.lblCancel.Text = "Cancel Execution";
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // lblExecuteTestScripts
            // 
            this.lblExecuteTestScripts.AutoSize = true;
            this.lblExecuteTestScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExecuteTestScripts.ForeColor = System.Drawing.Color.White;
            this.lblExecuteTestScripts.LinkColor = System.Drawing.Color.White;
            this.lblExecuteTestScripts.Location = new System.Drawing.Point(552, 14);
            this.lblExecuteTestScripts.Name = "lblExecuteTestScripts";
            this.lblExecuteTestScripts.Size = new System.Drawing.Size(137, 17);
            this.lblExecuteTestScripts.TabIndex = 4;
            this.lblExecuteTestScripts.TabStop = true;
            this.lblExecuteTestScripts.Text = "Execute Test Scripts";
            this.lblExecuteTestScripts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblExecuteTestScripts_LinkClicked);
            // 
            // lblLoadAssembly
            // 
            this.lblLoadAssembly.AutoSize = true;
            this.lblLoadAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadAssembly.ForeColor = System.Drawing.Color.White;
            this.lblLoadAssembly.LinkColor = System.Drawing.Color.White;
            this.lblLoadAssembly.Location = new System.Drawing.Point(426, 14);
            this.lblLoadAssembly.Name = "lblLoadAssembly";
            this.lblLoadAssembly.Size = new System.Drawing.Size(104, 17);
            this.lblLoadAssembly.TabIndex = 3;
            this.lblLoadAssembly.TabStop = true;
            this.lblLoadAssembly.Text = "Load Assembly";
            this.lblLoadAssembly.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLoadAssembly_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblPassedScripts);
            this.panel4.Controls.Add(this.lblFailedScripts);
            this.panel4.Controls.Add(this.lblWatingScripts);
            this.panel4.Controls.Add(this.lblRunningScripts);
            this.panel4.Controls.Add(this.prgrsbrTestProgress);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1055, 72);
            this.panel4.TabIndex = 10;
            // 
            // lblPassedScripts
            // 
            this.lblPassedScripts.AutoSize = true;
            this.lblPassedScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedScripts.ForeColor = System.Drawing.Color.White;
            this.lblPassedScripts.Location = new System.Drawing.Point(759, 43);
            this.lblPassedScripts.Name = "lblPassedScripts";
            this.lblPassedScripts.Size = new System.Drawing.Size(133, 17);
            this.lblPassedScripts.TabIndex = 5;
            this.lblPassedScripts.Text = "Passed scripts: 0";
            // 
            // lblFailedScripts
            // 
            this.lblFailedScripts.AutoSize = true;
            this.lblFailedScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailedScripts.ForeColor = System.Drawing.Color.White;
            this.lblFailedScripts.Location = new System.Drawing.Point(557, 43);
            this.lblFailedScripts.Name = "lblFailedScripts";
            this.lblFailedScripts.Size = new System.Drawing.Size(124, 17);
            this.lblFailedScripts.TabIndex = 4;
            this.lblFailedScripts.Text = "Failed scripts: 0";
            // 
            // lblWatingScripts
            // 
            this.lblWatingScripts.AutoSize = true;
            this.lblWatingScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatingScripts.ForeColor = System.Drawing.Color.White;
            this.lblWatingScripts.Location = new System.Drawing.Point(345, 43);
            this.lblWatingScripts.Name = "lblWatingScripts";
            this.lblWatingScripts.Size = new System.Drawing.Size(134, 17);
            this.lblWatingScripts.TabIndex = 3;
            this.lblWatingScripts.Text = "Waiting scripts: 0";
            // 
            // lblRunningScripts
            // 
            this.lblRunningScripts.AutoSize = true;
            this.lblRunningScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningScripts.ForeColor = System.Drawing.Color.White;
            this.lblRunningScripts.Location = new System.Drawing.Point(127, 43);
            this.lblRunningScripts.Name = "lblRunningScripts";
            this.lblRunningScripts.Size = new System.Drawing.Size(140, 17);
            this.lblRunningScripts.TabIndex = 2;
            this.lblRunningScripts.Text = "Running scripts: 0";
            // 
            // prgrsbrTestProgress
            // 
            this.prgrsbrTestProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgrsbrTestProgress.ForeColor = System.Drawing.Color.Coral;
            this.prgrsbrTestProgress.Location = new System.Drawing.Point(73, 9);
            this.prgrsbrTestProgress.Name = "prgrsbrTestProgress";
            this.prgrsbrTestProgress.Size = new System.Drawing.Size(911, 23);
            this.prgrsbrTestProgress.Step = 1;
            this.prgrsbrTestProgress.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1055, 487);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(319, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 487);
            this.panel3.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.panel7.Controls.Add(this.txtbxTestError);
            this.panel7.Controls.Add(this.lblTestStatus);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 111);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(736, 376);
            this.panel7.TabIndex = 17;
            // 
            // txtbxTestError
            // 
            this.txtbxTestError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxTestError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.txtbxTestError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxTestError.ForeColor = System.Drawing.Color.White;
            this.txtbxTestError.Location = new System.Drawing.Point(7, 26);
            this.txtbxTestError.Multiline = true;
            this.txtbxTestError.Name = "txtbxTestError";
            this.txtbxTestError.ReadOnly = true;
            this.txtbxTestError.Size = new System.Drawing.Size(719, 338);
            this.txtbxTestError.TabIndex = 17;
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestStatus.ForeColor = System.Drawing.Color.White;
            this.lblTestStatus.Location = new System.Drawing.Point(7, 5);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(70, 15);
            this.lblTestStatus.TabIndex = 16;
            this.lblTestStatus.Text = "Test Status:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtbxTestDescription);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(736, 111);
            this.panel6.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Test Description";
            // 
            // txtbxTestDescription
            // 
            this.txtbxTestDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxTestDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.txtbxTestDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxTestDescription.ForeColor = System.Drawing.Color.White;
            this.txtbxTestDescription.Location = new System.Drawing.Point(7, 25);
            this.txtbxTestDescription.Multiline = true;
            this.txtbxTestDescription.Name = "txtbxTestDescription";
            this.txtbxTestDescription.ReadOnly = true;
            this.txtbxTestDescription.Size = new System.Drawing.Size(719, 75);
            this.txtbxTestDescription.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cmbxFilter);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.trvTestCases);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(319, 487);
            this.panel5.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filter";
            // 
            // cmbxFilter
            // 
            this.cmbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFilter.FormattingEnabled = true;
            this.cmbxFilter.Items.AddRange(new object[] {
            "Everything",
            "Running Scripts",
            "Wating Scripts",
            "Failed Scripts",
            "Passed Scripts",
            "Active Scripts"});
            this.cmbxFilter.Location = new System.Drawing.Point(49, 30);
            this.cmbxFilter.Name = "cmbxFilter";
            this.cmbxFilter.Size = new System.Drawing.Size(261, 21);
            this.cmbxFilter.TabIndex = 8;
            this.cmbxFilter.SelectionChangeCommitted += new System.EventHandler(this.cmbxFilter_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Test scripts";
            // 
            // trvTestCases
            // 
            this.trvTestCases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvTestCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.trvTestCases.ForeColor = System.Drawing.Color.White;
            this.trvTestCases.Location = new System.Drawing.Point(12, 59);
            this.trvTestCases.Name = "trvTestCases";
            this.trvTestCases.Size = new System.Drawing.Size(298, 416);
            this.trvTestCases.TabIndex = 2;
            this.trvTestCases.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvTestCases_AfterCheck);
            this.trvTestCases.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTestCases_AfterSelect);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 606);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RC Runner";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtbxTestError;
        private System.Windows.Forms.Label lblTestStatus;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtbxTestDescription;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TreeView trvTestCases;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar prgrsbrTestProgress;
        private System.Windows.Forms.LinkLabel lblExecuteTestScripts;
        private System.Windows.Forms.LinkLabel lblLoadAssembly;
        private System.Windows.Forms.Label lblRunningScripts;
        private System.Windows.Forms.Label lblWatingScripts;
        private System.Windows.Forms.Label lblPassedScripts;
        private System.Windows.Forms.Label lblFailedScripts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTestRunners;

    }
}

