namespace DungeonGenerator.Dialogs
{
    partial class ItemComponentDetail
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
            this.components = new System.ComponentModel.Container();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxDescription = new System.Windows.Forms.TextBox();
            this.uxValue = new System.Windows.Forms.TextBox();
            this.uxWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // uxName
            // 
            this.uxName.Location = new System.Drawing.Point(106, 37);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(243, 20);
            this.uxName.TabIndex = 0;
            // 
            // uxDescription
            // 
            this.uxDescription.Location = new System.Drawing.Point(106, 63);
            this.uxDescription.Name = "uxDescription";
            this.uxDescription.Size = new System.Drawing.Size(243, 20);
            this.uxDescription.TabIndex = 1;
            // 
            // uxValue
            // 
            this.uxValue.Location = new System.Drawing.Point(106, 89);
            this.uxValue.Name = "uxValue";
            this.uxValue.Size = new System.Drawing.Size(108, 20);
            this.uxValue.TabIndex = 2;
            // 
            // uxWeight
            // 
            this.uxWeight.Location = new System.Drawing.Point(106, 115);
            this.uxWeight.Name = "uxWeight";
            this.uxWeight.Size = new System.Drawing.Size(108, 20);
            this.uxWeight.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Weight";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ItemComponentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 273);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxWeight);
            this.Controls.Add(this.uxValue);
            this.Controls.Add(this.uxDescription);
            this.Controls.Add(this.uxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ItemComponentDetail";
            this.Text = "ItemComponentDetail";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.TextBox uxDescription;
        private System.Windows.Forms.TextBox uxValue;
        private System.Windows.Forms.TextBox uxWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}