namespace TRW.Apps.RandomCharacterGenerator
{
    partial class AddProficiencyDialog<P>
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
            this.ProficiencyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProficiencyNameTextbox = new System.Windows.Forms.TextBox();
            this.ProficiencyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProficiencyTypeComboBox
            // 
            this.ProficiencyTypeComboBox.FormattingEnabled = true;
            this.ProficiencyTypeComboBox.Location = new System.Drawing.Point(91, 29);
            this.ProficiencyTypeComboBox.Name = "ProficiencyTypeComboBox";
            this.ProficiencyTypeComboBox.Size = new System.Drawing.Size(158, 21);
            this.ProficiencyTypeComboBox.TabIndex = 0;
            this.ProficiencyTypeComboBox.SelectedValueChanged += new System.EventHandler(this.ProficiencyTypeComboBox_SelectedIndexChanged);
            // 
            // ProficiencyNameTextbox
            // 
            this.ProficiencyNameTextbox.Location = new System.Drawing.Point(91, 66);
            this.ProficiencyNameTextbox.Name = "ProficiencyNameTextbox";
            this.ProficiencyNameTextbox.Size = new System.Drawing.Size(274, 20);
            this.ProficiencyNameTextbox.TabIndex = 1;
            // 
            // ProficiencyComboBox
            // 
            this.ProficiencyComboBox.FormattingEnabled = true;
            this.ProficiencyComboBox.Location = new System.Drawing.Point(91, 66);
            this.ProficiencyComboBox.Name = "ProficiencyComboBox";
            this.ProficiencyComboBox.Size = new System.Drawing.Size(180, 21);
            this.ProficiencyComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Proficiency";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(289, 102);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddProficiencyDialog
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(376, 137);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProficiencyComboBox);
            this.Controls.Add(this.ProficiencyNameTextbox);
            this.Controls.Add(this.ProficiencyTypeComboBox);
            this.Name = "AddProficiencyDialog";
            this.Text = "Add Proficiency";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProficiencyTypeComboBox;
        private System.Windows.Forms.TextBox ProficiencyNameTextbox;
        private System.Windows.Forms.ComboBox ProficiencyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
    }
}
