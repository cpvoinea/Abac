using Abac.Application.Controls;
using Abac.Business;
using System.Windows.Forms;

namespace Abac.Creator
{
    internal class MainForm : Form
    {
        private Panel pnlControls;
        private Button btnRun;
        private GroupBox grpJson;
        private TextBox txtJson;

        internal MainForm()
        {
            InitializeComponent();
            txtJson.Text = Properties.Resources.jsonSample;
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpJson = new System.Windows.Forms.GroupBox();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.pnlControls.SuspendLayout();
            this.grpJson.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnRun);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 661);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(984, 50);
            this.pnlControls.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(897, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 35);
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
            this.grpJson.Size = new System.Drawing.Size(984, 661);
            this.grpJson.TabIndex = 1;
            this.grpJson.TabStop = false;
            this.grpJson.Text = "&Application description";
            // 
            // txtJson
            // 
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Location = new System.Drawing.Point(3, 22);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(978, 636);
            this.txtJson.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnRun;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.grpJson);
            this.Controls.Add(this.pnlControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlControls.ResumeLayout(false);
            this.grpJson.ResumeLayout(false);
            this.grpJson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            var control = new AbacObjectControl(AbacValue.Parse(txtJson.Text));
            var form = new Form
            {
                Font = Font,
                Size = Size,
                FormBorderStyle = FormBorderStyle,
                StartPosition = StartPosition
            };
            form.Controls.Add(control);
            form.ShowDialog(this);
        }
    }
}