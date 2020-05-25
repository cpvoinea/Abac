using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public class JsonValueEditor
    {
        protected readonly JsonSchema _schema;
        protected IJsonValue _data;

        internal JsonValueEditor(JsonSchema schema, IJsonValue data)
        {
            _schema = schema;
            _data = data;
        }

        public virtual object DataValue { get; set; }

        public JsonSchemaType EditorType { get { return _schema != null ? _schema.SchemaType : JsonSchemaType.NULL; } }

        IJsonValue Data { get { return _data; } }

        public string Title { get { return _schema == null ? null : _schema.Title; } }
        public string Description { get { return _schema == null ? null : _schema.Description; } }

        public string DataString { get { return _data == null ? null : JsonSerializer.Serialize(_data); } }

        public void SaveDataToFile(string fileName)
        {
            string jsonData = DataString;
            if (!string.IsNullOrEmpty(jsonData))
                FileSystemAccess.WriteTextToFile(jsonData, fileName);
        }
    }
}