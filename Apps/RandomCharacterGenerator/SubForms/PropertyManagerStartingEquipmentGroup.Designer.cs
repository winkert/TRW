namespace TRW.Apps.RandomCharacterGenerator.SubForms
{
    partial class PropertyManagerStartingEquipmentGroup
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
            this.EquipmentListBox = new TRW.Apps.TrwAppsBase.Controls.AdvancedListBox();
            this.EditEquipmentButton = new System.Windows.Forms.Button();
            this.DeleteEquipmentButton = new System.Windows.Forms.Button();
            this.AddEquipmentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EquipmentListBox
            // 
            this.EquipmentListBox.FormattingEnabled = true;
            this.EquipmentListBox.Location = new System.Drawing.Point(48, 12);
            this.EquipmentListBox.Name = "EquipmentListBox";
            this.EquipmentListBox.Size = new System.Drawing.Size(181, 108);
            this.EquipmentListBox.TabIndex = 1;
            // 
            // EditEquipmentButton
            // 
            this.EditEquipmentButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.EditButtonImage;
            this.EditEquipmentButton.Location = new System.Drawing.Point(12, 48);
            this.EditEquipmentButton.Name = "EditEquipmentButton";
            this.EditEquipmentButton.Size = new System.Drawing.Size(30, 30);
            this.EditEquipmentButton.TabIndex = 3;
            this.EditEquipmentButton.UseVisualStyleBackColor = true;
            this.EditEquipmentButton.Click += new System.EventHandler(this.EditEquipmentButton_Click);
            // 
            // DeleteEquipmentButton
            // 
            this.DeleteEquipmentButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.DeleteButtonImage;
            this.DeleteEquipmentButton.Location = new System.Drawing.Point(12, 84);
            this.DeleteEquipmentButton.Name = "DeleteEquipmentButton";
            this.DeleteEquipmentButton.Size = new System.Drawing.Size(30, 30);
            this.DeleteEquipmentButton.TabIndex = 4;
            this.DeleteEquipmentButton.UseVisualStyleBackColor = true;
            this.DeleteEquipmentButton.Click += new System.EventHandler(this.DeleteEquipmentButton_Click);
            // 
            // AddEquipmentButton
            // 
            this.AddEquipmentButton.Image = global::TRW.Apps.RandomCharacterGenerator.RandomCharacterGenerator.AddButtonImage;
            this.AddEquipmentButton.Location = new System.Drawing.Point(12, 12);
            this.AddEquipmentButton.Name = "AddEquipmentButton";
            this.AddEquipmentButton.Size = new System.Drawing.Size(30, 30);
            this.AddEquipmentButton.TabIndex = 2;
            this.AddEquipmentButton.UseVisualStyleBackColor = true;
            this.AddEquipmentButton.Click += new System.EventHandler(this.AddEquipmentButton_Click);
            // 
            // PropertyManagerStartingEquipmentGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 129);
            this.ControlBox = false;
            this.Controls.Add(this.EditEquipmentButton);
            this.Controls.Add(this.DeleteEquipmentButton);
            this.Controls.Add(this.EquipmentListBox);
            this.Controls.Add(this.AddEquipmentButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyManagerStartingEquipmentGroup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PropertyManagerStartingEquipmentGroup";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button EditEquipmentButton;
        private System.Windows.Forms.Button DeleteEquipmentButton;
        private System.Windows.Forms.Button AddEquipmentButton;
        private TRW.Apps.TrwAppsBase.Controls.AdvancedListBox EquipmentListBox;
    }
}