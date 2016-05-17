using Abac.Business;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    public class AbacObjectControl : Panel, IAbacControl
    {
        public AbacObjectControl()
        {
            Dock = DockStyle.Fill;
            Padding = new Padding(3);
            AutoScroll = true;
        }

        public AbacObjectControl(AbacValue value)
            : this()
        {
            SetValue(value);
        }

        public void SetValue(AbacValue abacValue)
        {
            if (abacValue.Type != AbacValueType.Object)
                return;
            var value = abacValue.ObjectValue;

            double sizeRatio = Properties.Settings.Default.sizeRatio;
            int margin = Properties.Settings.Default.margin;
            int width = 0;
            int height = 0;
            foreach (var key in CreateReverseIterator(value.Keys))
            {
                var ctrlName = new Label
                {
                    Dock = DockStyle.Left,
                    Padding = new Padding(margin),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                    Text = key
                };
                var ctrlMember = new AbacValueControl(value[key]).Control as Control;
                var pnlMember = new Panel
                {
                    Dock = DockStyle.Top,
                    Padding = new Padding(margin),
                    Height = (int)(ctrlMember.Height * sizeRatio) + 2 * margin
                };

                pnlMember.Controls.Add(ctrlMember);
                pnlMember.Controls.Add(ctrlName);
                Controls.Add(pnlMember);

                if (ctrlName.Width > width)
                    width = ctrlName.Width;
                height += pnlMember.Height;
            }

            foreach (Panel p in Controls)
            {
                var l = p.Controls[1] as Label;
                if (l != null)
                {
                    l.AutoSize = false;
                    l.Width = (int)(width * sizeRatio) + 2 * margin;
                }
            }
            Height = height + 2 * margin;
        }

        public AbacValue GetValue()
        {
            return new AbacValue();
        }

        static IEnumerable<T> CreateReverseIterator<T>(ICollection<T> collection)
        {
            List<T> list = new List<T>();
            foreach (T e in collection)
                list.Add(e);
            int count = list.Count;
            for (int i = count - 1; i >= 0; --i)
            {
                yield return list[i];
            }
        }
    }
}
