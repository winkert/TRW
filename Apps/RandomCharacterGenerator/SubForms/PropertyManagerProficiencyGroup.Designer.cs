namespace TRW.Apps.RandomCharacterGenerator
{
    partial class PropertyManagerProficiencyGroup
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
            this.FeaturesGroup = new System.Windows.Forms.GroupBox();
            this.DeleteFeatureButton = new System.Windows.Forms.Button();
            this.EditFeatureButton = new System.Windows.Forms.Button();
            this.AddFeatureButton = new System.Windows.Forms.Button();
            this.FeaturesListBox = new TRW.Apps.TrwAppsBase.Controls.AdvancedListBox();
            this.ProficienciesGroup = new System.Windows.Forms.GroupBox();
            this.EditProficiencyButton = new System.Windows.Forms.Button();
            this.DeleteProficiencyButton = new System.Windows.Forms.Button();
            this.AddProficiencyButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ProficienciesListBox = new TRW.Apps.TrwAppsBase.Controls.AdvancedListBox();
            this.TotalProficienciesNumeric = new System.Windows.Forms.NumericUpDown();
            this.SkillsGroup = new System.Windows.Forms.GroupBox();
            this.EditSkillButton = new System.Windows.Forms.Button();
            this.DeleteSkillButton = new System.Windows.Forms.Button();
            this.AddSkillButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.SkillsListBox = new TRW.Apps.TrwAppsBase.Controls.AdvancedListBox();
            this.TotalSkillsNumeric = new System.Windows.Forms.NumericUpDown();
            this.LanguagesGroup = new System.Windows.Forms.GroupBox();
            this.EditLanguageButton = new System.Windows.Forms.Button();
            this.DeleteLanguageButton = new System.Windows.Forms.Button();
            this.AddLanguageButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.LanguagesListBox = new TRW.Apps.TrwAppsBase.Controls.AdvancedListBox();
            this.TotalLanguagesNumeric = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.FeaturesGroup.SuspendLayout();
            this.ProficienciesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalProficienciesNumeric)).BeginInit();
            this.SkillsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSkillsNumeric)).BeginInit();
            this.LanguagesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLanguagesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // FeaturesGroup
            // 
            this.FeaturesGroup.Controls.Add(this.DeleteFeatureButton);
            this.FeaturesGroup.Controls.Add(this.EditFeatureButton);
            this.FeaturesGroup.Controls.Add(this.AddFeatureButton);
            this.FeaturesGroup.Controls.Add(this.FeaturesListBox);
            this.FeaturesGroup.Location = new System.Drawing.Point(247, 193);
            this.FeaturesGroup.Name = "FeaturesGroup";
            this.FeaturesGroup.Size = new System.Drawing.Size(229, 156);
            this.FeaturesGroup.TabIndex = 17;
            this.FeaturesGroup.TabStop = false;
            this.FeaturesGroup.Text = "Features";
            // 
            // DeleteFeatureButton
            // 
            this.DeleteFeatureButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.DeleteButtonImage;
            this.DeleteFeatureButton.Location = new System.Drawing.Point(6, 114);
            this.DeleteFeatureButton.Name = "DeleteFeatureButton";
            this.DeleteFeatureButton.Size = new System.Drawing.Size(30, 30);
            this.DeleteFeatureButton.TabIndex = 4;
            this.DeleteFeatureButton.UseVisualStyleBackColor = true;
            this.DeleteFeatureButton.Click += new System.EventHandler(this.DeleteFeatureButton_Click);
            // 
            // EditFeatureButton
            // 
            this.EditFeatureButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.EditButtonImage;
            this.EditFeatureButton.Location = new System.Drawing.Point(6, 78);
            this.EditFeatureButton.Name = "EditFeatureButton";
            this.EditFeatureButton.Size = new System.Drawing.Size(30, 30);
            this.EditFeatureButton.TabIndex = 3;
            this.EditFeatureButton.UseVisualStyleBackColor = true;
            this.EditFeatureButton.Click += new System.EventHandler(this.EditFeatureButton_Click);
            // 
            // AddFeatureButton
            // 
            this.AddFeatureButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.AddButtonImage;
            this.AddFeatureButton.Location = new System.Drawing.Point(6, 42);
            this.AddFeatureButton.Name = "AddFeatureButton";
            this.AddFeatureButton.Size = new System.Drawing.Size(30, 30);
            this.AddFeatureButton.TabIndex = 2;
            this.AddFeatureButton.UseVisualStyleBackColor = true;
            this.AddFeatureButton.Click += new System.EventHandler(this.AddFeatureButton_Click);
            // 
            // FeaturesListBox
            // 
            this.FeaturesListBox.FormattingEnabled = true;
            this.FeaturesListBox.Location = new System.Drawing.Point(42, 42);
            this.FeaturesListBox.Name = "FeaturesListBox";
            this.FeaturesListBox.Size = new System.Drawing.Size(181, 108);
            this.FeaturesListBox.TabIndex = 1;
            // 
            // ProficienciesGroup
            // 
            this.ProficienciesGroup.Controls.Add(this.EditProficiencyButton);
            this.ProficienciesGroup.Controls.Add(this.DeleteProficiencyButton);
            this.ProficienciesGroup.Controls.Add(this.AddProficiencyButton);
            this.ProficienciesGroup.Controls.Add(this.label12);
            this.ProficienciesGroup.Controls.Add(this.ProficienciesListBox);
            this.ProficienciesGroup.Controls.Add(this.TotalProficienciesNumeric);
            this.ProficienciesGroup.Location = new System.Drawing.Point(12, 193);
            this.ProficienciesGroup.Name = "ProficienciesGroup";
            this.ProficienciesGroup.Size = new System.Drawing.Size(229, 156);
            this.ProficienciesGroup.TabIndex = 18;
            this.ProficienciesGroup.TabStop = false;
            this.ProficienciesGroup.Text = "Proficiencies";
            // 
            // EditProficiencyButton
            // 
            this.EditProficiencyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.EditButtonImage;
            this.EditProficiencyButton.Location = new System.Drawing.Point(6, 78);
            this.EditProficiencyButton.Name = "EditProficiencyButton";
            this.EditProficiencyButton.Size = new System.Drawing.Size(30, 30);
            this.EditProficiencyButton.TabIndex = 3;
            this.EditProficiencyButton.UseVisualStyleBackColor = true;
            this.EditProficiencyButton.Click += new System.EventHandler(this.EditProficiencyButton_Click);
            // 
            // DeleteProficiencyButton
            // 
            this.DeleteProficiencyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.DeleteButtonImage;
            this.DeleteProficiencyButton.Location = new System.Drawing.Point(6, 114);
            this.DeleteProficiencyButton.Name = "DeleteProficiencyButton";
            this.DeleteProficiencyButton.Size = new System.Drawing.Size(30, 30);
            this.DeleteProficiencyButton.TabIndex = 4;
            this.DeleteProficiencyButton.UseVisualStyleBackColor = true;
            this.DeleteProficiencyButton.Click += new System.EventHandler(this.DeleteProficiencyButton_Click);
            // 
            // AddProficiencyButton
            // 
            this.AddProficiencyButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.AddButtonImage;
            this.AddProficiencyButton.Location = new System.Drawing.Point(6, 42);
            this.AddProficiencyButton.Name = "AddProficiencyButton";
            this.AddProficiencyButton.Size = new System.Drawing.Size(30, 30);
            this.AddProficiencyButton.TabIndex = 2;
            this.AddProficiencyButton.UseVisualStyleBackColor = true;
            this.AddProficiencyButton.Click += new System.EventHandler(this.AddProficiencyButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Total Proficiencies";
            // 
            // ProficienciesListBox
            // 
            this.ProficienciesListBox.FormattingEnabled = true;
            this.ProficienciesListBox.Location = new System.Drawing.Point(42, 42);
            this.ProficienciesListBox.Name = "ProficienciesListBox";
            this.ProficienciesListBox.Size = new System.Drawing.Size(181, 108);
            this.ProficienciesListBox.TabIndex = 1;
            // 
            // TotalProficienciesNumeric
            // 
            this.TotalProficienciesNumeric.Location = new System.Drawing.Point(147, 19);
            this.TotalProficienciesNumeric.Name = "TotalProficienciesNumeric";
            this.TotalProficienciesNumeric.Size = new System.Drawing.Size(76, 20);
            this.TotalProficienciesNumeric.TabIndex = 0;
            // 
            // SkillsGroup
            // 
            this.SkillsGroup.Controls.Add(this.EditSkillButton);
            this.SkillsGroup.Controls.Add(this.DeleteSkillButton);
            this.SkillsGroup.Controls.Add(this.AddSkillButton);
            this.SkillsGroup.Controls.Add(this.label11);
            this.SkillsGroup.Controls.Add(this.SkillsListBox);
            this.SkillsGroup.Controls.Add(this.TotalSkillsNumeric);
            this.SkillsGroup.Location = new System.Drawing.Point(247, 12);
            this.SkillsGroup.Name = "SkillsGroup";
            this.SkillsGroup.Size = new System.Drawing.Size(229, 156);
            this.SkillsGroup.TabIndex = 19;
            this.SkillsGroup.TabStop = false;
            this.SkillsGroup.Text = "Skills";
            // 
            // EditSkillButton
            // 
            this.EditSkillButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.EditButtonImage;
            this.EditSkillButton.Location = new System.Drawing.Point(6, 78);
            this.EditSkillButton.Name = "EditSkillButton";
            this.EditSkillButton.Size = new System.Drawing.Size(30, 30);
            this.EditSkillButton.TabIndex = 3;
            this.EditSkillButton.UseVisualStyleBackColor = true;
            this.EditSkillButton.Click += new System.EventHandler(this.EditSkillButton_Click);
            // 
            // DeleteSkillButton
            // 
            this.DeleteSkillButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.DeleteButtonImage;
            this.DeleteSkillButton.Location = new System.Drawing.Point(6, 114);
            this.DeleteSkillButton.Name = "DeleteSkillButton";
            this.DeleteSkillButton.Size = new System.Drawing.Size(30, 30);
            this.DeleteSkillButton.TabIndex = 4;
            this.DeleteSkillButton.UseVisualStyleBackColor = true;
            this.DeleteSkillButton.Click += new System.EventHandler(this.DeleteSkillButton_Click);
            // 
            // AddSkillButton
            // 
            this.AddSkillButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.AddButtonImage;
            this.AddSkillButton.Location = new System.Drawing.Point(6, 42);
            this.AddSkillButton.Name = "AddSkillButton";
            this.AddSkillButton.Size = new System.Drawing.Size(30, 30);
            this.AddSkillButton.TabIndex = 2;
            this.AddSkillButton.UseVisualStyleBackColor = true;
            this.AddSkillButton.Click += new System.EventHandler(this.AddSkillButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(83, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Total Skills";
            // 
            // SkillsListBox
            // 
            this.SkillsListBox.FormattingEnabled = true;
            this.SkillsListBox.Location = new System.Drawing.Point(42, 42);
            this.SkillsListBox.Name = "SkillsListBox";
            this.SkillsListBox.Size = new System.Drawing.Size(181, 108);
            this.SkillsListBox.TabIndex = 1;
            // 
            // TotalSkillsNumeric
            // 
            this.TotalSkillsNumeric.Location = new System.Drawing.Point(147, 19);
            this.TotalSkillsNumeric.Name = "TotalSkillsNumeric";
            this.TotalSkillsNumeric.Size = new System.Drawing.Size(76, 20);
            this.TotalSkillsNumeric.TabIndex = 0;
            // 
            // LanguagesGroup
            // 
            this.LanguagesGroup.Controls.Add(this.EditLanguageButton);
            this.LanguagesGroup.Controls.Add(this.DeleteLanguageButton);
            this.LanguagesGroup.Controls.Add(this.AddLanguageButton);
            this.LanguagesGroup.Controls.Add(this.label10);
            this.LanguagesGroup.Controls.Add(this.LanguagesListBox);
            this.LanguagesGroup.Controls.Add(this.TotalLanguagesNumeric);
            this.LanguagesGroup.Location = new System.Drawing.Point(12, 12);
            this.LanguagesGroup.Name = "LanguagesGroup";
            this.LanguagesGroup.Size = new System.Drawing.Size(229, 156);
            this.LanguagesGroup.TabIndex = 20;
            this.LanguagesGroup.TabStop = false;
            this.LanguagesGroup.Text = "Languages";
            // 
            // EditLanguageButton
            // 
            this.EditLanguageButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.EditButtonImage;
            this.EditLanguageButton.Location = new System.Drawing.Point(6, 78);
            this.EditLanguageButton.Name = "EditLanguageButton";
            this.EditLanguageButton.Size = new System.Drawing.Size(30, 30);
            this.EditLanguageButton.TabIndex = 3;
            this.EditLanguageButton.UseVisualStyleBackColor = true;
            this.EditLanguageButton.Click += new System.EventHandler(this.EditLanguageButton_Click);
            // 
            // DeleteLanguageButton
            // 
            this.DeleteLanguageButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.DeleteButtonImage;
            this.DeleteLanguageButton.Location = new System.Drawing.Point(6, 114);
            this.DeleteLanguageButton.Name = "DeleteLanguageButton";
            this.DeleteLanguageButton.Size = new System.Drawing.Size(30, 30);
            this.DeleteLanguageButton.TabIndex = 4;
            this.DeleteLanguageButton.UseVisualStyleBackColor = true;
            this.DeleteLanguageButton.Click += new System.EventHandler(this.DeleteLanguageButton_Click);
            // 
            // AddLanguageButton
            // 
            this.AddLanguageButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.AddButtonImage;
            this.AddLanguageButton.Location = new System.Drawing.Point(6, 42);
            this.AddLanguageButton.Name = "AddLanguageButton";
            this.AddLanguageButton.Size = new System.Drawing.Size(30, 30);
            this.AddLanguageButton.TabIndex = 2;
            this.AddLanguageButton.UseVisualStyleBackColor = true;
            this.AddLanguageButton.Click += new System.EventHandler(this.AddLanguageButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Total Languages";
            // 
            // LanguagesListBox
            // 
            this.LanguagesListBox.FormattingEnabled = true;
            this.LanguagesListBox.Location = new System.Drawing.Point(42, 42);
            this.LanguagesListBox.Name = "LanguagesListBox";
            this.LanguagesListBox.Size = new System.Drawing.Size(181, 108);
            this.LanguagesListBox.TabIndex = 1;
            // 
            // TotalLanguagesNumeric
            // 
            this.TotalLanguagesNumeric.Location = new System.Drawing.Point(147, 19);
            this.TotalLanguagesNumeric.Name = "TotalLanguagesNumeric";
            this.TotalLanguagesNumeric.Size = new System.Drawing.Size(76, 20);
            this.TotalLanguagesNumeric.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PropertyManagerProficiencyGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 358);
            this.Controls.Add(this.FeaturesGroup);
            this.Controls.Add(this.ProficienciesGroup);
            this.Controls.Add(this.SkillsGroup);
            this.Controls.Add(this.LanguagesGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyManagerProficiencyGroup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PropertyManagerProficiencyGroup";
            this.FeaturesGroup.ResumeLayout(false);
            this.ProficienciesGroup.ResumeLayout(false);
            this.ProficienciesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalProficienciesNumeric)).EndInit();
            this.SkillsGroup.ResumeLayout(false);
            this.SkillsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSkillsNumeric)).EndInit();
            this.LanguagesGroup.ResumeLayout(false);
            this.LanguagesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLanguagesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FeaturesGroup;
        private System.Windows.Forms.Button DeleteFeatureButton;
        private System.Windows.Forms.Button EditFeatureButton;
        private System.Windows.Forms.Button AddFeatureButton;
        private TRW.Apps.TrwAppsBase.Controls.AdvancedListBox FeaturesListBox;
        private System.Windows.Forms.GroupBox ProficienciesGroup;
        private System.Windows.Forms.Button EditProficiencyButton;
        private System.Windows.Forms.Button DeleteProficiencyButton;
        private System.Windows.Forms.Button AddProficiencyButton;
        private System.Windows.Forms.Label label12;
        private TRW.Apps.TrwAppsBase.Controls.AdvancedListBox ProficienciesListBox;
        private System.Windows.Forms.NumericUpDown TotalProficienciesNumeric;
        private System.Windows.Forms.GroupBox SkillsGroup;
        private System.Windows.Forms.Button EditSkillButton;
        private System.Windows.Forms.Button DeleteSkillButton;
        private System.Windows.Forms.Button AddSkillButton;
        private System.Windows.Forms.Label label11;
        private TRW.Apps.TrwAppsBase.Controls.AdvancedListBox SkillsListBox;
        private System.Windows.Forms.NumericUpDown TotalSkillsNumeric;
        private System.Windows.Forms.GroupBox LanguagesGroup;
        private System.Windows.Forms.Button EditLanguageButton;
        private System.Windows.Forms.Button DeleteLanguageButton;
        private System.Windows.Forms.Button AddLanguageButton;
        private System.Windows.Forms.Label label10;
        private TRW.Apps.TrwAppsBase.Controls.AdvancedListBox LanguagesListBox;
        private System.Windows.Forms.NumericUpDown TotalLanguagesNumeric;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}