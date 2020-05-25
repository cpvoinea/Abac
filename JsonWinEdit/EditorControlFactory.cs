using JsonWinEdit.Schema;

namespace JsonWinEdit
{
    static class EditorControlFactory
    {
        internal static EditorControl CreateControl(JsonValueEditor editor)
        {
            if (editor == null)
                return null;

            switch (editor.EditorType)
            {
                case JsonSchemaType.OBJECT: return new ObjectEditorControl(editor);
                case JsonSchemaType.ARRAY: return new ArrayEditorControl(editor);
                case JsonSchemaType.STRING: return new StringEditorControl(editor);
                case JsonSchemaType.NUMBER: return new NumberEditorControl(editor);
                case JsonSchemaType.INTEGER: return new IntegerEditorControl(editor);
                case JsonSchemaType.BOOLEAN: return new BooleanEditorControl(editor);
                case JsonSchemaType.NULL: return new NullEditorControl(editor);
                default: return null;
            }
        }
    }
}
