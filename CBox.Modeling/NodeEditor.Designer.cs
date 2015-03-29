namespace cbox.modelling.editors
{
    partial class NodeEditor
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.typeLabel = new System.Windows.Forms.Label();
            this.titleInput = new System.Windows.Forms.TextBox();
            this.boundLink = new System.Windows.Forms.LinkLabel();
            this.expandButton = new System.Windows.Forms.Button();
            this.commentInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tagInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.innerEditorPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.expandButton);
            this.splitContainer.Panel1.Controls.Add(this.commentInput);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.tagInput);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.innerEditorPanel);
            this.splitContainer.Size = new System.Drawing.Size(280, 441);
            this.splitContainer.SplitterDistance = 157;
            this.splitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.typeLabel);
            this.panel1.Controls.Add(this.titleInput);
            this.panel1.Controls.Add(this.boundLink);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 58);
            this.panel1.TabIndex = 7;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(6, 4);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(68, 13);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "<Node type>";
            // 
            // titleInput
            // 
            this.titleInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleInput.Location = new System.Drawing.Point(6, 21);
            this.titleInput.Name = "titleInput";
            this.titleInput.Size = new System.Drawing.Size(268, 31);
            this.titleInput.TabIndex = 0;
            // 
            // boundLink
            // 
            this.boundLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boundLink.AutoSize = true;
            this.boundLink.Enabled = false;
            this.boundLink.Location = new System.Drawing.Point(226, 5);
            this.boundLink.Name = "boundLink";
            this.boundLink.Size = new System.Drawing.Size(51, 13);
            this.boundLink.TabIndex = 5;
            this.boundLink.TabStop = true;
            this.boundLink.Text = "Unbound";
            this.boundLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // expandButton
            // 
            this.expandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandButton.Location = new System.Drawing.Point(236, 116);
            this.expandButton.Name = "expandButton";
            this.expandButton.Size = new System.Drawing.Size(41, 21);
            this.expandButton.TabIndex = 6;
            this.expandButton.Text = "Expand";
            this.expandButton.UseVisualStyleBackColor = true;
            // 
            // commentInput
            // 
            this.commentInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentInput.Location = new System.Drawing.Point(6, 116);
            this.commentInput.Multiline = true;
            this.commentInput.Name = "commentInput";
            this.commentInput.Size = new System.Drawing.Size(221, 36);
            this.commentInput.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inclusion comment:";
            // 
            // tagInput
            // 
            this.tagInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagInput.Location = new System.Drawing.Point(6, 78);
            this.tagInput.Name = "tagInput";
            this.tagInput.Size = new System.Drawing.Size(268, 20);
            this.tagInput.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tags:";
            // 
            // innerEditorPanel
            // 
            this.innerEditorPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.innerEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerEditorPanel.Location = new System.Drawing.Point(0, 0);
            this.innerEditorPanel.Name = "innerEditorPanel";
            this.innerEditorPanel.Size = new System.Drawing.Size(280, 280);
            this.innerEditorPanel.TabIndex = 0;
            // 
            // NodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "NodeEditor";
            this.Size = new System.Drawing.Size(280, 441);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox tagInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleInput;
        private System.Windows.Forms.LinkLabel boundLink;
        private System.Windows.Forms.TextBox commentInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button expandButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Panel innerEditorPanel;
    }
}
