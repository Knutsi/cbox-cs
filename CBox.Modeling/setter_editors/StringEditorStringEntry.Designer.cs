namespace cbox.modelling.setter_editors
{
    partial class StringEditorStringEntry
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
            this.stringInput = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stringInput
            // 
            this.stringInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stringInput.Location = new System.Drawing.Point(3, 2);
            this.stringInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stringInput.Name = "stringInput";
            this.stringInput.Size = new System.Drawing.Size(415, 22);
            this.stringInput.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(425, 2);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(35, 25);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // StringEditorStringEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.stringInput);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StringEditorStringEntry";
            this.Size = new System.Drawing.Size(469, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stringInput;
        private System.Windows.Forms.Button deleteButton;
    }
}
