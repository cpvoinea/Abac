using JsonWinEdit.Schema;
using System;
using System.Windows.Forms;

namespace JsonWinEdit
{
    partial class MainForm : Form
    {
        EditorControl _editorControl;

        internal MainForm()
        {
            InitializeComponent();
        }

        internal EditorControl EditorControl
        {
            get { return _editorControl; }
            set
            {
                _editorControl = value;
                InitializeEditorControl();
            }
        }

        void InitializeEditorControl()
        {
            pnlEditor.Controls.Clear();
            if (_editorControl == null)
                return;

            pnlEditor.Controls.Add(_editorControl);

            Text = _editorControl.Title;
            lblDescription.Text = _editorControl.Description;
        }

        #region Event handlers

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (ofdOpen.ShowDialog(this) == DialogResult.OK)
                _editorControl = EditorControl.CreateFromFile(ofdOpen.FileName);
        }

        void BtnSave_Click(object sender, EventArgs e)
        {
            if (_editorControl == null)
                return;

            if (sfdSave.ShowDialog(this) == DialogResult.OK)
                _editorControl.SaveToFile(sfdSave.FileName);
        }

        void BtnRun_Click(object sender, EventArgs e)
        {
            if (_editorControl == null)
                return;

            string jsonData = "";

            if (!string.IsNullOrEmpty(jsonData))
                _editorControl = EditorControl.CreateFromData(jsonData);
        }

        #endregion
    }
}
