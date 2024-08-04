namespace TRW.Apps.TrwAppsBase.Forms
{
    partial class TextInputDialog
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
            this.uxOkButton = new System.Windows.Forms.Button();
            this.uxCancelButton = new System.Windows.Forms.Button();
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.uxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxOkButton
            // 
            this.uxOkButton.Location = new System.Drawing.Point(12, 108);
            this.uxOkButton.Name = "uxOkButton";
            this.uxOkButton.Size = new System.Drawing.Size(75, 23);
            this.uxOkButton.TabIndex = 1;
            this.uxOkButton.Text = "OK";
            this.uxOkButton.UseVisualStyleBackColor = true;
            this.uxOkButton.Click += new System.EventHandler(this.uxOkButton_Click);
            // 
            // uxCancelButton
            // 
            this.uxCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancelButton.Location = new System.Drawing.Point(297, 108);
            this.uxCancelButton.Name = "uxCancelButton";
            this.uxCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uxCancelButton.TabIndex = 2;
            this.uxCancelButton.Text = "Cancel";
            this.uxCancelButton.UseVisualStyleBackColor = true;
            this.uxCancelButton.Click += new System.EventHandler(this.uxCancelButton_Click);
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(12, 31);
            this.uxTextBox.Multiline = true;
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.Size = new System.Drawing.Size(360, 20);
            this.uxTextBox.TabIndex = 0;
            // 
            // uxLabel
            // 
            this.uxLabel.AutoSize = true;
            this.uxLabel.Location = new System.Drawing.Point(12, 15);
            this.uxLabel.Name = "uxLabel";
            this.uxLabel.Size = new System.Drawing.Size(35, 13);
            this.uxLabel.TabIndex = 3;
            this.uxLabel.Text = "label1";
            // 
            // TextInputDialog
            // 
            this.AcceptButton = this.uxOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxCancelButton;
            this.ClientSize = new System.Drawing.Size(384, 136);
            this.ControlBox = false;
            this.Controls.Add(this.uxLabel);
            this.Controls.Add(this.uxTextBox);
            this.Controls.Add(this.uxCancelButton);
            this.Controls.Add(this.uxOkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TextInputDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Enter Text";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxOkButton;
        private System.Windows.Forms.Button uxCancelButton;
        private System.Windows.Forms.TextBox uxTextBox;
        private System.Windows.Forms.Label uxLabel;
    }
}