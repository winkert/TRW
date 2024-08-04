namespace TRW.Apps.MapGenerator
{
    partial class ManageColorMapDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageColorMapDialog));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uxColorMapList = new System.Windows.Forms.ListView();
            this.grpColorMapDetails = new System.Windows.Forms.GroupBox();
            this.ColorMapDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.EditSaveButton = new System.Windows.Forms.Button();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateNewButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorPreviewColumn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpColorMapDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorMapDetailDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.uxColorMapList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpColorMapDetails);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // uxColorMapList
            // 
            this.uxColorMapList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxColorMapList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxColorMapList.FullRowSelect = true;
            this.uxColorMapList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.uxColorMapList.HideSelection = false;
            this.uxColorMapList.Location = new System.Drawing.Point(0, 28);
            this.uxColorMapList.MultiSelect = false;
            this.uxColorMapList.Name = "uxColorMapList";
            this.uxColorMapList.Size = new System.Drawing.Size(266, 422);
            this.uxColorMapList.TabIndex = 0;
            this.uxColorMapList.UseCompatibleStateImageBehavior = false;
            this.uxColorMapList.View = System.Windows.Forms.View.List;
            this.uxColorMapList.SelectedIndexChanged += new System.EventHandler(this.uxColorMapList_SelectedIndexChanged);
            // 
            // grpColorMapDetails
            // 
            this.grpColorMapDetails.Controls.Add(this.CancelEditButton);
            this.grpColorMapDetails.Controls.Add(this.EditSaveButton);
            this.grpColorMapDetails.Controls.Add(this.ColorMapDetailDataGridView);
            this.grpColorMapDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColorMapDetails.Location = new System.Drawing.Point(0, 0);
            this.grpColorMapDetails.Name = "grpColorMapDetails";
            this.grpColorMapDetails.Size = new System.Drawing.Size(530, 450);
            this.grpColorMapDetails.TabIndex = 0;
            this.grpColorMapDetails.TabStop = false;
            this.grpColorMapDetails.Text = "Color Map Details";
            // 
            // ColorMapDetailDataGridView
            // 
            this.ColorMapDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColorMapDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValueColumn,
            this.RColumn,
            this.GColumn,
            this.BColumn,
            this.ColorPreviewColumn});
            this.ColorMapDetailDataGridView.Location = new System.Drawing.Point(6, 65);
            this.ColorMapDetailDataGridView.Name = "ColorMapDetailDataGridView";
            this.ColorMapDetailDataGridView.Size = new System.Drawing.Size(512, 373);
            this.ColorMapDetailDataGridView.TabIndex = 0;
            this.ColorMapDetailDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ColorMapDetailDataGridView_CellContentClick);
            // 
            // EditSaveButton
            // 
            this.EditSaveButton.Location = new System.Drawing.Point(6, 19);
            this.EditSaveButton.Name = "EditSaveButton";
            this.EditSaveButton.Size = new System.Drawing.Size(75, 23);
            this.EditSaveButton.TabIndex = 1;
            this.EditSaveButton.Text = "Edit";
            this.EditSaveButton.UseVisualStyleBackColor = true;
            this.EditSaveButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.Location = new System.Drawing.Point(87, 19);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(75, 23);
            this.CancelEditButton.TabIndex = 1;
            this.CancelEditButton.Text = "Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = true;
            this.CancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewButton,
            this.DeleteButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(266, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CreateNewButton
            // 
            this.CreateNewButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateNewButton.Image")));
            this.CreateNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateNewButton.Name = "CreateNewButton";
            this.CreateNewButton.Size = new System.Drawing.Size(88, 22);
            this.CreateNewButton.Text = "Create New";
            this.CreateNewButton.Click += new System.EventHandler(this.CreateNewButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(60, 22);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValueColumn.Width = 50;
            // 
            // RColumn
            // 
            this.RColumn.HeaderText = "R";
            this.RColumn.Name = "RColumn";
            this.RColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RColumn.Width = 50;
            // 
            // GColumn
            // 
            this.GColumn.HeaderText = "G";
            this.GColumn.Name = "GColumn";
            this.GColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GColumn.Width = 50;
            // 
            // BColumn
            // 
            this.BColumn.HeaderText = "B";
            this.BColumn.Name = "BColumn";
            this.BColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BColumn.Width = 50;
            // 
            // ColorPreviewColumn
            // 
            this.ColorPreviewColumn.HeaderText = "";
            this.ColorPreviewColumn.Name = "ColorPreviewColumn";
            this.ColorPreviewColumn.ReadOnly = true;
            this.ColorPreviewColumn.Width = 50;
            // 
            // ManageColorMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ManageColorMapDialog";
            this.Text = "ManageColorMapDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageColorMapDialog_FormClosing);
            this.Load += new System.EventHandler(this.ManageColorMapDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpColorMapDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ColorMapDetailDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView uxColorMapList;
        private System.Windows.Forms.GroupBox grpColorMapDetails;
        private System.Windows.Forms.DataGridView ColorMapDetailDataGridView;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.Button EditSaveButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CreateNewButton;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BColumn;
        private System.Windows.Forms.DataGridViewImageColumn ColorPreviewColumn;
    }
}