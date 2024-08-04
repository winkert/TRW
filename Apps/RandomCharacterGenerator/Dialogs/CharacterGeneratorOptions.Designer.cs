namespace TRW.Apps.RandomCharacterGenerator
{
    partial class CharacterGeneratorOptions
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
            this.raceFilesPathTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseRacePathButton = new System.Windows.Forms.Button();
            this.chooseClassPathButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.classFilesPathTextbox = new System.Windows.Forms.TextBox();
            this.chooseBackgroundPathButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundFilesPathTextbox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // raceFilesPathTextbox
            // 
            this.raceFilesPathTextbox.Location = new System.Drawing.Point(109, 47);
            this.raceFilesPathTextbox.Name = "raceFilesPathTextbox";
            this.raceFilesPathTextbox.Size = new System.Drawing.Size(371, 20);
            this.raceFilesPathTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Races Path";
            // 
            // chooseRacePathButton
            // 
            this.chooseRacePathButton.Location = new System.Drawing.Point(486, 45);
            this.chooseRacePathButton.Name = "chooseRacePathButton";
            this.chooseRacePathButton.Size = new System.Drawing.Size(38, 23);
            this.chooseRacePathButton.TabIndex = 2;
            this.chooseRacePathButton.Tag = "Choose Location of Race Xml Files";
            this.chooseRacePathButton.Text = "...";
            this.chooseRacePathButton.UseVisualStyleBackColor = true;
            this.chooseRacePathButton.Click += new System.EventHandler(this.ChoosePath_Click);
            // 
            // chooseClassPathButton
            // 
            this.chooseClassPathButton.Location = new System.Drawing.Point(486, 74);
            this.chooseClassPathButton.Name = "chooseClassPathButton";
            this.chooseClassPathButton.Size = new System.Drawing.Size(38, 23);
            this.chooseClassPathButton.TabIndex = 5;
            this.chooseClassPathButton.Tag = "Choose Location of Class Xml Files";
            this.chooseClassPathButton.Text = "...";
            this.chooseClassPathButton.UseVisualStyleBackColor = true;
            this.chooseClassPathButton.Click += new System.EventHandler(this.ChoosePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Classes Path";
            // 
            // classFilesPathTextbox
            // 
            this.classFilesPathTextbox.Location = new System.Drawing.Point(109, 76);
            this.classFilesPathTextbox.Name = "classFilesPathTextbox";
            this.classFilesPathTextbox.Size = new System.Drawing.Size(371, 20);
            this.classFilesPathTextbox.TabIndex = 3;
            // 
            // chooseBackgroundPathButton
            // 
            this.chooseBackgroundPathButton.Location = new System.Drawing.Point(486, 103);
            this.chooseBackgroundPathButton.Name = "chooseBackgroundPathButton";
            this.chooseBackgroundPathButton.Size = new System.Drawing.Size(38, 23);
            this.chooseBackgroundPathButton.TabIndex = 8;
            this.chooseBackgroundPathButton.Tag = "Choose Location of Background Xml Files";
            this.chooseBackgroundPathButton.Text = "...";
            this.chooseBackgroundPathButton.UseVisualStyleBackColor = true;
            this.chooseBackgroundPathButton.Click += new System.EventHandler(this.ChoosePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Backgrounds Path";
            // 
            // backgroundFilesPathTextbox
            // 
            this.backgroundFilesPathTextbox.Location = new System.Drawing.Point(109, 105);
            this.backgroundFilesPathTextbox.Name = "backgroundFilesPathTextbox";
            this.backgroundFilesPathTextbox.Size = new System.Drawing.Size(371, 20);
            this.backgroundFilesPathTextbox.TabIndex = 6;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(449, 219);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // CharacterGeneratorOptions
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 254);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.chooseBackgroundPathButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backgroundFilesPathTextbox);
            this.Controls.Add(this.chooseClassPathButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.classFilesPathTextbox);
            this.Controls.Add(this.chooseRacePathButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.raceFilesPathTextbox);
            this.Name = "CharacterGeneratorOptions";
            this.Text = "CharacterGeneratorOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox raceFilesPathTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseRacePathButton;
        private System.Windows.Forms.Button chooseClassPathButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox classFilesPathTextbox;
        private System.Windows.Forms.Button chooseBackgroundPathButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox backgroundFilesPathTextbox;
        private System.Windows.Forms.Button saveButton;
    }
}