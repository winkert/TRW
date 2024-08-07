namespace TRW.Apps.MapGenerator
{
    partial class MapGeneratorMainForm
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
            pctPreview = new PictureBox();
            tabGenSettings = new TabControl();
            tabPgFromFile = new TabPage();
            label1 = new Label();
            txtMapFilePath = new TextBox();
            btnGetMapFile = new Button();
            tabPgProcDS = new TabPage();
            btn_ManageColorMaps = new Button();
            label7 = new Label();
            label6 = new Label();
            cmbColorMapStyle = new ComboBox();
            cmbColorMap = new ComboBox();
            label5 = new Label();
            txtDiamondValueSpread = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnGenerateDiamondSquare = new Button();
            txtDiamondBaseValue = new TextBox();
            txtDiamondMapHeight = new TextBox();
            txtDiamondMapWidth = new TextBox();
            tabProcRW = new TabPage();
            chkRandomWalkAvoidClusters = new CheckBox();
            chkRandomWalkAvoidEdges = new CheckBox();
            txtRandomWalkIterations = new NumericUpDown();
            label11 = new Label();
            txtRandomWalkStart = new TextBox();
            label10 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtRandomWalkHeight = new TextBox();
            txtRandomWalkWidth = new TextBox();
            btnRandomWalkGenerate = new Button();
            tabProcCA = new TabPage();
            chkCellAutomataAvoidEdges = new CheckBox();
            txtCellAutomataIterations = new NumericUpDown();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            txtCellAutomataHeight = new TextBox();
            txtCellAutomataWidth = new TextBox();
            btnGenerateCellAutomata = new Button();
            tabProcPN = new TabPage();
            label25 = new Label();
            uxPerlinNoiseAmp = new NumericUpDown();
            label24 = new Label();
            uxPerlinNoiseFreq = new NumericUpDown();
            uxPerlinNoiseOctaves = new NumericUpDown();
            label20 = new Label();
            uxPerlinNoisePersistence = new TextBox();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            uxPerlinNoiseHeight = new TextBox();
            uxPerlinNoiseWidth = new TextBox();
            uxGeneratePerlinNoise = new Button();
            rndDungeonTab = new TabPage();
            label18 = new Label();
            label19 = new Label();
            uxDungeonHeight = new TextBox();
            uxDungeonWidth = new TextBox();
            uxGenerateRandomDungeon = new Button();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            uxMaxYOfRooms = new NumericUpDown();
            uxMaxXOfRooms = new NumericUpDown();
            uxMinYOfRooms = new NumericUpDown();
            uxMinXOfRooms = new NumericUpDown();
            uxNumOfRooms = new NumericUpDown();
            txtStatus = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveMapToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            MainSplitContainer = new SplitContainer();
            SettingsSplitContainer = new SplitContainer();
            uxPerlinNoiseGrid = new ComboBox();
            label26 = new Label();
            ((System.ComponentModel.ISupportInitialize)pctPreview).BeginInit();
            tabGenSettings.SuspendLayout();
            tabPgFromFile.SuspendLayout();
            tabPgProcDS.SuspendLayout();
            tabProcRW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtRandomWalkIterations).BeginInit();
            tabProcCA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCellAutomataIterations).BeginInit();
            tabProcPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uxPerlinNoiseAmp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uxPerlinNoiseFreq).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uxPerlinNoiseOctaves).BeginInit();
            rndDungeonTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uxMaxYOfRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uxMaxXOfRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uxMinYOfRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uxMinXOfRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uxNumOfRooms).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsSplitContainer).BeginInit();
            SettingsSplitContainer.Panel1.SuspendLayout();
            SettingsSplitContainer.Panel2.SuspendLayout();
            SettingsSplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pctPreview
            // 
            pctPreview.BorderStyle = BorderStyle.FixedSingle;
            pctPreview.Location = new Point(2, 3);
            pctPreview.Margin = new Padding(4, 3, 4, 3);
            pctPreview.MaximumSize = new Size(700, 692);
            pctPreview.MinimumSize = new Size(525, 519);
            pctPreview.Name = "pctPreview";
            pctPreview.Size = new Size(700, 692);
            pctPreview.TabIndex = 1;
            pctPreview.TabStop = false;
            // 
            // tabGenSettings
            // 
            tabGenSettings.Controls.Add(tabPgFromFile);
            tabGenSettings.Controls.Add(tabPgProcDS);
            tabGenSettings.Controls.Add(tabProcRW);
            tabGenSettings.Controls.Add(tabProcCA);
            tabGenSettings.Controls.Add(tabProcPN);
            tabGenSettings.Controls.Add(rndDungeonTab);
            tabGenSettings.Dock = DockStyle.Fill;
            tabGenSettings.Location = new Point(0, 0);
            tabGenSettings.Margin = new Padding(4, 3, 4, 3);
            tabGenSettings.Name = "tabGenSettings";
            tabGenSettings.SelectedIndex = 0;
            tabGenSettings.Size = new Size(577, 335);
            tabGenSettings.TabIndex = 0;
            // 
            // tabPgFromFile
            // 
            tabPgFromFile.Controls.Add(label1);
            tabPgFromFile.Controls.Add(txtMapFilePath);
            tabPgFromFile.Controls.Add(btnGetMapFile);
            tabPgFromFile.Location = new Point(4, 24);
            tabPgFromFile.Margin = new Padding(4, 3, 4, 3);
            tabPgFromFile.Name = "tabPgFromFile";
            tabPgFromFile.Padding = new Padding(4, 3, 4, 3);
            tabPgFromFile.Size = new Size(569, 307);
            tabPgFromFile.TabIndex = 0;
            tabPgFromFile.Text = "From File";
            tabPgFromFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 2;
            label1.Text = "Map File Path";
            // 
            // txtMapFilePath
            // 
            txtMapFilePath.Location = new Point(7, 29);
            txtMapFilePath.Margin = new Padding(4, 3, 4, 3);
            txtMapFilePath.Name = "txtMapFilePath";
            txtMapFilePath.Size = new Size(306, 23);
            txtMapFilePath.TabIndex = 0;
            // 
            // btnGetMapFile
            // 
            btnGetMapFile.Location = new Point(7, 59);
            btnGetMapFile.Margin = new Padding(4, 3, 4, 3);
            btnGetMapFile.Name = "btnGetMapFile";
            btnGetMapFile.Size = new Size(88, 27);
            btnGetMapFile.TabIndex = 1;
            btnGetMapFile.Text = "Load File";
            btnGetMapFile.UseVisualStyleBackColor = true;
            btnGetMapFile.Click += btnGetMapFile_Click;
            // 
            // tabPgProcDS
            // 
            tabPgProcDS.Controls.Add(btn_ManageColorMaps);
            tabPgProcDS.Controls.Add(label7);
            tabPgProcDS.Controls.Add(label6);
            tabPgProcDS.Controls.Add(cmbColorMapStyle);
            tabPgProcDS.Controls.Add(cmbColorMap);
            tabPgProcDS.Controls.Add(label5);
            tabPgProcDS.Controls.Add(txtDiamondValueSpread);
            tabPgProcDS.Controls.Add(label4);
            tabPgProcDS.Controls.Add(label3);
            tabPgProcDS.Controls.Add(label2);
            tabPgProcDS.Controls.Add(btnGenerateDiamondSquare);
            tabPgProcDS.Controls.Add(txtDiamondBaseValue);
            tabPgProcDS.Controls.Add(txtDiamondMapHeight);
            tabPgProcDS.Controls.Add(txtDiamondMapWidth);
            tabPgProcDS.Location = new Point(4, 24);
            tabPgProcDS.Margin = new Padding(4, 3, 4, 3);
            tabPgProcDS.Name = "tabPgProcDS";
            tabPgProcDS.Padding = new Padding(4, 3, 4, 3);
            tabPgProcDS.Size = new Size(569, 307);
            tabPgProcDS.TabIndex = 1;
            tabPgProcDS.Text = "Diamond Square";
            tabPgProcDS.UseVisualStyleBackColor = true;
            // 
            // btn_ManageColorMaps
            // 
            btn_ManageColorMaps.Location = new Point(259, 136);
            btn_ManageColorMaps.Margin = new Padding(4, 3, 4, 3);
            btn_ManageColorMaps.Name = "btn_ManageColorMaps";
            btn_ManageColorMaps.Size = new Size(65, 24);
            btn_ManageColorMaps.TabIndex = 5;
            btn_ManageColorMaps.Text = "Manage";
            btn_ManageColorMaps.UseVisualStyleBackColor = true;
            btn_ManageColorMaps.Click += btn_ManageColorMaps_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 173);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 12;
            label7.Text = "Color Map Style";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 140);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 11;
            label6.Text = "Color Map";
            // 
            // cmbColorMapStyle
            // 
            cmbColorMapStyle.FormattingEnabled = true;
            cmbColorMapStyle.Location = new Point(111, 170);
            cmbColorMapStyle.Margin = new Padding(4, 3, 4, 3);
            cmbColorMapStyle.Name = "cmbColorMapStyle";
            cmbColorMapStyle.Size = new Size(140, 23);
            cmbColorMapStyle.TabIndex = 6;
            // 
            // cmbColorMap
            // 
            cmbColorMap.FormattingEnabled = true;
            cmbColorMap.Location = new Point(111, 136);
            cmbColorMap.Margin = new Padding(4, 3, 4, 3);
            cmbColorMap.Name = "cmbColorMap";
            cmbColorMap.Size = new Size(140, 23);
            cmbColorMap.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 110);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 8;
            label5.Text = "Seed";
            // 
            // txtDiamondValueSpread
            // 
            txtDiamondValueSpread.Location = new Point(111, 106);
            txtDiamondValueSpread.Margin = new Padding(4, 3, 4, 3);
            txtDiamondValueSpread.Name = "txtDiamondValueSpread";
            txtDiamondValueSpread.Size = new Size(87, 23);
            txtDiamondValueSpread.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 80);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 6;
            label4.Text = "Base Value";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 50);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 5;
            label3.Text = "Map Height";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 20);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 4;
            label2.Text = "Map Width";
            // 
            // btnGenerateDiamondSquare
            // 
            btnGenerateDiamondSquare.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerateDiamondSquare.Location = new Point(236, 200);
            btnGenerateDiamondSquare.Margin = new Padding(4, 3, 4, 3);
            btnGenerateDiamondSquare.Name = "btnGenerateDiamondSquare";
            btnGenerateDiamondSquare.Size = new Size(88, 27);
            btnGenerateDiamondSquare.TabIndex = 7;
            btnGenerateDiamondSquare.Text = "Generate";
            btnGenerateDiamondSquare.UseVisualStyleBackColor = true;
            btnGenerateDiamondSquare.Click += btnGenerateDiamondSquare_Click;
            // 
            // txtDiamondBaseValue
            // 
            txtDiamondBaseValue.Location = new Point(111, 76);
            txtDiamondBaseValue.Margin = new Padding(4, 3, 4, 3);
            txtDiamondBaseValue.Name = "txtDiamondBaseValue";
            txtDiamondBaseValue.Size = new Size(87, 23);
            txtDiamondBaseValue.TabIndex = 2;
            // 
            // txtDiamondMapHeight
            // 
            txtDiamondMapHeight.Location = new Point(111, 46);
            txtDiamondMapHeight.Margin = new Padding(4, 3, 4, 3);
            txtDiamondMapHeight.Name = "txtDiamondMapHeight";
            txtDiamondMapHeight.Size = new Size(87, 23);
            txtDiamondMapHeight.TabIndex = 1;
            // 
            // txtDiamondMapWidth
            // 
            txtDiamondMapWidth.Location = new Point(111, 16);
            txtDiamondMapWidth.Margin = new Padding(4, 3, 4, 3);
            txtDiamondMapWidth.Name = "txtDiamondMapWidth";
            txtDiamondMapWidth.Size = new Size(87, 23);
            txtDiamondMapWidth.TabIndex = 0;
            // 
            // tabProcRW
            // 
            tabProcRW.Controls.Add(chkRandomWalkAvoidClusters);
            tabProcRW.Controls.Add(chkRandomWalkAvoidEdges);
            tabProcRW.Controls.Add(txtRandomWalkIterations);
            tabProcRW.Controls.Add(label11);
            tabProcRW.Controls.Add(txtRandomWalkStart);
            tabProcRW.Controls.Add(label10);
            tabProcRW.Controls.Add(label8);
            tabProcRW.Controls.Add(label9);
            tabProcRW.Controls.Add(txtRandomWalkHeight);
            tabProcRW.Controls.Add(txtRandomWalkWidth);
            tabProcRW.Controls.Add(btnRandomWalkGenerate);
            tabProcRW.Location = new Point(4, 24);
            tabProcRW.Margin = new Padding(4, 3, 4, 3);
            tabProcRW.Name = "tabProcRW";
            tabProcRW.Padding = new Padding(4, 3, 4, 3);
            tabProcRW.Size = new Size(569, 307);
            tabProcRW.TabIndex = 2;
            tabProcRW.Text = "Random Walk";
            tabProcRW.UseVisualStyleBackColor = true;
            // 
            // chkRandomWalkAvoidClusters
            // 
            chkRandomWalkAvoidClusters.AutoSize = true;
            chkRandomWalkAvoidClusters.Location = new Point(145, 140);
            chkRandomWalkAvoidClusters.Margin = new Padding(4, 3, 4, 3);
            chkRandomWalkAvoidClusters.Name = "chkRandomWalkAvoidClusters";
            chkRandomWalkAvoidClusters.RightToLeft = RightToLeft.Yes;
            chkRandomWalkAvoidClusters.Size = new Size(102, 19);
            chkRandomWalkAvoidClusters.TabIndex = 5;
            chkRandomWalkAvoidClusters.Text = "Avoid Clusters";
            chkRandomWalkAvoidClusters.UseVisualStyleBackColor = true;
            // 
            // chkRandomWalkAvoidEdges
            // 
            chkRandomWalkAvoidEdges.AutoSize = true;
            chkRandomWalkAvoidEdges.Location = new Point(37, 140);
            chkRandomWalkAvoidEdges.Margin = new Padding(4, 3, 4, 3);
            chkRandomWalkAvoidEdges.Name = "chkRandomWalkAvoidEdges";
            chkRandomWalkAvoidEdges.RightToLeft = RightToLeft.Yes;
            chkRandomWalkAvoidEdges.Size = new Size(91, 19);
            chkRandomWalkAvoidEdges.TabIndex = 4;
            chkRandomWalkAvoidEdges.Text = "Avoid Edges";
            chkRandomWalkAvoidEdges.UseVisualStyleBackColor = true;
            // 
            // txtRandomWalkIterations
            // 
            txtRandomWalkIterations.Increment = new decimal(new int[] { 25, 0, 0, 0 });
            txtRandomWalkIterations.Location = new Point(112, 81);
            txtRandomWalkIterations.Margin = new Padding(4, 3, 4, 3);
            txtRandomWalkIterations.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            txtRandomWalkIterations.Name = "txtRandomWalkIterations";
            txtRandomWalkIterations.Size = new Size(88, 23);
            txtRandomWalkIterations.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 113);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(77, 15);
            label11.TabIndex = 13;
            label11.Text = "Start Position";
            // 
            // txtRandomWalkStart
            // 
            txtRandomWalkStart.Location = new Point(112, 110);
            txtRandomWalkStart.Margin = new Padding(4, 3, 4, 3);
            txtRandomWalkStart.Name = "txtRandomWalkStart";
            txtRandomWalkStart.Size = new Size(87, 23);
            txtRandomWalkStart.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 83);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(56, 15);
            label10.TabIndex = 11;
            label10.Text = "Iterations";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 53);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 9;
            label8.Text = "Map Height";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 23);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 8;
            label9.Text = "Map Width";
            // 
            // txtRandomWalkHeight
            // 
            txtRandomWalkHeight.Location = new Point(112, 50);
            txtRandomWalkHeight.Margin = new Padding(4, 3, 4, 3);
            txtRandomWalkHeight.Name = "txtRandomWalkHeight";
            txtRandomWalkHeight.Size = new Size(87, 23);
            txtRandomWalkHeight.TabIndex = 1;
            // 
            // txtRandomWalkWidth
            // 
            txtRandomWalkWidth.Location = new Point(112, 20);
            txtRandomWalkWidth.Margin = new Padding(4, 3, 4, 3);
            txtRandomWalkWidth.Name = "txtRandomWalkWidth";
            txtRandomWalkWidth.Size = new Size(87, 23);
            txtRandomWalkWidth.TabIndex = 0;
            // 
            // btnRandomWalkGenerate
            // 
            btnRandomWalkGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRandomWalkGenerate.Location = new Point(111, 166);
            btnRandomWalkGenerate.Margin = new Padding(4, 3, 4, 3);
            btnRandomWalkGenerate.Name = "btnRandomWalkGenerate";
            btnRandomWalkGenerate.Size = new Size(88, 27);
            btnRandomWalkGenerate.TabIndex = 4;
            btnRandomWalkGenerate.Text = "Generate";
            btnRandomWalkGenerate.UseVisualStyleBackColor = true;
            btnRandomWalkGenerate.Click += btnRandomWalkGenerate_Click;
            // 
            // tabProcCA
            // 
            tabProcCA.Controls.Add(chkCellAutomataAvoidEdges);
            tabProcCA.Controls.Add(txtCellAutomataIterations);
            tabProcCA.Controls.Add(label12);
            tabProcCA.Controls.Add(label13);
            tabProcCA.Controls.Add(label14);
            tabProcCA.Controls.Add(txtCellAutomataHeight);
            tabProcCA.Controls.Add(txtCellAutomataWidth);
            tabProcCA.Controls.Add(btnGenerateCellAutomata);
            tabProcCA.Location = new Point(4, 24);
            tabProcCA.Margin = new Padding(4, 3, 4, 3);
            tabProcCA.Name = "tabProcCA";
            tabProcCA.Padding = new Padding(4, 3, 4, 3);
            tabProcCA.Size = new Size(569, 307);
            tabProcCA.TabIndex = 3;
            tabProcCA.Text = "Cell Automata";
            tabProcCA.UseVisualStyleBackColor = true;
            // 
            // chkCellAutomataAvoidEdges
            // 
            chkCellAutomataAvoidEdges.AutoSize = true;
            chkCellAutomataAvoidEdges.Location = new Point(15, 104);
            chkCellAutomataAvoidEdges.Margin = new Padding(4, 3, 4, 3);
            chkCellAutomataAvoidEdges.Name = "chkCellAutomataAvoidEdges";
            chkCellAutomataAvoidEdges.RightToLeft = RightToLeft.Yes;
            chkCellAutomataAvoidEdges.Size = new Size(91, 19);
            chkCellAutomataAvoidEdges.TabIndex = 3;
            chkCellAutomataAvoidEdges.Text = "Avoid Edges";
            chkCellAutomataAvoidEdges.UseVisualStyleBackColor = true;
            // 
            // txtCellAutomataIterations
            // 
            txtCellAutomataIterations.Location = new Point(107, 74);
            txtCellAutomataIterations.Margin = new Padding(4, 3, 4, 3);
            txtCellAutomataIterations.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            txtCellAutomataIterations.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtCellAutomataIterations.Name = "txtCellAutomataIterations";
            txtCellAutomataIterations.Size = new Size(88, 23);
            txtCellAutomataIterations.TabIndex = 2;
            txtCellAutomataIterations.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 76);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(56, 15);
            label12.TabIndex = 19;
            label12.Text = "Iterations";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 46);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(70, 15);
            label13.TabIndex = 18;
            label13.Text = "Map Height";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 16);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(66, 15);
            label14.TabIndex = 17;
            label14.Text = "Map Width";
            // 
            // txtCellAutomataHeight
            // 
            txtCellAutomataHeight.Location = new Point(107, 43);
            txtCellAutomataHeight.Margin = new Padding(4, 3, 4, 3);
            txtCellAutomataHeight.Name = "txtCellAutomataHeight";
            txtCellAutomataHeight.Size = new Size(87, 23);
            txtCellAutomataHeight.TabIndex = 1;
            // 
            // txtCellAutomataWidth
            // 
            txtCellAutomataWidth.Location = new Point(107, 13);
            txtCellAutomataWidth.Margin = new Padding(4, 3, 4, 3);
            txtCellAutomataWidth.Name = "txtCellAutomataWidth";
            txtCellAutomataWidth.Size = new Size(87, 23);
            txtCellAutomataWidth.TabIndex = 0;
            // 
            // btnGenerateCellAutomata
            // 
            btnGenerateCellAutomata.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerateCellAutomata.Location = new Point(106, 130);
            btnGenerateCellAutomata.Margin = new Padding(4, 3, 4, 3);
            btnGenerateCellAutomata.Name = "btnGenerateCellAutomata";
            btnGenerateCellAutomata.Size = new Size(88, 27);
            btnGenerateCellAutomata.TabIndex = 4;
            btnGenerateCellAutomata.Text = "Generate";
            btnGenerateCellAutomata.UseVisualStyleBackColor = true;
            btnGenerateCellAutomata.Click += btnGenerateCellAutomata_Click;
            // 
            // tabProcPN
            // 
            tabProcPN.Controls.Add(label26);
            tabProcPN.Controls.Add(uxPerlinNoiseGrid);
            tabProcPN.Controls.Add(label25);
            tabProcPN.Controls.Add(uxPerlinNoiseAmp);
            tabProcPN.Controls.Add(label24);
            tabProcPN.Controls.Add(uxPerlinNoiseFreq);
            tabProcPN.Controls.Add(uxPerlinNoiseOctaves);
            tabProcPN.Controls.Add(label20);
            tabProcPN.Controls.Add(uxPerlinNoisePersistence);
            tabProcPN.Controls.Add(label21);
            tabProcPN.Controls.Add(label22);
            tabProcPN.Controls.Add(label23);
            tabProcPN.Controls.Add(uxPerlinNoiseHeight);
            tabProcPN.Controls.Add(uxPerlinNoiseWidth);
            tabProcPN.Controls.Add(uxGeneratePerlinNoise);
            tabProcPN.Location = new Point(4, 24);
            tabProcPN.Name = "tabProcPN";
            tabProcPN.Padding = new Padding(3);
            tabProcPN.Size = new Size(569, 307);
            tabProcPN.TabIndex = 5;
            tabProcPN.Text = "Perlin Noise";
            tabProcPN.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(19, 168);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(63, 15);
            label25.TabIndex = 28;
            label25.Text = "Amplitude";
            // 
            // uxPerlinNoiseAmp
            // 
            uxPerlinNoiseAmp.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            uxPerlinNoiseAmp.Location = new Point(115, 165);
            uxPerlinNoiseAmp.Margin = new Padding(4, 3, 4, 3);
            uxPerlinNoiseAmp.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            uxPerlinNoiseAmp.Name = "uxPerlinNoiseAmp";
            uxPerlinNoiseAmp.Size = new Size(87, 23);
            uxPerlinNoiseAmp.TabIndex = 5;
            uxPerlinNoiseAmp.Value = new decimal(new int[] { 128, 0, 0, 0 });
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(18, 139);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(62, 15);
            label24.TabIndex = 26;
            label24.Text = "Frequency";
            // 
            // uxPerlinNoiseFreq
            // 
            uxPerlinNoiseFreq.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            uxPerlinNoiseFreq.Location = new Point(114, 136);
            uxPerlinNoiseFreq.Margin = new Padding(4, 3, 4, 3);
            uxPerlinNoiseFreq.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            uxPerlinNoiseFreq.Name = "uxPerlinNoiseFreq";
            uxPerlinNoiseFreq.Size = new Size(87, 23);
            uxPerlinNoiseFreq.TabIndex = 4;
            uxPerlinNoiseFreq.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // uxPerlinNoiseOctaves
            // 
            uxPerlinNoiseOctaves.Location = new Point(114, 78);
            uxPerlinNoiseOctaves.Margin = new Padding(4, 3, 4, 3);
            uxPerlinNoiseOctaves.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            uxPerlinNoiseOctaves.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            uxPerlinNoiseOctaves.Name = "uxPerlinNoiseOctaves";
            uxPerlinNoiseOctaves.Size = new Size(88, 23);
            uxPerlinNoiseOctaves.TabIndex = 2;
            uxPerlinNoiseOctaves.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(18, 110);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(66, 15);
            label20.TabIndex = 24;
            label20.Text = "Persistence";
            // 
            // uxPerlinNoisePersistence
            // 
            uxPerlinNoisePersistence.Location = new Point(114, 107);
            uxPerlinNoisePersistence.Margin = new Padding(4, 3, 4, 3);
            uxPerlinNoisePersistence.Name = "uxPerlinNoisePersistence";
            uxPerlinNoisePersistence.Size = new Size(87, 23);
            uxPerlinNoisePersistence.TabIndex = 3;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(18, 80);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(49, 15);
            label21.TabIndex = 23;
            label21.Text = "Octaves";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(18, 50);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(70, 15);
            label22.TabIndex = 22;
            label22.Text = "Map Height";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(18, 20);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(66, 15);
            label23.TabIndex = 21;
            label23.Text = "Map Width";
            // 
            // uxPerlinNoiseHeight
            // 
            uxPerlinNoiseHeight.Location = new Point(114, 47);
            uxPerlinNoiseHeight.Margin = new Padding(4, 3, 4, 3);
            uxPerlinNoiseHeight.Name = "uxPerlinNoiseHeight";
            uxPerlinNoiseHeight.Size = new Size(87, 23);
            uxPerlinNoiseHeight.TabIndex = 1;
            // 
            // uxPerlinNoiseWidth
            // 
            uxPerlinNoiseWidth.Location = new Point(114, 17);
            uxPerlinNoiseWidth.Margin = new Padding(4, 3, 4, 3);
            uxPerlinNoiseWidth.Name = "uxPerlinNoiseWidth";
            uxPerlinNoiseWidth.Size = new Size(87, 23);
            uxPerlinNoiseWidth.TabIndex = 0;
            // 
            // uxGeneratePerlinNoise
            // 
            uxGeneratePerlinNoise.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            uxGeneratePerlinNoise.Location = new Point(113, 260);
            uxGeneratePerlinNoise.Margin = new Padding(4, 3, 4, 3);
            uxGeneratePerlinNoise.Name = "uxGeneratePerlinNoise";
            uxGeneratePerlinNoise.Size = new Size(88, 27);
            uxGeneratePerlinNoise.TabIndex = 7;
            uxGeneratePerlinNoise.Text = "Generate";
            uxGeneratePerlinNoise.UseVisualStyleBackColor = true;
            uxGeneratePerlinNoise.Click += uxGeneratePerlinNoise_Click;
            // 
            // rndDungeonTab
            // 
            rndDungeonTab.Controls.Add(label18);
            rndDungeonTab.Controls.Add(label19);
            rndDungeonTab.Controls.Add(uxDungeonHeight);
            rndDungeonTab.Controls.Add(uxDungeonWidth);
            rndDungeonTab.Controls.Add(uxGenerateRandomDungeon);
            rndDungeonTab.Controls.Add(label17);
            rndDungeonTab.Controls.Add(label16);
            rndDungeonTab.Controls.Add(label15);
            rndDungeonTab.Controls.Add(uxMaxYOfRooms);
            rndDungeonTab.Controls.Add(uxMaxXOfRooms);
            rndDungeonTab.Controls.Add(uxMinYOfRooms);
            rndDungeonTab.Controls.Add(uxMinXOfRooms);
            rndDungeonTab.Controls.Add(uxNumOfRooms);
            rndDungeonTab.Location = new Point(4, 24);
            rndDungeonTab.Margin = new Padding(4, 3, 4, 3);
            rndDungeonTab.Name = "rndDungeonTab";
            rndDungeonTab.Padding = new Padding(4, 3, 4, 3);
            rndDungeonTab.Size = new Size(569, 307);
            rndDungeonTab.TabIndex = 4;
            rndDungeonTab.Text = "Random Dungeon";
            rndDungeonTab.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(15, 40);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(70, 15);
            label18.TabIndex = 22;
            label18.Text = "Map Height";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(15, 10);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(66, 15);
            label19.TabIndex = 21;
            label19.Text = "Map Width";
            // 
            // uxDungeonHeight
            // 
            uxDungeonHeight.Location = new Point(111, 37);
            uxDungeonHeight.Margin = new Padding(4, 3, 4, 3);
            uxDungeonHeight.Name = "uxDungeonHeight";
            uxDungeonHeight.Size = new Size(87, 23);
            uxDungeonHeight.TabIndex = 1;
            // 
            // uxDungeonWidth
            // 
            uxDungeonWidth.Location = new Point(111, 7);
            uxDungeonWidth.Margin = new Padding(4, 3, 4, 3);
            uxDungeonWidth.Name = "uxDungeonWidth";
            uxDungeonWidth.Size = new Size(87, 23);
            uxDungeonWidth.TabIndex = 0;
            // 
            // uxGenerateRandomDungeon
            // 
            uxGenerateRandomDungeon.Location = new Point(205, 163);
            uxGenerateRandomDungeon.Margin = new Padding(4, 3, 4, 3);
            uxGenerateRandomDungeon.Name = "uxGenerateRandomDungeon";
            uxGenerateRandomDungeon.Size = new Size(88, 27);
            uxGenerateRandomDungeon.TabIndex = 10;
            uxGenerateRandomDungeon.Text = "Generate";
            uxGenerateRandomDungeon.UseVisualStyleBackColor = true;
            uxGenerateRandomDungeon.Click += uxGenerateRandomDungeon_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(15, 135);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(113, 15);
            label17.TabIndex = 7;
            label17.Text = "Maximum Size (x/y)";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(15, 105);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(111, 15);
            label16.TabIndex = 6;
            label16.Text = "Minimum Size (x/y)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(15, 75);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(105, 15);
            label15.TabIndex = 5;
            label15.Text = "Number of Rooms";
            // 
            // uxMaxYOfRooms
            // 
            uxMaxYOfRooms.Location = new Point(224, 133);
            uxMaxYOfRooms.Margin = new Padding(4, 3, 4, 3);
            uxMaxYOfRooms.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            uxMaxYOfRooms.Name = "uxMaxYOfRooms";
            uxMaxYOfRooms.Size = new Size(69, 23);
            uxMaxYOfRooms.TabIndex = 6;
            uxMaxYOfRooms.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // uxMaxXOfRooms
            // 
            uxMaxXOfRooms.Location = new Point(148, 133);
            uxMaxXOfRooms.Margin = new Padding(4, 3, 4, 3);
            uxMaxXOfRooms.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            uxMaxXOfRooms.Name = "uxMaxXOfRooms";
            uxMaxXOfRooms.Size = new Size(69, 23);
            uxMaxXOfRooms.TabIndex = 5;
            uxMaxXOfRooms.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // uxMinYOfRooms
            // 
            uxMinYOfRooms.Location = new Point(224, 103);
            uxMinYOfRooms.Margin = new Padding(4, 3, 4, 3);
            uxMinYOfRooms.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            uxMinYOfRooms.Name = "uxMinYOfRooms";
            uxMinYOfRooms.Size = new Size(69, 23);
            uxMinYOfRooms.TabIndex = 4;
            uxMinYOfRooms.Value = new decimal(new int[] { 4, 0, 0, 0 });
            uxMinYOfRooms.ValueChanged += uxMinXYOfRooms_ValueChanged;
            // 
            // uxMinXOfRooms
            // 
            uxMinXOfRooms.Location = new Point(148, 103);
            uxMinXOfRooms.Margin = new Padding(4, 3, 4, 3);
            uxMinXOfRooms.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            uxMinXOfRooms.Name = "uxMinXOfRooms";
            uxMinXOfRooms.Size = new Size(69, 23);
            uxMinXOfRooms.TabIndex = 3;
            uxMinXOfRooms.Value = new decimal(new int[] { 4, 0, 0, 0 });
            uxMinXOfRooms.ValueChanged += uxMinXYOfRooms_ValueChanged;
            // 
            // uxNumOfRooms
            // 
            uxNumOfRooms.Location = new Point(148, 73);
            uxNumOfRooms.Margin = new Padding(4, 3, 4, 3);
            uxNumOfRooms.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            uxNumOfRooms.Name = "uxNumOfRooms";
            uxNumOfRooms.Size = new Size(145, 23);
            uxNumOfRooms.TabIndex = 2;
            uxNumOfRooms.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // txtStatus
            // 
            txtStatus.Dock = DockStyle.Fill;
            txtStatus.Location = new Point(0, 0);
            txtStatus.Margin = new Padding(4, 3, 4, 3);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(577, 378);
            txtStatus.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1317, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveMapToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveMapToolStripMenuItem
            // 
            saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            saveMapToolStripMenuItem.Size = new Size(125, 22);
            saveMapToolStripMenuItem.Text = "Save Map";
            saveMapToolStripMenuItem.Click += saveMapToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(125, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(102, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.Location = new Point(0, 24);
            MainSplitContainer.Margin = new Padding(4, 3, 4, 3);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(SettingsSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.Controls.Add(pctPreview);
            MainSplitContainer.Panel2MinSize = 460;
            MainSplitContainer.Size = new Size(1317, 718);
            MainSplitContainer.SplitterDistance = 577;
            MainSplitContainer.SplitterWidth = 5;
            MainSplitContainer.TabIndex = 4;
            // 
            // SettingsSplitContainer
            // 
            SettingsSplitContainer.Dock = DockStyle.Fill;
            SettingsSplitContainer.Location = new Point(0, 0);
            SettingsSplitContainer.Margin = new Padding(4, 3, 4, 3);
            SettingsSplitContainer.Name = "SettingsSplitContainer";
            SettingsSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // SettingsSplitContainer.Panel1
            // 
            SettingsSplitContainer.Panel1.Controls.Add(tabGenSettings);
            SettingsSplitContainer.Panel1.RightToLeft = RightToLeft.No;
            // 
            // SettingsSplitContainer.Panel2
            // 
            SettingsSplitContainer.Panel2.Controls.Add(txtStatus);
            SettingsSplitContainer.Panel2.RightToLeft = RightToLeft.No;
            SettingsSplitContainer.RightToLeft = RightToLeft.No;
            SettingsSplitContainer.Size = new Size(577, 718);
            SettingsSplitContainer.SplitterDistance = 335;
            SettingsSplitContainer.SplitterWidth = 5;
            SettingsSplitContainer.TabIndex = 0;
            // 
            // uxPerlinNoiseGrid
            // 
            uxPerlinNoiseGrid.FormattingEnabled = true;
            uxPerlinNoiseGrid.Items.AddRange(new object[] { "Simple (4)", "Complex (12)" });
            uxPerlinNoiseGrid.Location = new Point(113, 194);
            uxPerlinNoiseGrid.Name = "uxPerlinNoiseGrid";
            uxPerlinNoiseGrid.Size = new Size(88, 23);
            uxPerlinNoiseGrid.TabIndex = 6;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(19, 197);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new Size(75, 15);
            label26.TabIndex = 30;
            label26.Text = "Gradient Size";
            // 
            // MapGeneratorMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 742);
            Controls.Add(MainSplitContainer);
            Controls.Add(menuStrip1);
            Margin = new Padding(5, 3, 5, 3);
            MinimumSize = new Size(931, 609);
            Name = "MapGeneratorMainForm";
            Text = "Map Generator";
            ((System.ComponentModel.ISupportInitialize)pctPreview).EndInit();
            tabGenSettings.ResumeLayout(false);
            tabPgFromFile.ResumeLayout(false);
            tabPgFromFile.PerformLayout();
            tabPgProcDS.ResumeLayout(false);
            tabPgProcDS.PerformLayout();
            tabProcRW.ResumeLayout(false);
            tabProcRW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtRandomWalkIterations).EndInit();
            tabProcCA.ResumeLayout(false);
            tabProcCA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtCellAutomataIterations).EndInit();
            tabProcPN.ResumeLayout(false);
            tabProcPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uxPerlinNoiseAmp).EndInit();
            ((System.ComponentModel.ISupportInitialize)uxPerlinNoiseFreq).EndInit();
            ((System.ComponentModel.ISupportInitialize)uxPerlinNoiseOctaves).EndInit();
            rndDungeonTab.ResumeLayout(false);
            rndDungeonTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uxMaxYOfRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)uxMaxXOfRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)uxMinYOfRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)uxMinXOfRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)uxNumOfRooms).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            SettingsSplitContainer.Panel1.ResumeLayout(false);
            SettingsSplitContainer.Panel2.ResumeLayout(false);
            SettingsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsSplitContainer).EndInit();
            SettingsSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox pctPreview;
        private System.Windows.Forms.TabControl tabGenSettings;
        private System.Windows.Forms.TabPage tabPgFromFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMapFilePath;
        private System.Windows.Forms.Button btnGetMapFile;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPgProcDS;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer SettingsSplitContainer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiamondValueSpread;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerateDiamondSquare;
        private System.Windows.Forms.TextBox txtDiamondBaseValue;
        private System.Windows.Forms.TextBox txtDiamondMapHeight;
        private System.Windows.Forms.TextBox txtDiamondMapWidth;
        private System.Windows.Forms.TabPage tabProcRW;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbColorMapStyle;
        private System.Windows.Forms.ComboBox cmbColorMap;
        private System.Windows.Forms.Button btnRandomWalkGenerate;
        private System.Windows.Forms.NumericUpDown txtRandomWalkIterations;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRandomWalkStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRandomWalkHeight;
        private System.Windows.Forms.TextBox txtRandomWalkWidth;
        private System.Windows.Forms.CheckBox chkRandomWalkAvoidEdges;
        private System.Windows.Forms.Button btn_ManageColorMaps;
        private System.Windows.Forms.TabPage tabProcCA;
        private System.Windows.Forms.CheckBox chkCellAutomataAvoidEdges;
        private System.Windows.Forms.NumericUpDown txtCellAutomataIterations;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCellAutomataHeight;
        private System.Windows.Forms.TextBox txtCellAutomataWidth;
        private System.Windows.Forms.Button btnGenerateCellAutomata;
        private System.Windows.Forms.TabPage rndDungeonTab;
        private System.Windows.Forms.Button uxGenerateRandomDungeon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown uxMaxYOfRooms;
        private System.Windows.Forms.NumericUpDown uxMaxXOfRooms;
        private System.Windows.Forms.NumericUpDown uxMinYOfRooms;
        private System.Windows.Forms.NumericUpDown uxMinXOfRooms;
        private System.Windows.Forms.NumericUpDown uxNumOfRooms;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox uxDungeonHeight;
        private System.Windows.Forms.TextBox uxDungeonWidth;
        private System.Windows.Forms.CheckBox chkRandomWalkAvoidClusters;
        private TabPage tabProcPN;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private NumericUpDown uxPerlinNoiseOctaves;
        private Label label20;
        private NumericUpDown uxPerlinNoiseFreq;
        private Label label21;
        private Label label22;
        private Label label23;
        private TextBox uxPerlinNoiseHeight;
        private TextBox uxPerlinNoiseWidth;
        private TextBox uxPerlinNoisePersistence;
        private Button uxGeneratePerlinNoise;
        private Label label25;
        private NumericUpDown uxPerlinNoiseAmp;
        private Label label24;
        private Label label26;
        private ComboBox uxPerlinNoiseGrid;
    }
}

