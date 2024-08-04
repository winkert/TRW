using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TRW.GameLibraries.Character;
using TRW.GameLibraries.Character.DnD;
using TRW.Apps.TrwAppsBase;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class AddProficiencyDialog<P> : TRW.Apps.TrwAppsBase.TrwFormBase where P : Proficiency, new()
    {
        public AddProficiencyDialog()
        {
            InitializeComponent();
            PopulateComboBoxWithEnum<ProficiencyTypes>(ProficiencyTypeComboBox);
            this.AddNew = true;
            this.DialogResult = DialogResult.Cancel;
            SetComboVisible(false, ProficiencyTypes.Unkown);
        }

        public AddProficiencyDialog(ProficiencyTypes proficiencyTypes)
            :this()
        {
            this.ProficiencyTypeComboBox.SetSelectedItem(proficiencyTypes);
            this.ProficiencyTypeComboBox.Enabled = false;
            switch (proficiencyTypes)
            {
                case ProficiencyTypes.Skill:
                case ProficiencyTypes.Language:
                case ProficiencyTypes.Saving_Throws:
                    SetComboVisible(true, proficiencyTypes);
                    break;
                case ProficiencyTypes.Armor:
                case ProficiencyTypes.Musical_Instrument:
                case ProficiencyTypes.Tool:
                case ProficiencyTypes.Weapon:
                case ProficiencyTypes.Unkown:
                    SetComboVisible(false, proficiencyTypes);
                    break;
            }
        }

        public AddProficiencyDialog(P proficiency, ProficiencyTypes proficiencyTypes, int index)
            : this()
        {
            this.AddNew = false;
            this.Index = index;
            this.ProficiencyTypeComboBox.SetSelectedItem(proficiencyTypes);
            this.ProficiencyTypeComboBox.Enabled = false;
            Proficiency = proficiency;
            switch(proficiency.ProficiencyType)
            {
                case ProficiencyTypes.Skill:
                    SetComboVisible(true, proficiency.ProficiencyType);
                    SkillProficiency skill = proficiency as SkillProficiency;
                    this.ProficiencyComboBox.SetSelectedItem(skill.Skill);
                    break;
                case ProficiencyTypes.Language:
                    SetComboVisible(true, proficiency.ProficiencyType);
                    LanguageProficiency language = proficiency as LanguageProficiency;
                    this.ProficiencyComboBox.SetSelectedItem(language.Language);
                    break;
                case ProficiencyTypes.Saving_Throws:
                case ProficiencyTypes.Musical_Instrument:
                case ProficiencyTypes.Armor:
                case ProficiencyTypes.Tool:
                case ProficiencyTypes.Weapon:
                case ProficiencyTypes.Unkown:
                    SetComboVisible(false, proficiency.ProficiencyType);
                    this.ProficiencyNameTextbox.Text = proficiency.Name;
                    break;
            }
        }

        public int Index { get; private set; }
        public bool AddNew { get; private set; }

        public P Proficiency { get; private set; }

        private void SetComboVisible(bool visible, ProficiencyTypes proficiencyType)
        {
            SetComboType(proficiencyType);
            this.ProficiencyComboBox.Visible = visible;
            this.ProficiencyNameTextbox.Visible = !visible;
            this.ProficiencyNameTextbox.Text = string.Empty;
            this.ProficiencyComboBox.SelectedIndex = visible ? 0 : -1;
        }

        private void SetComboType(ProficiencyTypes type)
        {
            this.ProficiencyComboBox.Items.Clear();
            switch (type)
            {
                case ProficiencyTypes.Skill:
                    PopulateComboBoxWithEnum<Skills>(ProficiencyComboBox);
                    break;
                case ProficiencyTypes.Language:
                    PopulateComboBoxWithEnum<Languages>(ProficiencyComboBox);
                    break;
                case ProficiencyTypes.Saving_Throws:
                    PopulateComboBoxWithEnum<Attributes>(ProficiencyComboBox);
                    break;
                case ProficiencyTypes.Armor:
                case ProficiencyTypes.Musical_Instrument:
                case ProficiencyTypes.Tool:
                case ProficiencyTypes.Weapon:
                case ProficiencyTypes.Unkown:
                    break;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ProficiencyTypes proficiencyType = (ProficiencyTypes)this.ProficiencyTypeComboBox.GetSelectedItem<ProficiencyTypes>();
            switch (proficiencyType)
            {
                case ProficiencyTypes.Skill:
                    SkillProficiency skill = new SkillProficiency(this.ProficiencyComboBox.GetSelectedItem<Skills>());
                    Proficiency = skill as P;
                    break;
                case ProficiencyTypes.Language:
                    LanguageProficiency language = new LanguageProficiency(this.ProficiencyComboBox.GetSelectedItem<Languages>());
                    Proficiency = language as P;
                    break;
                case ProficiencyTypes.Saving_Throws:
                    DnDSavingThrowProficiency save = new DnDSavingThrowProficiency(this.ProficiencyComboBox.GetSelectedItem<Attributes>());
                    Proficiency = save as P;
                    break;
                case ProficiencyTypes.Musical_Instrument:
                case ProficiencyTypes.Armor:
                case ProficiencyTypes.Tool:
                case ProficiencyTypes.Weapon:
                case ProficiencyTypes.Unkown:
                    Proficiency = new P();
                    Proficiency.Initialize(this.ProficiencyNameTextbox.Text, proficiencyType);
                    break;
            }

            this.Close();
        }

        private void ProficiencyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboVisible(this.ProficiencyTypeComboBox.GetSelectedItem<ProficiencyTypes>() == ProficiencyTypes.Skill, this.ProficiencyTypeComboBox.GetSelectedItem<ProficiencyTypes>());

        }
    }
}
