using Abac.Business;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    internal class StringControl : TextBox, IAbacControl
    {
        public StringControl(AbacValue value)
        {
            SetValue(value);
        }

        public void SetValue(AbacValue value)
        {
            if (value.Type != AbacValueType.String)
                return;
            Text = value.StringValue;
        }

        public AbacValue GetValue()
        {
            return new AbacValue(Text);
        }
    }
}
