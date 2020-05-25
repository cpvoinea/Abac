namespace Abac.Creator
{
    partial class MainFormOld
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormOld));
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.btnDeleteListItem = new System.Windows.Forms.Button();
            this.lstList = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddListItem = new System.Windows.Forms.Button();
            this.pnlListItem = new System.Windows.Forms.Panel();
            this.grpListItem = new System.Windows.Forms.GroupBox();
            this.grpItemDetails = new System.Windows.Forms.GroupBox();
            this.btnDeleteItemDetail = new System.Windows.Forms.Button();
            this.lstItemDetails = new System.Windows.Forms.ListView();
            this.chDetailName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDetailType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddItemDetail = new System.Windows.Forms.Button();
            this.chkItemIsOptions = new System.Windows.Forms.CheckBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.pnlActions.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.grpList.SuspendLayout();
            this.pnlListItem.SuspendLayout();
            this.grpListItem.SuspendLayout();
            this.grpItemDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlActions
            // 
            resources.ApplyResources(this.pnlActions, "pnlActions");
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.btnRun);
            this.pnlActions.Name = "pnlActions";
            // 
            // btnRun
            // 
            resources.ApplyResources(this.btnRun, "btnRun");
            this.btnRun.Name = "btnRun";
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Controls.Add(this.pnlList);
            this.pnlMain.Controls.Add(this.pnlListItem);
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlList
            // 
            resources.ApplyResources(this.pnlList, "pnlList");
            this.pnlList.Controls.Add(this.grpList);
            this.pnlList.Name = "pnlList";
            // 
            // grpList
            // 
            resources.ApplyResources(this.grpList, "grpList");
            this.grpList.Controls.Add(this.btnDeleteListItem);
            this.grpList.Controls.Add(this.lstList);
            this.grpList.Controls.Add(this.btnAddListItem);
            this.grpList.Name = "grpList";
            this.grpList.TabStop = false;
            // 
            // btnDeleteListItem
            // 
            resources.ApplyResources(this.btnDeleteListItem, "btnDeleteListItem");
            this.btnDeleteListItem.Name = "btnDeleteListItem";
            this.btnDeleteListItem.Click += new System.EventHandler(this.BtnDeleteListItem_Click);
            // 
            // lstList
            // 
            resources.ApplyResources(this.lstList, "lstList");
            this.lstList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chDetails});
            this.lstList.FullRowSelect = true;
            this.lstList.GridLines = true;
            this.lstList.HideSelection = false;
            this.lstList.MultiSelect = false;
            this.lstList.Name = "lstList";
            this.lstList.UseCompatibleStateImageBehavior = false;
            this.lstList.View = System.Windows.Forms.View.Details;
            this.lstList.SelectedIndexChanged += new System.EventHandler(this.LstList_SelectedIndexChanged);
            // 
            // chName
            // 
            resources.ApplyResources(this.chName, "chName");
            // 
            // chDetails
            // 
            resources.ApplyResources(this.chDetails, "chDetails");
            // 
            // btnAddListItem
            // 
            resources.ApplyResources(this.btnAddListItem, "btnAddListItem");
            this.btnAddListItem.Name = "btnAddListItem";
            this.btnAddListItem.Click += new System.EventHandler(this.BtnAddListItem_Click);
            // 
            // pnlListItem
            // 
            resources.ApplyResources(this.pnlListItem, "pnlListItem");
            this.pnlListItem.Controls.Add(this.grpListItem);
            this.pnlListItem.Name = "pnlListItem";
            // 
            // grpListItem
            // 
            resources.ApplyResources(this.grpListItem, "grpListItem");
            this.grpListItem.Controls.Add(this.grpItemDetails);
            this.grpListItem.Controls.Add(this.chkItemIsOptions);
            this.grpListItem.Controls.Add(this.lblItemName);
            this.grpListItem.Controls.Add(this.txtItemName);
            this.grpListItem.Name = "grpListItem";
            this.grpListItem.TabStop = false;
            // 
            // grpItemDetails
            // 
            resources.ApplyResources(this.grpItemDetails, "grpItemDetails");
            this.grpItemDetails.Controls.Add(this.btnDeleteItemDetail);
            this.grpItemDetails.Controls.Add(this.lstItemDetails);
            this.grpItemDetails.Controls.Add(this.btnAddItemDetail);
            this.grpItemDetails.Name = "grpItemDetails";
            this.grpItemDetails.TabStop = false;
            // 
            // btnDeleteItemDetail
            // 
            resources.ApplyResources(this.btnDeleteItemDetail, "btnDeleteItemDetail");
            this.btnDeleteItemDetail.Name = "btnDeleteItemDetail";
            this.btnDeleteItemDetail.Click += new System.EventHandler(this.BtnDeleteItemDetail_Click);
            // 
            // lstItemDetails
            // 
            resources.ApplyResources(this.lstItemDetails, "lstItemDetails");
            this.lstItemDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDetailName,
            this.chDetailType});
            this.lstItemDetails.FullRowSelect = true;
            this.lstItemDetails.GridLines = true;
            this.lstItemDetails.HideSelection = false;
            this.lstItemDetails.Name = "lstItemDetails";
            this.lstItemDetails.UseCompatibleStateImageBehavior = false;
            this.lstItemDetails.View = System.Windows.Forms.View.Details;
            this.lstItemDetails.SelectedIndexChanged += new System.EventHandler(this.LstItemDetails_SelectedIndexChanged);
            // 
            // chDetailName
            // 
            resources.ApplyResources(this.chDetailName, "chDetailName");
            // 
            // chDetailType
            // 
            resources.ApplyResources(this.chDetailType, "chDetailType");
            // 
            // btnAddItemDetail
            // 
            resources.ApplyResources(this.btnAddItemDetail, "btnAddItemDetail");
            this.btnAddItemDetail.Name = "btnAddItemDetail";
            this.btnAddItemDetail.Click += new System.EventHandler(this.BtnAddItemDetail_Click);
            // 
            // chkItemIsOptions
            // 
            resources.ApplyResources(this.chkItemIsOptions, "chkItemIsOptions");
            this.chkItemIsOptions.Name = "chkItemIsOptions";
            this.chkItemIsOptions.CheckedChanged += new System.EventHandler(this.ChkItemIsOptions_CheckedChanged);
            // 
            // lblItemName
            // 
            resources.ApplyResources(this.lblItemName, "lblItemName");
            this.lblItemName.Name = "lblItemName";
            // 
            // txtItemName
            // 
            resources.ApplyResources(this.txtItemName, "txtItemName");
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.TextChanged += new System.EventHandler(this.TxtItemName_TextChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnRun;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlActions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlActions.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlList.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            this.pnlListItem.ResumeLayout(false);
            this.grpListItem.ResumeLayout(false);
            this.grpListItem.PerformLayout();
            this.grpItemDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlListItem;
        private System.Windows.Forms.GroupBox grpListItem;
        private System.Windows.Forms.GroupBox grpItemDetails;
        private System.Windows.Forms.ListView lstItemDetails;
        private System.Windows.Forms.Button btnAddItemDetail;
        private System.Windows.Forms.CheckBox chkItemIsOptions;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.ColumnHeader chDetailName;
        private System.Windows.Forms.ColumnHeader chDetailType;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.Button btnDeleteListItem;
        private System.Windows.Forms.ListView lstList;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDetails;
        private System.Windows.Forms.Button btnAddListItem;
        private System.Windows.Forms.Button btnDeleteItemDetail;
    }
}

