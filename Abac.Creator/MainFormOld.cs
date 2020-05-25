using Abac.Business;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Abac.Creator
{
    public partial class MainFormOld : Form
    {
        public MainFormOld()
        {
            InitializeComponent();
        }

        #region Methods

        static ListViewItem CreateListViewItem(object newValue, string name, string description)
        {
            var item = new ListViewItem(new[] { name, description })
            {
                Tag = newValue
            };
            return item;
        }

        void SetEnabled()
        {
            bool canEditItemDetails = ValidateListItemName();
            bool canDeleteItemDetails = canEditItemDetails && lstItemDetails.SelectedItems.Count >= 1;
            bool canAddListItem = canEditItemDetails && lstItemDetails.Items.Count > 0;
            bool canDeleteListItem = lstList.SelectedItems.Count == 1 && CanDeleteInformationType(lstList.SelectedItems[0].Tag);
            bool canRun = canDeleteListItem && !(lstList.SelectedItems[0].Tag as InformationType).IsBaseType;

            grpItemDetails.Enabled = chkItemIsOptions.Enabled = canEditItemDetails;
            btnDeleteItemDetail.Enabled = canDeleteItemDetails;
            btnAddListItem.Enabled = canAddListItem;
            btnDeleteListItem.Enabled = canDeleteListItem;
            btnRun.Enabled = canRun;
        }

        bool CanDeleteInformationType(object type)
        {
            if (type == null)
                return false;
            if (!(type is InformationType))
                return false;
            return true;
        }

        bool ValidateListItemName()
        {
            string name = txtItemName.Text.Trim();
            if (string.IsNullOrEmpty(name))
                return false;
            return !InformationTypes.Types.ContainsKey(name);
        }

        void RefactorExistingItemDetails(bool hasType)
        {
            foreach (ListViewItem i in lstItemDetails.Items)
            {
                var detail = i.Tag as InformationTypeDetail;
                detail.Type = hasType ? InformationTypes.Types["Text"] : null;
                i.SubItems[1].Text = hasType ? detail.Type.Name : string.Empty;
            }
        }

        void ResetExistingItem()
        {
            foreach (ListViewItem i in lstItemDetails.Items)
            {
                i.Tag = null;
                i.Remove();
            }
            chkItemIsOptions.Checked = false;
            txtItemName.Text = string.Empty;
        }

        #endregion

        #region Events

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            foreach (var type in InformationTypes.Types)
            {
                lstList.Items.Add(new ListViewItem(new[] { type.Key, type.Value.GetDetailsString() }));
            }
            SetEnabled();
        }

        private void TxtItemName_TextChanged(object sender, System.EventArgs e)
        {
            SetEnabled();
        }

        private void ChkItemIsOptions_CheckedChanged(object sender, System.EventArgs e)
        {
            RefactorExistingItemDetails(!chkItemIsOptions.Checked);
        }

        #region ItemDetails

        private void LstItemDetails_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetEnabled();
        }

        private void BtnAddItemDetail_Click(object sender, System.EventArgs e)
        {
            bool hasType = !chkItemIsOptions.Checked;
            var frm = new ItemDetailForm(hasType);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                var d = frm.Detail;
                bool found = false;
                foreach (ListViewItem i in lstItemDetails.Items)
                    if (i.Text.Equals(d.Name))
                    {
                        if (d.Type != null)
                            i.SubItems[1].Text = d.Type.Name;
                        i.Tag = d;
                        found = true;
                        break;
                    }
                if (!found)
                    lstItemDetails.Items.Add(CreateListViewItem(d, d.Name, hasType ? d.Type.Name : string.Empty));
            }

            SetEnabled();
        }

        private void BtnDeleteItemDetail_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Delete details?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                foreach (ListViewItem i in lstItemDetails.SelectedItems)
                {
                    i.Tag = null;
                    i.Remove();
                }
            SetEnabled();
        }

        #endregion

        #region ListItems

        private void LstList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetEnabled();
        }

        private void BtnAddListItem_Click(object sender, System.EventArgs e)
        {
            var item = new InformationType
            {
                Name = txtItemName.Text.Trim(),
                BaseType = chkItemIsOptions.Checked ? BaseType.Options : (BaseType?)null,
                Details = new List<InformationTypeDetail>()
            };
            foreach (ListViewItem i in lstItemDetails.Items)
                item.Details.Add(i.Tag as InformationTypeDetail);

            lstList.Items.Insert(0, CreateListViewItem(item, item.Name, item.GetDetailsString())).Selected = true;
            InformationTypes.Types.Add(item.Name, item);
            ResetExistingItem();
            SetEnabled();
        }

        private void BtnDeleteListItem_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Delete type?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                foreach (ListViewItem i in lstList.SelectedItems)
                {
                    var t = i.Tag as InformationType;
                    InformationTypes.Types.Remove(t.Name);

                    i.Tag = null;
                    i.Remove();
                }
            SetEnabled();
        }

        #endregion

        private void BtnRun_Click(object sender, System.EventArgs e)
        {
            new Application.MainForm(lstList.SelectedItems[0].Tag as InformationType).ShowDialog(this);
        }

        #endregion
    }
}
