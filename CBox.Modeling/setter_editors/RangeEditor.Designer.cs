namespace cbox.modelling.setter_editors
{
    partial class RangeEditor
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
            this.rangeInput = new System.Windows.Forms.TextBox();
            this.disttributionPicker = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rangeInput
            // 
            this.rangeInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rangeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeInput.Location = new System.Drawing.Point(0, 4);
            this.rangeInput.Name = "rangeInput";
            this.rangeInput.Size = new System.Drawing.Size(149, 22);
            this.rangeInput.TabIndex = 0;
            // 
            // disttributionPicker
            // 
            this.disttributionPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disttributionPicker.Enabled = false;
            this.disttributionPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disttributionPicker.FormattingEnabled = true;
            this.disttributionPicker.Items.AddRange(new object[] {
            "Flat",
            "Binominal"});
            this.disttributionPicker.Location = new System.Drawing.Point(155, 4);
            this.disttributionPicker.Name = "disttributionPicker";
            this.disttributionPicker.Size = new System.Drawing.Size(106, 24);
            this.disttributionPicker.TabIndex = 1;
            // 
            // RangeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.disttributionPicker);
            this.Controls.Add(this.rangeInput);
            this.Name = "RangeEditor";
            this.Size = new System.Drawing.Size(264, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rangeInput;
        private System.Windows.Forms.ComboBox disttributionPicker;
    }
}
