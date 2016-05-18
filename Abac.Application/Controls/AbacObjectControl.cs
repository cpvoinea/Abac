using Abac.Business;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    public class AbacObjectControl : Panel, IAbacControl
    {
        private readonly int _margin;

        public AbacObjectControl()
        {
            _margin = Properties.Settings.Default.margin;
            Layout += AbacObjectControl_Layout;

            Dock = DockStyle.Fill;
            AutoScroll = true;
            Padding = new Padding(_margin);
        }

        void AbacObjectControl_Layout(object sender, LayoutEventArgs e)
        {
            SuspendLayout();
            ResizeControls();
            ResumeLayout(false);
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

            SuspendLayout();
            foreach (var name in CreateReverseIterator(abacValue.ObjectValue.Keys))
                Controls.Add(GetMemberControl(name, abacValue.ObjectValue[name], _margin));
            ResumeLayout(false);
        }

        public AbacValue GetValue()
        {
            return new AbacValue();
        }

        private Size GetTextSize(string text)
        {
            return TextRenderer.MeasureText(text, Font);
        }

        private void ResizeControls()
        {
            int height = 0;
            int width = 0;
            foreach (Panel pnlMember in Controls)
            {
                pnlMember.SuspendLayout();
                Control ctrlMember = pnlMember.Controls[0];
                Control ctrlName = pnlMember.Controls[1];
                int memberHeight = ctrlMember.Height;
                Size nameSize = GetTextSize(ctrlName.Text);

                pnlMember.Height = (memberHeight > nameSize.Height + _margin ? memberHeight : nameSize.Height + _margin) + _margin;
                ctrlMember.Dock = DockStyle.Fill;
                height += pnlMember.Height;

                if (nameSize.Width > width)
                    width = nameSize.Width;
            }
            Height = height + _margin;

            foreach(Panel pnlMember in Controls)
            {
                pnlMember.Controls[1].AutoSize = false;
                pnlMember.Controls[1].Width = width;
                pnlMember.ResumeLayout(false);
            }
        }

        private static Panel GetMemberControl(string name, AbacValue value, int margin)
        {
            var pnlMember = new Panel
            {
                Dock = DockStyle.Top,
                Padding = new Padding(margin)
            };

            pnlMember.SuspendLayout();
            var ctrlName = new Label
            {
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = name
            };
            var ctrlMember = new AbacValueControl(value).Control as Control ?? new NullControl();

            pnlMember.Controls.Add(ctrlMember);
            pnlMember.Controls.Add(ctrlName);
            pnlMember.ResumeLayout(false);

            return pnlMember;
        }

        private static IEnumerable<T> CreateReverseIterator<T>(ICollection<T> collection)
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
