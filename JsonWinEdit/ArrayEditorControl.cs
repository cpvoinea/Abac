using JsonWinEdit.Schema;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JsonWinEdit
{
    partial class ArrayEditorControl : EditorControl
    {
        public ArrayEditorControl(JsonValueEditor editor) : base(editor)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            GetData();
        }

        protected internal override object Value
        {
            get
            {
                List<JsonValueEditor> result = new List<JsonValueEditor>();
                foreach (ListViewItem i in lstItems.Items)
                    if (i.Tag != null && i.Tag is JsonValueEditor)
                        result.Add(i.Tag as JsonValueEditor);
                return result;
            }
            set
            {
                lstItems.Items.Clear();
                if (value == null)
                    return;

                if (!(value is List<JsonValueEditor> lValue))
                    return;

                foreach (JsonValueEditor v in lValue)
                    lstItems.Items.Add(v.DataString).Tag = v;
            }
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            SetData();
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            SetData();
        }

        private void BtnRemove_Click(object sender, System.EventArgs e)
        {
            SetData();
        }
    }
}
