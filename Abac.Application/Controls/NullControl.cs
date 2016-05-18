using Abac.Business;
using System.Drawing;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    public sealed class NullControl : Label, IAbacControl
    {
        public NullControl()
        {
            TextAlign = ContentAlignment.MiddleLeft;
            AutoSize = true;
            Text = Properties.Settings.Default.nullValueMessage;
        }

        public void SetValue(AbacValue value) { }
        public AbacValue GetValue() { return new AbacValue(); }
    }
}
