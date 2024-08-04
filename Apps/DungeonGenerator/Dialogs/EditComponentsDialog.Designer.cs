namespace DungeonGenerator.Dialogs
{
    partial class EditComponentsDialog<ComponentType, P>
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
            this.uxComponentListPanel = new System.Windows.Forms.Panel();
            this.uxComponentListToolStrip = new System.Windows.Forms.ToolStrip();
            this.uxAddComponentButton = new System.Windows.Forms.ToolStripButton();
            this.uxEditComponentButton = new System.Windows.Forms.ToolStripButton();
            this.uxDeleteComponentButton = new System.Windows.Forms.ToolStripButton();
            this.uxCloseButton = new System.Windows.Forms.ToolStripButton();
            this.uxComponentDetailsHost = new System.Windows.Forms.Panel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxComponentListView = new System.Windows.Forms.DataGridView();
            this.ItemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxComponentListPanel.SuspendLayout();
            this.uxComponentListToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxComponentListView)).BeginInit();
            this.SuspendLayout();
            // 
            // uxComponentListPanel
            // 
            this.uxComponentListPanel.Controls.Add(this.uxComponentListView);
            this.uxComponentListPanel.Controls.Add(this.uxComponentListToolStrip);
            this.uxComponentListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.uxComponentListPanel.Location = new System.Drawing.Point(0, 0);
            this.uxComponentListPanel.Name = "uxComponentListPanel";
            this.uxComponentListPanel.Size = new System.Drawing.Size(235, 476);
            this.uxComponentListPanel.TabIndex = 0;
            // 
            // uxComponentListToolStrip
            // 
            this.uxComponentListToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxAddComponentButton,
            this.uxEditComponentButton,
            this.uxDeleteComponentButton,
            this.uxCloseButton});
            this.uxComponentListToolStrip.Location = new System.Drawing.Point(0, 0);
            this.uxComponentListToolStrip.Name = "uxComponentListToolStrip";
            this.uxComponentListToolStrip.Size = new System.Drawing.Size(235, 25);
            this.uxComponentListToolStrip.TabIndex = 0;
            this.uxComponentListToolStrip.Text = "toolStrip1";
            // 
            // uxAddComponentButton
            // 
            this.uxAddComponentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uxAddComponentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxAddComponentButton.Name = "uxAddComponentButton";
            this.uxAddComponentButton.Size = new System.Drawing.Size(23, 22);
            this.uxAddComponentButton.Text = "uxAddComponentButton";
            this.uxAddComponentButton.ToolTipText = "Add new";
            this.uxAddComponentButton.Click += new System.EventHandler(this.uxAddComponentButton_Click);
            // 
            // uxEditComponentButton
            // 
            this.uxEditComponentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uxEditComponentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxEditComponentButton.Name = "uxEditComponentButton";
            this.uxEditComponentButton.Size = new System.Drawing.Size(23, 22);
            this.uxEditComponentButton.Text = "uxEditComponentButton";
            this.uxEditComponentButton.ToolTipText = "Edit";
            this.uxEditComponentButton.Click += new System.EventHandler(this.uxEditComponentButton_Click);
            // 
            // uxDeleteComponentButton
            // 
            this.uxDeleteComponentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uxDeleteComponentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxDeleteComponentButton.Name = "uxDeleteComponentButton";
            this.uxDeleteComponentButton.Size = new System.Drawing.Size(23, 22);
            this.uxDeleteComponentButton.Text = "uxDeleteComponentButton";
            this.uxDeleteComponentButton.ToolTipText = "Delete";
            this.uxDeleteComponentButton.Click += new System.EventHandler(this.uxDeleteComponentButton_Click);
            // 
            // uxCloseButton
            // 
            this.uxCloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxCloseButton.Name = "uxCloseButton";
            this.uxCloseButton.Size = new System.Drawing.Size(40, 22);
            this.uxCloseButton.Text = "Close";
            this.uxCloseButton.Click += new System.EventHandler(this.uxCloseButton_Click);
            // 
            // uxComponentDetailsHost
            // 
            this.uxComponentDetailsHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxComponentDetailsHost.Location = new System.Drawing.Point(235, 0);
            this.uxComponentDetailsHost.Name = "uxComponentDetailsHost";
            this.uxComponentDetailsHost.Size = new System.Drawing.Size(597, 476);
            this.uxComponentDetailsHost.TabIndex = 1;
            // 
            // uxComponentListView
            // 
            this.uxComponentListView.AllowUserToAddRows = false;
            this.uxComponentListView.AllowUserToDeleteRows = false;
            this.uxComponentListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxComponentListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNameColumn});
            this.uxComponentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxComponentListView.Location = new System.Drawing.Point(0, 25);
            this.uxComponentListView.MultiSelect = false;
            this.uxComponentListView.Name = "uxComponentListView";
            this.uxComponentListView.ReadOnly = true;
            this.uxComponentListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uxComponentListView.Size = new System.Drawing.Size(235, 451);
            this.uxComponentListView.TabIndex = 0;
            this.uxComponentListView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.uxComponentListView_RowEnter);
            // 
            // ItemNameColumn
            // 
            this.ItemNameColumn.HeaderText = "Item";
            this.ItemNameColumn.Name = "ItemNameColumn";
            this.ItemNameColumn.ReadOnly = true;
            this.ItemNameColumn.Width = 175;
            // 
            // EditComponentsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 476);
            this.ControlBox = false;
            this.Controls.Add(this.uxComponentDetailsHost);
            this.Controls.Add(this.uxComponentListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditComponentsDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "EditComponentsDialog";
            this.Load += new System.EventHandler(this.EditComponentsDialog_Load);
            this.uxComponentListPanel.ResumeLayout(false);
            this.uxComponentListPanel.PerformLayout();
            this.uxComponentListToolStrip.ResumeLayout(false);
            this.uxComponentListToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxComponentListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uxComponentListPanel;
        private System.Windows.Forms.ToolStrip uxComponentListToolStrip;
        private System.Windows.Forms.Panel uxComponentDetailsHost;
        private System.Windows.Forms.ToolStripButton uxAddComponentButton;
        private System.Windows.Forms.ToolStripButton uxDeleteComponentButton;
        private System.Windows.Forms.ToolStripButton uxCloseButton;
        private System.Windows.Forms.ToolStripButton uxEditComponentButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.DataGridView uxComponentListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNameColumn;
    }
}