using Abac.Business;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Abac.Application
{
    public partial class MainForm : Form
    {
        readonly List<Information> _data = new List<Information>();

        public MainForm(InformationType mainType)
        {
            InitializeComponent();
            lstMainList.ItemType = mainType;
        }

        private void lstMainList_AddItem()
        {
            Information newInfo = new Information(lstMainList.ItemType);
            newInfo.Value = 3;

            _data.Add(newInfo);
        }

        private void lstMainList_DeleteItem()
        {

        }
    }
}
