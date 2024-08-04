using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.TrwAppsBase.Controls
{
    public partial class CustomTabControl : UserControl
    {
        public CustomTabControl()
        {
            InitializeComponent();

        }

        public Image CloseImage { get; set; }
        public bool ShowCloseButton { get; set; } = false;
        public Point CloseImagePosition { get; set; } = new Point(20, 4);

        public TabPage SelectedTab => this.CTabControl1.SelectedTab;
        public TabControl.TabPageCollection TabPages => this.CTabControl1.TabPages;
        public bool MultiLine => this.CTabControl1.Multiline;
        public int SelectedIndex { get => this.CTabControl1.SelectedIndex; set { this.CTabControl1.SelectedIndex = value; } }

        internal static Size CloseImageSize = new Size(16, 16);

        private void CTabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle r = this.CTabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.CTabControl1.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            if (ShowCloseButton)
            {
                this.CTabControl1.Padding = CloseImagePosition;
                Image img = new Bitmap(CloseImage, CloseImageSize);
                e.Graphics.DrawImage(img, r.X + (this.CTabControl1.GetTabRect(e.Index).Width - CloseImagePosition.X), CloseImagePosition.Y, CloseImageSize.Width, CloseImageSize.Height);
            }

        }

        private void CTabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ShowCloseButton)
            {
                TabControl tabControl = (TabControl)sender;
                Point p = e.Location;
                int _tabWidth = this.CTabControl1.GetTabRect(tabControl.SelectedIndex).Width - (CloseImagePosition.X);
                Rectangle r = this.CTabControl1.GetTabRect(tabControl.SelectedIndex);
                r.Offset(_tabWidth, CloseImagePosition.Y);
                r.Width = 16;
                r.Height = 16;
                if (CTabControl1.SelectedIndex >= 1)
                {
                    if (r.Contains(p))
                    {
                        TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                        tabControl.TabPages.Remove(tabPage);
                    }
                }
            }
        }
    }
}

