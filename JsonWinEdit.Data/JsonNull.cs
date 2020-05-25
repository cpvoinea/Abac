namespace JsonWinEdit.Data
{
    public sealed class JsonNull : IJsonValue
    {
        public JsonValueType Type { get { return JsonValueType.NULL; } }
        public static JsonNull Value { get { return new JsonNull(); } }
    }
}
