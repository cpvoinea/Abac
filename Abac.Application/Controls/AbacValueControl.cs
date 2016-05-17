using Abac.Business;

namespace Abac.Application.Controls
{
    public class AbacValueControl : IAbacControl
    {
        public IAbacControl Control { get; set; }

        public AbacValueControl(AbacValue value)
        {
            SetValue(value);
        }

        public void SetValue(AbacValue value)
        {
            switch (value.Type)
            {
                case AbacValueType.Object:
                    Control = new AbacObjectControl(value);
                    break;
                case AbacValueType.Array:
                    Control = new AbacArrayControl(value);
                    break;
                case AbacValueType.String:
                    Control = new StringControl(value);
                    break;
                case AbacValueType.Number:
                    Control = new NumberControl(value);
                    break;
                case AbacValueType.Bool:
                    Control = new BoolControl(value);
                    break;
                default:
                    Control = new NullControl();
                    break;
            }
        }

        public AbacValue GetValue()
        {
            if (Control == null)
                return new AbacValue();
            return Control.GetValue();
        }
    }
}
