namespace TRW.Apps.RandomCharacterGenerator
{
    partial class AddFeatureDialog
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
            this.FeatureNameTextbox = new System.Windows.Forms.TextBox();
            this.FeatureDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FeatureNameTextbox
            // 
            this.FeatureNameTextbox.Location = new System.Drawing.Point(89, 27);
            this.FeatureNameTextbox.Name = "FeatureNameTextbox";
            this.FeatureNameTextbox.Size = new System.Drawing.Size(389, 20);
            this.FeatureNameTextbox.TabIndex = 0;
            // 
            // FeatureDescriptionTextbox
            // 
            this.FeatureDescriptionTextbox.Location = new System.Drawing.Point(89, 66);
            this.FeatureDescriptionTextbox.Multiline = true;
            this.FeatureDescriptionTextbox.Name = "FeatureDescriptionTextbox";
            this.FeatureDescriptionTextbox.Size = new System.Drawing.Size(389, 139);
            this.FeatureDescriptionTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(403, 217);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddFeatureDialog
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(490, 252);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FeatureDescriptionTextbox);
            this.Controls.Add(this.FeatureNameTextbox);
            this.Name = "AddFeatureDialog";
            this.Text = "Add Feature";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FeatureNameTextbox;
        private System.Windows.Forms.TextBox FeatureDescriptionTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
    }
}
