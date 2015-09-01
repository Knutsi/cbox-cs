namespace cbox.modelling.editors
{
    partial class SetValuesNodeEditor
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
            this.entryList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resampleButton = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // entryList
            // 
            this.entryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.entryList.Location = new System.Drawing.Point(3, 38);
            this.entryList.Name = "entryList";
            this.entryList.Size = new System.Drawing.Size(513, 446);
            this.entryList.TabIndex = 3;
            this.entryList.UseCompatibleStateImageBehavior = false;
            this.entryList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 176;
            // 
            // resampleButton
            // 
            this.resampleButton.Location = new System.Drawing.Point(4, 4);
            this.resampleButton.Name = "resampleButton";
            this.resampleButton.Size = new System.Drawing.Size(105, 28);
            this.resampleButton.TabIndex = 4;
            this.resampleButton.Text = "Resample";
            this.resampleButton.UseVisualStyleBackColor = true;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sample";
            this.columnHeader3.Width = 158;
            // 
            // SetValuesNodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resampleButton);
            this.Controls.Add(this.entryList);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetValuesNodeEditor";
            this.Size = new System.Drawing.Size(519, 487);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView entryList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button resampleButton;
    }
}
