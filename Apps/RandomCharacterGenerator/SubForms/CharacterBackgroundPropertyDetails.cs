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
    public partial class CharacterBackgroundPropertyDetails : TRW.Apps.TrwAppsBase.TrwFormBase, IPropertyDetailsForm
    {
        private DnDCharacterBackground _background;
        private string _filePath;
        PropertyManagerProficiencyGroup _proficiencies;
        BackgroundPropertyTraitsGroup _traits;

        public CharacterBackgroundPropertyDetails()
        {
            InitializeComponent();
            _proficiencies = this.ProficiencyGroupPanel.AddSubForm<PropertyManagerProficiencyGroup>();
            _traits = this.BackgroundTraitsPanel.AddSubForm<BackgroundPropertyTraitsGroup>();
        }


        public void Clear()
        {
            _background = null;
            _filePath = string.Empty;

            this.NameTextBox.Clear();

            this._proficiencies.Clear();
            this._traits.Clear();
        }

        public void LoadDetailScreen(CharacterPropertyBase property, string filePath)
        {
            _background = property as DnDCharacterBackground;
            _filePath = filePath;
            this.BackgroundDetailsGroupBox.Text = string.Format("{0} Race Details", _background.Name);

            this.NameTextBox.Text = _background.Name;

            _proficiencies.Populate(_background.Languages, _background.Skills, _background.Proficiencies, _background.Features);
            _traits.Populate(_background.Traits, _background.Flaws, _background.Ideals, _background.Bonds);
        }

        public CharacterPropertyBase Save()
        {
            if(_background == null)
            {
                _background = new DnDCharacterBackground();
            }
            LanguageCollection languages = _proficiencies.GetLanguages();
            SkillCollection skills = _proficiencies.GetSkills();
            ProficiencyCollection proficiencies = _proficiencies.GetProficiencies();
            List<Feature> features = _proficiencies.GetFeatures();

            List<DnDBackgroundPersonalityTrait> traits = _traits.GetPersonalityTraits();
            List<DnDBackgroundBond> bonds = _traits.GetBonds();
            List<DnDBackgroundIdeal> ideals = _traits.GetIdeals();
            List<DnDBackgroundFlaw> flaws = _traits.GetFlaws();

        _background.Create(this.NameTextBox.Text, languages, skills, proficiencies, features
            , traits, flaws, ideals, bonds);

            return _background;
        }

        public void SetEditMode(bool edit)
        {
            BackgroundDetailsGroupBox.Enabled = edit;

        }

        public bool ValidateScreen()
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                errorProvider1.SetError(NameTextBox, "Name Required");
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
            _background = null;
            _filePath = string.Empty;
        }


        #region Event Handlers

        #endregion
    }
}
