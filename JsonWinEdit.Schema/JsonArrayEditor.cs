using JsonWinEdit.Data;
using System.Collections.Generic;

namespace JsonWinEdit.Schema
{
    public class JsonArrayEditor : JsonValueEditor
    {
        JsonSchema _elementSchema;
        List<JsonValueEditor> _elementEditors = new List<JsonValueEditor>();

        public JsonArrayEditor(JsonSchema schema, JsonArray data) : base(schema, data)
        {
            InitializeElementEditors();
        }

        /// <summary>
        /// type of List<object> where object is JsonArray's element data value</object>
        /// </summary>
        public override object DataValue
        {
            get
            {
                if (_data == null)
                    return null;

                List<object> result = new List<object>();
                foreach (JsonValueEditor e in _elementEditors)
                    result.Add(e.DataValue);

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
                    _data = new JsonArray();

                JsonArray aData = _data as JsonArray;
                aData.Elements.Clear();
                List<object> lValue = value as List<object>;
                if (lValue == null)
                    return;

                for(int i = 0; i < lValue.Count; i++)
                {
                    if (i < _elementEditors.Count)
                        _elementEditors[i].DataValue = lValue[i];
                }
            }
        }

        void InitializeElementEditors()
        {
            if (_schema == null || _schema.Items == null)
            {
                _elementSchema = new JsonSchema(new JsonObject());
                return;
            }

            _elementSchema = new JsonSchema(_schema.Items as JsonObject);
            if (_data == null)
                _elementEditors.Add(JsonValueEditorFactory.Create(_elementSchema, null));
            else
                foreach (IJsonValue e in (_data as JsonArray).Elements)
                    _elementEditors.Add(JsonValueEditorFactory.Create(_elementSchema, e));
        }
    }
}
