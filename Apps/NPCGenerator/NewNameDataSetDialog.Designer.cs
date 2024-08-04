namespace TRW.Apps.NPCGenerator
{
    partial class NewNameDataSetDialog
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
            this.NameDataSetNameText = new System.Windows.Forms.TextBox();
            this.CreateNewNameDataSetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.InboundFileText = new System.Windows.Forms.TextBox();
            this.SelectInboundFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameDataSetNameText
            // 
            this.NameDataSetNameText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameDataSetNameText.Location = new System.Drawing.Point(12, 32);
            this.NameDataSetNameText.Name = "NameDataSetNameText";
            this.NameDataSetNameText.Size = new System.Drawing.Size(270, 20);
            this.NameDataSetNameText.TabIndex = 0;
            // 
            // CreateNewNameDataSetButton
            // 
            this.CreateNewNameDataSetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateNewNameDataSetButton.Location = new System.Drawing.Point(288, 58);
            this.CreateNewNameDataSetButton.Name = "CreateNewNameDataSetButton";
            this.CreateNewNameDataSetButton.Size = new System.Drawing.Size(75, 23);
            this.CreateNewNameDataSetButton.TabIndex = 1;
            this.CreateNewNameDataSetButton.Text = "Create";
            this.CreateNewNameDataSetButton.UseVisualStyleBackColor = true;
            this.CreateNewNameDataSetButton.Click += new System.EventHandler(this.CreateNewNameDataSetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name Data Set Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // InboundFileText
            // 
            this.InboundFileText.Location = new System.Drawing.Point(12, 63);
            this.InboundFileText.Name = "InboundFileText";
            this.InboundFileText.Size = new System.Drawing.Size(222, 20);
            this.InboundFileText.TabIndex = 3;
            // 
            // SelectInboundFileButton
            // 
            this.SelectInboundFileButton.Location = new System.Drawing.Point(240, 60);
            this.SelectInboundFileButton.Name = "SelectInboundFileButton";
            this.SelectInboundFileButton.Size = new System.Drawing.Size(30, 23);
            this.SelectInboundFileButton.TabIndex = 4;
            this.SelectInboundFileButton.Text = "...";
            this.SelectInboundFileButton.UseVisualStyleBackColor = true;
            this.SelectInboundFileButton.Click += new System.EventHandler(this.SelectInboundFileButton_Click);
            // 
            // NewNameDataSetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 93);
            this.Controls.Add(this.SelectInboundFileButton);
            this.Controls.Add(this.InboundFileText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateNewNameDataSetButton);
            this.Controls.Add(this.NameDataSetNameText);
            this.Name = "NewNameDataSetDialog";
            this.Text = "New Name Data Set";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameDataSetNameText;
        private System.Windows.Forms.Button CreateNewNameDataSetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button SelectInboundFileButton;
        private System.Windows.Forms.TextBox InboundFileText;
    }
}