using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Abac.Business;

namespace Abac.WinApplication
{
    public class MainForm : Form
    {
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

        public MainForm(AbacValue currentValue)
        {
            InitializeComponent();
            SuspendLayout();
            Controls.Add(InitializeControl(currentValue));
            ResumeLayout(false);
        }

        private static Control InitializeControl(AbacValue value)
        {
            switch (value.Type)
            {
                case AbacValueType.Object:
                    Panel pnl = new Panel
                    {
                        Dock = DockStyle.Fill,
                        AutoScroll = true
                    };
                    foreach (var key in CreateReverseIterator(value.ObjectValue.Keys))
                    {
                        var ctrlName = new Label
                        {
                            Text = key,
                            Dock = DockStyle.Left,
                            TextAlign = ContentAlignment.MiddleLeft
                        };
                        var ctrlMember = InitializeControl(value.ObjectValue[key]);
                        var pnlMember = new Panel
                        {
                            Dock = DockStyle.Top,
                            Height = ctrlMember.Height
                        };

                        pnlMember.Controls.Add(ctrlMember);
                        pnlMember.Controls.Add(ctrlName);
                        pnl.Controls.Add(pnlMember);
                    }
                    return pnl;
                case AbacValueType.Array:
                    var lst = new ListView
                    {
                        Dock = DockStyle.Fill,
                        View = View.Details
                    };
                    lst.Columns.Add("", "");
                    foreach (var elem in value.ArrayValue)
                        lst.Items.Add(InitializeItemControl(lst, elem));
                    return lst;
                case AbacValueType.String:
                    var txt = new TextBox
                    {
                        Dock = DockStyle.Fill,
                        Text = value.StringValue
                    };
                    return txt;
                case AbacValueType.Number:
                    var num = new NumericUpDown
                    {
                        Dock = DockStyle.Fill,
                        Value = Convert.ToDecimal(value.NumberValue)
                    };
                    return num;
                case AbacValueType.Bool:
                    var chk = new CheckBox
                    {
                        Dock = DockStyle.Fill,
                        Checked = value.BoolValue
                    };
                    return chk;
                default:
                    return new Label
                    {
                        Dock = DockStyle.Fill,
                        Text = "null"
                    };
            }
        }

        private static ListViewItem InitializeItemControl(ListView parent, AbacValue value)
        {
            switch (value.Type)
            {
                case AbacValueType.Object:
                    var oItem = new ListViewItem();
                    foreach (var m in value.ObjectValue)
                    {
                        if (!parent.Columns.ContainsKey(m.Key))
                            parent.Columns.Add(m.Key, m.Key);
                        oItem.SubItems.Add(m.Value.ToString());
                    }
                    return oItem;
                case AbacValueType.Array:
                    string aVal = value.ArrayValue.ToString();
                    return new ListViewItem(aVal);
                case AbacValueType.String:
                    string sVal = value.StringValue;
                    return new ListViewItem(sVal);
                case AbacValueType.Number:
                    string nVal = value.NumberValue.ToString(CultureInfo.CurrentCulture);
                    return new ListViewItem(nVal);
                case AbacValueType.Bool:
                    string bVal = value.BoolValue.ToString();
                    return new ListViewItem(bVal);
                default:
                    return new ListViewItem();
            }
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
        }

        #endregion
    }
}