using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.CommonLibraries.Xml;
using TRW.GameLibraries.Character;

namespace TRW.Apps.NPCGenerator
{
    public partial class NPCGenerator : TRW.Apps.TrwAppsBase.TrwFormBase
    {

        #region Constants
        internal const string _maleNameFileName = "MaleGivenNames.xml";
        internal const string _femaleNameFileName = "FemaleGivenNames.xml";
        internal const string _surnameFileName = "Surnames.xml";
        #endregion

        #region Fields
        internal string _includesPath;
        internal Dictionary<string, string> _nameDataSets;
        #endregion
        public NPCGenerator()
        {
            InitializeComponent();
            InitializeConfig();
            ConfigureControls();
        }

        protected override bool HasConfigFile => true;

        private void InitializeConfig()
        {
            if (!_settings.ContainsKey("Includes"))
            {
                _settings.Add("Includes", System.IO.Path.Combine(Application.StartupPath, "Includes"));
            }
            _includesPath = _settings["Includes"];
            if (!_settings.ContainsKey("NameDataSets"))
            {
                _settings.Add("NameDataSets", "1523York|Modern");
            }

            ConfigureNameDataSets();
        }

        private void ConfigureNameDataSets()
        {
            _nameDataSets = new Dictionary<string, string>();
            foreach (string nameSubFolder in _settings["NameDataSets"].Split('|'))
            {
                string subFolder = System.IO.Path.Combine(_includesPath, nameSubFolder);
                if (!System.IO.Directory.Exists(subFolder))
                    System.IO.Directory.CreateDirectory(subFolder);
                _nameDataSets.Add(nameSubFolder, subFolder);
            }
        }

        private void ConfigureControls()
        {
            NameDataSetsCombo.Items.Clear();
            foreach (KeyValuePair<string, string> nameDataset in _nameDataSets)
            {
                NameDataSetsCombo.Items.Add(nameDataset.Key);
            }
            if (NameDataSetsCombo.Items.Count > 0)
                NameDataSetsCombo.SelectedIndex = 0;
        }

        public void UpdateSettings()
        {
            HashSet<string> nameDataSets = new HashSet<string>();
            foreach (KeyValuePair<string, string> nameDataset in _nameDataSets)
            {
                nameDataSets.Add(nameDataset.Key);
            }
            _settings["NameDataSets"] = string.Join("|", nameDataSets);
        }

        public void RefreshData()
        {
            ConfigureControls();
            UpdateSettings();
        }

        private string GetNewName(string selectedDataSet, Gender gender)
        {
            string nameDataSetSubFolder = _nameDataSets[selectedDataSet];
            
            string givenNameXmlFilePath = string.Empty;
            string surnameXmlFilePath = System.IO.Path.Combine(_includesPath, nameDataSetSubFolder, _surnameFileName);
            switch (gender)
            {
                case Gender.Male:
                    givenNameXmlFilePath = System.IO.Path.Combine(_includesPath, nameDataSetSubFolder, _maleNameFileName);
                    break;
                case Gender.Female:
                    givenNameXmlFilePath = System.IO.Path.Combine(_includesPath, nameDataSetSubFolder, _femaleNameFileName);
                    break;
            }

            NameData givenName = new NameData();
            givenName.ReadXml(givenNameXmlFilePath);
            NameData surName = new NameData();
            surName.ReadXml(surnameXmlFilePath);

            return $"{givenName.GetRandom()} {surName.GetRandom()}";
        }

        private Gender GetSelectedGender()
        {
            if (MaleRadioButton.Checked)
                return Gender.Male;
            else
                return Gender.Female;
        }

        private void GenerateNpcStats()
        {
            NpcCharacter character = new NpcCharacter();
            character.InitializeCharacter();
            AttributeDataGridView.Rows.Clear();
            AttributeDataGridView.Rows.Add(Attributes.Strength, character.Strength);
            AttributeDataGridView.Rows.Add(Attributes.Dexterity, character.Dexterity);
            AttributeDataGridView.Rows.Add(Attributes.Constitution, character.Constitution);
            AttributeDataGridView.Rows.Add(Attributes.Intelligence, character.Intelligence);
            AttributeDataGridView.Rows.Add(Attributes.Wisdom, character.Wisdom);
            AttributeDataGridView.Rows.Add(Attributes.Charisma, character.Charisma);
        }

        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            this.NameTextBox.Clear();

            NameTextBox.Text = GetNewName(NameDataSetsCombo.SelectedItem.ToString(), GetSelectedGender());
        }

        private void ViewEditNameDataSet_Click(object sender, EventArgs e)
        {
            ViewEditNameDataSets dialog = new ViewEditNameDataSets(this);
            dialog.Show();
        }

        internal enum Gender { Male, Female }

        private void GenerateStatsButton_Click(object sender, EventArgs e)
        {
            GenerateNpcStats();
        }

        private void GenerateNpcButton_Click(object sender, EventArgs e)
        {
            this.NameTextBox.Clear();

            NameTextBox.Text = GetNewName(NameDataSetsCombo.SelectedItem.ToString(), GetSelectedGender());
            GenerateNpcStats();
        }
    }
}
