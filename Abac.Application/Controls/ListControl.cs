using Abac.Business;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Abac.Application
{
    internal delegate void AddItemHandler();
    internal delegate void DeleteItemHandler();

    partial class ListControl : UserControl
    {
        readonly string strTitle;
        readonly string strAdd;
        readonly string strDelete;

        InformationType _itemType;
        public event AddItemHandler AddItem;
        public event DeleteItemHandler DeleteItem;

        public ListControl()
        {
            InitializeComponent();

            strTitle = grpList.Text;
            strAdd = btnAddItem.Text;
            strDelete = btnDeleteItem.Text;
        }

        public InformationType ItemType
        {
            get { return _itemType; }
            set
            {
                _itemType = value;

                if (_itemType != null)
                {
                    SetItemName(grpList, _itemType.Name, strTitle);
                    SetItemName(btnAddItem, _itemType.Name, strAdd);
                    SetItemName(btnDeleteItem, _itemType.Name, strDelete);

                    foreach (var d in _itemType.Details)
                        lstList.Columns.Add(d.Name).Tag = d;
                }
            }
        }

        void OnAddItem()
        {
            if (AddItem != null)
                AddItem();
        }

        void OnDeleteItem()
        {
            if (DeleteItem != null)
                DeleteItem();
        }

        static void SetItemName(Control control, string name, string prefix = "")
        {
            control.Text = string.Format("{0}{1}", prefix, name);
        }

        private void btnAddItem_Click(object sender, System.EventArgs e)
        {
            OnAddItem();
        }

        private void btnDeleteItem_Click(object sender, System.EventArgs e)
        {
            OnDeleteItem();
        }

        private void lstList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            btnDeleteItem.Enabled = lstList.SelectedItems.Count == 1;
        }
    }
}
