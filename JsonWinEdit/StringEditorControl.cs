using JsonWinEdit.Schema;
using System;
using System.Windows.Forms;

namespace JsonWinEdit
{
    partial class StringEditorControl : EditorControl
    {
        internal StringEditorControl(JsonValueEditor editor) : base(editor)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            GetData();
        }

        protected internal override object Value { get { return txtValue.Text; } set { txtValue.Text = value.ToString(); } }

        private void TxtValue_TextChanged(object sender, EventArgs e)
        {
            SetData();
        }
    }
}
