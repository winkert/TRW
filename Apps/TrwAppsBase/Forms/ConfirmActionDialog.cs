using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.TrwAppsBase.Forms
{
    public partial class ConfirmActionDialog : Form
    {
        // TODO: Implement
        public ConfirmActionDialog(string message)
        {
            InitializeComponent();
            ConfirmMessageLabel.Text = message;
            InitDialog(false, false);
        }

        public ConfirmActionDialog(string message, string title)
            : this(message)
        {
            this.Text = title;
        }


        private void InitDialog(bool showAlternateButton1, bool showAlternateButton2)
        {
            AlternateButton1.Visible = showAlternateButton1;
            AlternateButton2.Visible = showAlternateButton2;
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {

        }
    }
}
