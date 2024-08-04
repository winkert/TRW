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
using TRW.Apps.TrwAppsBase;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class PropertyManagerProficiencyGroup : TrwFormBase
    {
        public PropertyManagerProficiencyGroup()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.TotalLanguagesNumeric.Value = 0;
            this.LanguagesListBox.Items.Clear();
            this.TotalSkillsNumeric.Value = 0;
            this.SkillsListBox.Items.Clear();
            this.TotalProficienciesNumeric.Value = 0;
            this.ProficienciesListBox.Items.Clear();
            this.FeaturesListBox.Items.Clear();
        }

        public void Populate(LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features)
        {
            this.TotalLanguagesNumeric.Value = languages.TotalProficiencies;
            foreach (LanguageProficiency language in languages)
            {
                AddLanguage(language);
            }
            this.TotalSkillsNumeric.Value = skills.TotalProficiencies;
            foreach (SkillProficiency skill in skills)
            {
                AddSkill(skill);
            }
            this.TotalProficienciesNumeric.Value = proficiencies.TotalProficiencies;
            foreach (Proficiency proficiency in proficiencies)
            {
                AddProficiency(proficiency);
            }
            foreach (Feature feature in features)
            {
                AddFeature(feature);
            }
        }

        public LanguageCollection GetLanguages()
        {
            LanguageCollection languages = new LanguageCollection(Convert.ToInt32(this.TotalLanguagesNumeric.Value));
            foreach (LanguageProficiency l in GetItemsAsList<LanguageProficiency>(this.LanguagesListBox))
            {
                languages.Add(l);
            }
            return languages;
        }

        public SkillCollection GetSkills()
        {
            SkillCollection skills = new SkillCollection(Convert.ToInt32(this.TotalSkillsNumeric.Value));
            foreach (SkillProficiency s in GetItemsAsList<SkillProficiency>(this.SkillsListBox))
            {
                skills.Add(s);
            }
            return skills;
        }

        public ProficiencyCollection GetProficiencies()
        {
            ProficiencyCollection proficiencies = new ProficiencyCollection(Convert.ToInt32(this.TotalProficienciesNumeric.Value));
            foreach (Proficiency p in GetItemsAsList<Proficiency>(this.ProficienciesListBox))
            {
                proficiencies.Add(p);
            }
            return proficiencies;
        }

        public List<Feature> GetFeatures()
        {
            return GetItemsAsList<Feature>(this.FeaturesListBox);
        }

        public void AddLanguage(LanguageProficiency language)
        {
            this.LanguagesListBox.Items.Add(language);
        }

        public void AddSkill(SkillProficiency skill)
        {
            this.SkillsListBox.Items.Add(skill);
        }

        public void AddProficiency(Proficiency proficiency)
        {
            this.ProficienciesListBox.Items.Add(proficiency);
        }

        public void AddFeature(Feature feature)
        {
            this.FeaturesListBox.Items.Add(feature);
        }

        public bool ValidateScreen()
        {
            return true;
        }
        #region Event Handlers
        private void AddLanguageButton_Click(object sender, EventArgs e)
        {
            AddProficiencyDialog<LanguageProficiency> dialog = new AddProficiencyDialog<LanguageProficiency>(ProficiencyTypes.Language);
            dialog.FormClosed += AddLanguageDialog_FormClosed;
            dialog.Show();
        }

        private void AddLanguageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddProficiencyDialog<LanguageProficiency> dialog = sender as AddProficiencyDialog<LanguageProficiency>;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddLanguage(dialog.Proficiency);
                }
                else
                {
                    this.LanguagesListBox.Items[dialog.Index] = dialog.Proficiency;
                }
            }
        }

        private void EditLanguageButton_Click(object sender, EventArgs e)
        {
            if (this.LanguagesListBox.SelectedIndex > -1)
            {
                AddProficiencyDialog<LanguageProficiency> dialog = new AddProficiencyDialog<LanguageProficiency>(((LanguageProficiency)this.LanguagesListBox.SelectedItem), ProficiencyTypes.Language, this.LanguagesListBox.SelectedIndex);
                dialog.FormClosed += AddLanguageDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteLanguageButton_Click(object sender, EventArgs e)
        {
            if (this.LanguagesListBox.SelectedIndex > -1)
                this.LanguagesListBox.Items.RemoveAt(this.LanguagesListBox.SelectedIndex);
        }

        private void AddSkillButton_Click(object sender, EventArgs e)
        {
            AddProficiencyDialog<SkillProficiency> dialog = new AddProficiencyDialog<SkillProficiency>(ProficiencyTypes.Skill);
            dialog.FormClosed += AddSkillDialog_FormClosed;
            dialog.Show();
        }

        private void AddSkillDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddProficiencyDialog<SkillProficiency> dialog = sender as AddProficiencyDialog<SkillProficiency>;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddSkill(dialog.Proficiency);
                }
                else
                {
                    this.SkillsListBox.Items[dialog.Index] = dialog.Proficiency;
                }
            }
        }

        private void EditSkillButton_Click(object sender, EventArgs e)
        {
            if (SkillsListBox.SelectedIndex > -1)
            {
                AddProficiencyDialog<SkillProficiency> dialog = new AddProficiencyDialog<SkillProficiency>((SkillProficiency)SkillsListBox.SelectedItem, ProficiencyTypes.Skill, SkillsListBox.SelectedIndex);
                dialog.FormClosed += AddSkillDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteSkillButton_Click(object sender, EventArgs e)
        {
            if (this.SkillsListBox.SelectedIndex > -1)
                this.SkillsListBox.Items.RemoveAt(this.SkillsListBox.SelectedIndex);
        }

        private void AddProficiencyButton_Click(object sender, EventArgs e)
        {
            AddProficiencyDialog<Proficiency> dialog = new AddProficiencyDialog<Proficiency>();
            dialog.FormClosed += AddProficiencyDialog_FormClosed;
            dialog.Show();
        }

        private void AddProficiencyDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddProficiencyDialog<Proficiency> dialog = sender as AddProficiencyDialog<Proficiency>;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddProficiency(dialog.Proficiency);
                }
                else
                {
                    this.ProficienciesListBox.Items[dialog.Index] = dialog.Proficiency;
                }
            }
        }

        private void EditProficiencyButton_Click(object sender, EventArgs e)
        {
            if (this.ProficienciesListBox.SelectedIndex > -1)
            {
                AddProficiencyDialog<Proficiency> dialog = new AddProficiencyDialog<Proficiency>((Proficiency)ProficienciesListBox.SelectedItem, ((Proficiency)ProficienciesListBox.SelectedItem).ProficiencyType, this.ProficienciesListBox.SelectedIndex);
                dialog.FormClosed += AddProficiencyDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteProficiencyButton_Click(object sender, EventArgs e)
        {
            if (this.ProficienciesListBox.SelectedIndex > -1)
                this.ProficienciesListBox.Items.RemoveAt(this.ProficienciesListBox.SelectedIndex);
        }

        private void AddFeatureButton_Click(object sender, EventArgs e)
        {
            AddFeatureDialog dialog = new AddFeatureDialog();
            dialog.FormClosed += AddFeatureDialog_FormClosed;
            dialog.Show();
        }

        private void AddFeatureDialog_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender == null)
                return;

            AddFeatureDialog? dialog = sender as AddFeatureDialog;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddFeature(dialog.Feature);
                }
                else
                {
                    this.FeaturesListBox.Items[dialog.Index] = dialog.Feature;
                }
            }
        }

        private void EditFeatureButton_Click(object sender, EventArgs e)
        {
            if (this.FeaturesListBox.SelectedIndex > -1)
            {
                AddFeatureDialog dialog = new AddFeatureDialog((Feature)this.FeaturesListBox.SelectedItem, this.FeaturesListBox.SelectedIndex);
                dialog.FormClosed += AddFeatureDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteFeatureButton_Click(object sender, EventArgs e)
        {
            if (this.FeaturesListBox.SelectedIndex > -1)
                this.FeaturesListBox.Items.RemoveAt(this.FeaturesListBox.SelectedIndex);
        }
        #endregion

    }
}
