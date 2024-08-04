
namespace TRW.Apps.TrwAppsBase.Forms
{
    partial class ConfirmActionDialog
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
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.AlternateButton1 = new System.Windows.Forms.Button();
            this.AlternateButton2 = new System.Windows.Forms.Button();
            this.ConfirmMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(12, 51);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 0;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(257, 51);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AlternateButton1
            // 
            this.AlternateButton1.Location = new System.Drawing.Point(93, 51);
            this.AlternateButton1.Name = "AlternateButton1";
            this.AlternateButton1.Size = new System.Drawing.Size(75, 23);
            this.AlternateButton1.TabIndex = 1;
            this.AlternateButton1.Text = "Save As";
            this.AlternateButton1.UseVisualStyleBackColor = true;
            // 
            // AlternateButton2
            // 
            this.AlternateButton2.Location = new System.Drawing.Point(176, 51);
            this.AlternateButton2.Name = "AlternateButton2";
            this.AlternateButton2.Size = new System.Drawing.Size(75, 23);
            this.AlternateButton2.TabIndex = 2;
            this.AlternateButton2.Text = "Save As";
            this.AlternateButton2.UseVisualStyleBackColor = true;
            // 
            // ConfirmMessageLabel
            // 
            this.ConfirmMessageLabel.AutoSize = true;
            this.ConfirmMessageLabel.Location = new System.Drawing.Point(150, 9);
            this.ConfirmMessageLabel.Name = "ConfirmMessageLabel";
            this.ConfirmMessageLabel.Size = new System.Drawing.Size(35, 13);
            this.ConfirmMessageLabel.TabIndex = 4;
            this.ConfirmMessageLabel.Text = "label1";
            // 
            // ConfirmActionDialog
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 86);
            this.ControlBox = false;
            this.Controls.Add(this.ConfirmMessageLabel);
            this.Controls.Add(this.AlternateButton2);
            this.Controls.Add(this.AlternateButton1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmActionDialog";
            this.ShowInTaskbar = false;
            this.Text = "Confirm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button AlternateButton1;
        private System.Windows.Forms.Button AlternateButton2;
        private System.Windows.Forms.Label ConfirmMessageLabel;
    }
}