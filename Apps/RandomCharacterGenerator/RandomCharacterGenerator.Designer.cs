namespace TRW.Apps.RandomCharacterGenerator
{
    partial class RandomCharacterGenerator
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importClassToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBackgroundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placeholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRacesPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveClassesPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBackgroundsPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCharacterSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCharacterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormSplitter = new System.Windows.Forms.SplitContainer();
            this.grpBoxFilters = new System.Windows.Forms.GroupBox();
            this.filterFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.grpBoxGenerationSettings = new System.Windows.Forms.GroupBox();
            this.chk_RandomBackground = new System.Windows.Forms.CheckBox();
            this.chk_RandomClass = new System.Windows.Forms.CheckBox();
            this.chk_RandomRace = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numNumberOfCharacters = new System.Windows.Forms.NumericUpDown();
            this.cmbBackground = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRace = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.listTabPage = new System.Windows.Forms.TabPage();
            this.characterGrid = new System.Windows.Forms.DataGridView();
            this.CharacterObjectColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.RaceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackgroundColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HitPointsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrengthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DexterityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConstitutionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntelligenceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WisdomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharismaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsTabPage = new System.Windows.Forms.TabPage();
            this.characterListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteCharacterContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCharacterSheetContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainFormSplitter)).BeginInit();
            this.MainFormSplitter.Panel1.SuspendLayout();
            this.MainFormSplitter.Panel2.SuspendLayout();
            this.MainFormSplitter.SuspendLayout();
            this.grpBoxFilters.SuspendLayout();
            this.grpBoxGenerationSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfCharacters)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.listTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterGrid)).BeginInit();
            this.characterListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.printToolStripMenuItem,
            this.testToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1060, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCharactersToolStripMenuItem,
            this.loadCharactersToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveCharactersToolStripMenuItem
            // 
            this.saveCharactersToolStripMenuItem.Name = "saveCharactersToolStripMenuItem";
            this.saveCharactersToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveCharactersToolStripMenuItem.Text = "Save Characters";
            this.saveCharactersToolStripMenuItem.Click += new System.EventHandler(this.saveCharactersToolStripMenuItem_Click);
            // 
            // loadCharactersToolStripMenuItem
            // 
            this.loadCharactersToolStripMenuItem.Name = "loadCharactersToolStripMenuItem";
            this.loadCharactersToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.loadCharactersToolStripMenuItem.Text = "Load Characters";
            this.loadCharactersToolStripMenuItem.Click += new System.EventHandler(this.loadCharactersToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importClassToolStripMenuItem,
            this.importClassToolStripMenuItem1,
            this.importBackgroundToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // importClassToolStripMenuItem
            // 
            this.importClassToolStripMenuItem.Name = "importClassToolStripMenuItem";
            this.importClassToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.importClassToolStripMenuItem.Text = "Import Race";
            this.importClassToolStripMenuItem.Click += new System.EventHandler(this.importRaceToolStripMenuItem_Click);
            // 
            // importClassToolStripMenuItem1
            // 
            this.importClassToolStripMenuItem1.Name = "importClassToolStripMenuItem1";
            this.importClassToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.importClassToolStripMenuItem1.Text = "Import Class";
            this.importClassToolStripMenuItem1.Click += new System.EventHandler(this.importClassToolStripMenuItem1_Click);
            // 
            // importBackgroundToolStripMenuItem
            // 
            this.importBackgroundToolStripMenuItem.Name = "importBackgroundToolStripMenuItem";
            this.importBackgroundToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.importBackgroundToolStripMenuItem.Text = "Import Background";
            this.importBackgroundToolStripMenuItem.Click += new System.EventHandler(this.importBackgroundToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageRacesToolStripMenuItem,
            this.manageClassesToolStripMenuItem,
            this.manageBackgroundsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // manageRacesToolStripMenuItem
            // 
            this.manageRacesToolStripMenuItem.Name = "manageRacesToolStripMenuItem";
            this.manageRacesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.manageRacesToolStripMenuItem.Text = "Manage Races";
            this.manageRacesToolStripMenuItem.Click += new System.EventHandler(this.manageRacesToolStripMenuItem_Click);
            // 
            // manageClassesToolStripMenuItem
            // 
            this.manageClassesToolStripMenuItem.Name = "manageClassesToolStripMenuItem";
            this.manageClassesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.manageClassesToolStripMenuItem.Text = "Manage Classes";
            this.manageClassesToolStripMenuItem.Click += new System.EventHandler(this.manageClassesToolStripMenuItem_Click);
            // 
            // manageBackgroundsToolStripMenuItem
            // 
            this.manageBackgroundsToolStripMenuItem.Name = "manageBackgroundsToolStripMenuItem";
            this.manageBackgroundsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.manageBackgroundsToolStripMenuItem.Text = "Manage Backgrounds";
            this.manageBackgroundsToolStripMenuItem.Click += new System.EventHandler(this.manageBackgroundsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.placeholderToolStripMenuItem,
            this.characterToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.printToolStripMenuItem.Text = "PDF";
            // 
            // placeholderToolStripMenuItem
            // 
            this.placeholderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRacesPDFToolStripMenuItem,
            this.saveClassesPDFToolStripMenuItem,
            this.saveBackgroundsPDFToolStripMenuItem});
            this.placeholderToolStripMenuItem.Name = "placeholderToolStripMenuItem";
            this.placeholderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.placeholderToolStripMenuItem.Text = "Character Properties";
            // 
            // saveRacesPDFToolStripMenuItem
            // 
            this.saveRacesPDFToolStripMenuItem.Name = "saveRacesPDFToolStripMenuItem";
            this.saveRacesPDFToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveRacesPDFToolStripMenuItem.Text = "Save Races";
            this.saveRacesPDFToolStripMenuItem.Click += new System.EventHandler(this.saveRacesPDFToolStripMenuItem_Click);
            // 
            // saveClassesPDFToolStripMenuItem
            // 
            this.saveClassesPDFToolStripMenuItem.Name = "saveClassesPDFToolStripMenuItem";
            this.saveClassesPDFToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveClassesPDFToolStripMenuItem.Text = "Save Classes";
            this.saveClassesPDFToolStripMenuItem.Click += new System.EventHandler(this.saveClassesPDFToolStripMenuItem_Click);
            // 
            // saveBackgroundsPDFToolStripMenuItem
            // 
            this.saveBackgroundsPDFToolStripMenuItem.Name = "saveBackgroundsPDFToolStripMenuItem";
            this.saveBackgroundsPDFToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveBackgroundsPDFToolStripMenuItem.Text = "Save Backgrounds";
            this.saveBackgroundsPDFToolStripMenuItem.Click += new System.EventHandler(this.saveBackgroundsPDFToolStripMenuItem_Click);
            // 
            // characterToolStripMenuItem
            // 
            this.characterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCharacterSheetToolStripMenuItem,
            this.saveCharacterListToolStripMenuItem});
            this.characterToolStripMenuItem.Name = "characterToolStripMenuItem";
            this.characterToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.characterToolStripMenuItem.Text = "Character";
            // 
            // saveCharacterSheetToolStripMenuItem
            // 
            this.saveCharacterSheetToolStripMenuItem.Name = "saveCharacterSheetToolStripMenuItem";
            this.saveCharacterSheetToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveCharacterSheetToolStripMenuItem.Tag = "TopMenu";
            this.saveCharacterSheetToolStripMenuItem.Text = "Save Character Sheet";
            this.saveCharacterSheetToolStripMenuItem.Click += new System.EventHandler(this.saveCharacterSheet_Click);
            // 
            // saveCharacterListToolStripMenuItem
            // 
            this.saveCharacterListToolStripMenuItem.Name = "saveCharacterListToolStripMenuItem";
            this.saveCharacterListToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveCharacterListToolStripMenuItem.Text = "Save Character List";
            this.saveCharacterListToolStripMenuItem.Click += new System.EventHandler(this.saveCharacterListToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            // 
            // MainFormSplitter
            // 
            this.MainFormSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormSplitter.Location = new System.Drawing.Point(0, 24);
            this.MainFormSplitter.Name = "MainFormSplitter";
            // 
            // MainFormSplitter.Panel1
            // 
            this.MainFormSplitter.Panel1.Controls.Add(this.grpBoxFilters);
            this.MainFormSplitter.Panel1.Controls.Add(this.grpBoxGenerationSettings);
            this.MainFormSplitter.Panel1MinSize = 365;
            // 
            // MainFormSplitter.Panel2
            // 
            this.MainFormSplitter.Panel2.Controls.Add(this.tabControl1);
            this.MainFormSplitter.Panel2MinSize = 600;
            this.MainFormSplitter.Size = new System.Drawing.Size(1060, 457);
            this.MainFormSplitter.SplitterDistance = 365;
            this.MainFormSplitter.TabIndex = 1;
            // 
            // grpBoxFilters
            // 
            this.grpBoxFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxFilters.Controls.Add(this.filterFlowPanel);
            this.grpBoxFilters.Location = new System.Drawing.Point(3, 3);
            this.grpBoxFilters.Name = "grpBoxFilters";
            this.grpBoxFilters.Size = new System.Drawing.Size(364, 212);
            this.grpBoxFilters.TabIndex = 0;
            this.grpBoxFilters.TabStop = false;
            this.grpBoxFilters.Text = "Filters";
            // 
            // filterFlowPanel
            // 
            this.filterFlowPanel.AutoScroll = true;
            this.filterFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterFlowPanel.Location = new System.Drawing.Point(3, 16);
            this.filterFlowPanel.Name = "filterFlowPanel";
            this.filterFlowPanel.Size = new System.Drawing.Size(358, 193);
            this.filterFlowPanel.TabIndex = 0;
            // 
            // grpBoxGenerationSettings
            // 
            this.grpBoxGenerationSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxGenerationSettings.Controls.Add(this.chk_RandomBackground);
            this.grpBoxGenerationSettings.Controls.Add(this.chk_RandomClass);
            this.grpBoxGenerationSettings.Controls.Add(this.chk_RandomRace);
            this.grpBoxGenerationSettings.Controls.Add(this.btnGenerate);
            this.grpBoxGenerationSettings.Controls.Add(this.label5);
            this.grpBoxGenerationSettings.Controls.Add(this.numLevel);
            this.grpBoxGenerationSettings.Controls.Add(this.label4);
            this.grpBoxGenerationSettings.Controls.Add(this.numNumberOfCharacters);
            this.grpBoxGenerationSettings.Controls.Add(this.cmbBackground);
            this.grpBoxGenerationSettings.Controls.Add(this.label3);
            this.grpBoxGenerationSettings.Controls.Add(this.cmbClass);
            this.grpBoxGenerationSettings.Controls.Add(this.label2);
            this.grpBoxGenerationSettings.Controls.Add(this.cmbRace);
            this.grpBoxGenerationSettings.Controls.Add(this.label1);
            this.grpBoxGenerationSettings.Location = new System.Drawing.Point(3, 221);
            this.grpBoxGenerationSettings.Name = "grpBoxGenerationSettings";
            this.grpBoxGenerationSettings.Size = new System.Drawing.Size(359, 188);
            this.grpBoxGenerationSettings.TabIndex = 1;
            this.grpBoxGenerationSettings.TabStop = false;
            this.grpBoxGenerationSettings.Text = "Generation Settings";
            // 
            // chk_RandomBackground
            // 
            this.chk_RandomBackground.AutoSize = true;
            this.chk_RandomBackground.Location = new System.Drawing.Point(272, 116);
            this.chk_RandomBackground.Name = "chk_RandomBackground";
            this.chk_RandomBackground.Size = new System.Drawing.Size(66, 17);
            this.chk_RandomBackground.TabIndex = 3;
            this.chk_RandomBackground.Text = "Random";
            this.chk_RandomBackground.UseVisualStyleBackColor = true;
            this.chk_RandomBackground.CheckedChanged += new System.EventHandler(this.chkRandom_Checked);
            // 
            // chk_RandomClass
            // 
            this.chk_RandomClass.AutoSize = true;
            this.chk_RandomClass.Location = new System.Drawing.Point(272, 89);
            this.chk_RandomClass.Name = "chk_RandomClass";
            this.chk_RandomClass.Size = new System.Drawing.Size(66, 17);
            this.chk_RandomClass.TabIndex = 2;
            this.chk_RandomClass.Text = "Random";
            this.chk_RandomClass.UseVisualStyleBackColor = true;
            this.chk_RandomClass.CheckedChanged += new System.EventHandler(this.chkRandom_Checked);
            // 
            // chk_RandomRace
            // 
            this.chk_RandomRace.AutoSize = true;
            this.chk_RandomRace.Location = new System.Drawing.Point(272, 62);
            this.chk_RandomRace.Name = "chk_RandomRace";
            this.chk_RandomRace.Size = new System.Drawing.Size(66, 17);
            this.chk_RandomRace.TabIndex = 1;
            this.chk_RandomRace.Text = "Random";
            this.chk_RandomRace.UseVisualStyleBackColor = true;
            this.chk_RandomRace.CheckedChanged += new System.EventHandler(this.chkRandom_Checked);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(278, 159);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Level:";
            // 
            // numLevel
            // 
            this.numLevel.Location = new System.Drawing.Point(89, 141);
            this.numLevel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(82, 20);
            this.numLevel.TabIndex = 4;
            this.numLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Number:";
            // 
            // numNumberOfCharacters
            // 
            this.numNumberOfCharacters.Location = new System.Drawing.Point(89, 34);
            this.numNumberOfCharacters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumberOfCharacters.Name = "numNumberOfCharacters";
            this.numNumberOfCharacters.Size = new System.Drawing.Size(82, 20);
            this.numNumberOfCharacters.TabIndex = 0;
            this.numNumberOfCharacters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbBackground
            // 
            this.cmbBackground.FormattingEnabled = true;
            this.cmbBackground.Location = new System.Drawing.Point(89, 114);
            this.cmbBackground.Name = "cmbBackground";
            this.cmbBackground.Size = new System.Drawing.Size(177, 21);
            this.cmbBackground.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Background:";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(89, 87);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(177, 21);
            this.cmbClass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class:";
            // 
            // cmbRace
            // 
            this.cmbRace.FormattingEnabled = true;
            this.cmbRace.Location = new System.Drawing.Point(89, 60);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(177, 21);
            this.cmbRace.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Race:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.listTabPage);
            this.tabControl1.Controls.Add(this.detailsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 457);
            this.tabControl1.TabIndex = 0;
            // 
            // listTabPage
            // 
            this.listTabPage.Controls.Add(this.characterGrid);
            this.listTabPage.Location = new System.Drawing.Point(4, 22);
            this.listTabPage.Name = "listTabPage";
            this.listTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.listTabPage.Size = new System.Drawing.Size(683, 431);
            this.listTabPage.TabIndex = 0;
            this.listTabPage.Text = "List";
            this.listTabPage.UseVisualStyleBackColor = true;
            // 
            // characterGrid
            // 
            this.characterGrid.AllowUserToAddRows = false;
            this.characterGrid.AllowUserToResizeRows = false;
            this.characterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.characterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterObjectColumn,
            this.RaceColumn,
            this.ClassColumn,
            this.BackgroundColumn,
            this.LevelColumn,
            this.HitPointsColumn,
            this.StrengthColumn,
            this.DexterityColumn,
            this.ConstitutionColumn,
            this.IntelligenceColumn,
            this.WisdomColumn,
            this.CharismaColumn});
            this.characterGrid.ContextMenuStrip = this.characterListContextMenu;
            this.characterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterGrid.Location = new System.Drawing.Point(3, 3);
            this.characterGrid.MultiSelect = false;
            this.characterGrid.Name = "characterGrid";
            this.characterGrid.ReadOnly = true;
            this.characterGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.characterGrid.ShowEditingIcon = false;
            this.characterGrid.Size = new System.Drawing.Size(677, 425);
            this.characterGrid.TabIndex = 0;
            // 
            // CharacterObjectColumn
            // 
            this.CharacterObjectColumn.HeaderText = "C";
            this.CharacterObjectColumn.Name = "CharacterObjectColumn";
            this.CharacterObjectColumn.ReadOnly = true;
            this.CharacterObjectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CharacterObjectColumn.Visible = false;
            this.CharacterObjectColumn.Width = 5;
            // 
            // RaceColumn
            // 
            this.RaceColumn.HeaderText = "Race";
            this.RaceColumn.Name = "RaceColumn";
            this.RaceColumn.ReadOnly = true;
            this.RaceColumn.Width = 125;
            // 
            // ClassColumn
            // 
            this.ClassColumn.HeaderText = "Class";
            this.ClassColumn.Name = "ClassColumn";
            this.ClassColumn.ReadOnly = true;
            this.ClassColumn.Width = 125;
            // 
            // BackgroundColumn
            // 
            this.BackgroundColumn.HeaderText = "Background";
            this.BackgroundColumn.Name = "BackgroundColumn";
            this.BackgroundColumn.ReadOnly = true;
            this.BackgroundColumn.Width = 125;
            // 
            // LevelColumn
            // 
            this.LevelColumn.HeaderText = "Level";
            this.LevelColumn.Name = "LevelColumn";
            this.LevelColumn.ReadOnly = true;
            this.LevelColumn.Width = 50;
            // 
            // HitPointsColumn
            // 
            this.HitPointsColumn.HeaderText = "HP";
            this.HitPointsColumn.Name = "HitPointsColumn";
            this.HitPointsColumn.ReadOnly = true;
            this.HitPointsColumn.Width = 25;
            // 
            // StrengthColumn
            // 
            this.StrengthColumn.HeaderText = "ST";
            this.StrengthColumn.Name = "StrengthColumn";
            this.StrengthColumn.ReadOnly = true;
            this.StrengthColumn.Width = 30;
            // 
            // DexterityColumn
            // 
            this.DexterityColumn.HeaderText = "DX";
            this.DexterityColumn.Name = "DexterityColumn";
            this.DexterityColumn.ReadOnly = true;
            this.DexterityColumn.Width = 30;
            // 
            // ConstitutionColumn
            // 
            this.ConstitutionColumn.HeaderText = "CN";
            this.ConstitutionColumn.Name = "ConstitutionColumn";
            this.ConstitutionColumn.ReadOnly = true;
            this.ConstitutionColumn.Width = 30;
            // 
            // IntelligenceColumn
            // 
            this.IntelligenceColumn.HeaderText = "IN";
            this.IntelligenceColumn.Name = "IntelligenceColumn";
            this.IntelligenceColumn.ReadOnly = true;
            this.IntelligenceColumn.Width = 30;
            // 
            // WisdomColumn
            // 
            this.WisdomColumn.HeaderText = "WS";
            this.WisdomColumn.Name = "WisdomColumn";
            this.WisdomColumn.ReadOnly = true;
            this.WisdomColumn.Width = 30;
            // 
            // CharismaColumn
            // 
            this.CharismaColumn.HeaderText = "CH";
            this.CharismaColumn.Name = "CharismaColumn";
            this.CharismaColumn.ReadOnly = true;
            this.CharismaColumn.Width = 30;
            // 
            // detailsTabPage
            // 
            this.detailsTabPage.Location = new System.Drawing.Point(4, 22);
            this.detailsTabPage.Name = "detailsTabPage";
            this.detailsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailsTabPage.Size = new System.Drawing.Size(683, 431);
            this.detailsTabPage.TabIndex = 1;
            this.detailsTabPage.Text = "Details";
            this.detailsTabPage.UseVisualStyleBackColor = true;
            // 
            // characterListContextMenu
            // 
            this.characterListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCharacterContextMenuItem,
            this.saveCharacterSheetContextMenuItem});
            this.characterListContextMenu.Name = "characterListContextMenu";
            this.characterListContextMenu.ShowImageMargin = false;
            this.characterListContextMenu.Size = new System.Drawing.Size(160, 48);
            // 
            // deleteCharacterContextMenuItem
            // 
            this.deleteCharacterContextMenuItem.Name = "deleteCharacterContextMenuItem";
            this.deleteCharacterContextMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deleteCharacterContextMenuItem.Text = "Delete";
            this.deleteCharacterContextMenuItem.Click += new System.EventHandler(this.deleteCharacterContextMenuItem_Click);
            // 
            // saveCharacterSheetContextMenuItem
            // 
            this.saveCharacterSheetContextMenuItem.Name = "saveCharacterSheetContextMenuItem";
            this.saveCharacterSheetContextMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveCharacterSheetContextMenuItem.Text = "Save Character Sheet";
            this.saveCharacterSheetContextMenuItem.Click += new System.EventHandler(this.saveCharacterSheetContextMenuItem_Click);
            // 
            // RandomCharacterGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 481);
            this.Controls.Add(this.MainFormSplitter);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(1076, 500);
            this.Name = "RandomCharacterGenerator";
            this.Text = "Random Character Generator";
            this.Load += new System.EventHandler(this.RandomCharacterGenerator_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.MainFormSplitter.Panel1.ResumeLayout(false);
            this.MainFormSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainFormSplitter)).EndInit();
            this.MainFormSplitter.ResumeLayout(false);
            this.grpBoxFilters.ResumeLayout(false);
            this.grpBoxGenerationSettings.ResumeLayout(false);
            this.grpBoxGenerationSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfCharacters)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.listTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.characterGrid)).EndInit();
            this.characterListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainFormSplitter;
        private System.Windows.Forms.GroupBox grpBoxGenerationSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numNumberOfCharacters;
        private System.Windows.Forms.ComboBox cmbBackground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage listTabPage;
        private System.Windows.Forms.DataGridView characterGrid;
        private System.Windows.Forms.TabPage detailsTabPage;
        private System.Windows.Forms.ToolStripMenuItem saveCharactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCharactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importClassToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBackgroundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chk_RandomBackground;
        private System.Windows.Forms.CheckBox chk_RandomClass;
        private System.Windows.Forms.CheckBox chk_RandomRace;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn CharacterObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackgroundColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HitPointsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrengthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DexterityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConstitutionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntelligenceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WisdomColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharismaColumn;
        private System.Windows.Forms.ToolStripMenuItem placeholderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCharacterSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCharacterListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRacesPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveClassesPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBackgroundsPDFToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpBoxFilters;
        private System.Windows.Forms.FlowLayoutPanel filterFlowPanel;
        private System.Windows.Forms.ContextMenuStrip characterListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteCharacterContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCharacterSheetContextMenuItem;
    }
}

