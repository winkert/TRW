namespace DungeonGenerator
{
    partial class DungeonGeneratorMain
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
            this.saveDungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDungeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCreaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxGenerateDungeonButton = new System.Windows.Forms.Button();
            this.uxGenSettingsGroup = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uxRoomTypeCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uxHallwayStyleCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uxNumberOfRooms = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uxMaxHOfRooms = new System.Windows.Forms.NumericUpDown();
            this.uxMaxWOfRooms = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uxMinHOfRooms = new System.Windows.Forms.NumericUpDown();
            this.uxMinWOfRooms = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxDungeonHeight = new System.Windows.Forms.NumericUpDown();
            this.uxDungeonWidth = new System.Windows.Forms.NumericUpDown();
            this.uxDungeonPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.uxAllowIntersectingRoomsCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxMainSplitContainer)).BeginInit();
            this.uxMainSplitContainer.Panel1.SuspendLayout();
            this.uxMainSplitContainer.Panel2.SuspendLayout();
            this.uxMainSplitContainer.SuspendLayout();
            this.uxGenSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMaxHOfRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMaxWOfRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinHOfRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinWOfRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDungeonHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDungeonWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDungeonPreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDungeonToolStripMenuItem,
            this.loadDungeonToolStripMenuItem,
            this.exportDungeonToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveDungeonToolStripMenuItem
            // 
            this.saveDungeonToolStripMenuItem.Name = "saveDungeonToolStripMenuItem";
            this.saveDungeonToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveDungeonToolStripMenuItem.Text = "Save Dungeon";
            this.saveDungeonToolStripMenuItem.Click += new System.EventHandler(this.saveDungeonToolStripMenuItem_Click);
            // 
            // loadDungeonToolStripMenuItem
            // 
            this.loadDungeonToolStripMenuItem.Name = "loadDungeonToolStripMenuItem";
            this.loadDungeonToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadDungeonToolStripMenuItem.Text = "Load Dungeon";
            this.loadDungeonToolStripMenuItem.Click += new System.EventHandler(this.loadDungeonToolStripMenuItem_Click);
            // 
            // exportDungeonToolStripMenuItem
            // 
            this.exportDungeonToolStripMenuItem.Name = "exportDungeonToolStripMenuItem";
            this.exportDungeonToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exportDungeonToolStripMenuItem.Text = "Export Dungeon";
            this.exportDungeonToolStripMenuItem.Click += new System.EventHandler(this.exportDungeonToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editLootToolStripMenuItem,
            this.editCreaturesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editLootToolStripMenuItem
            // 
            this.editLootToolStripMenuItem.Name = "editLootToolStripMenuItem";
            this.editLootToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editLootToolStripMenuItem.Text = "Edit Loot";
            this.editLootToolStripMenuItem.Click += new System.EventHandler(this.editLootToolStripMenuItem_Click);
            // 
            // editCreaturesToolStripMenuItem
            // 
            this.editCreaturesToolStripMenuItem.Name = "editCreaturesToolStripMenuItem";
            this.editCreaturesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editCreaturesToolStripMenuItem.Text = "Edit Creatures";
            this.editCreaturesToolStripMenuItem.Click += new System.EventHandler(this.editCreaturesToolStripMenuItem_Click);
            // 
            // uxMainSplitContainer
            // 
            this.uxMainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxMainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.uxMainSplitContainer.Name = "uxMainSplitContainer";
            // 
            // uxMainSplitContainer.Panel1
            // 
            this.uxMainSplitContainer.Panel1.Controls.Add(this.uxGenerateDungeonButton);
            this.uxMainSplitContainer.Panel1.Controls.Add(this.uxGenSettingsGroup);
            this.uxMainSplitContainer.Panel1MinSize = 350;
            // 
            // uxMainSplitContainer.Panel2
            // 
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxDungeonPreviewPictureBox);
            this.uxMainSplitContainer.Panel2MinSize = 400;
            this.uxMainSplitContainer.Size = new System.Drawing.Size(1118, 576);
            this.uxMainSplitContainer.SplitterDistance = 351;
            this.uxMainSplitContainer.TabIndex = 1;
            // 
            // uxGenerateDungeonButton
            // 
            this.uxGenerateDungeonButton.Location = new System.Drawing.Point(255, 528);
            this.uxGenerateDungeonButton.Name = "uxGenerateDungeonButton";
            this.uxGenerateDungeonButton.Size = new System.Drawing.Size(87, 36);
            this.uxGenerateDungeonButton.TabIndex = 99;
            this.uxGenerateDungeonButton.Text = "Generate Dungeon";
            this.uxGenerateDungeonButton.UseVisualStyleBackColor = true;
            this.uxGenerateDungeonButton.Click += new System.EventHandler(this.uxGenerateDungeonButton_Click);
            // 
            // uxGenSettingsGroup
            // 
            this.uxGenSettingsGroup.Controls.Add(this.uxAllowIntersectingRoomsCheck);
            this.uxGenSettingsGroup.Controls.Add(this.label9);
            this.uxGenSettingsGroup.Controls.Add(this.uxRoomTypeCombo);
            this.uxGenSettingsGroup.Controls.Add(this.label8);
            this.uxGenSettingsGroup.Controls.Add(this.uxHallwayStyleCombo);
            this.uxGenSettingsGroup.Controls.Add(this.label7);
            this.uxGenSettingsGroup.Controls.Add(this.uxNumberOfRooms);
            this.uxGenSettingsGroup.Controls.Add(this.label5);
            this.uxGenSettingsGroup.Controls.Add(this.label6);
            this.uxGenSettingsGroup.Controls.Add(this.uxMaxHOfRooms);
            this.uxGenSettingsGroup.Controls.Add(this.uxMaxWOfRooms);
            this.uxGenSettingsGroup.Controls.Add(this.label3);
            this.uxGenSettingsGroup.Controls.Add(this.label4);
            this.uxGenSettingsGroup.Controls.Add(this.uxMinHOfRooms);
            this.uxGenSettingsGroup.Controls.Add(this.uxMinWOfRooms);
            this.uxGenSettingsGroup.Controls.Add(this.label2);
            this.uxGenSettingsGroup.Controls.Add(this.label1);
            this.uxGenSettingsGroup.Controls.Add(this.uxDungeonHeight);
            this.uxGenSettingsGroup.Controls.Add(this.uxDungeonWidth);
            this.uxGenSettingsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxGenSettingsGroup.Location = new System.Drawing.Point(0, 0);
            this.uxGenSettingsGroup.Name = "uxGenSettingsGroup";
            this.uxGenSettingsGroup.Size = new System.Drawing.Size(351, 364);
            this.uxGenSettingsGroup.TabIndex = 0;
            this.uxGenSettingsGroup.TabStop = false;
            this.uxGenSettingsGroup.Text = "Dungeon Generation Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Room Type";
            // 
            // uxRoomTypeCombo
            // 
            this.uxRoomTypeCombo.FormattingEnabled = true;
            this.uxRoomTypeCombo.Location = new System.Drawing.Point(149, 228);
            this.uxRoomTypeCombo.Name = "uxRoomTypeCombo";
            this.uxRoomTypeCombo.Size = new System.Drawing.Size(168, 21);
            this.uxRoomTypeCombo.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Hallway Creation Style";
            // 
            // uxHallwayStyleCombo
            // 
            this.uxHallwayStyleCombo.FormattingEnabled = true;
            this.uxHallwayStyleCombo.Location = new System.Drawing.Point(149, 192);
            this.uxHallwayStyleCombo.Name = "uxHallwayStyleCombo";
            this.uxHallwayStyleCombo.Size = new System.Drawing.Size(168, 21);
            this.uxHallwayStyleCombo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Number of Rooms";
            // 
            // uxNumberOfRooms
            // 
            this.uxNumberOfRooms.Location = new System.Drawing.Point(110, 91);
            this.uxNumberOfRooms.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.uxNumberOfRooms.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumberOfRooms.Name = "uxNumberOfRooms";
            this.uxNumberOfRooms.Size = new System.Drawing.Size(50, 20);
            this.uxNumberOfRooms.TabIndex = 2;
            this.uxNumberOfRooms.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Room Max Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Room Max Width";
            // 
            // uxMaxHOfRooms
            // 
            this.uxMaxHOfRooms.Location = new System.Drawing.Point(267, 153);
            this.uxMaxHOfRooms.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.uxMaxHOfRooms.Name = "uxMaxHOfRooms";
            this.uxMaxHOfRooms.Size = new System.Drawing.Size(50, 20);
            this.uxMaxHOfRooms.TabIndex = 6;
            this.uxMaxHOfRooms.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // uxMaxWOfRooms
            // 
            this.uxMaxWOfRooms.Location = new System.Drawing.Point(267, 127);
            this.uxMaxWOfRooms.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.uxMaxWOfRooms.Name = "uxMaxWOfRooms";
            this.uxMaxWOfRooms.Size = new System.Drawing.Size(50, 20);
            this.uxMaxWOfRooms.TabIndex = 5;
            this.uxMaxWOfRooms.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Room Min Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Room Min Width";
            // 
            // uxMinHOfRooms
            // 
            this.uxMinHOfRooms.Location = new System.Drawing.Point(110, 153);
            this.uxMinHOfRooms.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.uxMinHOfRooms.Name = "uxMinHOfRooms";
            this.uxMinHOfRooms.Size = new System.Drawing.Size(50, 20);
            this.uxMinHOfRooms.TabIndex = 4;
            this.uxMinHOfRooms.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.uxMinHOfRooms.ValueChanged += new System.EventHandler(this.uxMinXYOfRooms_ValueChanged);
            // 
            // uxMinWOfRooms
            // 
            this.uxMinWOfRooms.Location = new System.Drawing.Point(110, 127);
            this.uxMinWOfRooms.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.uxMinWOfRooms.Name = "uxMinWOfRooms";
            this.uxMinWOfRooms.Size = new System.Drawing.Size(50, 20);
            this.uxMinWOfRooms.TabIndex = 3;
            this.uxMinWOfRooms.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.uxMinWOfRooms.ValueChanged += new System.EventHandler(this.uxMinXYOfRooms_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // uxDungeonHeight
            // 
            this.uxDungeonHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uxDungeonHeight.Location = new System.Drawing.Point(85, 58);
            this.uxDungeonHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.uxDungeonHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxDungeonHeight.Name = "uxDungeonHeight";
            this.uxDungeonHeight.Size = new System.Drawing.Size(75, 20);
            this.uxDungeonHeight.TabIndex = 1;
            this.uxDungeonHeight.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // uxDungeonWidth
            // 
            this.uxDungeonWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uxDungeonWidth.Location = new System.Drawing.Point(85, 32);
            this.uxDungeonWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.uxDungeonWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxDungeonWidth.Name = "uxDungeonWidth";
            this.uxDungeonWidth.Size = new System.Drawing.Size(75, 20);
            this.uxDungeonWidth.TabIndex = 0;
            this.uxDungeonWidth.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // uxDungeonPreviewPictureBox
            // 
            this.uxDungeonPreviewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxDungeonPreviewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.uxDungeonPreviewPictureBox.Name = "uxDungeonPreviewPictureBox";
            this.uxDungeonPreviewPictureBox.Size = new System.Drawing.Size(763, 576);
            this.uxDungeonPreviewPictureBox.TabIndex = 0;
            this.uxDungeonPreviewPictureBox.TabStop = false;
            // 
            // uxAllowIntersectingRoomsCheck
            // 
            this.uxAllowIntersectingRoomsCheck.AutoSize = true;
            this.uxAllowIntersectingRoomsCheck.Location = new System.Drawing.Point(149, 255);
            this.uxAllowIntersectingRoomsCheck.Name = "uxAllowIntersectingRoomsCheck";
            this.uxAllowIntersectingRoomsCheck.Size = new System.Drawing.Size(145, 17);
            this.uxAllowIntersectingRoomsCheck.TabIndex = 18;
            this.uxAllowIntersectingRoomsCheck.Text = "Allow Intersecting Rooms";
            this.uxAllowIntersectingRoomsCheck.UseVisualStyleBackColor = true;
            // 
            // DungeonGeneratorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 600);
            this.Controls.Add(this.uxMainSplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DungeonGeneratorMain";
            this.Text = "Dungeon Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DungeonGeneratorMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.uxMainSplitContainer.Panel1.ResumeLayout(false);
            this.uxMainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxMainSplitContainer)).EndInit();
            this.uxMainSplitContainer.ResumeLayout(false);
            this.uxGenSettingsGroup.ResumeLayout(false);
            this.uxGenSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMaxHOfRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMaxWOfRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinHOfRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinWOfRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDungeonHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDungeonWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDungeonPreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDungeonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDungeonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDungeonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCreaturesToolStripMenuItem;
        private System.Windows.Forms.SplitContainer uxMainSplitContainer;
        private System.Windows.Forms.GroupBox uxGenSettingsGroup;
        private System.Windows.Forms.PictureBox uxDungeonPreviewPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uxDungeonHeight;
        private System.Windows.Forms.NumericUpDown uxDungeonWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown uxNumberOfRooms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uxMaxHOfRooms;
        private System.Windows.Forms.NumericUpDown uxMaxWOfRooms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown uxMinHOfRooms;
        private System.Windows.Forms.NumericUpDown uxMinWOfRooms;
        private System.Windows.Forms.Button uxGenerateDungeonButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox uxHallwayStyleCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox uxRoomTypeCombo;
        private System.Windows.Forms.CheckBox uxAllowIntersectingRoomsCheck;
    }
}

