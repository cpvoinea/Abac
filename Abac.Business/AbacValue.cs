using System.Globalization;

namespace Abac.Business
{
    /// <summary>
    ///     A value can be a string in double quotes, or a number, or true or false or null, or an object or an array
    /// </summary>
    public class AbacValue
    {
        #region Members
        private readonly AbacValueType _type;
        private AbacObject _objectValue;
        private AbacArray _arrayValue;
        private string _stringValue;
        private double _numberValue;
        private bool _boolValue;
        #endregion

        #region Properties

        public AbacValueType Type
        {
            get { return _type; }
        }

        public AbacObject ObjectValue
        {
            get { return _type == AbacValueType.Object ? _objectValue : null; }
            set
            {
                if (_type == AbacValueType.Object)
                    _objectValue = value;
            }
        }

        public AbacArray ArrayValue
        {
            get { return _type == AbacValueType.Array ? _arrayValue : null; }
            set
            {
                if (_type == AbacValueType.Array)
                    _arrayValue = value;
            }
        }

        public string StringValue
        {
            get { return _type == AbacValueType.String ? _stringValue : null; }
            set
            {
                if (_type == AbacValueType.String)
                    _stringValue = value;
            }
        }

        public double NumberValue
        {
            get { return _type == AbacValueType.Number ? _numberValue : 0; }
            set
            {
                if (_type == AbacValueType.Number)
                    _numberValue = value;
            }
        }

        public bool BoolValue
        {
            get { return _type == AbacValueType.Bool && _boolValue; }
            set
            {
                if (_type == AbacValueType.Bool)
                    _boolValue = value;
            }
        }

        public bool IsNull
        {
            get { return _type == AbacValueType.Null; }
        }

        #endregion

        #region Constructors

        public AbacValue(AbacValueType type)
        {
            _type = type;
        }

        public AbacValue()
            : this(AbacValueType.Null)
        {
        }

        public AbacValue(bool value)
            : this(AbacValueType.Bool)
        {
            _boolValue = value;
        }

        public AbacValue(string value)
            : this(AbacValueType.String)
        {
            _stringValue = value;
        }

        public AbacValue(double value)
            : this(AbacValueType.Number)
        {
            _numberValue = value;
        }

        public AbacValue(AbacObject value)
            : this(AbacValueType.Object)
        {
            _objectValue = value;
        }

        public AbacValue(AbacArray value)
            : this(AbacValueType.Array)
        {
            _arrayValue = value;
        }

        #endregion

        #region Equality

        private object GetValue()
        {
            switch (_type)
            {
                case AbacValueType.Object:
                    return _objectValue;
                case AbacValueType.Array:
                    return _arrayValue;
                case AbacValueType.String:
                    return _stringValue;
                case AbacValueType.Number:
                    return _numberValue;
                case AbacValueType.Bool:
                    return _boolValue;
                default:
                    return null;
            }
        }

        public override bool Equals(object obj)
        {
            var v = (AbacValue) obj;
            if (v == null)
                return false;
            if (v.IsNull)
                return IsNull;
            return v._type == _type && v.GetValue().Equals(GetValue());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        #endregion

        #region Serialization

        public override string ToString()
        {
            return ToJsonString("").Trim();
        }

        internal string ToJsonString(string indent)
        {
            switch (_type)
            {
                case AbacValueType.Object:
                    return _objectValue.ToJsonString(indent);
                case AbacValueType.Array:
                    return _arrayValue.ToJsonString(indent);
                case AbacValueType.String:
                    return string.Format("\"{0}\"", _stringValue);
                case AbacValueType.Number:
                    return _numberValue.ToString(CultureInfo.InvariantCulture);
                case AbacValueType.Bool:
                    return _boolValue.ToString().ToLower();
                default:
                    return "null";
            }
        }

        #endregion

        #region Deserialization

        public static AbacValue Parse(string str)
        {
            int i;
            return FromJsonString(str.Replace("\r\n", "").Replace("\t", "").Trim(), out i);
        }

        internal static AbacValue FromJsonString(string json, out int nextIndex)
        {
            if (string.IsNullOrEmpty(json))
            {
                nextIndex = 1;
                return new AbacValue();
            }

            var i = 0;
            while (i < json.Length)
            {
                var c = json[i];
                if (char.IsWhiteSpace(c))
                {
                    i++;
                }
                else
                    switch (c)
                    {
                        case '{':
                            var resultObj = new AbacValue(AbacObject.FromJsonString(json.Substring(i), out nextIndex));
                            nextIndex += i;
                            return resultObj;
                        case '[':
                            var resultArr = new AbacValue(AbacArray.FromJsonString(json.Substring(i), out nextIndex));
                            nextIndex += i;
                            return resultArr;
                        case '"':
                            var resultStr = new AbacValue(ParseStringValue(json.Substring(i), out nextIndex));
                            nextIndex += i;
                            return resultStr;
                        default:
                            var valueStr = GetValueString(json.Substring(i), out nextIndex);
                            if (nextIndex <= 0)
                            {
                                nextIndex = json.Length;
                                return new AbacValue();
                            }
                            nextIndex += i;
                            if (string.IsNullOrEmpty(valueStr))
                                return new AbacValue();

                            double resultNum;
                            if (double.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out resultNum))
                                return new AbacValue(resultNum);
                            bool resultBool;
                            if (bool.TryParse(valueStr, out resultBool))
                                return new AbacValue(resultBool);
                            return new AbacValue();
                    }
            }

            nextIndex = i;
            return new AbacValue();
        }

        internal static string ParseStringValue(string json, out int nextIndex)
        {
            var result = "";
            var i = 1;
            var prev = default(char);
            while (i < json.Length)
            {
                var c = json[i];
                if (c == '"' && prev != '\\')
                {
                    nextIndex = i + 1;
                    return result;
                }
                result += c;
                prev = c;
                i++;
            }

            nextIndex = i;
            return result;
        }

        internal static string GetValueString(string json, out int nextIndex)
        {
            nextIndex = json.IndexOfAny(new[] {',', '}', ']'});
            if (nextIndex >= 0)
                return json.Substring(0, nextIndex).Trim();

            return "";
        }

        #endregion
    }
}