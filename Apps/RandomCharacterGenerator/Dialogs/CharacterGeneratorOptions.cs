using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class CharacterGeneratorOptions : TRW.Apps.TrwAppsBase.TrwFormBase
    {
        public CharacterGeneratorOptions(Dictionary<string, string> settings)
        {
            InitializeComponent();
            raceFilesPathTextbox.Text = settings[RandomCharacterGenerator._raceLocationSetting];
            classFilesPathTextbox.Text = settings[RandomCharacterGenerator._classLocationSetting];
            backgroundFilesPathTextbox.Text = settings[RandomCharacterGenerator._backgroundLocationSetting];

            this.DialogResult = DialogResult.Cancel;
        }

        public string RaceLocationPath { get; private set; }
        public string ClassLocationPath { get; private set; }
        public string BackgroundLocationPath { get; private set; }

        public bool RefreshData { get; private set; }
        public bool CopyFiles { get; private set; }

        private void ChoosePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = ((Button)sender).Tag.ToString();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                if (sender.Equals(chooseRacePathButton))
                {
                    raceFilesPathTextbox.Text = folderDialog.SelectedPath;
                }
                else if (sender.Equals(chooseClassPathButton))
                {
                    classFilesPathTextbox.Text = folderDialog.SelectedPath;
                }
                else if (sender.Equals(chooseBackgroundPathButton))
                {
                    backgroundFilesPathTextbox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.RaceLocationPath = raceFilesPathTextbox.Text;
            this.ClassLocationPath = classFilesPathTextbox.Text;
            this.BackgroundLocationPath = backgroundFilesPathTextbox.Text;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }




}
