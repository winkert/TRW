using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Xml;
using TRW.GameLibraries.GameCore;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDCharacterClass : CharacterClassBase
    {
        #region Fields
        private GameCore.Dice _hitDie;
        private Attributes _primaryAttribute;
        private Attributes _secondaryAttribute;
        private Attributes _spellCastingAbility;
        private ProficiencyCollection<DnDSavingThrowProficiency> _savingThrows;

        private LanguageCollection _languages;
        private SkillCollection _skills;
        private ProficiencyCollection _proficiences;
        private List<Feature> _features;
        #endregion

        #region Constructors
        public DnDCharacterClass() : base(string.Empty, string.Empty)
        {
            InternalInitialize();
        }
        public DnDCharacterClass(string name, string description)
            : base(name, description)
        {
            InternalInitialize();
        }
        /// <summary>
        /// ISerializable Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public DnDCharacterClass(SerializationInfo info, StreamingContext context)
            : this()
        {
            _languages = (LanguageCollection)info.GetValue("Languages", typeof(LanguageCollection));
            _skills = (SkillCollection)info.GetValue("Skills", typeof(SkillCollection));
            _proficiences = (ProficiencyCollection)info.GetValue("Proficiencies", typeof(ProficiencyCollection));
            _features = (List<Feature>)info.GetValue("Features", typeof(List<Feature>));
            _hitDie = (GameCore.Dice)info.GetValue("HitDie", typeof(GameCore.Dice));
            _savingThrows = (ProficiencyCollection<DnDSavingThrowProficiency>)info.GetValue("SavingThrows", typeof(ProficiencyCollection<DnDSavingThrowProficiency>));
            _primaryAttribute = (Attributes)info.GetValue("PrimaryAttribute", typeof(Attributes));
            _secondaryAttribute = (Attributes)info.GetValue("SecondaryAttribute", typeof(Attributes));
            _spellCastingAbility = (Attributes)info.GetValue("SpellCastingAbility", typeof(Attributes));

            _name = info.GetString("Name");
            _description = info.GetString("Description");
            _category = info.GetString("Category");
        }
        #endregion

        #region Properties
        public override Attributes PrimaryAttribute => _primaryAttribute;
        public override Attributes SecondaryAttribute => _secondaryAttribute;
        public override Attributes SpellCastingAbility => _spellCastingAbility;
        public ProficiencyCollection<DnDSavingThrowProficiency> SavingThrows => _savingThrows;
        public override LanguageCollection Languages => _languages;
        public override SkillCollection Skills => _skills;
        public override ProficiencyCollection Proficiencies => _proficiences;
        public override List<Feature> Features => _features;
        public GameCore.Dice HitDie => _hitDie;
        #endregion

        #region Public Methods
        public override void ReadXml(string filePath)
        {
            using (XmlParser reader = new XmlParser(filePath))
            {
                XmlDocumentElement root = reader.RootElement;
                if (root.Name != "Class")
                    throw new ArgumentException(string.Format("Unexpected root node name {0} found in xml file {1}. Expected 'Class'", root.Name, filePath));

                if (root.SeekElement(XmlNameElement))
                    this._name = root.CurrentChild.Value;

                if (root.SeekElement(XmlCategoryElement))
                    this._category = root.CurrentChild.Value;

                if (root.SeekElement(XmlHitDieElement))
                {
                    this._hitDie = new GameCore.Dice(int.Parse(root.CurrentChild.Value));
                }

                if (root.SeekElement(XmlPrimaryAttributeElement))
                {
                    this._primaryAttribute = root.CurrentChild.GetEnumFromValue<Attributes>();
                }

                if (root.SeekElement(XmlSecondaryAttributeElement))
                {
                    this._secondaryAttribute = root.CurrentChild.GetEnumFromValue<Attributes>();
                }

                if (root.SeekElement(XmlSpellcastingAbilityElement))
                {
                        this._spellCastingAbility = root.CurrentChild.GetEnumFromValue<Attributes>();
                }

                if (root.SeekElement(XmlSaveProficienciesElement))
                {
                    XmlDocumentElement saveProficiencies = root.CurrentChild;

                    foreach (XmlDocumentElement saveProficiency in saveProficiencies.Children)
                    {
                        _savingThrows.Add(new DnDSavingThrowProficiency(saveProficiency.GetEnumFromValue<Attributes>()));
                    }
                }

                if (root.SeekElement(XmlLanguagesElement))
                {
                    // languages...
                    XmlDocumentElement languages = root.CurrentChild;

                    int totalLanguagesAllowed = languages.Children.Count;

                    _languages = new LanguageCollection(totalLanguagesAllowed);

                    foreach (XmlDocumentElement language in languages.Children)
                    {
                        _languages.Add(new LanguageProficiency(language.GetEnumFromValue<Languages>()));
                    }
                }

                if (root.SeekElement(XmlSkillsElement))
                {
                    // skills...
                    XmlDocumentElement skills = root.CurrentChild;

                    int totalSkillsAllowed = skills.Children.Count;
                    if (skills.HasAttribute(XmlSkillsTotalAttribute))
                        totalSkillsAllowed = int.Parse(skills.GetAttributeString(XmlSkillsTotalAttribute));

                    _skills = new SkillCollection(totalSkillsAllowed);

                    foreach (XmlDocumentElement skill in skills.Children)
                    {
                        _skills.Add(new SkillProficiency(skill.GetEnumFromValue<Skills>()));
                    }
                }

                if (root.SeekElement(XmlProficienciesElement))
                {
                    // proficiences...
                    XmlDocumentElement proficiencies = root.CurrentChild;

                    int totalProfsAllowed = proficiencies.Children.Count;

                    _proficiences = new ProficiencyCollection(totalProfsAllowed);

                    foreach (XmlDocumentElement proficiency in proficiencies.Children)
                    {
                        ProficiencyTypes type = ProficiencyTypes.Unkown;
                        if (proficiency.HasAttribute(XmlProficiencyTypeAttribute))
                            type = proficiency.GetEnumFromAttributeValue<ProficiencyTypes>(XmlProficiencyTypeAttribute);
                        _proficiences.Add(new Proficiency(proficiency.Value, type));
                    }
                }

                if (root.SeekElement(XmlFeaturesElement))
                {
                    XmlDocumentElement features = root.CurrentChild;
                    _features = new List<Feature>();
                    FillCollectionFromChildElements<Feature>(_features, features, (n, d) => new Feature(n, d));
                }
            }
        }

        public override void WriteXml(string filePath)
        {
            using (XmlBuilder writer = new XmlBuilder(filePath))
            {
                writer.OpenElement("Class");
                writer.WriteElement(XmlNameElement, this.Name);

                writer.WriteElement(XmlCategoryElement, this.Category);

                writer.WriteElement(XmlHitDieElement, this._hitDie.DiceSides);

                if (this.PrimaryAttribute != Attributes.None)
                    writer.WriteElement(XmlPrimaryAttributeElement, PrimaryAttribute);

                if (this.SecondaryAttribute != Attributes.None)
                    writer.WriteElement(XmlSecondaryAttributeElement, SecondaryAttribute);

                if (this.SpellCastingAbility != Attributes.None)
                    writer.WriteElement(XmlSpellcastingAbilityElement, SpellCastingAbility);

                if (SavingThrows.Count > 0)
                {
                    writer.OpenElement(XmlSaveProficienciesElement);
                    foreach (DnDSavingThrowProficiency save in SavingThrows)
                    {
                        writer.WriteElement(XmlSaveProficiencyElement, save.SavingThrowAttribute);
                    }
                    writer.CloseElement();
                }

                if (Languages.Count > 0)
                {
                    writer.OpenElement(XmlLanguagesElement);
                    foreach (LanguageProficiency language in Languages)
                    {
                        writer.WriteElement(XmlLanguageElement, language.Language);
                    }
                    writer.CloseElement();
                }

                if (Skills.Count > 0)
                {
                    writer.OpenElement(XmlSkillsElement);
                    writer.AddAttribute(XmlSkillsTotalAttribute, Skills.TotalProficiencies);
                    foreach (SkillProficiency skill in Skills)
                    {
                        writer.WriteElement(XmlSkillOptionElement, skill.Name);
                    }
                    writer.CloseElement();
                }

                if (Proficiencies.Count > 0)
                {
                    writer.OpenElement(XmlProficienciesElement);
                    foreach (Proficiency proficiency in Proficiencies)
                    {
                        writer.WriteElement(XmlProficiencyElement, proficiency.Name
                            , new Tuple<string, string>(XmlProficiencyTypeAttribute, proficiency.ProficiencyType.ToString()));
                    }
                    writer.CloseElement();
                }

                if (Features.Count > 0)
                {
                    writer.OpenElement(XmlFeaturesElement);
                    foreach (Feature feature in Features)
                    {
                        writer.WriteElement(XmlFeatureElement, feature.Description
                            , new Tuple<string, string>(XmlNameAttribute, feature.Name));
                    }
                    writer.CloseElement();
                }

                writer.FinalizeDocument();
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Languages", _languages);
            info.AddValue("Skills", _skills);
            info.AddValue("Proficiencies", _proficiences);
            info.AddValue("Features", _features);
            info.AddValue("HitDie", _hitDie);
            info.AddValue("SavingThrows", _savingThrows);
            info.AddValue("PrimaryAttribute", _primaryAttribute);
            info.AddValue("SecondaryAttribute", _secondaryAttribute);
            info.AddValue("SpellCastingAbility", _spellCastingAbility);

            info.AddValue("Name", _name);
            info.AddValue("Description", _description);
            info.AddValue("Category", _category);
        }

        public override void Create(string name, GameCore.Dice hitDie, Attributes primaryAttribute, Attributes secondaryAttribute, Attributes spellCastingAbility, LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features)
        {
            Create(name, hitDie, primaryAttribute, secondaryAttribute, spellCastingAbility, new ProficiencyCollection<DnDSavingThrowProficiency>(), languages, skills, proficiencies, features);
        }

        public void Create(string name, GameCore.Dice hitDie, Attributes primaryAttribute, Attributes secondaryAttribute, Attributes spellCastingAbility, ProficiencyCollection<DnDSavingThrowProficiency> savingThrows
            , LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features)
        {
            _name = name;
            _hitDie = hitDie;
            _primaryAttribute = primaryAttribute;
            _secondaryAttribute = secondaryAttribute;
            _savingThrows = savingThrows;
            _languages = languages;
            _skills = skills;
            _proficiences = proficiencies;
            _features = features;
            _spellCastingAbility = spellCastingAbility;
        }

        public override CharacterPropertyBase Clone()
        {
            DnDCharacterClass clone = new DnDCharacterClass(_name, _description);
            clone._category = this._category;
            clone._hitDie = this._hitDie;
            clone._primaryAttribute = this._primaryAttribute;
            clone._secondaryAttribute = this._secondaryAttribute;
            clone._spellCastingAbility = this._spellCastingAbility;
            clone._savingThrows = this._savingThrows;
            clone._languages = this._languages;
            clone._skills = this._skills;
            clone._proficiences = this._proficiences;
            clone._features = this._features;

            return clone;
        }

        #endregion

        #region Private Methods
        protected override void InternalInitialize()
        {
            _hitDie = new GameCore.Dice();

            _savingThrows = new ProficiencyCollection<DnDSavingThrowProficiency>();

            _languages = new LanguageCollection(0);
            _skills = new SkillCollection(0);
            _proficiences = new ProficiencyCollection(0);
            _features = new List<Feature>();
        }
        #endregion
    }
}
