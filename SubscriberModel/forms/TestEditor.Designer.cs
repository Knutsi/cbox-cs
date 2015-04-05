namespace OntologyEditor
{
    partial class TestEditor
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
            this.label2 = new System.Windows.Forms.Label();
            this.keyInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.suffixInput = new System.Windows.Forms.TextBox();
            this.unitInput = new System.Windows.Forms.TextBox();
            this.derivedFromSelect = new System.Windows.Forms.ComboBox();
            this.titleInput = new System.Windows.Forms.TextBox();
            this.setterSelect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.datatypeSelect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.acumulativeCheckbox = new System.Windows.Forms.CheckBox();
            this.deriveCheckbox = new System.Windows.Forms.CheckBox();
            this.setterPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title:";
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(97, 19);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(296, 20);
            this.keyInput.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Suffix:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Unit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Datatype:";
            // 
            // suffixInput
            // 
            this.suffixInput.Location = new System.Drawing.Point(97, 74);
            this.suffixInput.Name = "suffixInput";
            this.suffixInput.Size = new System.Drawing.Size(296, 20);
            this.suffixInput.TabIndex = 8;
            // 
            // unitInput
            // 
            this.unitInput.Location = new System.Drawing.Point(97, 101);
            this.unitInput.Name = "unitInput";
            this.unitInput.Size = new System.Drawing.Size(296, 20);
            this.unitInput.TabIndex = 9;
            // 
            // derivedFromSelect
            // 
            this.derivedFromSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.derivedFromSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.derivedFromSelect.DropDownHeight = 306;
            this.derivedFromSelect.FormattingEnabled = true;
            this.derivedFromSelect.IntegralHeight = false;
            this.derivedFromSelect.Location = new System.Drawing.Point(216, 157);
            this.derivedFromSelect.Name = "derivedFromSelect";
            this.derivedFromSelect.Size = new System.Drawing.Size(177, 21);
            this.derivedFromSelect.TabIndex = 11;
            // 
            // titleInput
            // 
            this.titleInput.Location = new System.Drawing.Point(97, 45);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(296, 20);
            this.titleInput.TabIndex = 3;
            // 
            // setterSelect
            // 
            this.setterSelect.FormattingEnabled = true;
            this.setterSelect.Items.AddRange(new object[] {
            "Model",
            "Javascript",
            "Setter"});
            this.setterSelect.Location = new System.Drawing.Point(97, 184);
            this.setterSelect.Name = "setterSelect";
            this.setterSelect.Size = new System.Drawing.Size(95, 21);
            this.setterSelect.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Setter:";
            // 
            // datatypeSelect
            // 
            this.datatypeSelect.FormattingEnabled = true;
            this.datatypeSelect.Items.AddRange(new object[] {
            "NUMBER",
            "TEXT",
            "DATA"});
            this.datatypeSelect.Location = new System.Drawing.Point(97, 128);
            this.datatypeSelect.Name = "datatypeSelect";
            this.datatypeSelect.Size = new System.Drawing.Size(95, 21);
            this.datatypeSelect.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Derived from:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.acumulativeCheckbox);
            this.groupBox1.Controls.Add(this.deriveCheckbox);
            this.groupBox1.Controls.Add(this.derivedFromSelect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.unitInput);
            this.groupBox1.Controls.Add(this.suffixInput);
            this.groupBox1.Controls.Add(this.keyInput);
            this.groupBox1.Controls.Add(this.titleInput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.setterSelect);
            this.groupBox1.Controls.Add(this.datatypeSelect);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 221);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test information";
            // 
            // acumulativeCheckbox
            // 
            this.acumulativeCheckbox.AutoSize = true;
            this.acumulativeCheckbox.Location = new System.Drawing.Point(216, 130);
            this.acumulativeCheckbox.Name = "acumulativeCheckbox";
            this.acumulativeCheckbox.Size = new System.Drawing.Size(84, 17);
            this.acumulativeCheckbox.TabIndex = 15;
            this.acumulativeCheckbox.Text = "Acumualtive";
            this.acumulativeCheckbox.UseVisualStyleBackColor = true;
            // 
            // deriveCheckbox
            // 
            this.deriveCheckbox.AutoSize = true;
            this.deriveCheckbox.Location = new System.Drawing.Point(97, 159);
            this.deriveCheckbox.Name = "deriveCheckbox";
            this.deriveCheckbox.Size = new System.Drawing.Size(116, 17);
            this.deriveCheckbox.TabIndex = 2;
            this.deriveCheckbox.Text = "Derive from parent:";
            this.deriveCheckbox.UseVisualStyleBackColor = true;
            this.deriveCheckbox.CheckedChanged += new System.EventHandler(this.deriveCheckbox_CheckedChanged);
            // 
            // setterPanel
            // 
            this.setterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setterPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.setterPanel.Location = new System.Drawing.Point(12, 240);
            this.setterPanel.Name = "setterPanel";
            this.setterPanel.Size = new System.Drawing.Size(417, 297);
            this.setterPanel.TabIndex = 2;
            // 
            // TestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 549);
            this.Controls.Add(this.setterPanel);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "TestEditor";
            this.Text = "TestEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyInput;
        private System.Windows.Forms.TextBox titleInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox suffixInput;
        private System.Windows.Forms.TextBox unitInput;
        private System.Windows.Forms.ComboBox derivedFromSelect;
        private System.Windows.Forms.ComboBox setterSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox datatypeSelect;
        private System.Windows.Forms.CheckBox deriveCheckbox;
        private System.Windows.Forms.CheckBox acumulativeCheckbox;
        private System.Windows.Forms.Panel setterPanel;
    }
}