namespace JsonWinEdit.Data
{
    public class JsonString : IJsonValue
    {
        string _value;

        public JsonString() { }

        public JsonString(string value)
        {
            _value = value;
        }

        public JsonValueType Type { get { return JsonValueType.STRING; } }
        public string Value { get { return _value; } set { _value = value; } }
    }
}
