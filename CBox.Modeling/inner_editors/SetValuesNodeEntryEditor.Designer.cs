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
            this.panel1 = new System.Windows.Forms.Panel();
            this.setterSelect = new System.Windows.Forms.ComboBox();
            this.datatypeLabel = new System.Windows.Forms.Label();
            this.setterEditorPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.keySelect = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.setterSelect);
            this.panel1.Controls.Add(this.datatypeLabel);
            this.panel1.Controls.Add(this.setterEditorPanel);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.keySelect);
            this.panel1.Location = new System.Drawing.Point(18, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 105);
            this.panel1.TabIndex = 0;
            // 
            // setterSelect
            // 
            this.setterSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setterSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.setterSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.setterSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setterSelect.FormattingEnabled = true;
            this.setterSelect.Location = new System.Drawing.Point(173, 12);
            this.setterSelect.Name = "setterSelect";
            this.setterSelect.Size = new System.Drawing.Size(77, 17);
            this.setterSelect.TabIndex = 5;
            // 
            // datatypeLabel
            // 
            this.datatypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datatypeLabel.AutoSize = true;
            this.datatypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datatypeLabel.Location = new System.Drawing.Point(171, 3);
            this.datatypeLabel.Name = "datatypeLabel";
            this.datatypeLabel.Size = new System.Drawing.Size(33, 9);
            this.datatypeLabel.TabIndex = 7;
            this.datatypeLabel.Text = "datatype";
            // 
            // setterEditorPanel
            // 
            this.setterEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setterEditorPanel.Location = new System.Drawing.Point(3, 35);
            this.setterEditorPanel.Name = "setterEditorPanel";
            this.setterEditorPanel.Size = new System.Drawing.Size(287, 67);
            this.setterEditorPanel.TabIndex = 6;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(256, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(34, 27);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // keySelect
            // 
            this.keySelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keySelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.keySelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.keySelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keySelect.FormattingEnabled = true;
            this.keySelect.Location = new System.Drawing.Point(3, 5);
            this.keySelect.Name = "keySelect";
            this.keySelect.Size = new System.Drawing.Size(164, 24);
            this.keySelect.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(19, 105);
            this.panel3.TabIndex = 1;
            // 
            // SetValuesNodeEntryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "SetValuesNodeEntryEditor";
            this.Size = new System.Drawing.Size(311, 105);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel setterEditorPanel;
        private System.Windows.Forms.ComboBox setterSelect;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ComboBox keySelect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label datatypeLabel;

    }
}
