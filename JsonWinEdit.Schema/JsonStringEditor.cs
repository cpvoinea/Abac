using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public class JsonStringEditor : JsonValueEditor
    {
        public JsonStringEditor(JsonSchema schema, JsonString data) : base(schema, data)
        {
        }

        public override object DataValue
        {
            get
            {
                if (_data == null)
                    return null;

                return (_data as JsonString).Value;
            }
            set
            {
                if (value == null)
                {
                    _data = null;
                    return;
                }

                if (_data == null)
                    _data = new JsonString(value.ToString());
            }
        }
    }
}