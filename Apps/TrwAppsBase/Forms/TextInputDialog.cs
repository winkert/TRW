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
    public partial class TextInputDialog : Form
    {
        private const int TextboxHeightMin = 20;
        private const int TextboxHeightMax = 70;

        public TextInputDialog()
        {
            InitializeComponent();
        }

        public string Value { get; private set; }

        public DialogResult ShowDialog(string title)
        {
            return ShowDialog(title, string.Empty, false);
        }

        public DialogResult ShowDialog(string title, string instructions)
        {
            return ShowDialog(title, instructions, false);
        }

        public DialogResult ShowDialog(string title, string instructions, bool multiLine)
        {
            this.Text = title;
            this.uxLabel.Text = instructions;
            this.uxTextBox.Multiline = multiLine;
            if (multiLine)
                uxTextBox.Size = new Size(uxTextBox.Size.Width, TextboxHeightMax);
            else
                uxTextBox.Size = new Size(uxTextBox.Size.Width, TextboxHeightMin);

            return base.ShowDialog();
        }

        private void uxOkButton_Click(object sender, EventArgs e)
        {
            this.Value = uxTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void uxCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
