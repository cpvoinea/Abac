using Abac.Business;
using System.Drawing;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    public class NullControl : Label, IAbacControl
    {
        public NullControl()
        {
            Dock = DockStyle.Fill;
            TextAlign = ContentAlignment.MiddleLeft;
            Text = Properties.Settings.Default.nullValueMessage;
        }

        public void SetValue(AbacValue value) { }
        public AbacValue GetValue() { return new AbacValue(); }
    }
}
