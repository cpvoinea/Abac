using Abac.Business;
using System.Globalization;
using System.Windows.Forms;

namespace Abac.Application.Controls
{
    public class AbacArrayControl : ListView, IAbacControl
    {
        public AbacArrayControl()
        {
            Dock = DockStyle.Fill;
            FullRowSelect = true;
            View = View.Details;
            HeaderStyle = ColumnHeaderStyle.None;
            Columns.Add("", -1);
        }

        public AbacArrayControl(AbacValue value)
            : this()
        {
            SetValue(value);
        }

        public void SetValue(AbacValue abacValue)
        {
            if (abacValue.Type != AbacValueType.Array)
                return;
            var value = abacValue.ArrayValue;

            if (value.Count == 0)
                Items.Add(Properties.Settings.Default.emptyListMessage);
            else
            {
                foreach (var elem in value)
                    AddElement(elem);
            }
        }

        public AbacValue GetValue()
        {
            return new AbacValue();
        }

        private void AddElement(AbacValue value)
        {
            switch (value.Type)
            {
                case AbacValueType.Object:
                    HeaderStyle = ColumnHeaderStyle.Clickable;
                    var oItem = new ListViewItem();
                    foreach (var m in value.ObjectValue)
                    {
                        if (!Columns.ContainsKey(m.Key))
                            Columns.Add(m.Key, m.Key, -2);
                        oItem.SubItems.Add(m.Value.ToString());
                    }
                    Items.Add(oItem);
                    break;
                case AbacValueType.Array:
                    Items.Add(value.ArrayValue.ToString());
                    break;
                case AbacValueType.String:
                    Items.Add(value.StringValue);
                    break;
                case AbacValueType.Number:
                    Items.Add(value.NumberValue.ToString(CultureInfo.CurrentCulture));
                    break;
                case AbacValueType.Bool:
                    Items.Add(value.BoolValue.ToString());
                    break;
                default:
                    Items.Add(Properties.Settings.Default.nullValueMessage);
                    break;
            }
        }
    }
}
