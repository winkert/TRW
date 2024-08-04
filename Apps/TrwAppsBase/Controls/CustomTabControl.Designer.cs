
namespace TRW.Apps.TrwAppsBase.Controls
{
    partial class CustomTabControl
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
            this.CTabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CTabControl1
            // 
            this.CTabControl1.Controls.Add(this.tabPage1);
            this.CTabControl1.Controls.Add(this.tabPage2);
            this.CTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.CTabControl1.Location = new System.Drawing.Point(0, 0);
            this.CTabControl1.Name = "CTabControl1";
            this.CTabControl1.SelectedIndex = 0;
            this.CTabControl1.Size = new System.Drawing.Size(688, 377);
            this.CTabControl1.TabIndex = 0;
            this.CTabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CTabControl1_DrawItem);
            this.CTabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CTabControl1_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(680, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(680, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CustomTabControl
            // 
            this.Controls.Add(this.CTabControl1);
            this.Name = "CustomTabControl";
            this.Size = new System.Drawing.Size(688, 377);
            this.CTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.TabControl CTabControl1;
    }
}
