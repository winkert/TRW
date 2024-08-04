namespace DungeonGenerator.Dialogs
{
    partial class NpcComponentDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxNotes = new System.Windows.Forms.TextBox();
            this.uxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uxClass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uxRace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uxChallengeRating = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uxHostility = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Notes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // uxNotes
            // 
            this.uxNotes.Location = new System.Drawing.Point(127, 162);
            this.uxNotes.Multiline = true;
            this.uxNotes.Name = "uxNotes";
            this.uxNotes.Size = new System.Drawing.Size(356, 104);
            this.uxNotes.TabIndex = 5;
            // 
            // uxName
            // 
            this.uxName.Location = new System.Drawing.Point(127, 31);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(243, 20);
            this.uxName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Class";
            // 
            // uxClass
            // 
            this.uxClass.Location = new System.Drawing.Point(127, 57);
            this.uxClass.Name = "uxClass";
            this.uxClass.Size = new System.Drawing.Size(243, 20);
            this.uxClass.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Race";
            // 
            // uxRace
            // 
            this.uxRace.Location = new System.Drawing.Point(127, 83);
            this.uxRace.Name = "uxRace";
            this.uxRace.Size = new System.Drawing.Size(243, 20);
            this.uxRace.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Challenge Rating";
            // 
            // uxChallengeRating
            // 
            this.uxChallengeRating.Location = new System.Drawing.Point(127, 109);
            this.uxChallengeRating.Name = "uxChallengeRating";
            this.uxChallengeRating.Size = new System.Drawing.Size(200, 20);
            this.uxChallengeRating.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Hostility";
            // 
            // uxHostility
            // 
            this.uxHostility.FormattingEnabled = true;
            this.uxHostility.Location = new System.Drawing.Point(127, 135);
            this.uxHostility.Name = "uxHostility";
            this.uxHostility.Size = new System.Drawing.Size(200, 21);
            this.uxHostility.TabIndex = 4;
            // 
            // NpcComponentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 380);
            this.Controls.Add(this.uxHostility);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.uxChallengeRating);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uxRace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxNotes);
            this.Controls.Add(this.uxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NpcComponentDetail";
            this.Text = "NpcComponentDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxNotes;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uxClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uxRace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uxChallengeRating;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox uxHostility;
    }
}