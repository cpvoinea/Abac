using Abac.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Abac.Application
{
    partial class InformationTypeDetailControl : UserControl
    {
        BaseType _baseType;

        internal InformationTypeDetailControl()
        {
            InitializeComponent();
            cOptions.DisplayMember = "Name";
            cOptions.ValueMember = "Name";
        }

        public string InformationName { get { return lblName.Text; } set { lblName.Text = value; } }

        public BaseType InformationType
        {
            get { return _baseType; }
            set
            {
                _baseType = value;

                cText.Visible = _baseType == BaseType.Text;
                cReal.Visible = _baseType == BaseType.Real;
                cInteger.Visible = _baseType == BaseType.Integer;
                cDate.Visible = _baseType == BaseType.Date;
                cOptions.Visible = _baseType == BaseType.Options;
            }
        }

        public object InformationValue
        {
            get
            {
                switch (_baseType)
                {
                    case BaseType.Text: return cText.Text;
                    case BaseType.Real: return float.Parse(cReal.Text);
                    case BaseType.Integer: return (int)cInteger.Value;
                    case BaseType.Date: return cDate.Value.Date;
                    case BaseType.Options: return cOptions.SelectedValue;
                    default: return string.Empty;
                }
            }
            set
            {
                switch (_baseType)
                {
                    case BaseType.Text: cText.Text = (string)value; break;
                    case BaseType.Real: cReal.Text = value.ToString(); break;
                    case BaseType.Integer: cInteger.Value = (int)value; break;
                    case BaseType.Date: cDate.Value = (DateTime)value; break;
                    case BaseType.Options: cOptions.SelectedValue = value; break;
                }
            }
        }

        public List<InformationTypeDetail> InformationOptions
        {
            set
            {
                cOptions.DataSource = new BindingSource(value, null);
            }
        }
    }
}
