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
            this.deleteButton.Location = new System.Drawing.Point(240, 9);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(26, 36);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // wordEntry
            // 
            this.wordEntry.Location = new System.Drawing.Point(3, 9);
            this.wordEntry.Name = "wordEntry";
            this.wordEntry.Size = new System.Drawing.Size(49, 20);
            this.wordEntry.TabIndex = 2;
            // 
            // synonymEntry
            // 
            this.synonymEntry.Location = new System.Drawing.Point(58, 9);
            this.synonymEntry.Multiline = true;
            this.synonymEntry.Name = "synonymEntry";
            this.synonymEntry.Size = new System.Drawing.Size(178, 36);
            this.synonymEntry.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 7);
            this.label1.TabIndex = 5;
            this.label1.Text = "Word:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 7);
            this.label2.TabIndex = 6;
            this.label2.Text = "Synonyms (comma-sep):";
            // 
            // StringEditorThesaurusEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.synonymEntry);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.wordEntry);
            this.Name = "StringEditorThesaurusEntry";
            this.Size = new System.Drawing.Size(269, 48);
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
