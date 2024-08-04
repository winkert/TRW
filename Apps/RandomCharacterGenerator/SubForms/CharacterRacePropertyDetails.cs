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
    public partial class CharacterRacePropertyDetails : TRW.Apps.TrwAppsBase.TrwFormBase, IPropertyDetailsForm
    {
        private DnDCharacterRace _race;
        private string _filePath;
        PropertyManagerProficiencyGroup _proficiencies;

        public CharacterRacePropertyDetails()
        {
            InitializeComponent();
            PopulateComboBoxWithEnum<Sizes>(this.SizeComboBox);
            PopulateComboBoxWithEnum<VisionTypes>(this.VisionTypeComboBox);
            _proficiencies = this.ProficiencyGroupPanel.AddSubForm<PropertyManagerProficiencyGroup>();
        }


        public void Clear()
        {
            _race = null;
            _filePath = string.Empty;

            this.NameTextBox.Clear();
            this.SizeComboBox.SelectedIndex = -1;
            this.TotalAttributeBonusesNumeric.Value = 0;
            this.AttributeBonusesListBox.Items.Clear();
            this._proficiencies.Clear();
            this.WalkingSpeedNumeric.Value = 0;
            this.ClimbingSpeedNumeric.Value = 0;
            this.FlyingSpeedNumeric.Value = 0;
            this.SwimmingSpeedNumeric.Value = 0;
            this.AmphibiousCheckbox.Checked = false;
            this.VisionTypeComboBox.SelectedIndex = -1;
            this.SunlightSensitiveCheckbox.Checked = false;
            this.HitpointBonusNumeric.Value = 0;
        }

        public void LoadDetailScreen(CharacterPropertyBase property, string filePath)
        {
            _race = property as DnDCharacterRace;
            _filePath = filePath;
            this.RaceDetailsGroupBox.Text = string.Format("{0} Race Details", _race.Name);

            this.NameTextBox.Text = _race.Name;
            this.SizeComboBox.SetSelectedItem(_race.Size);
            this.TotalAttributeBonusesNumeric.Value = _race.AttributeBonuses.TotalBonuses;
            foreach (DnDAttributeBonus bonus in _race.AttributeBonuses)
            {
                AddAttributeBonus(bonus);
            }
            _proficiencies.Populate(_race.Languages, _race.Skills, _race.Proficiencies, _race.Features);
            this.WalkingSpeedNumeric.Value = _race.WalkingSpeed;
            this.ClimbingSpeedNumeric.Value = _race.ClimbingSpeed;
            this.FlyingSpeedNumeric.Value = _race.FlyingSpeed;
            this.SwimmingSpeedNumeric.Value = _race.SwimmingSpeed;
            this.AmphibiousCheckbox.Checked = _race.IsAmphibious;
            this.VisionTypeComboBox.SetSelectedItem(_race.VisionType);
            this.SunlightSensitiveCheckbox.Checked = _race.IsSunlightSensitive;
            this.HitpointBonusNumeric.Value = _race.HitPointBonus;
        }

        public CharacterPropertyBase Save()
        {
            if(_race == null)
            {
                _race = new DnDCharacterRace();
            }
            Sizes size = this.SizeComboBox.GetSelectedItem<Sizes>();
            VisionTypes vision = this.VisionTypeComboBox.GetSelectedItem<VisionTypes>();
            DnDAttributeBonusCollection attributeBonus = new DnDAttributeBonusCollection(Convert.ToInt32(this.TotalAttributeBonusesNumeric.Value));
            foreach (DnDAttributeBonus bonus in GetItemsAsList<DnDAttributeBonus>(this.AttributeBonusesListBox))
            {
                attributeBonus.Add(bonus);
            }

            LanguageCollection languages = _proficiencies.GetLanguages();

            SkillCollection skills = _proficiencies.GetSkills();

            ProficiencyCollection proficiencies = _proficiencies.GetProficiencies();

            List<Feature> features = _proficiencies.GetFeatures();

            _race.Create(this.NameTextBox.Text, size, attributeBonus
                , Convert.ToInt32(this.WalkingSpeedNumeric.Value), Convert.ToInt32(this.ClimbingSpeedNumeric.Value), Convert.ToInt32(this.FlyingSpeedNumeric.Value), Convert.ToInt32(this.SwimmingSpeedNumeric.Value)
                , vision, AmphibiousCheckbox.Checked, SunlightSensitiveCheckbox.Checked
                , languages, skills, proficiencies, features, Convert.ToInt32(this.HitpointBonusNumeric.Value));

            return _race;
        }

        public void SetEditMode(bool edit)
        {
            RaceDetailsGroupBox.Enabled = edit;
        }

        public bool ValidateScreen()
        {
            if(string.IsNullOrEmpty(NameTextBox.Text))
            {
                errorProvider1.SetError(NameTextBox, "Name Required");
                return false;
            }
            if(VisionTypeComboBox.SelectedItem == null)
            {
                errorProvider1.SetError(VisionTypeComboBox, "Vision Type Required");
                return false;
            }
            if (SizeComboBox.SelectedItem == null)
            {
                errorProvider1.SetError(SizeComboBox, "Size Required");
                return false;
            }
            if(!_proficiencies.ValidateScreen())
            {
                return false;
            }
            return true;
        }

        public void CopyNew()
        {
            _race = null;
            _filePath = string.Empty;
        }

        private void AddAttributeBonus(DnDAttributeBonus bonus)
        {
            this.AttributeBonusesListBox.Items.Add(bonus);
            if (this.TotalAttributeBonusesNumeric.Value < this.AttributeBonusesListBox.Items.Count)
                this.TotalAttributeBonusesNumeric.Value = this.AttributeBonusesListBox.Items.Count;
        }

        #region Event Handlers
        private void AddAttributeBonusButton_Click(object sender, EventArgs e)
        {
            AddAttributeBonusDialog dialog = new AddAttributeBonusDialog();
            dialog.FormClosed += AddAttributeDialog_FormClosed;
            dialog.Show();
        }

        private void AddAttributeDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddAttributeBonusDialog dialog = sender as AddAttributeBonusDialog;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddAttributeBonus(dialog.AttributeBonus);
                }
                else
                {
                    this.AttributeBonusesListBox.Items[dialog.Index] = dialog.AttributeBonus;
                }
            }
        }

        private void EditAttributeBonusButton_Click(object sender, EventArgs e)
        {
            if (this.AttributeBonusesListBox.SelectedIndex > -1)
            {
                AddAttributeBonusDialog dialog = new AddAttributeBonusDialog((DnDAttributeBonus)this.AttributeBonusesListBox.SelectedItem, this.AttributeBonusesListBox.SelectedIndex);
                dialog.FormClosed += AddAttributeDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteAttributeBonusButtom_Click(object sender, EventArgs e)
        {
            if (this.AttributeBonusesListBox.SelectedIndex > -1)
                this.AttributeBonusesListBox.Items.RemoveAt(this.AttributeBonusesListBox.SelectedIndex);
        }
        #endregion
    }
}
