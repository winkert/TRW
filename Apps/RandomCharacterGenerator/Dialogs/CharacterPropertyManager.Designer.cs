namespace TRW.Apps.RandomCharacterGenerator
{
    partial class CharacterPropertyManager<PropertyV>
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
            this.ManagerSplitter = new System.Windows.Forms.SplitContainer();
            this.PropertyListBox = new System.Windows.Forms.ListBox();
            this.PropertyListToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddPropertyButton = new System.Windows.Forms.ToolStripButton();
            this.DeletePropertyButton = new System.Windows.Forms.ToolStripButton();
            this.EditPropertyButton = new System.Windows.Forms.ToolStripButton();
            this.CancelEditPropertyButton = new System.Windows.Forms.ToolStripButton();
            this.SavePropertyButton = new System.Windows.Forms.ToolStripButton();
            this.CopyPropertyButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CategoryFilterDropDownMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.label1 = new System.Windows.Forms.Label();
            this.PropertyCategoryTextBox = new System.Windows.Forms.TextBox();
            this.PropertyManagerContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerSplitter)).BeginInit();
            this.ManagerSplitter.Panel1.SuspendLayout();
            this.ManagerSplitter.Panel2.SuspendLayout();
            this.ManagerSplitter.SuspendLayout();
            this.PropertyListToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManagerSplitter
            // 
            this.ManagerSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManagerSplitter.Location = new System.Drawing.Point(0, 0);
            this.ManagerSplitter.Name = "ManagerSplitter";
            // 
            // ManagerSplitter.Panel1
            // 
            this.ManagerSplitter.Panel1.Controls.Add(this.PropertyListBox);
            this.ManagerSplitter.Panel1.Controls.Add(this.PropertyListToolStrip);
            // 
            // ManagerSplitter.Panel2
            // 
            this.ManagerSplitter.Panel2.Controls.Add(this.label1);
            this.ManagerSplitter.Panel2.Controls.Add(this.PropertyCategoryTextBox);
            this.ManagerSplitter.Panel2.Controls.Add(this.PropertyManagerContainer);
            this.ManagerSplitter.Size = new System.Drawing.Size(1046, 512);
            this.ManagerSplitter.SplitterDistance = 269;
            this.ManagerSplitter.TabIndex = 0;
            // 
            // PropertyListBox
            // 
            this.PropertyListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyListBox.FormattingEnabled = true;
            this.PropertyListBox.Location = new System.Drawing.Point(3, 28);
            this.PropertyListBox.Name = "PropertyListBox";
            this.PropertyListBox.Size = new System.Drawing.Size(266, 485);
            this.PropertyListBox.TabIndex = 1;
            this.PropertyListBox.SelectedIndexChanged += new System.EventHandler(this.PropertyListBox_SelectedIndexChanged);
            // 
            // PropertyListToolStrip
            // 
            this.PropertyListToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PropertyListToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPropertyButton,
            this.DeletePropertyButton,
            this.EditPropertyButton,
            this.CancelEditPropertyButton,
            this.SavePropertyButton,
            this.CopyPropertyButton,
            this.toolStripSeparator1,
            this.CategoryFilterDropDownMenu});
            this.PropertyListToolStrip.Location = new System.Drawing.Point(0, 0);
            this.PropertyListToolStrip.Name = "PropertyListToolStrip";
            this.PropertyListToolStrip.Size = new System.Drawing.Size(269, 26);
            this.PropertyListToolStrip.TabIndex = 0;
            // 
            // AddPropertyButton
            // 
            this.AddPropertyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddPropertyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.AddButtonImage;
            this.AddPropertyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPropertyButton.Name = "AddPropertyButton";
            this.AddPropertyButton.Size = new System.Drawing.Size(23, 23);
            this.AddPropertyButton.ToolTipText = "Add New";
            this.AddPropertyButton.Click += new System.EventHandler(this.AddPropertyButton_Click);
            // 
            // DeletePropertyButton
            // 
            this.DeletePropertyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeletePropertyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.DeleteButtonImage;
            this.DeletePropertyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletePropertyButton.Name = "DeletePropertyButton";
            this.DeletePropertyButton.Size = new System.Drawing.Size(23, 23);
            this.DeletePropertyButton.ToolTipText = "Delete";
            this.DeletePropertyButton.Click += new System.EventHandler(this.DeletePropertyButton_Click);
            // 
            // EditPropertyButton
            // 
            this.EditPropertyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditPropertyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.EditButtonImage;
            this.EditPropertyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditPropertyButton.Name = "EditPropertyButton";
            this.EditPropertyButton.Size = new System.Drawing.Size(23, 23);
            this.EditPropertyButton.ToolTipText = "Edit";
            this.EditPropertyButton.Click += new System.EventHandler(this.EditPropertyButton_Click);
            // 
            // CancelEditPropertyButton
            // 
            this.CancelEditPropertyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelEditPropertyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.CancelButtonImage;
            this.CancelEditPropertyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelEditPropertyButton.Name = "CancelEditPropertyButton";
            this.CancelEditPropertyButton.Size = new System.Drawing.Size(23, 23);
            this.CancelEditPropertyButton.ToolTipText = "Cancel";
            this.CancelEditPropertyButton.Click += new System.EventHandler(this.CancelEditPropertyButton_Click);
            // 
            // SavePropertyButton
            // 
            this.SavePropertyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SavePropertyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.SaveButtonImage;
            this.SavePropertyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SavePropertyButton.Name = "SavePropertyButton";
            this.SavePropertyButton.Size = new System.Drawing.Size(23, 23);
            this.SavePropertyButton.ToolTipText = "Save";
            this.SavePropertyButton.Click += new System.EventHandler(this.SavePropertyButton_Click);
            // 
            // CopyPropertyButton
            // 
            this.CopyPropertyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyPropertyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.CopyButtonImage;
            this.CopyPropertyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyPropertyButton.Name = "CopyPropertyButton";
            this.CopyPropertyButton.Size = new System.Drawing.Size(23, 23);
            this.CopyPropertyButton.Text = "Copy Property";
            this.CopyPropertyButton.Click += new System.EventHandler(this.CopyPropertyButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // CategoryFilterDropDownMenu
            // 
            this.CategoryFilterDropDownMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CategoryFilterDropDownMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CategoryFilterDropDownMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CategoryFilterDropDownMenu.Name = "CategoryFilterDropDownMenu";
            this.CategoryFilterDropDownMenu.Size = new System.Drawing.Size(112, 23);
            this.CategoryFilterDropDownMenu.Text = "Category Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category:";
            // 
            // PropertyCategoryTextBox
            // 
            this.PropertyCategoryTextBox.Location = new System.Drawing.Point(89, 5);
            this.PropertyCategoryTextBox.Name = "PropertyCategoryTextBox";
            this.PropertyCategoryTextBox.Size = new System.Drawing.Size(146, 20);
            this.PropertyCategoryTextBox.TabIndex = 1;
            // 
            // PropertyManagerContainer
            // 
            this.PropertyManagerContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyManagerContainer.Location = new System.Drawing.Point(3, 28);
            this.PropertyManagerContainer.Name = "PropertyManagerContainer";
            this.PropertyManagerContainer.Size = new System.Drawing.Size(767, 481);
            this.PropertyManagerContainer.TabIndex = 0;
            // 
            // CharacterPropertyManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 512);
            this.Controls.Add(this.ManagerSplitter);
            this.Name = "CharacterPropertyManager";
            this.Text = "CharacterPropertyManager";
            this.ManagerSplitter.Panel1.ResumeLayout(false);
            this.ManagerSplitter.Panel1.PerformLayout();
            this.ManagerSplitter.Panel2.ResumeLayout(false);
            this.ManagerSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerSplitter)).EndInit();
            this.ManagerSplitter.ResumeLayout(false);
            this.PropertyListToolStrip.ResumeLayout(false);
            this.PropertyListToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ManagerSplitter;
        private System.Windows.Forms.ListBox PropertyListBox;
        private System.Windows.Forms.ToolStrip PropertyListToolStrip;
        private System.Windows.Forms.ToolStripButton AddPropertyButton;
        private System.Windows.Forms.ToolStripButton EditPropertyButton;
        private System.Windows.Forms.ToolStripButton DeletePropertyButton;
        private System.Windows.Forms.ToolStripButton SavePropertyButton;
        private System.Windows.Forms.ToolStripButton CancelEditPropertyButton;
        private System.Windows.Forms.Panel PropertyManagerContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PropertyCategoryTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton CategoryFilterDropDownMenu;
        private System.Windows.Forms.ToolStripButton CopyPropertyButton;
    }
}