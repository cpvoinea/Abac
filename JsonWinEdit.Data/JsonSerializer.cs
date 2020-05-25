using System.Collections.Generic;
using System.Text;

namespace JsonWinEdit.Data
{
    public static class JsonSerializer
    {
        #region JSON Syntax
        const char OBJECT_OPEN = '{';
        const char OBJECT_CLOSE = '}';
        const char ARRAY_OPEN = '[';
        const char ARRAY_CLOSE = ']';
        const char STRING_DELIM = '"';
        const char MEMBER_SEP = ':';
        const char ITEM_SEP = ',';
        const string TRUE = "true";
        const string FALSE = "false";
        const string NULL = "null";
        #endregion

        #region Serialize

        public static string Serialize(IJsonValue objValue)
        {
            if (objValue == null)
                return null;

            switch (objValue.Type)
            {
                case JsonValueType.NULL: return NULL;
                case JsonValueType.BOOLEAN: return (objValue as JsonBoolean).Value ? TRUE : FALSE;
                case JsonValueType.INTEGER:
                case JsonValueType.NUMBER: return SerializeNumber(objValue as JsonNumber);
                case JsonValueType.STRING: return SerializeString(objValue as JsonString);
                case JsonValueType.ARRAY: return SerializeArray(objValue as JsonArray);
                case JsonValueType.OBJECT: return SerializeObject(objValue as JsonObject);
                default: return null;
            }
        }

        static string SerializeObject(JsonObject obj)
        {
            if (obj == null)
                return null;

            StringBuilder sb = new StringBuilder(OBJECT_OPEN);
            bool addSep = false;
            foreach (var key in obj.Keys)
            {
                if (addSep) sb.Append(ITEM_SEP);
                else addSep = true;
                sb.Append(key);
                sb.Append(MEMBER_SEP);
                sb.Append(Serialize(obj[key]));
            }
            sb.Append(OBJECT_CLOSE);

            return sb.ToString();
        }

        static string SerializeArray(JsonArray objArray)
        {
            if (objArray == null)
                return null;

            StringBuilder sb = new StringBuilder(ARRAY_OPEN);
            if (objArray.Elements != null)
            {
                bool addSep = false;
                foreach (var e in objArray.Elements)
                {
                    if (addSep) sb.Append(ITEM_SEP);
                    else addSep = true;
                    sb.Append(Serialize(e));
                }
            }
            sb.Append(ARRAY_CLOSE);

            return sb.ToString();
        }

        static string SerializeString(JsonString objString)
        {
            if (objString == null)
                return null;

            return string.Format("\"{0}\"", objString.Value);
        }

        static string SerializeNumber(JsonNumber objNumber)
        {
            if (objNumber == null)
                return null;

            return objNumber.Value.ToString();
        }

        #endregion

        #region Deserialize

        public static IJsonValue[] Deserialize(string json)
        {
            var objects = new List<IJsonValue>();

            var text = json.Trim();
            int i = 0;
            while (!string.IsNullOrEmpty(text))
            {
                var obj = Deserialize(text, out i);
                if (obj != null)
                    objects.Add(obj);
                text = i < text.Length ? text.Substring(i).Trim() : string.Empty;
            }
            return objects.ToArray();
        }

        static IJsonValue Deserialize(string json, out int i)
        {
            if (string.IsNullOrEmpty(json))
            {
                i = 0;
                return null;
            }

            switch (json[0])
            {
                case OBJECT_OPEN: return DeserializeObject(json, out i);
                case ARRAY_OPEN: return DeserializeArray(json, out i);
                case STRING_DELIM: return DeserializeString(json, out i);
                default: return DeserializeValue(json, out i);
            }
        }

        static IJsonValue DeserializeValue(string json, out int i)
        {
            if (string.IsNullOrEmpty(json))
            {
                i = 0;
                return null;
            }

            if (json.StartsWith(NULL))
            {
                i = NULL.Length;
                return new JsonNull();
            }
            if (json.StartsWith(TRUE))
            {
                i = TRUE.Length;
                return new JsonBoolean(true);
            }
            if (json.StartsWith(FALSE))
            {
                i = FALSE.Length;
                return new JsonBoolean(false);
            }

            var strInt = string.Empty;
            i = 0;
            while (i < json.Length && IsIntChar(json[i]))
            {
                strInt += json[i];
                i++;
            }

            var strNum = strInt;
            while (i < json.Length && IsNumChar(json[i]))
            {
                strNum += json[i];
                i++;
            }

            if (strNum.Length > strInt.Length)
            {
                double valNum;
                if (double.TryParse(strNum, out valNum))
                    return new JsonNumber(valNum);
            }

            int valInt;
            if (int.TryParse(strInt, out valInt))
                return new JsonInteger(valInt);

            return new JsonString(json);
        }

        static JsonString DeserializeString(string json, out int i)
        {
            if (string.IsNullOrEmpty(json))
            {
                i = 0;
                return null;
            }

            var str = string.Empty;
            i = 1;
            while (i < json.Length && json[i] != STRING_DELIM)
            {
                str += json[i];
                i++;
            }

            i++;
            return new JsonString(str);
        }

        static JsonArray DeserializeArray(string json, out int i)
        {
            if (string.IsNullOrEmpty(json))
            {
                i = 0;
                return null;
            }

            var array = new JsonArray();
            var arrayText = json.Substring(1).TrimStart();
            while(!string.IsNullOrEmpty(arrayText) && arrayText[0] != ARRAY_CLOSE)
            {
                array.Elements.Add(Deserialize(arrayText, out i));
                arrayText = i < arrayText.Length ? arrayText.Substring(i).TrimStart().TrimStart(ITEM_SEP).TrimStart() : string.Empty;
            }

            i = json.Length - arrayText.Length + 1;
            return array;
        }

        static JsonObject DeserializeObject(string json, out int i)
        {
            if (string.IsNullOrEmpty(json))
            {
                i = 0;
                return null;
            }

            var obj = new JsonObject();
            var objText = json.Substring(1).TrimStart();
            while (!string.IsNullOrEmpty(objText) && objText[0] != OBJECT_CLOSE)
            {
                var member = DeserializeMember(objText, out i);
                obj.Add(member.Key, member.Value);
                objText = i < objText.Length ? objText.Substring(i).TrimStart().TrimStart(ITEM_SEP).TrimStart() : string.Empty;
            }

            i = json.Length - objText.Length + 1;
            return obj;
        }

        static JsonMember DeserializeMember(string json, out int i)
        {
            var key = DeserializeString(json, out i).Value;
            var valueText = json.Substring(i).TrimStart().TrimStart(MEMBER_SEP).TrimStart();

            int j;
            var value = Deserialize(valueText, out j);

            i = json.Length - valueText.Length + j;
            return new JsonMember { Key = key, Value = value };
        }

        static bool IsIntChar(char c)
        {
            return char.IsNumber(c) || c == '-';
        }

        static bool IsNumChar(char c)
        {
            return IsIntChar(c) || c == '.' || c == 'e';
        }

        #endregion
    }
}
