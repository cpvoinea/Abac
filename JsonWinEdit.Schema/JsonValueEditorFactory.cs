using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public static class JsonValueEditorFactory
    {
        public static JsonValueEditor Create(JsonSchema schema, IJsonValue data)
        {
            if (schema == null)
                return null;

            switch (schema.SchemaType)
            {
                case JsonSchemaType.OBJECT: return new JsonObjectEditor(schema, data as JsonObject);
                case JsonSchemaType.ARRAY: return new JsonArrayEditor(schema, data as JsonArray);
                case JsonSchemaType.STRING: return new JsonStringEditor(schema, data as JsonString);
                case JsonSchemaType.NUMBER: return new JsonNumberEditor(schema, data as JsonNumber);
                case JsonSchemaType.INTEGER: return new JsonIntegerEditor(schema, data as JsonInteger);
                case JsonSchemaType.BOOLEAN: return new JsonBooleanEditor(schema, data as JsonBoolean);
                case JsonSchemaType.NULL: return new JsonNullEditor();
                default: return null;
            }
        }

        public static JsonValueEditor CreateFromData(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
                return null;

            IJsonValue data;
            JsonSchema schema = JsonSchema.Create(jsonData, out data);
            return Create(schema, data);
        }

        public static JsonValueEditor CreateFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            string jsonData = FileSystemAccess.ReadTextFromFile(fileName);
            return CreateFromData(jsonData);
        }
    }
}
