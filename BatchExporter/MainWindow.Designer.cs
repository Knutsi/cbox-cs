namespace BatchExporter
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.systemRootInput = new System.Windows.Forms.TextBox();
            this.pickSystemRootButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.serviceRootInput = new System.Windows.Forms.TextBox();
            this.pickServiceRootButton = new System.Windows.Forms.Button();
            this.buildButton = new System.Windows.Forms.Button();
            this.logOutput = new System.Windows.Forms.TextBox();
            this.caseCountPicker = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.buildAutoButton = new System.Windows.Forms.Button();
            this.backupCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.caseCountPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "System root:";
            // 
            // systemRootInput
            // 
            this.systemRootInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemRootInput.Location = new System.Drawing.Point(106, 10);
            this.systemRootInput.Name = "systemRootInput";
            this.systemRootInput.Size = new System.Drawing.Size(265, 22);
            this.systemRootInput.TabIndex = 1;
            // 
            // pickSystemRootButton
            // 
            this.pickSystemRootButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickSystemRootButton.Location = new System.Drawing.Point(377, 10);
            this.pickSystemRootButton.Name = "pickSystemRootButton";
            this.pickSystemRootButton.Size = new System.Drawing.Size(75, 23);
            this.pickSystemRootButton.TabIndex = 2;
            this.pickSystemRootButton.Text = "Pick";
            this.pickSystemRootButton.UseVisualStyleBackColor = true;
            this.pickSystemRootButton.Click += new System.EventHandler(this.pickSystemRootButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Service root:";
            // 
            // serviceRootInput
            // 
            this.serviceRootInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceRootInput.Location = new System.Drawing.Point(106, 38);
            this.serviceRootInput.Name = "serviceRootInput";
            this.serviceRootInput.Size = new System.Drawing.Size(265, 22);
            this.serviceRootInput.TabIndex = 1;
            // 
            // pickServiceRootButton
            // 
            this.pickServiceRootButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickServiceRootButton.Location = new System.Drawing.Point(377, 38);
            this.pickServiceRootButton.Name = "pickServiceRootButton";
            this.pickServiceRootButton.Size = new System.Drawing.Size(75, 23);
            this.pickServiceRootButton.TabIndex = 2;
            this.pickServiceRootButton.Text = "Pick";
            this.pickServiceRootButton.UseVisualStyleBackColor = true;
            this.pickServiceRootButton.Click += new System.EventHandler(this.pickServiceRootButton_Click);
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(16, 122);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(111, 23);
            this.buildButton.TabIndex = 4;
            this.buildButton.Text = "Build now";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // logOutput
            // 
            this.logOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logOutput.BackColor = System.Drawing.Color.LightSlateGray;
            this.logOutput.ForeColor = System.Drawing.Color.White;
            this.logOutput.Location = new System.Drawing.Point(16, 151);
            this.logOutput.Multiline = true;
            this.logOutput.Name = "logOutput";
            this.logOutput.Size = new System.Drawing.Size(436, 470);
            this.logOutput.TabIndex = 5;
            this.logOutput.Text = "Ready";
            // 
            // caseCountPicker
            // 
            this.caseCountPicker.Location = new System.Drawing.Point(106, 67);
            this.caseCountPicker.Name = "caseCountPicker";
            this.caseCountPicker.Size = new System.Drawing.Size(120, 22);
            this.caseCountPicker.TabIndex = 6;
            this.caseCountPicker.ValueChanged += new System.EventHandler(this.caseCountPicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Case count:";
            // 
            // buildAutoButton
            // 
            this.buildAutoButton.Location = new System.Drawing.Point(133, 122);
            this.buildAutoButton.Name = "buildAutoButton";
            this.buildAutoButton.Size = new System.Drawing.Size(143, 23);
            this.buildAutoButton.TabIndex = 8;
            this.buildAutoButton.Text = "Start autobuild";
            this.buildAutoButton.UseVisualStyleBackColor = true;
            // 
            // backupCheckbox
            // 
            this.backupCheckbox.AutoSize = true;
            this.backupCheckbox.Location = new System.Drawing.Point(16, 95);
            this.backupCheckbox.Name = "backupCheckbox";
            this.backupCheckbox.Size = new System.Drawing.Size(141, 21);
            this.backupCheckbox.TabIndex = 9;
            this.backupCheckbox.Text = "Backup old cases";
            this.backupCheckbox.UseVisualStyleBackColor = true;
            this.backupCheckbox.CheckStateChanged += new System.EventHandler(this.backupCheckbox_CheckStateChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 633);
            this.Controls.Add(this.backupCheckbox);
            this.Controls.Add(this.buildAutoButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.caseCountPicker);
            this.Controls.Add(this.logOutput);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.pickServiceRootButton);
            this.Controls.Add(this.pickSystemRootButton);
            this.Controls.Add(this.serviceRootInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.systemRootInput);
            this.Controls.Add(this.label1);
            this.Name = "MainWindow";
            this.Text = "Batch Exporter";
            ((System.ComponentModel.ISupportInitialize)(this.caseCountPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox systemRootInput;
        private System.Windows.Forms.Button pickSystemRootButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serviceRootInput;
        private System.Windows.Forms.Button pickServiceRootButton;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.TextBox logOutput;
        private System.Windows.Forms.NumericUpDown caseCountPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buildAutoButton;
        private System.Windows.Forms.CheckBox backupCheckbox;
    }
}

