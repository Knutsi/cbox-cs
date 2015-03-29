namespace cbox.modelling
{
    partial class SetValuesNodeEntryEditor
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
            this.keySelect = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.quickEditorPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // keySelect
            // 
            this.keySelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keySelect.FormattingEnabled = true;
            this.keySelect.Location = new System.Drawing.Point(3, 3);
            this.keySelect.Name = "keySelect";
            this.keySelect.Size = new System.Drawing.Size(101, 20);
            this.keySelect.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(286, 1);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(22, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // quickEditorPanel
            // 
            this.quickEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.quickEditorPanel.Location = new System.Drawing.Point(111, 3);
            this.quickEditorPanel.Name = "quickEditorPanel";
            this.quickEditorPanel.Size = new System.Drawing.Size(169, 20);
            this.quickEditorPanel.TabIndex = 2;
            // 
            // SetValuesNodeEntryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quickEditorPanel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.keySelect);
            this.Name = "SetValuesNodeEntryEditor";
            this.Size = new System.Drawing.Size(311, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox keySelect;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel quickEditorPanel;
    }
}
