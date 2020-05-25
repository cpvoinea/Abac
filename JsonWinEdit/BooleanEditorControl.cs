using JsonWinEdit.Schema;
using System.Windows.Forms;

namespace JsonWinEdit
{
    partial class BooleanEditorControl : EditorControl
    {
        internal BooleanEditorControl(JsonValueEditor editor) : base(editor)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            GetData();
        }

        protected internal override object Value { get { return chkValue.Checked; } set { chkValue.Checked = (bool)value; } }

        private void ChkValue_CheckedChanged(object sender, System.EventArgs e)
        {
            SetData();
        }
    }
}
