namespace TRW.Apps.RandomCharacterGenerator
{
    partial class CharacterBackgroundPropertyDetails
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
            this.components = new System.ComponentModel.Container();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BackgroundDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.BackgroundPropertiesTabControl = new System.Windows.Forms.TabControl();
            this.BackgroundProficienciesTab = new System.Windows.Forms.TabPage();
            this.ProficiencyGroupPanel = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BackgroundTraitsPanel = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.BackgroundDetailsGroupBox.SuspendLayout();
            this.BackgroundPropertiesTabControl.SuspendLayout();
            this.BackgroundProficienciesTab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(93, 26);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(149, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name";
            // 
            // BackgroundDetailsGroupBox
            // 
            this.BackgroundDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundDetailsGroupBox.Controls.Add(this.BackgroundPropertiesTabControl);
            this.BackgroundDetailsGroupBox.Controls.Add(this.label1);
            this.BackgroundDetailsGroupBox.Controls.Add(this.NameTextBox);
            this.BackgroundDetailsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.BackgroundDetailsGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.BackgroundDetailsGroupBox.Name = "BackgroundDetailsGroupBox";
            this.BackgroundDetailsGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.BackgroundDetailsGroupBox.Size = new System.Drawing.Size(741, 433);
            this.BackgroundDetailsGroupBox.TabIndex = 0;
            this.BackgroundDetailsGroupBox.TabStop = false;
            this.BackgroundDetailsGroupBox.Text = "Background Details";
            // 
            // BackgroundPropertiesTabControl
            // 
            this.BackgroundPropertiesTabControl.Controls.Add(this.BackgroundProficienciesTab);
            this.BackgroundPropertiesTabControl.Controls.Add(this.tabPage2);
            this.BackgroundPropertiesTabControl.Location = new System.Drawing.Point(248, 26);
            this.BackgroundPropertiesTabControl.Name = "BackgroundPropertiesTabControl";
            this.BackgroundPropertiesTabControl.SelectedIndex = 0;
            this.BackgroundPropertiesTabControl.Size = new System.Drawing.Size(493, 407);
            this.BackgroundPropertiesTabControl.TabIndex = 25;
            // 
            // BackgroundProficienciesTab
            // 
            this.BackgroundProficienciesTab.Controls.Add(this.ProficiencyGroupPanel);
            this.BackgroundProficienciesTab.Location = new System.Drawing.Point(4, 22);
            this.BackgroundProficienciesTab.Name = "BackgroundProficienciesTab";
            this.BackgroundProficienciesTab.Padding = new System.Windows.Forms.Padding(3);
            this.BackgroundProficienciesTab.Size = new System.Drawing.Size(485, 381);
            this.BackgroundProficienciesTab.TabIndex = 0;
            this.BackgroundProficienciesTab.Text = "Proficiencies";
            this.BackgroundProficienciesTab.UseVisualStyleBackColor = true;
            // 
            // ProficiencyGroupPanel
            // 
            this.ProficiencyGroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProficiencyGroupPanel.Location = new System.Drawing.Point(3, 3);
            this.ProficiencyGroupPanel.Name = "ProficiencyGroupPanel";
            this.ProficiencyGroupPanel.Size = new System.Drawing.Size(479, 375);
            this.ProficiencyGroupPanel.TabIndex = 24;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BackgroundTraitsPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(485, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Traits";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BackgroundTraitsPanel
            // 
            this.BackgroundTraitsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundTraitsPanel.Location = new System.Drawing.Point(3, 3);
            this.BackgroundTraitsPanel.Name = "BackgroundTraitsPanel";
            this.BackgroundTraitsPanel.Size = new System.Drawing.Size(479, 375);
            this.BackgroundTraitsPanel.TabIndex = 25;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CharacterBackgroundPropertyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 457);
            this.ControlBox = false;
            this.Controls.Add(this.BackgroundDetailsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterBackgroundPropertyDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CharacterRacePropertyDetails";
            this.BackgroundDetailsGroupBox.ResumeLayout(false);
            this.BackgroundDetailsGroupBox.PerformLayout();
            this.BackgroundPropertiesTabControl.ResumeLayout(false);
            this.BackgroundProficienciesTab.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox BackgroundDetailsGroupBox;
        private System.Windows.Forms.Panel ProficiencyGroupPanel;
        private System.Windows.Forms.TabControl BackgroundPropertiesTabControl;
        private System.Windows.Forms.TabPage BackgroundProficienciesTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel BackgroundTraitsPanel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}