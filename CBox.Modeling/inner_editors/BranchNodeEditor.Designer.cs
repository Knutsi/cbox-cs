namespace cbox.modelling.editors
{
    partial class BranchNodeEditor
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
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.noffRadioButton = new System.Windows.Forms.RadioButton();
            this.maybeRadioButton = new System.Windows.Forms.RadioButton();
            this.branchesInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nSelect = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Location = new System.Drawing.Point(3, 4);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(36, 17);
            this.allRadioButton.TabIndex = 0;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "All";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // noffRadioButton
            // 
            this.noffRadioButton.AutoSize = true;
            this.noffRadioButton.Location = new System.Drawing.Point(45, 4);
            this.noffRadioButton.Name = "noffRadioButton";
            this.noffRadioButton.Size = new System.Drawing.Size(45, 17);
            this.noffRadioButton.TabIndex = 1;
            this.noffRadioButton.TabStop = true;
            this.noffRadioButton.Text = "nOff";
            this.noffRadioButton.UseVisualStyleBackColor = true;
            // 
            // maybeRadioButton
            // 
            this.maybeRadioButton.AutoSize = true;
            this.maybeRadioButton.Location = new System.Drawing.Point(96, 4);
            this.maybeRadioButton.Name = "maybeRadioButton";
            this.maybeRadioButton.Size = new System.Drawing.Size(57, 17);
            this.maybeRadioButton.TabIndex = 2;
            this.maybeRadioButton.TabStop = true;
            this.maybeRadioButton.Text = "Maybe";
            this.maybeRadioButton.UseVisualStyleBackColor = true;
            // 
            // branchesInput
            // 
            this.branchesInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.branchesInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchesInput.Location = new System.Drawing.Point(3, 78);
            this.branchesInput.Multiline = true;
            this.branchesInput.Name = "branchesInput";
            this.branchesInput.Size = new System.Drawing.Size(183, 157);
            this.branchesInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Branches (one for each line):";
            // 
            // nSelect
            // 
            this.nSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSelect.Location = new System.Drawing.Point(23, 27);
            this.nSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSelect.Name = "nSelect";
            this.nSelect.Size = new System.Drawing.Size(163, 26);
            this.nSelect.TabIndex = 5;
            this.nSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "N:";
            // 
            // BranchNodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.branchesInput);
            this.Controls.Add(this.maybeRadioButton);
            this.Controls.Add(this.noffRadioButton);
            this.Controls.Add(this.allRadioButton);
            this.Name = "BranchNodeEditor";
            this.Size = new System.Drawing.Size(189, 238);
            ((System.ComponentModel.ISupportInitialize)(this.nSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.RadioButton noffRadioButton;
        private System.Windows.Forms.RadioButton maybeRadioButton;
        private System.Windows.Forms.TextBox branchesInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nSelect;
        private System.Windows.Forms.Label label2;
    }
}
