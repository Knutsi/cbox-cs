﻿namespace ModelEditor.forms
{
    partial class OutputView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Demo 1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Demo 2");
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buildButton = new System.Windows.Forms.Button();
            this.jsonViewCheck = new System.Windows.Forms.RadioButton();
            this.textViewCheck = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.onlyWithSelectedCheckbox = new System.Windows.Forms.CheckBox();
            this.treeViewCheck = new System.Windows.Forms.RadioButton();
            this.tableViewCheck = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.outputViewPanel = new System.Windows.Forms.Panel();
            this.jsonView = new System.Windows.Forms.TextBox();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.treeView = new System.Windows.Forms.TreeView();
            this.textView = new System.Windows.Forms.TextBox();
            this.deleteLimitSetButton = new System.Windows.Forms.Button();
            this.saveLimitSetButton = new System.Windows.Forms.Button();
            this.customLimitSetSelections = new System.Windows.Forms.ComboBox();
            this.actionListView = new System.Windows.Forms.ListView();
            this.actioncOLUMN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.problemColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.customLimitSelect = new System.Windows.Forms.RadioButton();
            this.journalModeSelect = new System.Windows.Forms.RadioButton();
            this.setRecModeSelect = new System.Windows.Forms.RadioButton();
            this.setModeSelect = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.outputViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(162, 48);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(169, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Auto-build on updates";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(-2, 40);
            this.buildButton.Margin = new System.Windows.Forms.Padding(6);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(150, 44);
            this.buildButton.TabIndex = 3;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            // 
            // jsonViewCheck
            // 
            this.jsonViewCheck.AutoSize = true;
            this.jsonViewCheck.Location = new System.Drawing.Point(412, 4);
            this.jsonViewCheck.Margin = new System.Windows.Forms.Padding(6);
            this.jsonViewCheck.Name = "jsonViewCheck";
            this.jsonViewCheck.Size = new System.Drawing.Size(66, 21);
            this.jsonViewCheck.TabIndex = 4;
            this.jsonViewCheck.Text = "JSON";
            this.jsonViewCheck.UseVisualStyleBackColor = true;
            // 
            // textViewCheck
            // 
            this.textViewCheck.AutoSize = true;
            this.textViewCheck.Checked = true;
            this.textViewCheck.Location = new System.Drawing.Point(90, 4);
            this.textViewCheck.Margin = new System.Windows.Forms.Padding(6);
            this.textViewCheck.Name = "textViewCheck";
            this.textViewCheck.Size = new System.Drawing.Size(56, 21);
            this.textViewCheck.TabIndex = 5;
            this.textViewCheck.TabStop = true;
            this.textViewCheck.Text = "Text";
            this.textViewCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-6, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Format:";
            // 
            // onlyWithSelectedCheckbox
            // 
            this.onlyWithSelectedCheckbox.AutoSize = true;
            this.onlyWithSelectedCheckbox.Location = new System.Drawing.Point(432, 48);
            this.onlyWithSelectedCheckbox.Margin = new System.Windows.Forms.Padding(6);
            this.onlyWithSelectedCheckbox.Name = "onlyWithSelectedCheckbox";
            this.onlyWithSelectedCheckbox.Size = new System.Drawing.Size(115, 21);
            this.onlyWithSelectedCheckbox.TabIndex = 7;
            this.onlyWithSelectedCheckbox.Text = "Selected only";
            this.onlyWithSelectedCheckbox.UseVisualStyleBackColor = true;
            // 
            // treeViewCheck
            // 
            this.treeViewCheck.AutoSize = true;
            this.treeViewCheck.Location = new System.Drawing.Point(306, 4);
            this.treeViewCheck.Margin = new System.Windows.Forms.Padding(6);
            this.treeViewCheck.Name = "treeViewCheck";
            this.treeViewCheck.Size = new System.Drawing.Size(59, 21);
            this.treeViewCheck.TabIndex = 8;
            this.treeViewCheck.Text = "Tree";
            this.treeViewCheck.UseVisualStyleBackColor = true;
            // 
            // tableViewCheck
            // 
            this.tableViewCheck.AutoSize = true;
            this.tableViewCheck.Location = new System.Drawing.Point(188, 4);
            this.tableViewCheck.Margin = new System.Windows.Forms.Padding(6);
            this.tableViewCheck.Name = "tableViewCheck";
            this.tableViewCheck.Size = new System.Drawing.Size(65, 21);
            this.tableViewCheck.TabIndex = 10;
            this.tableViewCheck.Text = "Table";
            this.tableViewCheck.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 94);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.outputViewPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.deleteLimitSetButton);
            this.splitContainer1.Panel2.Controls.Add(this.saveLimitSetButton);
            this.splitContainer1.Panel2.Controls.Add(this.customLimitSetSelections);
            this.splitContainer1.Panel2.Controls.Add(this.actionListView);
            this.splitContainer1.Panel2.Controls.Add(this.customLimitSelect);
            this.splitContainer1.Panel2.Controls.Add(this.journalModeSelect);
            this.splitContainer1.Panel2.Controls.Add(this.setRecModeSelect);
            this.splitContainer1.Panel2.Controls.Add(this.setModeSelect);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(888, 1013);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 11;
            // 
            // outputViewPanel
            // 
            this.outputViewPanel.Controls.Add(this.jsonView);
            this.outputViewPanel.Controls.Add(this.dataView);
            this.outputViewPanel.Controls.Add(this.treeView);
            this.outputViewPanel.Controls.Add(this.textView);
            this.outputViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputViewPanel.Location = new System.Drawing.Point(0, 0);
            this.outputViewPanel.Margin = new System.Windows.Forms.Padding(6);
            this.outputViewPanel.Name = "outputViewPanel";
            this.outputViewPanel.Size = new System.Drawing.Size(888, 543);
            this.outputViewPanel.TabIndex = 10;
            // 
            // jsonView
            // 
            this.jsonView.BackColor = System.Drawing.Color.Gainsboro;
            this.jsonView.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jsonView.ForeColor = System.Drawing.Color.Black;
            this.jsonView.Location = new System.Drawing.Point(22, 200);
            this.jsonView.Margin = new System.Windows.Forms.Padding(6);
            this.jsonView.Multiline = true;
            this.jsonView.Name = "jsonView";
            this.jsonView.Size = new System.Drawing.Size(236, 123);
            this.jsonView.TabIndex = 5;
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToOrderColumns = true;
            this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(530, 62);
            this.dataView.Margin = new System.Windows.Forms.Padding(6);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.Size = new System.Drawing.Size(230, 127);
            this.dataView.TabIndex = 4;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(276, 62);
            this.treeView.Margin = new System.Windows.Forms.Padding(6);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(212, 123);
            this.treeView.TabIndex = 3;
            // 
            // textView
            // 
            this.textView.BackColor = System.Drawing.Color.Navy;
            this.textView.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textView.ForeColor = System.Drawing.Color.Snow;
            this.textView.Location = new System.Drawing.Point(22, 62);
            this.textView.Margin = new System.Windows.Forms.Padding(6);
            this.textView.Multiline = true;
            this.textView.Name = "textView";
            this.textView.Size = new System.Drawing.Size(236, 123);
            this.textView.TabIndex = 2;
            // 
            // deleteLimitSetButton
            // 
            this.deleteLimitSetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteLimitSetButton.Location = new System.Drawing.Point(788, 46);
            this.deleteLimitSetButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteLimitSetButton.Name = "deleteLimitSetButton";
            this.deleteLimitSetButton.Size = new System.Drawing.Size(100, 44);
            this.deleteLimitSetButton.TabIndex = 9;
            this.deleteLimitSetButton.Text = "Delete";
            this.deleteLimitSetButton.UseVisualStyleBackColor = true;
            // 
            // saveLimitSetButton
            // 
            this.saveLimitSetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLimitSetButton.Location = new System.Drawing.Point(642, 46);
            this.saveLimitSetButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveLimitSetButton.Name = "saveLimitSetButton";
            this.saveLimitSetButton.Size = new System.Drawing.Size(134, 44);
            this.saveLimitSetButton.TabIndex = 8;
            this.saveLimitSetButton.Text = "Save set";
            this.saveLimitSetButton.UseVisualStyleBackColor = true;
            // 
            // customLimitSetSelections
            // 
            this.customLimitSetSelections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customLimitSetSelections.FormattingEnabled = true;
            this.customLimitSetSelections.Items.AddRange(new object[] {
            "None",
            "All",
            "(Save current..)",
            "(Delete current..)"});
            this.customLimitSetSelections.Location = new System.Drawing.Point(0, 50);
            this.customLimitSetSelections.Margin = new System.Windows.Forms.Padding(6);
            this.customLimitSetSelections.Name = "customLimitSetSelections";
            this.customLimitSetSelections.Size = new System.Drawing.Size(626, 24);
            this.customLimitSetSelections.TabIndex = 7;
            // 
            // actionListView
            // 
            this.actionListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionListView.CheckBoxes = true;
            this.actionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.actioncOLUMN,
            this.problemColumn});
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.actionListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.actionListView.Location = new System.Drawing.Point(0, 96);
            this.actionListView.Margin = new System.Windows.Forms.Padding(6);
            this.actionListView.Name = "actionListView";
            this.actionListView.Size = new System.Drawing.Size(884, 344);
            this.actionListView.TabIndex = 6;
            this.actionListView.UseCompatibleStateImageBehavior = false;
            this.actionListView.View = System.Windows.Forms.View.Details;
            // 
            // actioncOLUMN
            // 
            this.actioncOLUMN.Text = "Action";
            this.actioncOLUMN.Width = 416;
            // 
            // problemColumn
            // 
            this.problemColumn.Text = "Problem";
            this.problemColumn.Width = 156;
            // 
            // customLimitSelect
            // 
            this.customLimitSelect.AutoSize = true;
            this.customLimitSelect.Location = new System.Drawing.Point(490, 6);
            this.customLimitSelect.Margin = new System.Windows.Forms.Padding(6);
            this.customLimitSelect.Name = "customLimitSelect";
            this.customLimitSelect.Size = new System.Drawing.Size(76, 21);
            this.customLimitSelect.TabIndex = 5;
            this.customLimitSelect.Text = "Custom";
            this.customLimitSelect.UseVisualStyleBackColor = true;
            // 
            // journalModeSelect
            // 
            this.journalModeSelect.AutoSize = true;
            this.journalModeSelect.Location = new System.Drawing.Point(292, 6);
            this.journalModeSelect.Margin = new System.Windows.Forms.Padding(6);
            this.journalModeSelect.Name = "journalModeSelect";
            this.journalModeSelect.Size = new System.Drawing.Size(121, 21);
            this.journalModeSelect.TabIndex = 3;
            this.journalModeSelect.Text = "Default journal";
            this.journalModeSelect.UseVisualStyleBackColor = true;
            // 
            // setRecModeSelect
            // 
            this.setRecModeSelect.AutoSize = true;
            this.setRecModeSelect.Location = new System.Drawing.Point(150, 6);
            this.setRecModeSelect.Margin = new System.Windows.Forms.Padding(6);
            this.setRecModeSelect.Name = "setRecModeSelect";
            this.setRecModeSelect.Size = new System.Drawing.Size(86, 21);
            this.setRecModeSelect.TabIndex = 2;
            this.setRecModeSelect.Text = "Set + rec";
            this.setRecModeSelect.UseVisualStyleBackColor = true;
            // 
            // setModeSelect
            // 
            this.setModeSelect.AutoSize = true;
            this.setModeSelect.Checked = true;
            this.setModeSelect.Location = new System.Drawing.Point(62, 6);
            this.setModeSelect.Margin = new System.Windows.Forms.Padding(6);
            this.setModeSelect.Name = "setModeSelect";
            this.setModeSelect.Size = new System.Drawing.Size(50, 21);
            this.setModeSelect.TabIndex = 1;
            this.setModeSelect.TabStop = true;
            this.setModeSelect.Text = "Set";
            this.setModeSelect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-6, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Limit:";
            // 
            // OutputView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tableViewCheck);
            this.Controls.Add(this.treeViewCheck);
            this.Controls.Add(this.onlyWithSelectedCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textViewCheck);
            this.Controls.Add(this.jsonViewCheck);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.checkBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OutputView";
            this.Size = new System.Drawing.Size(888, 1108);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.outputViewPanel.ResumeLayout(false);
            this.outputViewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.RadioButton jsonViewCheck;
        private System.Windows.Forms.RadioButton textViewCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox onlyWithSelectedCheckbox;
        private System.Windows.Forms.RadioButton treeViewCheck;
        private System.Windows.Forms.RadioButton tableViewCheck;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel outputViewPanel;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox textView;
        private System.Windows.Forms.TextBox jsonView;
        private System.Windows.Forms.RadioButton journalModeSelect;
        private System.Windows.Forms.RadioButton setRecModeSelect;
        private System.Windows.Forms.RadioButton setModeSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView actionListView;
        private System.Windows.Forms.ColumnHeader actioncOLUMN;
        private System.Windows.Forms.RadioButton customLimitSelect;
        private System.Windows.Forms.ColumnHeader problemColumn;
        private System.Windows.Forms.ComboBox customLimitSetSelections;
        private System.Windows.Forms.Button deleteLimitSetButton;
        private System.Windows.Forms.Button saveLimitSetButton;
    }
}
