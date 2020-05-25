namespace JsonWinEdit.Data
{
    public class JsonInteger : IJsonValue
    {
        int _value;

        public JsonInteger() { }

        public JsonInteger(int value)
        {
            _value = value;
        }

        public JsonValueType Type { get { return JsonValueType.INTEGER; } }
        public int Value { get { return _value; } set { _value = value; } }
    }
}
