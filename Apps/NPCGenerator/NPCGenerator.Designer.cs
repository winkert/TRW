namespace TRW.Apps.NPCGenerator
{
    partial class NPCGenerator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NameDataSetsCombo = new System.Windows.Forms.ComboBox();
            this.ViewEditNameDataSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GenerateNameButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AttributeDataGridView = new System.Windows.Forms.DataGridView();
            this.StatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenerateStatsButton = new System.Windows.Forms.Button();
            this.GenerateNpcButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttributeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NameDataSetsCombo);
            this.groupBox1.Controls.Add(this.ViewEditNameDataSet);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.GenerateNameButton);
            this.groupBox1.Controls.Add(this.NameTextBox);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name Generator";
            // 
            // NameDataSetsCombo
            // 
            this.NameDataSetsCombo.FormattingEnabled = true;
            this.NameDataSetsCombo.Location = new System.Drawing.Point(202, 39);
            this.NameDataSetsCombo.Name = "NameDataSetsCombo";
            this.NameDataSetsCombo.Size = new System.Drawing.Size(140, 21);
            this.NameDataSetsCombo.TabIndex = 8;
            // 
            // ViewEditNameDataSet
            // 
            this.ViewEditNameDataSet.Location = new System.Drawing.Point(348, 37);
            this.ViewEditNameDataSet.Name = "ViewEditNameDataSet";
            this.ViewEditNameDataSet.Size = new System.Drawing.Size(75, 23);
            this.ViewEditNameDataSet.TabIndex = 7;
            this.ViewEditNameDataSet.Text = "View/Edit";
            this.ViewEditNameDataSet.UseVisualStyleBackColor = true;
            this.ViewEditNameDataSet.Click += new System.EventHandler(this.ViewEditNameDataSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name Data Set";
            // 
            // GenerateNameButton
            // 
            this.GenerateNameButton.Location = new System.Drawing.Point(6, 101);
            this.GenerateNameButton.Name = "GenerateNameButton";
            this.GenerateNameButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateNameButton.TabIndex = 4;
            this.GenerateNameButton.Text = "Generate";
            this.GenerateNameButton.UseVisualStyleBackColor = true;
            this.GenerateNameButton.Click += new System.EventHandler(this.GenerateNameButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(87, 104);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(336, 20);
            this.NameTextBox.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MaleRadioButton);
            this.groupBox2.Controls.Add(this.FemaleRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(101, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gender";
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(6, 19);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.MaleRadioButton.TabIndex = 0;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(6, 42);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleRadioButton.TabIndex = 1;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AttributeDataGridView);
            this.groupBox3.Controls.Add(this.GenerateStatsButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 225);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generate Stats";
            // 
            // AttributeDataGridView
            // 
            this.AttributeDataGridView.AllowUserToAddRows = false;
            this.AttributeDataGridView.AllowUserToDeleteRows = false;
            this.AttributeDataGridView.AllowUserToResizeColumns = false;
            this.AttributeDataGridView.AllowUserToResizeRows = false;
            this.AttributeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttributeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatName,
            this.AttributeValueColumn});
            this.AttributeDataGridView.Location = new System.Drawing.Point(6, 49);
            this.AttributeDataGridView.Name = "AttributeDataGridView";
            this.AttributeDataGridView.ReadOnly = true;
            this.AttributeDataGridView.Size = new System.Drawing.Size(262, 163);
            this.AttributeDataGridView.TabIndex = 1;
            // 
            // StatName
            // 
            this.StatName.HeaderText = "Attribute";
            this.StatName.Name = "StatName";
            this.StatName.ReadOnly = true;
            // 
            // AttributeValueColumn
            // 
            this.AttributeValueColumn.HeaderText = "Value";
            this.AttributeValueColumn.Name = "AttributeValueColumn";
            this.AttributeValueColumn.ReadOnly = true;
            // 
            // GenerateStatsButton
            // 
            this.GenerateStatsButton.Location = new System.Drawing.Point(6, 19);
            this.GenerateStatsButton.Name = "GenerateStatsButton";
            this.GenerateStatsButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateStatsButton.TabIndex = 0;
            this.GenerateStatsButton.Text = "Generate";
            this.GenerateStatsButton.UseVisualStyleBackColor = true;
            this.GenerateStatsButton.Click += new System.EventHandler(this.GenerateStatsButton_Click);
            // 
            // GenerateNpcButton
            // 
            this.GenerateNpcButton.Location = new System.Drawing.Point(367, 386);
            this.GenerateNpcButton.Name = "GenerateNpcButton";
            this.GenerateNpcButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateNpcButton.TabIndex = 2;
            this.GenerateNpcButton.Text = "Generate";
            this.GenerateNpcButton.UseVisualStyleBackColor = true;
            this.GenerateNpcButton.Click += new System.EventHandler(this.GenerateNpcButton_Click);
            // 
            // NPCGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 419);
            this.Controls.Add(this.GenerateNpcButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "NPCGenerator";
            this.Text = "NPC Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttributeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GenerateNameButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NameDataSetsCombo;
        private System.Windows.Forms.Button ViewEditNameDataSet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button GenerateStatsButton;
        private System.Windows.Forms.DataGridView AttributeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeValueColumn;
        private System.Windows.Forms.Button GenerateNpcButton;
    }
}

