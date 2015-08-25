namespace cbox.modelling.editors
{
    partial class ProblemRevealConditionEditor
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.actionKeysSelect = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.triggersList = new System.Windows.Forms.TextBox();
            this.keyCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.individualKeySelect = new System.Windows.Forms.ComboBox();
            this.addTriggerKeyButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(422, 591);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(341, 591);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.individualKeySelect);
            this.groupBox1.Controls.Add(this.addTriggerKeyButton);
            this.groupBox1.Controls.Add(this.actionKeysSelect);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.triggersList);
            this.groupBox1.Controls.Add(this.keyCombobox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 572);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reveal condition";
            // 
            // actionKeysSelect
            // 
            this.actionKeysSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionKeysSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.actionKeysSelect.FormattingEnabled = true;
            this.actionKeysSelect.Location = new System.Drawing.Point(187, 503);
            this.actionKeysSelect.Name = "actionKeysSelect";
            this.actionKeysSelect.Size = new System.Drawing.Size(292, 24);
            this.actionKeysSelect.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(10, 502);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(171, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add keys from action";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autotriggers (one pr. line):";
            // 
            // triggersList
            // 
            this.triggersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triggersList.Location = new System.Drawing.Point(10, 72);
            this.triggersList.Multiline = true;
            this.triggersList.Name = "triggersList";
            this.triggersList.Size = new System.Drawing.Size(469, 424);
            this.triggersList.TabIndex = 2;
            // 
            // keyCombobox
            // 
            this.keyCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.keyCombobox.FormattingEnabled = true;
            this.keyCombobox.Location = new System.Drawing.Point(50, 25);
            this.keyCombobox.Name = "keyCombobox";
            this.keyCombobox.Size = new System.Drawing.Size(429, 24);
            this.keyCombobox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key:";
            // 
            // individualKeySelect
            // 
            this.individualKeySelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.individualKeySelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.individualKeySelect.FormattingEnabled = true;
            this.individualKeySelect.Location = new System.Drawing.Point(187, 532);
            this.individualKeySelect.Name = "individualKeySelect";
            this.individualKeySelect.Size = new System.Drawing.Size(292, 24);
            this.individualKeySelect.TabIndex = 7;
            // 
            // addTriggerKeyButton
            // 
            this.addTriggerKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addTriggerKeyButton.Location = new System.Drawing.Point(10, 531);
            this.addTriggerKeyButton.Name = "addTriggerKeyButton";
            this.addTriggerKeyButton.Size = new System.Drawing.Size(171, 23);
            this.addTriggerKeyButton.TabIndex = 6;
            this.addTriggerKeyButton.Text = "Add individual key";
            this.addTriggerKeyButton.UseVisualStyleBackColor = true;
            this.addTriggerKeyButton.Click += new System.EventHandler(this.addTriggerKeyButton_Click);
            // 
            // ProblemRevealConditionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 626);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "ProblemRevealConditionEditor";
            this.Text = "Problem reveal condition";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox actionKeysSelect;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox triggersList;
        private System.Windows.Forms.ComboBox keyCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox individualKeySelect;
        private System.Windows.Forms.Button addTriggerKeyButton;
    }
}