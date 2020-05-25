using JsonWinEdit.Schema;
using System.Windows.Forms;

namespace JsonWinEdit
{
    partial class EditorControl : UserControl
    {
        protected readonly JsonValueEditor _editor;

        internal EditorControl() { }

        internal EditorControl(JsonValueEditor editor)
        {
            _editor = editor;
        }

        protected internal virtual object Value { get; set; }

        internal string Title { get { return _editor == null ? string.Empty : _editor.Title ?? string.Empty; } }
        internal string Description { get { return _editor == null ? string.Empty : _editor.Description ?? string.Empty; } }

        protected internal object Data
        {
            get
            {
                if (_editor == null)
                    return null;
                return _editor.DataValue;
            }
            set
            {
                if (_editor == null)
                    return;
                _editor.DataValue = value;
            }
        }

        protected virtual void SetData()
        {
            Data = Value;
        }

        protected virtual void GetData()
        {
            Value = Data;
        }

        internal void SaveToFile(string fileName)
        {
            if (_editor == null)
                return;

            _editor.SaveDataToFile(fileName);
        }

        internal static EditorControl CreateFromData(string jsonData)
        {
            return new EditorControl(JsonValueEditorFactory.CreateFromData(jsonData));
        }

        internal static EditorControl CreateFromFile(string fileName)
        {
            return new EditorControl(JsonValueEditorFactory.CreateFromFile(fileName));
        }
    }
}
