using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TRW.CommonLibraries.Xml;
using TRW.GameLibraries.Character;
using TRW.GameLibraries.Character.DnD;
using TRW.Apps.TrwAppsBase;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class RandomCharacterGenerator : TrwFormBase
    {
        public delegate void ExportList<T>(List<T> exportables, string fileName);

        public RandomCharacterGenerator()
            : base()
        {
            InitializeComponent();
        }

        private readonly Attributes[] _attributesInOrder = new Attributes[6]
        {
            Attributes.Strength, Attributes.Dexterity, Attributes.Constitution,
            Attributes.Intelligence, Attributes.Wisdom, Attributes.Charisma
        };

        internal const string _raceLocationSetting = "RaceLocation";
        internal const string _classLocationSetting = "ClassLocation";
        internal const string _backgroundLocationSetting = "BackgroundLocation";

        protected override bool HasConfigFile => true;
        private HashSet<string> _filterOptions = new HashSet<string>();
        private HashSet<string> _filteredCategories = new HashSet<string>();

        #region Init Methods
        private void LoadData()
        {
            if (!_settings.ContainsKey(_raceLocationSetting))
            {
                _settings.Add(_raceLocationSetting, System.IO.Path.Combine(Environment.CurrentDirectory, "Xml", "Races"));
            }

            if (!_settings.ContainsKey(_classLocationSetting))
            {
                _settings.Add(_classLocationSetting, System.IO.Path.Combine(Environment.CurrentDirectory, "Xml", "Classes"));
            }

            if (!_settings.ContainsKey(_backgroundLocationSetting))
            {
                _settings.Add(_backgroundLocationSetting, System.IO.Path.Combine(Environment.CurrentDirectory, "Xml", "Backgrounds"));
            }

        }

        private void RefreshLists()
        {
            PopulateComboBoxFromLocation<DnDCharacterRace>(cmbRace, _settings[_raceLocationSetting]);
            PopulateComboBoxFromLocation<DnDCharacterClass>(cmbClass, _settings[_classLocationSetting]);
            PopulateComboBoxFromLocation<DnDCharacterBackground>(cmbBackground, _settings[_backgroundLocationSetting]);
        }

        private void PopulateFilterList()
        {
            filterFlowPanel.Controls.Clear();
            foreach (string category in _filterOptions)
            {
                if (!string.IsNullOrEmpty(category))
                {
                    CheckBox check = new CheckBox
                    {
                        Text = category,
                        Checked = true
                    };
                    _filteredCategories.Add(category);
                    check.CheckedChanged += FilterCheck_CheckedChanged;
                    filterFlowPanel.Controls.Add(check);
                }
            }
        }

        private void PopulateComboBoxFromLocation<T>(ComboBox comboBox, string folder)
            where T : CharacterPropertyBase, IXmlData, new()
        {
            if (string.IsNullOrEmpty(folder))
                return;

            comboBox.SelectedIndex = -1;
            comboBox.Items.Clear();

            if (System.IO.Directory.Exists(folder))
            {
                IEnumerable<string> filesInFolder = System.IO.Directory.EnumerateFiles(folder, "*.xml", System.IO.SearchOption.AllDirectories);
                foreach (string file in filesInFolder)
                {
                    AddItemToComboBox<T>(comboBox, file, out _);
                }
            }
            else
            {
                // as a kind of initialization, let's create the folder
                System.IO.Directory.CreateDirectory(folder);
            }

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        private bool AddItemToComboBox<T>(ComboBox comboBox, string file, out T? item)
            where T : CharacterPropertyBase, IXmlData, new()
        {
            item = null;
            try
            {
                item = new T();
                item.ReadXml(file);
                if (_filteredCategories.Contains(item.Category)
                    || string.IsNullOrEmpty(item.Category))
                {
                    comboBox.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                WriteLog(string.Format("Error parsing file [{0}] : {1}", file, e.ToString()));
                return false;
            }
            return true;
        }

        private void PopulateCategories()
        {
            string[] folders = new string[3]
            {
                    _settings[_raceLocationSetting],
                    _settings[_classLocationSetting],
                    _settings[_backgroundLocationSetting]
            };

            foreach (string folder in folders)
            {
                if (System.IO.Directory.Exists(folder))
                {
                    IEnumerable<string> categoryFolders = System.IO.Directory.EnumerateDirectories(folder);
                    foreach (string categoryPath in categoryFolders)
                    {
                        try
                        {
                            string category = new System.IO.DirectoryInfo(categoryPath).Name;
                            _filterOptions.Add(category);
                        }
                        catch (Exception e)
                        {
                            WriteLog(string.Format("Error getting Category name from [{0}] : {1}", categoryPath, e.ToString()));
                        }
                    }
                }

            }
        }
        #endregion

        private void ImportXmlFile(string fileToImport, string folderToImportTo)
        {
            if (!System.IO.Directory.Exists(folderToImportTo))
                System.IO.Directory.CreateDirectory(folderToImportTo);

            System.IO.File.Copy(fileToImport, System.IO.Path.Combine(folderToImportTo, System.IO.Path.GetFileName(fileToImport)), true);
        }

        internal void ImportProperty<T>(T property, string fileName, string rootImportFolder)
            where T : CharacterPropertyBase, IXmlData
        {
            string cat = property.Category;
            ImportXmlFile(fileName, System.IO.Path.Combine(rootImportFolder, cat));

        }

        private void GetValuesFromUI(out DnDCharacterRace oRace, out DnDCharacterClass oClass, out DnDCharacterBackground oBackground, out int iLevel)
        {
            bool randomRace = chk_RandomRace.Checked;
            bool randomClass = chk_RandomClass.Checked;
            bool randomBackground = chk_RandomBackground.Checked;

            oRace = GetValueFromDropDown<DnDCharacterRace>(cmbRace, randomRace);
            oClass = GetValueFromDropDown<DnDCharacterClass>(cmbClass, randomClass);
            oBackground = GetValueFromDropDown<DnDCharacterBackground>(cmbBackground, randomBackground);

            iLevel = Convert.ToInt32(numLevel.Value);
        }

        private T GetValueFromDropDown<T>(ComboBox comboBox, bool random)
            where T : CharacterPropertyBase
        {
            T value;
            if (random)
            {
                value = (T)comboBox.Items[R.Next(0, comboBox.Items.Count - 1)];
            }
            else
            {
                value = (T)comboBox.SelectedItem;
            }

            return value;
        }

        private void AddCharacterToGridView(DnDCharacter character)
        {
            int index = characterGrid.Rows.Add();
            characterGrid.Rows[index].Cells[CharacterObjectColumn.Index].Value = character;
            characterGrid.Rows[index].Cells[RaceColumn.Index].Value = character.Race;
            characterGrid.Rows[index].Cells[ClassColumn.Index].Value = character.Class;
            characterGrid.Rows[index].Cells[BackgroundColumn.Index].Value = character.Background;
            characterGrid.Rows[index].Cells[LevelColumn.Index].Value = character.CharacterLevel;
            characterGrid.Rows[index].Cells[HitPointsColumn.Index].Value = character.CharacterMaxHitPoints;
            characterGrid.Rows[index].Cells[StrengthColumn.Index].Value = character.Strength;
            characterGrid.Rows[index].Cells[DexterityColumn.Index].Value = character.Dexterity;
            characterGrid.Rows[index].Cells[ConstitutionColumn.Index].Value = character.Constitution;
            characterGrid.Rows[index].Cells[IntelligenceColumn.Index].Value = character.Intelligence;
            characterGrid.Rows[index].Cells[WisdomColumn.Index].Value = character.Wisdom;
            characterGrid.Rows[index].Cells[CharismaColumn.Index].Value = character.Charisma;

        }

        #region Save Load Methods
        private void SaveCharacterSheetAsPDF(DataGridViewRow row, string fileName)
        {
            DnDCharacter character = row.Cells[CharacterObjectColumn.Index].Value as DnDCharacter;
            CharacterPrinter.SaveDnDCharacterSheetToPdf(character, fileName);
        }

        private void SaveCharactersAsPDF(string fileName, List<DnDCharacter> characters)
        {
            CharacterPrinter.SaveDnDCharactersToPdf(characters, fileName);
        }

        private void SaveCharacterListAsFile(string fileName)
        {
            List<DnDCharacter> characters = new List<DnDCharacter>();
            foreach (DataGridViewRow row in characterGrid.Rows)
            {
                characters.Add(row.Cells[CharacterObjectColumn.Index].Value as DnDCharacter);
            }
            TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeListToFile(characters, fileName);
        }

        private void LoadCharacterListFromFile(string fileName)
        {
            List<DnDCharacter> characters = TRW.CommonLibraries.Serialization.BinarySerializationRoutines.DeserializeListFromFile<DnDCharacter>(fileName); ;
            foreach (DnDCharacter character in characters)
            {
                AddCharacterToGridView(character);
            }
        }

        private void SavePropertyListAsPdfToFile<T>(string fileName, ComboBox comboBox, ExportList<T> exportMethod)
            where T : CharacterPropertyBase
        {
            List<T> list = GetItemsAsList<T>(comboBox);
            exportMethod.Invoke(list, fileName);
        }
        #endregion
        // TO DO - IMPLEMENT MASS IMPORT
        #region Menu Events
        private void saveCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile("Character List|*.chl", out string fileName))
            {
                SaveCharacterListAsFile(fileName);
            }
        }

        private void loadCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadFile("Character List|*.chl", out string fileName))
            {
                LoadCharacterListFromFile(fileName);
            }
        }

        private void importRaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadFile("Xml|*.xml", out string file))
            {
                if (AddItemToComboBox<DnDCharacterRace>(cmbRace, file, out DnDCharacterRace raceObj))
                {
                    ImportProperty<DnDCharacterRace>(raceObj, file, _settings[_raceLocationSetting]);
                }
            }
        }

        private void importClassToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (LoadFile("Xml|*.xml", out string file))
            {
                if (AddItemToComboBox<DnDCharacterClass>(cmbClass, file, out DnDCharacterClass classObj))
                {
                    ImportProperty<DnDCharacterClass>(classObj, file, _settings[_classLocationSetting]);
                }
            }
        }

        private void importBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadFile("Xml|*.xml", out string file))
            {
                if (AddItemToComboBox<DnDCharacterBackground>(cmbBackground, file, out DnDCharacterBackground backgroundObj))
                {
                    ImportProperty<DnDCharacterBackground>(backgroundObj, file, _settings[_backgroundLocationSetting]);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageRacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CharacterPropertyManager<DnDCharacterRace> manager = new CharacterPropertyManager<DnDCharacterRace>(this, _settings[_raceLocationSetting]);
                manager.FormClosed += PropertyManagerCloseEvent;
                manager.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void manageClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CharacterPropertyManager<DnDCharacterClass> manager = new CharacterPropertyManager<DnDCharacterClass>(this, _settings[_classLocationSetting]);
                manager.FormClosed += PropertyManagerCloseEvent;
                manager.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void manageBackgroundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CharacterPropertyManager<DnDCharacterBackground> manager = new CharacterPropertyManager<DnDCharacterBackground>(this, _settings[_backgroundLocationSetting]);
                manager.FormClosed += PropertyManagerCloseEvent;
                manager.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PropertyManagerCloseEvent(object? sender, EventArgs e)
        {
            LoadData();
            PopulateCategories();
            PopulateFilterList();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterGeneratorOptions options = new CharacterGeneratorOptions(_settings);
            options.FormClosed += Options_FormClosed;
            options.Show();
        }

        private void Options_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender == null)
                return;

            CharacterGeneratorOptions options = (CharacterGeneratorOptions)sender;
            if (options.DialogResult == DialogResult.OK)
            {
                // do I want to introduce the ability to copy files from old locations to new locations and/or refresh?
                _settings[_raceLocationSetting] = options.RaceLocationPath;
                _settings[_classLocationSetting] = options.ClassLocationPath;
                _settings[_backgroundLocationSetting] = options.BackgroundLocationPath;
                this.SaveConfigFile();
            }
        }

        private void saveCharacterSheet_Click(object sender, EventArgs e)
        {
            if (!SaveFile("PDF|*.pdf", out string fileName))
                return;

            DataGridViewRow row;
            if (sender is ToolStripMenuItem)
            {
                if (characterGrid.SelectedRows.Count == 0)
                {
                    // no selected row
                    MessageBox.Show("Please select a character from the list to save as a character sheet.");
                    return;
                }
                row = characterGrid.SelectedRows[0];
            }
            else
            {
                // um....
                MessageBox.Show("No idea where this came from");
                return;
            }

            SaveCharacterSheetAsPDF(row, fileName);
        }

        private void saveCharacterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (characterGrid.Rows.Count == 0)
                return;

            if (!SaveFile("PDF|*.pdf", out string fileName))
                return;

            List<DnDCharacter> characters = new List<DnDCharacter>();
            foreach (DataGridViewRow row in characterGrid.Rows)
            {
                DnDCharacter character = row.Cells[CharacterObjectColumn.Index].Value as DnDCharacter;
                characters.Add(character);
            }

            SaveCharactersAsPDF(fileName, characters);
        }

        private void saveBackgroundsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile("PDF|*.pdf", out string fileName))
                SavePropertyListAsPdfToFile<DnDCharacterBackground>(fileName, cmbBackground, CharacterPrinter.SaveDnDBackgroundListToPdf);
        }

        private void saveClassesPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile("PDF|*.pdf", out string fileName))
                SavePropertyListAsPdfToFile<DnDCharacterClass>(fileName, cmbClass, CharacterPrinter.SaveDnDClassListToPdf);
        }

        private void saveRacesPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile("PDF|*.pdf", out string fileName))
                SavePropertyListAsPdfToFile<DnDCharacterRace>(fileName, cmbRace, CharacterPrinter.SaveDnDRaceListToPdf);
        }
        
        private void deleteCharacterContextMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow characterRow = GetSelectedCharacterRow((ToolStripMenuItem)sender);
            if(characterRow != null)
            {
                characterRow.DataGridView.Rows.Remove(characterRow);
            }
        }

        private void saveCharacterSheetContextMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow characterRow = GetSelectedCharacterRow((ToolStripMenuItem)sender);
            if (characterRow != null)
            {
                if (!SaveFile("PDF|*.pdf", out string fileName))
                    return;

                SaveCharacterSheetAsPDF(characterRow, fileName);
            }
        }

        private DataGridViewRow? GetSelectedCharacterRow(ToolStripMenuItem sender)
        {
            ContextMenuStrip parent = (ContextMenuStrip)sender.Owner;
            DataGridView grid = (DataGridView)parent.SourceControl;
            if (grid.SelectedRows.Count != 1)
                return null;
            return grid.SelectedRows[0];
        }
        #endregion

        #region UI Events
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int iCount = Convert.ToInt32(numNumberOfCharacters.Value);

            for (int count = 0; count < iCount; count++)
            {
                GetValuesFromUI(out DnDCharacterRace oRace, out DnDCharacterClass oClass, out DnDCharacterBackground oBackground, out int iLevel);
                int[] attributeRollsTemp = CharacterBase.RollAttributes<DnDCharacter>();
                Dictionary<Attributes, int> attributeRolls = new Dictionary<Attributes, int>()
                {
                    { Attributes.Strength, 0 },
                    { Attributes.Dexterity, 0 },
                    { Attributes.Constitution, 0 },
                    { Attributes.Intelligence, 0 },
                    { Attributes.Wisdom, 0 },
                    { Attributes.Charisma, 0 }
                };

                List<int> sortedAttributes = attributeRollsTemp.ToList();
                sortedAttributes.Sort();
                sortedAttributes.Reverse();

                attributeRolls[oClass.PrimaryAttribute] = sortedAttributes[0];
                attributeRolls[oClass.SecondaryAttribute] = sortedAttributes[1];

                int sortedI = 2;
                for (int i = 0; i < 6; i++)
                {
                    if (attributeRolls[_attributesInOrder[i]] == 0)
                    {
                        attributeRolls[_attributesInOrder[i]] = sortedAttributes[sortedI++];
                    }
                }

                int level = (int)numLevel.Value;

                AddCharacterToGridView(new DnDCharacter(oRace, oClass, oBackground, level, attributeRolls.Values.ToArray()));
            }
        }

        private void chkRandom_Checked(object sender, EventArgs e)
        {
            bool enable = !((CheckBox)sender).Checked;
            int selectedIndex = enable ? 0 : -1;
            if (sender.Equals(chk_RandomRace))
            {
                cmbRace.SelectedIndex = selectedIndex;
                cmbRace.Enabled = enable;
            }
            else if (sender.Equals(chk_RandomClass))
            {
                cmbClass.SelectedIndex = selectedIndex;
                cmbClass.Enabled = enable;
            }
            else if (sender.Equals(chk_RandomBackground))
            {
                cmbBackground.SelectedIndex = selectedIndex;
                cmbBackground.Enabled = enable;
            }
        }

        private void FilterCheck_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender == null)
                return;

            CheckBox? box = sender as CheckBox;
            if (box.Checked)
            {
                _filteredCategories.Add(box.Text);
            }
            else
            {
                _filteredCategories.Remove(box.Text);
            }
            RefreshLists();
        }

        private void RandomCharacterGenerator_Load(object sender, EventArgs e)
        {
            LoadData();
            PopulateCategories();
            PopulateFilterList();
            RefreshLists();
        }
        #endregion

    }
}
