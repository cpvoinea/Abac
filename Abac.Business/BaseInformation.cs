namespace Abac.Business
{
    public class BaseInformation
    {
        BaseType _baseType;
        object _value;

        public object Value { get { return _value; } }

        public BaseInformation(BaseType baseType, object value)
        {
            _baseType = baseType;
            _value = value;
        }
    }
}
