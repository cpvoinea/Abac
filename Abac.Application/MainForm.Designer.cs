namespace Abac.Application
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstMainList = new Abac.Application.ListControl();
            this.SuspendLayout();
            // 
            // lstMainList
            // 
            resources.ApplyResources(this.lstMainList, "lstMainList");
            this.lstMainList.ItemType = null;
            this.lstMainList.Name = "lstMainList";
            this.lstMainList.AddItem += new Abac.Application.AddItemHandler(this.lstMainList_AddItem);
            this.lstMainList.DeleteItem += new Abac.Application.DeleteItemHandler(this.lstMainList_DeleteItem);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstMainList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListControl lstMainList;
    }
}