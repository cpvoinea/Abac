using System.Collections.Generic;

namespace JsonWinEdit.Data
{
    public class JsonArray : IJsonValue
    {
        readonly List<IJsonValue> _elements = new List<IJsonValue>();

        public JsonValueType Type { get { return JsonValueType.ARRAY; } }
        public List<IJsonValue> Elements { get { return _elements; } }
    }
}
