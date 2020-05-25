namespace JsonWinEdit.Data
{
    public sealed class JsonBoolean : IJsonValue
    {
        bool _value;

        public JsonBoolean() { }

        public JsonBoolean(bool value)
        {
            _value = value;
        }

        public JsonValueType Type { get { return JsonValueType.BOOLEAN; } }
        public bool Value { get { return _value; } set { _value = value; } }
    }
}
