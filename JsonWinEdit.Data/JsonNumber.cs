namespace JsonWinEdit.Data
{
    public class JsonNumber : IJsonValue
    {
        double _value;

        public JsonNumber() { }

        public JsonNumber(double value)
        {
            _value = value;
        }

        public JsonValueType Type { get { return JsonValueType.NUMBER; } }
        public double Value { get { return _value; } set { _value = value; } }
    }
}
