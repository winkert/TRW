using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.GameLibraries.Character;
using TRW.GameLibraries.Character.DnD;
using TRW.Apps.TrwAppsBase;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class CharacterClassPropertyDetails : TRW.Apps.TrwAppsBase.TrwFormBase, IPropertyDetailsForm
    {
        private DnDCharacterClass _class;
        private string _filePath;
        PropertyManagerProficiencyGroup _proficiencies;

        public CharacterClassPropertyDetails()
        {
            InitializeComponent();
            PopulateComboBoxWithEnum<Attributes>(this.PrimaryAttributeComboBox);
            PopulateComboBoxWithEnum<Attributes>(this.SecondaryAttributeComboBox);
            PopulateComboBoxWithEnum<Attributes>(this.SpellCastingAbilityComboBox);
            _proficiencies = this.ProficiencyGroupPanel.AddSubForm<PropertyManagerProficiencyGroup>();
        }


        public void Clear()
        {
            _class = null;
            _filePath = string.Empty;

            this.NameTextBox.Clear();
            this.PrimaryAttributeComboBox.SelectedIndex = -1;
            this.SecondaryAttributeComboBox.SelectedIndex = -1;
            this.SpellCastingAbilityComboBox.SelectedIndex = -1;
            this.SavingThrowsListBox.Items.Clear();
            this._proficiencies.Clear();
        }

        public void LoadDetailScreen(CharacterPropertyBase property, string filePath)
        {
            _class = property as DnDCharacterClass;
            _filePath = filePath;
            this.ClassDetailsGroupBox.Text = string.Format("{0} Class Details", _class.Name);

            this.NameTextBox.Text = _class.Name;
            this.HitDieNumeric.Value = _class.HitDie.DiceSides;
            this.PrimaryAttributeComboBox.SetSelectedItem(_class.PrimaryAttribute);
            this.SecondaryAttributeComboBox.SetSelectedItem(_class.SecondaryAttribute);
            this.SpellCastingAbilityComboBox.SetSelectedItem(_class.SpellCastingAbility);
            foreach (DnDSavingThrowProficiency save in _class.SavingThrows)
            {
                AddSavingThrow(save);
            }
            _proficiencies.Populate(_class.Languages, _class.Skills, _class.Proficiencies, _class.Features);
        }

        public CharacterPropertyBase Save()
        {
            if(_class == null)
            {
                _class = new DnDCharacterClass();
            }
            ProficiencyCollection<DnDSavingThrowProficiency> saves = new ProficiencyCollection<DnDSavingThrowProficiency>();
            foreach (DnDSavingThrowProficiency save in GetItemsAsList<DnDSavingThrowProficiency>(this.SavingThrowsListBox))
            {
                saves.Add(save);
            }
            LanguageCollection languages = _proficiencies.GetLanguages();

            SkillCollection skills = _proficiencies.GetSkills();

            ProficiencyCollection proficiencies = _proficiencies.GetProficiencies();

            List<Feature> features = _proficiencies.GetFeatures();

            _class.Create(this.NameTextBox.Text, new GameLibraries.GameCore.Dice(Convert.ToInt32(this.HitDieNumeric.Value)), this.PrimaryAttributeComboBox.GetSelectedItem<Attributes>(), this.SecondaryAttributeComboBox.GetSelectedItem<Attributes>(), this.SpellCastingAbilityComboBox.GetSelectedItem<Attributes>(), saves
                , languages, skills, proficiencies, features);

            return _class;
        }

        public void SetEditMode(bool edit)
        {
            ClassDetailsGroupBox.Enabled = edit;
        }

        public bool ValidateScreen()
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                errorProvider1.SetError(NameTextBox, "Name Required");
                return false;
            }
            if (HitDieNumeric.Value < 1)
            {
                errorProvider1.SetError(HitDieNumeric, "Hit Dice Type Required");
                return false;
            }
            if (PrimaryAttributeComboBox.SelectedItem == null)
            {
                errorProvider1.SetError(PrimaryAttributeComboBox, "Primary Attribute Required");
                return false;
            }
            if (SecondaryAttributeComboBox.SelectedItem == null)
            {
                errorProvider1.SetError(SecondaryAttributeComboBox, "Secondary Attribute Required");
                return false;
            }
            if (SpellCastingAbilityComboBox.SelectedItem == null)
            {
                SpellCastingAbilityComboBox.SetSelectedItem(Attributes.None);
                return false;
            }
            if (!_proficiencies.ValidateScreen())
            {
                return false;
            }
            return true;
        }

        public void CopyNew()
        {
            _class = null;
            _filePath = string.Empty;
        }

        private void AddSavingThrow(DnDSavingThrowProficiency save)
        {
            this.SavingThrowsListBox.Items.Add(save);
        }

        #region Event Handlers
        private void AddSavingThrowButton_Click(object sender, EventArgs e)
        {
            AddAttributeBonusDialog dialog = new AddAttributeBonusDialog();
            dialog.FormClosed += AddSavingThrowDialog_FormClosed;
            dialog.Show();
        }

        private void AddSavingThrowDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddAttributeBonusDialog dialog = sender as AddAttributeBonusDialog;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {

                }
                else
                {
                    this.SavingThrowsListBox.Items[dialog.Index] = dialog.AttributeBonus;
                }
            }
        }

        private void EditSavingThrowButton_Click(object sender, EventArgs e)
        {
            if (this.SavingThrowsListBox.SelectedIndex > -1)
            {
                AddAttributeBonusDialog dialog = new AddAttributeBonusDialog((DnDAttributeBonus)this.SavingThrowsListBox.SelectedItem, this.SavingThrowsListBox.SelectedIndex);
                dialog.FormClosed += AddSavingThrowDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteSavingThrowButton_Click(object sender, EventArgs e)
        {
            if (this.SavingThrowsListBox.SelectedIndex > -1)
                this.SavingThrowsListBox.Items.RemoveAt(this.SavingThrowsListBox.SelectedIndex);
        }

        #endregion
    }
}
