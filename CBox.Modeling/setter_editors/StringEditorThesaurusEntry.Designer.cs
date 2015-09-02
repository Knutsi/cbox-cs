namespace cbox.modelling.setter_editors
{
    partial class StringEditorThesaurusEntry
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.wordEntry = new System.Windows.Forms.TextBox();
            this.synonymEntry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(455, 11);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(35, 44);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // wordEntry
            // 
            this.wordEntry.Location = new System.Drawing.Point(4, 11);
            this.wordEntry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wordEntry.Name = "wordEntry";
            this.wordEntry.Size = new System.Drawing.Size(64, 22);
            this.wordEntry.TabIndex = 2;
            // 
            // synonymEntry
            // 
            this.synonymEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.synonymEntry.Location = new System.Drawing.Point(77, 11);
            this.synonymEntry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.synonymEntry.Multiline = true;
            this.synonymEntry.Name = "synonymEntry";
            this.synonymEntry.Size = new System.Drawing.Size(371, 97);
            this.synonymEntry.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Word:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Synonyms (comma-sep):";
            // 
            // StringEditorThesaurusEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.synonymEntry);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.wordEntry);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StringEditorThesaurusEntry";
            this.Size = new System.Drawing.Size(494, 113);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox wordEntry;
        private System.Windows.Forms.TextBox synonymEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
