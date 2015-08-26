namespace cbox.modelling.editors
{
    partial class DiagnosisNodeEditor
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
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.previousCheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dxNameInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dxSearchResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dxSearchInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.specificChecbox = new System.Windows.Forms.CheckBox();
            this.majorCheckbox = new System.Windows.Forms.CheckBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.groupNameInput = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dxTree = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.missCommentInput = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(774, 778);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(855, 778);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.missCommentInput);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.previousCheckbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dxNameInput);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.specificChecbox);
            this.panel1.Controls.Add(this.majorCheckbox);
            this.panel1.Controls.Add(this.codeLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(this.groupNameInput);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dxTree);
            this.panel1.Location = new System.Drawing.Point(-3, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 775);
            this.panel1.TabIndex = 2;
            // 
            // previousCheckbox
            // 
            this.previousCheckbox.AutoSize = true;
            this.previousCheckbox.Enabled = false;
            this.previousCheckbox.Location = new System.Drawing.Point(415, 119);
            this.previousCheckbox.Name = "previousCheckbox";
            this.previousCheckbox.Size = new System.Drawing.Size(194, 21);
            this.previousCheckbox.TabIndex = 13;
            this.previousCheckbox.Text = "Previous, known condition";
            this.previousCheckbox.UseVisualStyleBackColor = true;
            this.previousCheckbox.CheckedChanged += new System.EventHandler(this.previousCheckbox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Diagnosis in groups:";
            // 
            // dxNameInput
            // 
            this.dxNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dxNameInput.Enabled = false;
            this.dxNameInput.Location = new System.Drawing.Point(415, 62);
            this.dxNameInput.Name = "dxNameInput";
            this.dxNameInput.Size = new System.Drawing.Size(520, 22);
            this.dxNameInput.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dxSearchResults);
            this.groupBox1.Controls.Add(this.dxSearchInput);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(323, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 495);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endre diagnose:";
            // 
            // dxSearchResults
            // 
            this.dxSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dxSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.dxSearchResults.Enabled = false;
            this.dxSearchResults.Location = new System.Drawing.Point(9, 63);
            this.dxSearchResults.Name = "dxSearchResults";
            this.dxSearchResults.Size = new System.Drawing.Size(594, 426);
            this.dxSearchResults.TabIndex = 2;
            this.dxSearchResults.UseCompatibleStateImageBehavior = false;
            this.dxSearchResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code/Name";
            this.columnHeader1.Width = 575;
            // 
            // dxSearchInput
            // 
            this.dxSearchInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dxSearchInput.Enabled = false;
            this.dxSearchInput.Location = new System.Drawing.Point(48, 25);
            this.dxSearchInput.Name = "dxSearchInput";
            this.dxSearchInput.Size = new System.Drawing.Size(558, 22);
            this.dxSearchInput.TabIndex = 1;
            this.dxSearchInput.TextChanged += new System.EventHandler(this.dxSearchInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Søk:";
            // 
            // specificChecbox
            // 
            this.specificChecbox.AutoSize = true;
            this.specificChecbox.Enabled = false;
            this.specificChecbox.Location = new System.Drawing.Point(415, 173);
            this.specificChecbox.Name = "specificChecbox";
            this.specificChecbox.Size = new System.Drawing.Size(79, 21);
            this.specificChecbox.TabIndex = 9;
            this.specificChecbox.Text = "Specific";
            this.specificChecbox.UseVisualStyleBackColor = true;
            // 
            // majorCheckbox
            // 
            this.majorCheckbox.AutoSize = true;
            this.majorCheckbox.Enabled = false;
            this.majorCheckbox.Location = new System.Drawing.Point(415, 146);
            this.majorCheckbox.Name = "majorCheckbox";
            this.majorCheckbox.Size = new System.Drawing.Size(65, 21);
            this.majorCheckbox.TabIndex = 8;
            this.majorCheckbox.Text = "Major";
            this.majorCheckbox.UseVisualStyleBackColor = true;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.Location = new System.Drawing.Point(508, 90);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(78, 17);
            this.codeLabel.TabIndex = 7;
            this.codeLabel.Text = "- CODE - ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "ICD-10 code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Diagnosis:";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(44, 745);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(28, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // groupNameInput
            // 
            this.groupNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNameInput.Enabled = false;
            this.groupNameInput.Location = new System.Drawing.Point(415, 30);
            this.groupNameInput.Name = "groupNameInput";
            this.groupNameInput.Size = new System.Drawing.Size(520, 22);
            this.groupNameInput.TabIndex = 2;
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newButton.Location = new System.Drawing.Point(10, 745);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(28, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "+";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group name:";
            // 
            // dxTree
            // 
            this.dxTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dxTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dxTree.Location = new System.Drawing.Point(11, 30);
            this.dxTree.Name = "dxTree";
            this.dxTree.Size = new System.Drawing.Size(300, 709);
            this.dxTree.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Miss comment:";
            // 
            // missCommentInput
            // 
            this.missCommentInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.missCommentInput.Enabled = false;
            this.missCommentInput.Location = new System.Drawing.Point(415, 200);
            this.missCommentInput.Name = "missCommentInput";
            this.missCommentInput.Size = new System.Drawing.Size(520, 22);
            this.missCommentInput.TabIndex = 15;
            // 
            // DiagnosisNodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 813);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Name = "DiagnosisNodeEditor";
            this.Text = "Diagnosis node editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox specificChecbox;
        private System.Windows.Forms.CheckBox majorCheckbox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox groupNameInput;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView dxTree;
        private System.Windows.Forms.TextBox dxNameInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dxSearchInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView dxSearchResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox previousCheckbox;
        private System.Windows.Forms.TextBox missCommentInput;
        private System.Windows.Forms.Label label6;
    }
}