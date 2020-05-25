using JsonWinEdit.Schema;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JsonWinEdit
{
    partial class ObjectEditorControl : EditorControl
    {
        internal ObjectEditorControl(JsonValueEditor editor) : base(editor)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            InitializeProperties();
            GetData();
        }

        protected internal override object Value
        {
            get
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (ObjectMemberControl m in pnlMembers.Controls)
                    result.Add(m.Key, m.ValueEditor.Value);

                return result;
            }
            set
            {
                pnlMembers.Controls.Clear();
                if (value == null)
                    return;

                if (!(value is Dictionary<string, JsonValueEditor> dValue))
                    return;

                foreach (string key in dValue.Keys)
                    pnlMembers.Controls.Add(new ObjectMemberControl
                    {
                        Key = key,
                        ValueEditor = EditorControlFactory.CreateControl(dValue[key])
                    });
            }
        }

        void InitializeProperties()
        {

        }
    }
}
