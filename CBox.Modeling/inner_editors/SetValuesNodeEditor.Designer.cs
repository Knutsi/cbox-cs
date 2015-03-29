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
            this.editorsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // editorsFlow
            // 
            this.editorsFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorsFlow.AutoScroll = true;
            this.editorsFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.editorsFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.editorsFlow.Location = new System.Drawing.Point(3, 3);
            this.editorsFlow.Name = "editorsFlow";
            this.editorsFlow.Size = new System.Drawing.Size(351, 381);
            this.editorsFlow.TabIndex = 0;
            // 
            // SetValuesNodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editorsFlow);
            this.Name = "SetValuesNodeEditor";
            this.Size = new System.Drawing.Size(357, 387);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel editorsFlow;

    }
}
