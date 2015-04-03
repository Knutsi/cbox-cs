namespace ModelEditor.forms
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
            this.dataView = new System.Windows.Forms.DataGridView();
            this.treeView = new System.Windows.Forms.TreeView();
            this.textView = new System.Windows.Forms.TextBox();
            this.jsonView = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
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
            this.checkBox1.Location = new System.Drawing.Point(87, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(129, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Auto-build on updates";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(6, 20);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(75, 23);
            this.buildButton.TabIndex = 3;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // jsonViewCheck
            // 
            this.jsonViewCheck.AutoSize = true;
            this.jsonViewCheck.Location = new System.Drawing.Point(212, 2);
            this.jsonViewCheck.Name = "jsonViewCheck";
            this.jsonViewCheck.Size = new System.Drawing.Size(53, 17);
            this.jsonViewCheck.TabIndex = 4;
            this.jsonViewCheck.Text = "JSON";
            this.jsonViewCheck.UseVisualStyleBackColor = true;
            // 
            // textViewCheck
            // 
            this.textViewCheck.AutoSize = true;
            this.textViewCheck.Checked = true;
            this.textViewCheck.Location = new System.Drawing.Point(51, 2);
            this.textViewCheck.Name = "textViewCheck";
            this.textViewCheck.Size = new System.Drawing.Size(46, 17);
            this.textViewCheck.TabIndex = 5;
            this.textViewCheck.TabStop = true;
            this.textViewCheck.Text = "Text";
            this.textViewCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Format:";
            // 
            // onlyWithSelectedCheckbox
            // 
            this.onlyWithSelectedCheckbox.AutoSize = true;
            this.onlyWithSelectedCheckbox.Location = new System.Drawing.Point(222, 25);
            this.onlyWithSelectedCheckbox.Name = "onlyWithSelectedCheckbox";
            this.onlyWithSelectedCheckbox.Size = new System.Drawing.Size(90, 17);
            this.onlyWithSelectedCheckbox.TabIndex = 7;
            this.onlyWithSelectedCheckbox.Text = "Selected only";
            this.onlyWithSelectedCheckbox.UseVisualStyleBackColor = true;
            // 
            // treeViewCheck
            // 
            this.treeViewCheck.AutoSize = true;
            this.treeViewCheck.Location = new System.Drawing.Point(159, 2);
            this.treeViewCheck.Name = "treeViewCheck";
            this.treeViewCheck.Size = new System.Drawing.Size(47, 17);
            this.treeViewCheck.TabIndex = 8;
            this.treeViewCheck.Text = "Tree";
            this.treeViewCheck.UseVisualStyleBackColor = true;
            // 
            // tableViewCheck
            // 
            this.tableViewCheck.AutoSize = true;
            this.tableViewCheck.Location = new System.Drawing.Point(100, 2);
            this.tableViewCheck.Name = "tableViewCheck";
            this.tableViewCheck.Size = new System.Drawing.Size(52, 17);
            this.tableViewCheck.TabIndex = 10;
            this.tableViewCheck.Text = "Table";
            this.tableViewCheck.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.outputViewPanel);
            this.splitContainer1.Size = new System.Drawing.Size(473, 665);
            this.splitContainer1.SplitterDistance = 572;
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
            this.outputViewPanel.Name = "outputViewPanel";
            this.outputViewPanel.Size = new System.Drawing.Size(473, 572);
            this.outputViewPanel.TabIndex = 10;
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToOrderColumns = true;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(265, 32);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.Size = new System.Drawing.Size(115, 66);
            this.dataView.TabIndex = 4;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(138, 32);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(108, 66);
            this.treeView.TabIndex = 3;
            // 
            // textView
            // 
            this.textView.BackColor = System.Drawing.Color.MidnightBlue;
            this.textView.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textView.ForeColor = System.Drawing.Color.Snow;
            this.textView.Location = new System.Drawing.Point(11, 32);
            this.textView.Multiline = true;
            this.textView.Name = "textView";
            this.textView.Size = new System.Drawing.Size(120, 66);
            this.textView.TabIndex = 2;
            // 
            // jsonView
            // 
            this.jsonView.BackColor = System.Drawing.Color.Gainsboro;
            this.jsonView.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jsonView.ForeColor = System.Drawing.Color.Black;
            this.jsonView.Location = new System.Drawing.Point(11, 104);
            this.jsonView.Multiline = true;
            this.jsonView.Name = "jsonView";
            this.jsonView.Size = new System.Drawing.Size(120, 66);
            this.jsonView.TabIndex = 5;
            // 
            // OutputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tableViewCheck);
            this.Controls.Add(this.treeViewCheck);
            this.Controls.Add(this.onlyWithSelectedCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textViewCheck);
            this.Controls.Add(this.jsonViewCheck);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.checkBox1);
            this.Name = "OutputView";
            this.Size = new System.Drawing.Size(473, 714);
            this.splitContainer1.Panel1.ResumeLayout(false);
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
    }
}
