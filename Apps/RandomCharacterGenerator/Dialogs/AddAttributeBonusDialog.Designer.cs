namespace TRW.Apps.RandomCharacterGenerator
{
    partial class AddAttributeBonusDialog
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
            this.AttributesCombo = new System.Windows.Forms.ComboBox();
            this.BonusNumeric = new System.Windows.Forms.NumericUpDown();
            this.RequiredCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BonusNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // AttributesCombo
            // 
            this.AttributesCombo.FormattingEnabled = true;
            this.AttributesCombo.Location = new System.Drawing.Point(89, 26);
            this.AttributesCombo.Name = "AttributesCombo";
            this.AttributesCombo.Size = new System.Drawing.Size(199, 21);
            this.AttributesCombo.TabIndex = 0;
            // 
            // BonusNumeric
            // 
            this.BonusNumeric.Location = new System.Drawing.Point(294, 26);
            this.BonusNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BonusNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BonusNumeric.Name = "BonusNumeric";
            this.BonusNumeric.Size = new System.Drawing.Size(58, 20);
            this.BonusNumeric.TabIndex = 1;
            this.BonusNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RequiredCheckbox
            // 
            this.RequiredCheckbox.AutoSize = true;
            this.RequiredCheckbox.Location = new System.Drawing.Point(89, 53);
            this.RequiredCheckbox.Name = "RequiredCheckbox";
            this.RequiredCheckbox.Size = new System.Drawing.Size(69, 17);
            this.RequiredCheckbox.TabIndex = 2;
            this.RequiredCheckbox.Text = "Required";
            this.RequiredCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Attribute";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(281, 73);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddAttributeBonusDialog
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(368, 108);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RequiredCheckbox);
            this.Controls.Add(this.BonusNumeric);
            this.Controls.Add(this.AttributesCombo);
            this.Name = "AddAttributeBonusDialog";
            this.Text = "Add Attribute Bonus";
            ((System.ComponentModel.ISupportInitialize)(this.BonusNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox AttributesCombo;
        public System.Windows.Forms.NumericUpDown BonusNumeric;
        public System.Windows.Forms.CheckBox RequiredCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveButton;
    }
}
