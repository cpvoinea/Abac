using System.Collections.Generic;

namespace JsonWinEdit.Data
{
    public class JsonObject : IJsonValue
    {
        protected Dictionary<string, IJsonValue> _members = new Dictionary<string, IJsonValue>();

        public JsonValueType Type { get { return JsonValueType.OBJECT; } }
        public IEnumerable<string> Keys { get { return _members.Keys; } }
        public IJsonValue this[string key] { get { return GetValue(key); } }

        internal void Add(string key, IJsonValue value)
        {
            _members[key] = value;
        }

        protected IJsonValue GetValue(string key)
        {
            if (!_members.ContainsKey(key))
                return null;
            return _members[key];
        }

        protected JsonObject GetObjectValue(string key)
        {
            var o = GetValue(key);
            if (o == null)
                return null;

            return o as JsonObject;
        }

        protected IJsonValue[] GetArrayValue(string key)
        {
            var a = GetValue(key) as JsonArray;
            if (a == null || a.Elements == null)
                return null;
            return a.Elements.ToArray();
        }

        protected string[] GetStringArrayValue(string key)
        {
            var a = GetArrayValue(key);
            if (a == null)
                return null;

            var result = new List<string>();
            foreach(var e in a)
            {
                var s = e as JsonString;
                if (s != null && !string.IsNullOrEmpty(s.Value))
                    result.Add(s.Value);
            }

            return result.ToArray();
        }

        protected string GetStringValue(string key)
        {
            var s = GetValue(key) as JsonString;
            return s == null || string.IsNullOrEmpty(s.Value) ? null : s.Value;
        }

        protected double? GetNumberValue(string key)
        {
            var d = GetValue(key) as JsonNumber;
            return d == null ? (double?)null : d.Value;
        }

        protected int? GetIntValue(string key)
        {
            var i = GetValue(key) as JsonInteger;
            return i == null ? (int?)null : i.Value;
        }

        protected bool? GetBoolValue(string key)
        {
            var b = GetValue(key) as JsonBoolean;
            return b == null ? (bool?)null : b.Value;
        }
    }
}
