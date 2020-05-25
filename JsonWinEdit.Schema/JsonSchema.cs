using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public class JsonSchema : JsonObject
    {
        #region Keywords
        const string SCHEMA = "$schema";
        const string REF = "$ref";
        const string ID = "id";
        const string TITLE = "title";
        const string DESCRIPTION = "description";
        const string DEFAULT = "default";
        const string ENUM = "enum";
        const string TYPE = "type";
        const string ALL_OF = "allOf";
        const string ANY_OF = "anyOf";
        const string ONE_OF = "oneOf";
        const string NOT = "not";
        const string DEFINITIONS = "definitions";
        const string MULTIPLE_OF = "multipleOf";
        const string MAXIMUM = "maximum";
        const string EXCLUSIVE_MAXIMUM = "exclusiveMaximum";
        const string MINIMUM = "minimum";
        const string EXCLUSIVE_MINIMUM = "exclusiveMinimum";
        const string MAX_LENGTH = "maxLength";
        const string MIN_LENGTH = "minLength";
        const string PATTERN = "pattern";
        const string ITEMS = "items";
        const string ADDITIONAL_ITEMS = "additionalItems";
        const string MAX_ITEMS = "maxItems";
        const string MIN_ITEMS = "minItems";
        const string UNIQUE_ITEMS = "uniqueItems";
        const string PROPERTIES = "properties";
        const string ADDITIONAL_PROPERTIES = "additionalProperties";
        const string PATTERN_PROPERTIES = "patternProperties";
        const string MAX_PROPERTIES = "maxProperties";
        const string MIN_PROPERTIES = "minProperties";
        const string REQUIRED = "required";
        const string DEPENDENCIES = "dependencies";
        const string FORMAT_DATETIME = "date-time";
        const string FORMAT_EMAIL = "email";
        const string FORMAT_HOSTNAME = "hostname";
        const string FORMAT_IPV4 = "ipv4";
        const string FORMAT_IPV6 = "ipv6";
        const string FORMAT_URI = "uri";
        const string FORMAT_REGEX = "regex";
        const string TYPE_ARRAY = "array";
        const string TYPE_BOOLEAN = "boolean";
        const string TYPE_INTEGER = "integer";
        const string TYPE_NULL = "null";
        const string TYPE_NUMBER = "number";
        const string TYPE_OBJECT = "object";
        const string TYPE_STRING = "string";
        #endregion

        public JsonSchema(JsonObject objJson)
        {
            foreach (string key in objJson.Keys)
                _members[key] = objJson[key];
        }

        #region Properties

        internal bool IsEmpty { get { return _members.Count == 0; } }
        internal string Schema { get { return GetStringValue(SCHEMA); } }
        internal string Ref { get { return GetStringValue(REF); } }
        internal string Id { get { return GetStringValue(ID); } }
        internal JsonObject Definitions { get { return GetObjectValue(DEFINITIONS); } }

        internal string Title { get { return GetStringValue(TITLE); } }
        internal string Description { get { return GetStringValue(DESCRIPTION); } }

        internal JsonObject Default { get { return GetObjectValue(DEFAULT); } }
        internal JsonSchemaType SchemaType { get { return GetSchemaType(); } }

        internal double? MultipleOf { get { return GetNumberValue(MULTIPLE_OF); } }
        internal double? Minimum { get { return GetNumberValue(MINIMUM); } }
        internal bool? ExclusiveMinimum { get { return GetBoolValue(EXCLUSIVE_MINIMUM); } }
        internal double? Maximum { get { return GetNumberValue(MAXIMUM); } }
        internal bool? ExclusiveMaximum { get { return GetBoolValue(EXCLUSIVE_MAXIMUM); } }

        internal int? MinLength { get { return GetIntValue(MIN_LENGTH); } }
        internal int? MaxLength { get { return GetIntValue(MAX_LENGTH); } }
        internal string Pattern { get { return GetStringValue(PATTERN); } }

        internal IJsonValue Items { get { return GetValue(ITEMS); } }
        internal IJsonValue AdditionalItems { get { return GetValue(ADDITIONAL_ITEMS); } }
        internal int? MinItems { get { return GetIntValue(MIN_ITEMS); } }
        internal int? MaxItems { get { return GetIntValue(MAX_ITEMS); } }
        internal bool? UniqueItems { get { return GetBoolValue(UNIQUE_ITEMS); } }

        internal int? MinProperties { get { return GetIntValue(MIN_PROPERTIES); } }
        internal int? MaxProperties { get { return GetIntValue(MAX_PROPERTIES); } }
        internal string[] Required { get { return GetStringArrayValue(REQUIRED); } }

        internal JsonObject Properties { get { return GetObjectValue(PROPERTIES); } }
        internal IJsonValue AdditionalProperties { get { return GetValue(ADDITIONAL_PROPERTIES); } }
        internal JsonObject PatternProperties { get { return GetObjectValue(PATTERN_PROPERTIES); } }
        internal JsonObject Dependencies { get { return GetObjectValue(DEPENDENCIES); } }

        internal IJsonValue[] Enum { get { return GetArrayValue(ENUM); } }

        internal IJsonValue[] AllOf { get { return GetArrayValue(ALL_OF); } }
        internal IJsonValue[] AnyOf { get { return GetArrayValue(ANY_OF); } }
        internal IJsonValue[] OneOf { get { return GetArrayValue(ONE_OF); } }
        internal JsonObject Not { get { return GetObjectValue(NOT); } }

        #endregion

        internal static JsonSchema Create(string jsonData, out IJsonValue data)
        {
            var jsonObjects = JsonSerializer.Deserialize(jsonData);

            if (jsonObjects == null || jsonObjects.Length == 0 || !(jsonObjects[0] is JsonObject))
            {
                data = null;
                return null;
            }

            data = jsonObjects.Length > 1 ? jsonObjects[1] : null;
            return new JsonSchema(jsonObjects[0] as JsonObject);
        }

        JsonSchemaType GetSchemaType()
        {
            if (!_members.ContainsKey(TYPE))
                return JsonSchemaType.NULL;

            IJsonValue type = _members[TYPE];
            if (type == null)
                return JsonSchemaType.NULL;

            if (type.Type == JsonValueType.ARRAY)
            {
                var arr = type as JsonArray;
                if (arr == null || arr.Elements == null || arr.Elements.Count == 0)
                    return JsonSchemaType.NULL;
                type = arr.Elements[0];
            }

            var sType = type as JsonString;
            if (sType == null || string.IsNullOrEmpty(sType.Value))
                return JsonSchemaType.NULL;

            switch (sType.Value)
            {
                case TYPE_ARRAY: return JsonSchemaType.ARRAY;
                case TYPE_BOOLEAN: return JsonSchemaType.BOOLEAN;
                case TYPE_INTEGER: return JsonSchemaType.INTEGER;
                case TYPE_NULL: return JsonSchemaType.NULL;
                case TYPE_NUMBER: return JsonSchemaType.NUMBER;
                case TYPE_OBJECT: return JsonSchemaType.OBJECT;
                case TYPE_STRING: return JsonSchemaType.STRING;
                default: return JsonSchemaType.NULL;
            }
        }
    }
}
