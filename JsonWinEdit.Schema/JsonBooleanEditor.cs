using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public class JsonBooleanEditor : JsonValueEditor
    {
        public JsonBooleanEditor(JsonSchema schema, JsonBoolean data) : base(schema, data)
        {
        }

        public override object DataValue
        {
            get
            {
                if (_data == null)
                    return null;

                return (_data as JsonBoolean).Value;
            }
            set
            {
                if (value == null)
                {
                    _data = null;
                    return;
                }

                if (_data == null)
                    _data = new JsonBoolean((bool)value);
            }
        }
    }
}
