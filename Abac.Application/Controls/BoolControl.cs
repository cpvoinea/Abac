using Abac.Business;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    public class BoolControl : CheckBox, IAbacControl
    {
        internal BoolControl(AbacValue value)
        {
            Dock = DockStyle.Fill;
            SetValue(value);
        }

        public void SetValue(AbacValue value)
        {
            if (value.Type != AbacValueType.Bool)
                return;
            Checked = value.BoolValue;
        }

        public AbacValue GetValue()
        {
            return new AbacValue(Checked);
        }
    }
}
