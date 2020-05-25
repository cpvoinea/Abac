namespace JsonWinEdit
{
    partial class BooleanEditorControl
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
            this.chkValue = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkValue
            // 
            this.chkValue.AutoSize = true;
            this.chkValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkValue.Location = new System.Drawing.Point(0, 0);
            this.chkValue.Name = "chkValue";
            this.chkValue.Size = new System.Drawing.Size(150, 150);
            this.chkValue.TabIndex = 0;
            this.chkValue.UseVisualStyleBackColor = true;
            this.chkValue.CheckedChanged += new System.EventHandler(this.ChkValue_CheckedChanged);
            // 
            // BooleanEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkValue);
            this.Name = "BooleanEditorControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkValue;
    }
}
