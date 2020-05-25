using JsonWinEdit.Schema;
using System.Windows.Forms;

namespace JsonWinEdit
{
    internal partial class ObjectMemberControl : UserControl
    {
        internal ObjectMemberControl()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
        }

        internal string Key { get { return lblKey.Text; } set { lblKey.Text = value; } }

        internal EditorControl ValueEditor
        {
            get
            {
                if (pnlValueEditor.Controls.Count == 0)
                    return null;
                return pnlValueEditor.Controls[0] as EditorControl;
            }
            set
            {
                pnlValueEditor.Controls.Clear();
                if (value != null)
                    pnlValueEditor.Controls.Add(value);
            }
        }

        internal void SetMember(string key, JsonValueEditor editor)
        {
            Key = key;
            ValueEditor = EditorControlFactory.CreateControl(editor);
        }
    }
}
