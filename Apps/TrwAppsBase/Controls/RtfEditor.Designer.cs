namespace TRW.Apps.TrwAppsBase.Controls
{
    partial class RtfEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RtfEditor));
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBold = new System.Windows.Forms.ToolStripButton();
            this.toolItalics = new System.Windows.Forms.ToolStripButton();
            this.toolUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStrikethrough = new System.Windows.Forms.ToolStripButton();
            this.toolSuperScript = new System.Windows.Forms.ToolStripButton();
            this.toolSubScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.richTextBox.Location = new System.Drawing.Point(0, 28);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(700, 508);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFontSize,
            this.toolStripSeparator1,
            this.toolBold,
            this.toolItalics,
            this.toolUnderline,
            this.toolStrikethrough,
            this.toolSuperScript,
            this.toolSubScript});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(700, 26);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolBold
            // 
            this.toolBold.CheckOnClick = true;
            this.toolBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBold.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolBold.Image = ((System.Drawing.Image)(resources.GetObject("toolBold.Image")));
            this.toolBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBold.Name = "toolBold";
            this.toolBold.Size = new System.Drawing.Size(23, 23);
            this.toolBold.Text = "B";
            this.toolBold.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolItalics
            // 
            this.toolItalics.CheckOnClick = true;
            this.toolItalics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolItalics.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.toolItalics.Image = ((System.Drawing.Image)(resources.GetObject("toolItalics.Image")));
            this.toolItalics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItalics.Name = "toolItalics";
            this.toolItalics.Size = new System.Drawing.Size(23, 23);
            this.toolItalics.Text = "I";
            this.toolItalics.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolUnderline
            // 
            this.toolUnderline.CheckOnClick = true;
            this.toolUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolUnderline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.toolUnderline.Image = ((System.Drawing.Image)(resources.GetObject("toolUnderline.Image")));
            this.toolUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUnderline.Name = "toolUnderline";
            this.toolUnderline.Size = new System.Drawing.Size(23, 23);
            this.toolUnderline.Text = "U";
            this.toolUnderline.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolStrikethrough
            // 
            this.toolStrikethrough.CheckOnClick = true;
            this.toolStrikethrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStrikethrough.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Strikeout);
            this.toolStrikethrough.Image = ((System.Drawing.Image)(resources.GetObject("toolStrikethrough.Image")));
            this.toolStrikethrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrikethrough.Name = "toolStrikethrough";
            this.toolStrikethrough.Size = new System.Drawing.Size(23, 23);
            this.toolStrikethrough.Text = "S";
            this.toolStrikethrough.ToolTipText = "Strikethrough";
            this.toolStrikethrough.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolSuperScript
            // 
            this.toolSuperScript.CheckOnClick = true;
            this.toolSuperScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSuperScript.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.toolSuperScript.Image = ((System.Drawing.Image)(resources.GetObject("toolSuperScript.Image")));
            this.toolSuperScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSuperScript.Name = "toolSuperScript";
            this.toolSuperScript.Size = new System.Drawing.Size(23, 23);
            this.toolSuperScript.Text = "Sp";
            this.toolSuperScript.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolSuperScript.ToolTipText = "Superscript";
            this.toolSuperScript.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolSubScript
            // 
            this.toolSubScript.CheckOnClick = true;
            this.toolSubScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSubScript.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.toolSubScript.Image = ((System.Drawing.Image)(resources.GetObject("toolSubScript.Image")));
            this.toolSubScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSubScript.Name = "toolSubScript";
            this.toolSubScript.Size = new System.Drawing.Size(23, 23);
            this.toolSubScript.Text = "Sb";
            this.toolSubScript.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolSubScript.ToolTipText = "Subscript";
            this.toolSubScript.Click += new System.EventHandler(this.tool_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolFontSize
            // 
            this.toolFontSize.AutoSize = false;
            this.toolFontSize.DropDownHeight = 75;
            this.toolFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolFontSize.DropDownWidth = 75;
            this.toolFontSize.IntegralHeight = false;
            this.toolFontSize.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "32",
            "40",
            "48",
            "64"});
            this.toolFontSize.Name = "toolFontSize";
            this.toolFontSize.Size = new System.Drawing.Size(75, 23);
            this.toolFontSize.SelectedIndexChanged += new System.EventHandler(this.toolFontSize_SelectedIndexChanged);
            // 
            // RtfEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.richTextBox);
            this.Name = "RtfEditor";
            this.Size = new System.Drawing.Size(700, 536);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBold;
        private System.Windows.Forms.ToolStripButton toolItalics;
        private System.Windows.Forms.ToolStripButton toolUnderline;
        private System.Windows.Forms.ToolStripButton toolStrikethrough;
        private System.Windows.Forms.ToolStripButton toolSuperScript;
        private System.Windows.Forms.ToolStripButton toolSubScript;
        private System.Windows.Forms.ToolStripComboBox toolFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
