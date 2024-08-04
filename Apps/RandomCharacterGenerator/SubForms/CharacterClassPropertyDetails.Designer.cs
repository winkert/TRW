namespace TRW.Apps.RandomCharacterGenerator
{
    partial class CharacterClassPropertyDetails
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
            this.HitDieNumeric = new System.Windows.Forms.NumericUpDown();
            this.ClassDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.ProficiencyGroupPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.SpellCastingAbilityComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SecondaryAttributeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SavingThrowsGroup = new System.Windows.Forms.GroupBox();
            this.EditSavingThrowButton = new System.Windows.Forms.Button();
            this.DeleteSavingThrowButton = new System.Windows.Forms.Button();
            this.AddSavingThrowButton = new System.Windows.Forms.Button();
            this.SavingThrowsListBox = new TRW.Apps.TrwAppsBase.Controls.AdvancedListBox();
            this.PrimaryAttributeComboBox = new System.Windows.Forms.ComboBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HitDieNumeric)).BeginInit();
            this.ClassDetailsGroupBox.SuspendLayout();
            this.SavingThrowsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // HitDieNumeric
            // 
            this.HitDieNumeric.Location = new System.Drawing.Point(109, 55);
            this.HitDieNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.HitDieNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.HitDieNumeric.Name = "HitDieNumeric";
            this.HitDieNumeric.Size = new System.Drawing.Size(76, 20);
            this.HitDieNumeric.TabIndex = 1;
            this.HitDieNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ClassDetailsGroupBox
            // 
            this.ClassDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassDetailsGroupBox.Controls.Add(this.ProficiencyGroupPanel);
            this.ClassDetailsGroupBox.Controls.Add(this.label5);
            this.ClassDetailsGroupBox.Controls.Add(this.SpellCastingAbilityComboBox);
            this.ClassDetailsGroupBox.Controls.Add(this.label4);
            this.ClassDetailsGroupBox.Controls.Add(this.HitDieNumeric);
            this.ClassDetailsGroupBox.Controls.Add(this.label3);
            this.ClassDetailsGroupBox.Controls.Add(this.SecondaryAttributeComboBox);
            this.ClassDetailsGroupBox.Controls.Add(this.label2);
            this.ClassDetailsGroupBox.Controls.Add(this.label1);
            this.ClassDetailsGroupBox.Controls.Add(this.SavingThrowsGroup);
            this.ClassDetailsGroupBox.Controls.Add(this.PrimaryAttributeComboBox);
            this.ClassDetailsGroupBox.Controls.Add(this.NameTextBox);
            this.ClassDetailsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ClassDetailsGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.ClassDetailsGroupBox.Name = "ClassDetailsGroupBox";
            this.ClassDetailsGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.ClassDetailsGroupBox.Size = new System.Drawing.Size(741, 433);
            this.ClassDetailsGroupBox.TabIndex = 0;
            this.ClassDetailsGroupBox.TabStop = false;
            this.ClassDetailsGroupBox.Text = "Class Details";
            // 
            // ProficiencyGroupPanel
            // 
            this.ProficiencyGroupPanel.Location = new System.Drawing.Point(248, 26);
            this.ProficiencyGroupPanel.Name = "ProficiencyGroupPanel";
            this.ProficiencyGroupPanel.Size = new System.Drawing.Size(480, 371);
            this.ProficiencyGroupPanel.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Spellcasting Ability";
            // 
            // SpellCastingAbilityComboBox
            // 
            this.SpellCastingAbilityComboBox.FormattingEnabled = true;
            this.SpellCastingAbilityComboBox.Location = new System.Drawing.Point(122, 146);
            this.SpellCastingAbilityComboBox.Name = "SpellCastingAbilityComboBox";
            this.SpellCastingAbilityComboBox.Size = new System.Drawing.Size(120, 21);
            this.SpellCastingAbilityComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hit Dice Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Secondary Attribute";
            // 
            // SecondaryAttributeComboBox
            // 
            this.SecondaryAttributeComboBox.FormattingEnabled = true;
            this.SecondaryAttributeComboBox.Location = new System.Drawing.Point(122, 117);
            this.SecondaryAttributeComboBox.Name = "SecondaryAttributeComboBox";
            this.SecondaryAttributeComboBox.Size = new System.Drawing.Size(120, 21);
            this.SecondaryAttributeComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Primary Attribute";
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
            // SavingThrowsGroup
            // 
            this.SavingThrowsGroup.Controls.Add(this.EditSavingThrowButton);
            this.SavingThrowsGroup.Controls.Add(this.DeleteSavingThrowButton);
            this.SavingThrowsGroup.Controls.Add(this.AddSavingThrowButton);
            this.SavingThrowsGroup.Controls.Add(this.SavingThrowsListBox);
            this.SavingThrowsGroup.Location = new System.Drawing.Point(13, 262);
            this.SavingThrowsGroup.Name = "SavingThrowsGroup";
            this.SavingThrowsGroup.Size = new System.Drawing.Size(229, 135);
            this.SavingThrowsGroup.TabIndex = 5;
            this.SavingThrowsGroup.TabStop = false;
            this.SavingThrowsGroup.Text = "Saving Throws";
            // 
            // EditSavingThrowButton
            // 
            this.EditSavingThrowButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.EditButtonImage;
            this.EditSavingThrowButton.Location = new System.Drawing.Point(6, 55);
            this.EditSavingThrowButton.Name = "EditSavingThrowButton";
            this.EditSavingThrowButton.Size = new System.Drawing.Size(30, 30);
            this.EditSavingThrowButton.TabIndex = 3;
            this.EditSavingThrowButton.UseVisualStyleBackColor = true;
            this.EditSavingThrowButton.Click += new System.EventHandler(this.EditSavingThrowButton_Click);
            // 
            // DeleteSavingThrowButton
            // 
            this.DeleteSavingThrowButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.DeleteButtonImage;
            this.DeleteSavingThrowButton.Location = new System.Drawing.Point(6, 91);
            this.DeleteSavingThrowButton.Name = "DeleteSavingThrowButton";
            this.DeleteSavingThrowButton.Size = new System.Drawing.Size(30, 30);
            this.DeleteSavingThrowButton.TabIndex = 4;
            this.DeleteSavingThrowButton.UseVisualStyleBackColor = true;
            this.DeleteSavingThrowButton.Click += new System.EventHandler(this.DeleteSavingThrowButton_Click);
            // 
            // AddSavingThrowButton
            // 
            this.AddSavingThrowButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.AddButtonImage;
            this.AddSavingThrowButton.Location = new System.Drawing.Point(6, 19);
            this.AddSavingThrowButton.Name = "AddSavingThrowButton";
            this.AddSavingThrowButton.Size = new System.Drawing.Size(30, 30);
            this.AddSavingThrowButton.TabIndex = 2;
            this.AddSavingThrowButton.UseVisualStyleBackColor = true;
            this.AddSavingThrowButton.Click += new System.EventHandler(this.AddSavingThrowButton_Click);
            // 
            // SavingThrowsListBox
            // 
            this.SavingThrowsListBox.FormattingEnabled = true;
            this.SavingThrowsListBox.Location = new System.Drawing.Point(42, 16);
            this.SavingThrowsListBox.Name = "SavingThrowsListBox";
            this.SavingThrowsListBox.Size = new System.Drawing.Size(181, 108);
            this.SavingThrowsListBox.TabIndex = 1;
            // 
            // PrimaryAttributeComboBox
            // 
            this.PrimaryAttributeComboBox.FormattingEnabled = true;
            this.PrimaryAttributeComboBox.Location = new System.Drawing.Point(122, 87);
            this.PrimaryAttributeComboBox.Name = "PrimaryAttributeComboBox";
            this.PrimaryAttributeComboBox.Size = new System.Drawing.Size(120, 21);
            this.PrimaryAttributeComboBox.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(93, 26);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(149, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CharacterClassPropertyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 457);
            this.ControlBox = false;
            this.Controls.Add(this.ClassDetailsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharacterClassPropertyDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CharacterRacePropertyDetails";
            ((System.ComponentModel.ISupportInitialize)(this.HitDieNumeric)).EndInit();
            this.ClassDetailsGroupBox.ResumeLayout(false);
            this.ClassDetailsGroupBox.PerformLayout();
            this.SavingThrowsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ClassDetailsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PrimaryAttributeComboBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.GroupBox SavingThrowsGroup;
        private System.Windows.Forms.Button EditSavingThrowButton;
        private System.Windows.Forms.Button DeleteSavingThrowButton;
        private System.Windows.Forms.Button AddSavingThrowButton;
        private TRW.Apps.TrwAppsBase.Controls.AdvancedListBox SavingThrowsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SecondaryAttributeComboBox;
        private System.Windows.Forms.NumericUpDown HitDieNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SpellCastingAbilityComboBox;
        private System.Windows.Forms.Panel ProficiencyGroupPanel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}