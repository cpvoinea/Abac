namespace JsonWinEdit
{
    partial class ObjectMemberControl
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
            this.pnlKey = new System.Windows.Forms.Panel();
            this.lblKey = new System.Windows.Forms.Label();
            this.pnlValueEditor = new System.Windows.Forms.Panel();
            this.pnlKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKey
            // 
            this.pnlKey.AutoSize = true;
            this.pnlKey.Controls.Add(this.lblKey);
            this.pnlKey.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKey.Location = new System.Drawing.Point(0, 0);
            this.pnlKey.Name = "pnlKey";
            this.pnlKey.Size = new System.Drawing.Size(0, 155);
            this.pnlKey.TabIndex = 0;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKey.Location = new System.Drawing.Point(0, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(0, 13);
            this.lblKey.TabIndex = 0;
            // 
            // pnlValueEditor
            // 
            this.pnlValueEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlValueEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlValueEditor.Name = "pnlValueEditor";
            this.pnlValueEditor.Size = new System.Drawing.Size(244, 155);
            this.pnlValueEditor.TabIndex = 1;
            // 
            // ObjectMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlValueEditor);
            this.Controls.Add(this.pnlKey);
            this.Name = "ObjectMemberControl";
            this.Size = new System.Drawing.Size(244, 155);
            this.pnlKey.ResumeLayout(false);
            this.pnlKey.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Panel pnlValueEditor;

    }
}
