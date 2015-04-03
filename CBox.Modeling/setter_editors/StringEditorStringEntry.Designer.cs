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
            this.stringInput.Location = new System.Drawing.Point(2, 2);
            this.stringInput.Name = "stringInput";
            this.stringInput.Size = new System.Drawing.Size(212, 20);
            this.stringInput.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(218, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(26, 20);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // StringEditorStringEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.stringInput);
            this.Name = "StringEditorStringEntry";
            this.Size = new System.Drawing.Size(251, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stringInput;
        private System.Windows.Forms.Button deleteButton;
    }
}
