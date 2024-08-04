namespace TwitterUtility
{
    partial class Form1
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
            this.uxResultsRTB = new System.Windows.Forms.RichTextBox();
            this.uxMainSplitter = new System.Windows.Forms.SplitContainer();
            this.uxSettingsGroup = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uxUrlText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxMainSplitter)).BeginInit();
            this.uxMainSplitter.Panel1.SuspendLayout();
            this.uxMainSplitter.Panel2.SuspendLayout();
            this.uxMainSplitter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxResultsRTB
            // 
            this.uxResultsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxResultsRTB.Location = new System.Drawing.Point(0, 0);
            this.uxResultsRTB.Name = "uxResultsRTB";
            this.uxResultsRTB.Size = new System.Drawing.Size(488, 436);
            this.uxResultsRTB.TabIndex = 0;
            this.uxResultsRTB.Text = "";
            // 
            // uxMainSplitter
            // 
            this.uxMainSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMainSplitter.Location = new System.Drawing.Point(4, 106);
            this.uxMainSplitter.Name = "uxMainSplitter";
            // 
            // uxMainSplitter.Panel1
            // 
            this.uxMainSplitter.Panel1.Controls.Add(this.uxResultsRTB);
            // 
            // uxMainSplitter.Panel2
            // 
            this.uxMainSplitter.Panel2.Controls.Add(this.uxSettingsGroup);
            this.uxMainSplitter.Size = new System.Drawing.Size(690, 436);
            this.uxMainSplitter.SplitterDistance = 488;
            this.uxMainSplitter.TabIndex = 1;
            // 
            // uxSettingsGroup
            // 
            this.uxSettingsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxSettingsGroup.Location = new System.Drawing.Point(0, 0);
            this.uxSettingsGroup.Name = "uxSettingsGroup";
            this.uxSettingsGroup.Size = new System.Drawing.Size(198, 436);
            this.uxSettingsGroup.TabIndex = 0;
            this.uxSettingsGroup.TabStop = false;
            this.uxSettingsGroup.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uxUrlText);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 100);
            this.panel1.TabIndex = 2;
            // 
            // uxUrlText
            // 
            this.uxUrlText.Location = new System.Drawing.Point(12, 12);
            this.uxUrlText.Name = "uxUrlText";
            this.uxUrlText.Size = new System.Drawing.Size(591, 20);
            this.uxUrlText.TabIndex = 1;
            this.uxUrlText.Text = "https://twitter.com/search?q=%23CatholicTwitter&src=typed_query";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(609, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Fetch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uxMainSplitter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.uxMainSplitter.Panel1.ResumeLayout(false);
            this.uxMainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxMainSplitter)).EndInit();
            this.uxMainSplitter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox uxResultsRTB;
        private System.Windows.Forms.SplitContainer uxMainSplitter;
        private System.Windows.Forms.GroupBox uxSettingsGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox uxUrlText;
    }
}

