using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public class JsonIntegerEditor : JsonValueEditor
    {
        public JsonIntegerEditor(JsonSchema schema, JsonInteger data) : base(schema, data)
        {
        }

        public override object DataValue
        {
            get
            {
                if (_data == null)
                    return null;

                return (_data as JsonInteger).Value;
            }
            set
            {
                if (value == null)
                {
                    _data = null;
                    return;
                }

                if (_data == null)
                    _data = new JsonInteger((int)value);
            }
        }
    }
}
