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
    public partial class AdvancedListBox : ListBox
    {
        public AdvancedListBox()
        {
            InitializeComponent();
            this.KeyUp += AdvancedListBox_KeyUp;
        }

        private void AdvancedListBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (this.SelectedIndex > -1)
                    {
                        this.Items.RemoveAt(this.SelectedIndex);
                    }
                    break;
                default:
                    return;
            }
        }
    }
}
