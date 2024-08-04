namespace TRW.Apps.NPCGenerator
{
    partial class ViewEditNameDataSets
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importNewFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.NameDataSetListView = new System.Windows.Forms.ListBox();
            this.NameDataSetDetailsTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MaleNamesGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrequencyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FemaleNamesGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SurnameGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.NameDataSetDetailsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaleNamesGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FemaleNamesGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SurnameGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.importToolStripMenuItem,
            this.addNewToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "Save";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importNewFromFileToolStripMenuItem,
            this.appendFromFileToolStripMenuItem,
            this.appendFromClipboardToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // importNewFromFileToolStripMenuItem
            // 
            this.importNewFromFileToolStripMenuItem.Name = "importNewFromFileToolStripMenuItem";
            this.importNewFromFileToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.importNewFromFileToolStripMenuItem.Text = "Import New From File";
            this.importNewFromFileToolStripMenuItem.Click += new System.EventHandler(this.ImportNewFromFileToolStripMenuItem_Click);
            // 
            // appendFromFileToolStripMenuItem
            // 
            this.appendFromFileToolStripMenuItem.Name = "appendFromFileToolStripMenuItem";
            this.appendFromFileToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.appendFromFileToolStripMenuItem.Text = "Append from File";
            this.appendFromFileToolStripMenuItem.Click += new System.EventHandler(this.AppendFromFileToolStripMenuItem_Click);
            // 
            // appendFromClipboardToolStripMenuItem
            // 
            this.appendFromClipboardToolStripMenuItem.Name = "appendFromClipboardToolStripMenuItem";
            this.appendFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.appendFromClipboardToolStripMenuItem.Text = "Append from Clipboard";
            this.appendFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.AppendFromClipboardToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.addNewToolStripMenuItem.Text = "Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.AddNewToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NameDataSetListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.NameDataSetDetailsTab);
            this.splitContainer1.Size = new System.Drawing.Size(715, 446);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // NameDataSetListView
            // 
            this.NameDataSetListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameDataSetListView.FormattingEnabled = true;
            this.NameDataSetListView.ItemHeight = 15;
            this.NameDataSetListView.Location = new System.Drawing.Point(0, 0);
            this.NameDataSetListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NameDataSetListView.Name = "NameDataSetListView";
            this.NameDataSetListView.Size = new System.Drawing.Size(260, 446);
            this.NameDataSetListView.TabIndex = 0;
            this.NameDataSetListView.SelectedIndexChanged += new System.EventHandler(this.NameDataSetListView_SelectedIndexChanged);
            // 
            // NameDataSetDetailsTab
            // 
            this.NameDataSetDetailsTab.Controls.Add(this.tabPage1);
            this.NameDataSetDetailsTab.Controls.Add(this.tabPage2);
            this.NameDataSetDetailsTab.Controls.Add(this.tabPage3);
            this.NameDataSetDetailsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameDataSetDetailsTab.Location = new System.Drawing.Point(0, 0);
            this.NameDataSetDetailsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NameDataSetDetailsTab.Name = "NameDataSetDetailsTab";
            this.NameDataSetDetailsTab.SelectedIndex = 0;
            this.NameDataSetDetailsTab.Size = new System.Drawing.Size(450, 446);
            this.NameDataSetDetailsTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MaleNamesGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(442, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Male Names";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MaleNamesGridView
            // 
            this.MaleNamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaleNamesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.FrequencyColumn});
            this.MaleNamesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaleNamesGridView.Location = new System.Drawing.Point(4, 3);
            this.MaleNamesGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaleNamesGridView.Name = "MaleNamesGridView";
            this.MaleNamesGridView.Size = new System.Drawing.Size(434, 412);
            this.MaleNamesGridView.TabIndex = 1;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            // 
            // FrequencyColumn
            // 
            this.FrequencyColumn.HeaderText = "Frequency";
            this.FrequencyColumn.Name = "FrequencyColumn";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FemaleNamesGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(442, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Female Names";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FemaleNamesGridView
            // 
            this.FemaleNamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FemaleNamesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.FemaleNamesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FemaleNamesGridView.Location = new System.Drawing.Point(4, 3);
            this.FemaleNamesGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FemaleNamesGridView.Name = "FemaleNamesGridView";
            this.FemaleNamesGridView.Size = new System.Drawing.Size(434, 412);
            this.FemaleNamesGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Frequency";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.SurnameGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Size = new System.Drawing.Size(442, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Surnames";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SurnameGridView
            // 
            this.SurnameGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SurnameGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.SurnameGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SurnameGridView.Location = new System.Drawing.Point(4, 3);
            this.SurnameGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SurnameGridView.Name = "SurnameGridView";
            this.SurnameGridView.Size = new System.Drawing.Size(434, 412);
            this.SurnameGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Frequency";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // ViewEditNameDataSets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 470);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ViewEditNameDataSets";
            this.Text = "ViewEditNameDataSets";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.NameDataSetDetailsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaleNamesGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FemaleNamesGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SurnameGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox NameDataSetListView;
        private System.Windows.Forms.TabControl NameDataSetDetailsTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView MaleNamesGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView FemaleNamesGridView;
        private System.Windows.Forms.DataGridView SurnameGridView;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importNewFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrequencyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}