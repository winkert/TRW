using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.NPCGenerator
{
    public partial class NewNameDataSetDialog : Form
    {
        public NewNameDataSetDialog(HashSet<string> existingNameDataSets, bool selectFile)
        {
            InitializeComponent();
            _existingNameDataSets = existingNameDataSets;
            if(selectFile)
            {
                SelectInboundFileButton.Visible = true;
                InboundFileText.Visible = true;
            }
            else
            {
                SelectInboundFileButton.Visible = false;
                InboundFileText.Visible = false;
            }
        }

        private HashSet<string> _existingNameDataSets;

        public string NameDataSetName { get; private set; }

        private void CreateNewNameDataSetButton_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(NameDataSetNameText, string.Empty);

            if(string.IsNullOrEmpty(NameDataSetNameText.Text))
            {
                errorProvider1.SetError(NameDataSetNameText, "Please enter a name.");
                return;
            }
            if(_existingNameDataSets != null && _existingNameDataSets.Contains(NameDataSetNameText.Text))
            {
                errorProvider1.SetError(NameDataSetNameText, "A data set with that name already exists.");
                return;
            }
            if(InboundFileText.Visible && string.IsNullOrEmpty(InboundFileText.Text))
            {
                errorProvider1.SetError(InboundFileText, "Select a file to import.");
                return;
            }

            NameDataSetName = NameDataSetNameText.Text;
            this.Close();
        }

        private void SelectInboundFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Compatible Files|*.csv;*.tab;*.txt";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                InboundFileText.Text = ofd.FileName;
            }
        }
    }
}
