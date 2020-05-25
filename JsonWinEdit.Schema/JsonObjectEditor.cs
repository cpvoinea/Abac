using JsonWinEdit.Data;
using System.Collections.Generic;

namespace JsonWinEdit.Schema
{
    public class JsonObjectEditor : JsonValueEditor
    {
        Dictionary<string, JsonValueEditor> _propertyEditors = new Dictionary<string, JsonValueEditor>();

        public JsonObjectEditor(JsonSchema schema, JsonObject data) : base(schema, data)
        {
            InitializePropertyEditors();
        }

        /// <summary>
        /// type of Dictionary<string, object> where object is JsonObject's property data value
        /// </summary>
        public override object DataValue
        {
            get
            {
                if (_data == null)
                    return null;

                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (string key in _propertyEditors.Keys)
                    result.Add(key, _propertyEditors[key]);

                return result;
            }
            set
            {
                if (value == null)
                {
                    _data = null;
                    return;
                }

                if (_data == null)
                    _data = new JsonObject();

                JsonObject oData = _data as JsonObject;
                Dictionary<string, object> dValue = value as Dictionary<string, object>;
                if (dValue == null)
                    return;

                foreach (string key in dValue.Keys)
                    if (_propertyEditors[key] != null)
                        _propertyEditors[key].DataValue = dValue[key];
            }
        }

        void InitializePropertyEditors()
        {
            if (_schema == null || _schema.Properties == null)
                return;

            foreach (string key in _schema.Properties.Keys)
            {
                JsonSchema schema = new JsonSchema(_schema.Properties[key] as JsonObject ?? new JsonObject());
                IJsonValue data = _data == null ? null : (_data as JsonObject)[key];
                _propertyEditors[key] = JsonValueEditorFactory.Create(schema, data);
            }
        }

        public JsonValueEditor GetPropertyEditor(string key)
        {
            if (!_propertyEditors.ContainsKey(key))
                return null;

            return _propertyEditors[key];
        }
    }
}
