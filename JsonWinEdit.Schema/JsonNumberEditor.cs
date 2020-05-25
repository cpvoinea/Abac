using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public class JsonNumberEditor : JsonValueEditor
    {
        public JsonNumberEditor(JsonSchema schema, JsonNumber data) : base(schema, data)
        {
        }

        public override object DataValue
        {
            get
            {
                if (_data == null)
                    return null;

                return (_data as JsonNumber).Value;
            }
            set
            {
                if (value == null)
                {
                    _data = null;
                    return;
                }

                if (_data == null)
                    _data = new JsonNumber((double)value);
            }
        }
    }
}
