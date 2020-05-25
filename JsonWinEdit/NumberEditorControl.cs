using JsonWinEdit.Schema;
using System;
using System.Windows.Forms;

namespace JsonWinEdit
{
    partial class NumberEditorControl : EditorControl
    {
        internal NumberEditorControl(JsonValueEditor editor) : base(editor)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            GetData();
        }

        protected internal override object Value { get { return Convert.ToDouble(nudValue.Value); } set { nudValue.Value = Convert.ToDecimal(value); } }

        private void NudValue_ValueChanged(object sender, EventArgs e)
        {
            SetData();
        }
    }
}
