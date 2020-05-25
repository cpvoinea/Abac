namespace Abac.Application
{
    partial class InformationTypeDetailControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.pnlValue = new System.Windows.Forms.Panel();
            this.cReal = new System.Windows.Forms.MaskedTextBox();
            this.cDate = new System.Windows.Forms.DateTimePicker();
            this.cOptions = new System.Windows.Forms.ComboBox();
            this.cInteger = new System.Windows.Forms.NumericUpDown();
            this.cText = new System.Windows.Forms.TextBox();
            this.pnlValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cInteger)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 0;
            // 
            // pnlValue
            // 
            this.pnlValue.Controls.Add(this.cReal);
            this.pnlValue.Controls.Add(this.cDate);
            this.pnlValue.Controls.Add(this.cOptions);
            this.pnlValue.Controls.Add(this.cInteger);
            this.pnlValue.Controls.Add(this.cText);
            this.pnlValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlValue.Location = new System.Drawing.Point(0, 0);
            this.pnlValue.Name = "pnlValue";
            this.pnlValue.Size = new System.Drawing.Size(300, 21);
            this.pnlValue.TabIndex = 1;
            // 
            // cReal
            // 
            this.cReal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cReal.Location = new System.Drawing.Point(0, 0);
            this.cReal.Name = "cReal";
            this.cReal.Size = new System.Drawing.Size(300, 20);
            this.cReal.TabIndex = 0;
            this.cReal.Visible = false;
            // 
            // cDate
            // 
            this.cDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cDate.Location = new System.Drawing.Point(0, 0);
            this.cDate.Name = "cDate";
            this.cDate.Size = new System.Drawing.Size(300, 20);
            this.cDate.TabIndex = 0;
            this.cDate.Visible = false;
            // 
            // cOptions
            // 
            this.cOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cOptions.FormattingEnabled = true;
            this.cOptions.Location = new System.Drawing.Point(0, 0);
            this.cOptions.Name = "cOptions";
            this.cOptions.Size = new System.Drawing.Size(300, 21);
            this.cOptions.TabIndex = 0;
            this.cOptions.Visible = false;
            // 
            // cInteger
            // 
            this.cInteger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cInteger.Location = new System.Drawing.Point(0, 0);
            this.cInteger.Name = "cInteger";
            this.cInteger.Size = new System.Drawing.Size(300, 20);
            this.cInteger.TabIndex = 0;
            this.cInteger.Visible = false;
            // 
            // cText
            // 
            this.cText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cText.Location = new System.Drawing.Point(0, 0);
            this.cText.Name = "cText";
            this.cText.Size = new System.Drawing.Size(300, 20);
            this.cText.TabIndex = 0;
            this.cText.Visible = false;
            // 
            // InformationTypeDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlValue);
            this.Controls.Add(this.lblName);
            this.Name = "InformationTypeDetailControl";
            this.Size = new System.Drawing.Size(300, 21);
            this.pnlValue.ResumeLayout(false);
            this.pnlValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cInteger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlValue;
        private System.Windows.Forms.TextBox cText;
        private System.Windows.Forms.NumericUpDown cInteger;
        private System.Windows.Forms.ComboBox cOptions;
        private System.Windows.Forms.DateTimePicker cDate;
        private System.Windows.Forms.MaskedTextBox cReal;
    }
}
