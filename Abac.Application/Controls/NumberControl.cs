using Abac.Business;
using System;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    public class NumberControl : NumericUpDown, IAbacControl
    {
        public NumberControl()
        {
            DecimalPlaces = 2;
            Minimum = decimal.MinValue;
            Maximum = decimal.MaxValue;
        }

        public NumberControl(AbacValue value)
            : this()
        {
            SetValue(value);
        }

        public void SetValue(AbacValue value)
        {
            if (value.Type != AbacValueType.Number)
                return;
            Value = Convert.ToDecimal(value.NumberValue);
        }

        public AbacValue GetValue()
        {
            return new AbacValue(Convert.ToDouble(Value));
        }
    }
}
