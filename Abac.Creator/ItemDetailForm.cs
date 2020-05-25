using Abac.Business;
using System.Windows.Forms;

namespace Abac.Creator
{
    public partial class ItemDetailForm : Form
    {
        readonly bool _hasType;

        public ItemDetailForm(bool hasType)
        {
            InitializeComponent();
            cmbType.DisplayMember = "Key";
            cmbType.ValueMember = "Value";

            _hasType = hasType;
            SetEnabled();
        }

        public InformationTypeDetail Detail { get; private set; }

        public bool EditMode { get; }

        void SetEnabled()
        {
            lblType.Visible = cmbType.Visible = _hasType;

            cmbType.Enabled = !string.IsNullOrEmpty(txtName.Text.Trim());
            btnOk.Enabled = cmbType.Enabled && (!_hasType || cmbType.SelectedItem != null);
        }

        private void ItemDetailForm_Load(object sender, System.EventArgs e)
        {
            cmbType.DataSource = new BindingSource(InformationTypes.Types, null);
        }

        private void TxtName_TextChanged(object sender, System.EventArgs e)
        {
            SetEnabled();
        }

        private void CmbType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetEnabled();
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            Detail = new InformationTypeDetail
            {
                Name = txtName.Text.Trim(),
                Type = _hasType ? cmbType.SelectedValue as InformationType : null
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
