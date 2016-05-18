using Abac.Application.Controls;
using Abac.Business;
using System.Windows.Forms;
using Abac.Creator.Properties;

namespace Abac.Creator
{
    internal class MainForm : Form
    {
        private Panel pnlControls;
        private Button btnRun;
        private GroupBox grpJson;
        private FontDialog fontDialog;
        private Button btnFont;
        private TextBox txtJson;

        internal MainForm()
        {
            InitializeComponent();
            txtJson.Text = Resources.jsonSample;
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpJson = new System.Windows.Forms.GroupBox();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.pnlControls.SuspendLayout();
            this.grpJson.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnFont);
            this.pnlControls.Controls.Add(this.btnRun);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 601);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(984, 60);
            this.pnlControls.TabIndex = 1;
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFont.Location = new System.Drawing.Point(12, 6);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 42);
            this.btnFont.TabIndex = 1;
            this.btnFont.Text = "&Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(897, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 42);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "&Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // grpJson
            // 
            this.grpJson.Controls.Add(this.txtJson);
            this.grpJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpJson.Location = new System.Drawing.Point(0, 0);
            this.grpJson.Name = "grpJson";
            this.grpJson.Size = new System.Drawing.Size(984, 601);
            this.grpJson.TabIndex = 0;
            this.grpJson.TabStop = false;
            this.grpJson.Text = "&Application description";
            // 
            // txtJson
            // 
            this.txtJson.AcceptsReturn = true;
            this.txtJson.AcceptsTab = true;
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Location = new System.Drawing.Point(3, 22);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJson.Size = new System.Drawing.Size(978, 576);
            this.txtJson.TabIndex = 0;
            this.txtJson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJson_KeyDown);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnRun;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.grpJson);
            this.Controls.Add(this.pnlControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Creator";
            this.pnlControls.ResumeLayout(false);
            this.grpJson.ResumeLayout(false);
            this.grpJson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void Run()
        {
            var control = new AbacObjectControl(AbacValue.Parse(txtJson.Text));
            var form = new Form
            {
                Font = Font,
                Size = Size,
                FormBorderStyle = FormBorderStyle,
                StartPosition = StartPosition,
                ShowIcon = ShowIcon,
                Text = Resources.titleApplication,
                ShowInTaskbar = false
            };
            form.Controls.Add(control);
            form.ShowDialog(this);
        }

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            Run();
        }

        private void txtJson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
                Run();
        }

        private void btnFont_Click(object sender, System.EventArgs e)
        {
            fontDialog.Font = Font;
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                SuspendLayout();
                Font = fontDialog.Font;
                ResumeLayout(false);
            }
        }
    }
}