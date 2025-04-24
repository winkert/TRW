using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Serialization;
using TRW.CommonLibraries.Xml;
using TRW.GameLibraries.GameCore;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDCharacterBackground : CharacterBackgroundBase
    {
        #region Fields
        private LanguageCollection _languages;
        private SkillCollection _skills;
        private ProficiencyCollection _proficiences;
        private List<Feature> _features;
        private List<DnDBackgroundPersonalityTrait> _traits;
        private List<DnDBackgroundBond> _bonds;
        private List<DnDBackgroundIdeal> _ideals;
        private List<DnDBackgroundFlaw> _flaws;
        #endregion

        #region Constructors
        public DnDCharacterBackground() : base()
        {
            InternalInitialize();
        }
        public DnDCharacterBackground(string name, string description)
            : base(name, description)
        {
            InternalInitialize();
        }
        
        #endregion

        #region Properties
        public override LanguageCollection Languages => _languages;
        public override SkillCollection Skills => _skills;
        public override ProficiencyCollection Proficiencies => _proficiences;
        public override List<Feature> Features => _features;

        public List<DnDBackgroundPersonalityTrait> Traits => _traits;
        public List<DnDBackgroundBond> Bonds => _bonds;
        public List<DnDBackgroundIdeal> Ideals => _ideals;
        public List<DnDBackgroundFlaw> Flaws => _flaws;
        #endregion

        #region Public Methods

        public override void ReadXml(string filePath)
        {
            using (XmlParser reader = new XmlParser(filePath))
            {
                XmlDocumentElement root = reader.RootElement;
                if (root.Name != "Background")
                    throw new ArgumentException(string.Format("Unexpected root node name {0} found in xml file {1}. Expected 'Background'", root.Name, filePath));

                if (root.SeekElement(XmlNameElement))
                    this._name = root.CurrentChild.Value;

                if (root.SeekElement(XmlCategoryElement))
                    this._category = root.CurrentChild.Value;

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

                // traits, bonds, ideals, flaws
                if (root.SeekElement(XmlBackgroundTraitsElement))
                {
                    XmlDocumentElement traits = root.CurrentChild;
                    _traits = new List<DnDBackgroundPersonalityTrait>();
                    FillCollectionFromChildElements<DnDBackgroundPersonalityTrait>(_traits, traits, (n, d) => new DnDBackgroundPersonalityTrait(n, d));
                }

                if (root.SeekElement(XmlBackgroundBondsElement))
                {
                    XmlDocumentElement bonds = root.CurrentChild;
                    _bonds = new List<DnDBackgroundBond>();
                    FillCollectionFromChildElements<DnDBackgroundBond>(_bonds, bonds, (n, d) => new DnDBackgroundBond(n, d));
                }

                if (root.SeekElement(XmlBackgroundIdealsElement))
                {
                    XmlDocumentElement ideals = root.CurrentChild;
                    _ideals = new List<DnDBackgroundIdeal>();
                    FillCollectionFromChildElements<DnDBackgroundIdeal>(_ideals, ideals, (n, d) => new DnDBackgroundIdeal(n, d));
                }

                if (root.SeekElement(XmlBackgroundFlawsElement))
                {
                    XmlDocumentElement flaws = root.CurrentChild;
                    _flaws = new List<DnDBackgroundFlaw>();
                    FillCollectionFromChildElements<DnDBackgroundFlaw>(_flaws, flaws, (n, d) => new DnDBackgroundFlaw(n, d));
                }
            }
        }

        public override void WriteXml(string filePath)
        {
            using (XmlBuilder writer = new XmlBuilder(filePath))
            {
                writer.OpenElement("Background");
                writer.WriteElement(XmlNameElement, this.Name);

                writer.WriteElement(XmlCategoryElement, this.Category);

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

                // traits, bonds, ideals, flaws
                if (Traits.Count > 0)
                {
                    writer.OpenElement(XmlBackgroundTraitsElement);
                    foreach (DnDBackgroundPersonalityTrait trait in Traits)
                    {
                        writer.WriteElement(XmlBackgroundTraitElement, trait.Description
                            , new Tuple<string, string>(XmlNameAttribute, trait.Name));
                    }
                    writer.CloseElement();
                }

                if (Bonds.Count > 0)
                {
                    writer.OpenElement(XmlBackgroundBondsElement);
                    foreach (DnDBackgroundBond bond in Bonds)
                    {
                        writer.WriteElement(XmlBackgroundBondElement, bond.Description
                            , new Tuple<string, string>(XmlNameAttribute, bond.Name));
                    }
                    writer.CloseElement();
                }

                if (Ideals.Count > 0)
                {
                    writer.OpenElement(XmlBackgroundIdealsElement);
                    foreach (DnDBackgroundIdeal ideal in Ideals)
                    {
                        writer.WriteElement(XmlBackgroundIdealElement, ideal.Description
                            , new Tuple<string, string>(XmlNameAttribute, ideal.Name));
                    }
                    writer.CloseElement();
                }

                if (Flaws.Count > 0)
                {
                    writer.OpenElement(XmlBackgroundFlawsElement);
                    foreach (DnDBackgroundFlaw flaw in Flaws)
                    {
                        writer.WriteElement(XmlBackgroundFlawElement, flaw.Description
                            , new Tuple<string, string>(XmlNameAttribute, flaw.Name));
                    }
                    writer.CloseElement();
                }
                writer.FinalizeDocument();
            }
        }

        public override void WriteTo(BinaryWriter writer)
        {
            writer.Write(_languages.ToByteArray());
            writer.Write(_skills.ToByteArray());
            writer.Write(_proficiences.ToByteArray());
            BinarySerializationRoutines.WriteCollection(writer, _features.Count, _features);

            BinarySerializationRoutines.WriteCollection(writer, _traits.Count, _traits);
            BinarySerializationRoutines.WriteCollection(writer, _bonds.Count, _bonds);
            BinarySerializationRoutines.WriteCollection(writer, _ideals.Count, _ideals);
            BinarySerializationRoutines.WriteCollection(writer, _flaws.Count, _flaws);

            WriteToBase(writer);
        }

        public override void ReadFrom(BinaryReader reader)
        {
            _languages = new LanguageCollection();
            _languages.ReadFrom(reader);
            _skills = new SkillCollection();
            _skills.ReadFrom(reader);
            _proficiences = new ProficiencyCollection();
            _proficiences.ReadFrom(reader);
            int count = reader.ReadInt32();
            _features = new List<Feature>();
            BinarySerializationRoutines.ReadCollection(reader, count, _features);

            count = reader.ReadInt32();
            _traits = new List<DnDBackgroundPersonalityTrait>();
            BinarySerializationRoutines.ReadCollection(reader, count, _traits);

            count = reader.ReadInt32();
            _bonds = new List<DnDBackgroundBond>();
            BinarySerializationRoutines.ReadCollection(reader, count, _bonds);

            count = reader.ReadInt32();
            _ideals = new List<DnDBackgroundIdeal>();
            BinarySerializationRoutines.ReadCollection(reader, count, _ideals);

            count = reader.ReadInt32();
            _flaws = new List<DnDBackgroundFlaw>();
            BinarySerializationRoutines.ReadCollection(reader, count, _flaws);

            ReadFromBase(reader);
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }

        public override void Create(string name, LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features)
        {
            Create(name, languages, skills, proficiencies, features, new List<DnDBackgroundPersonalityTrait>(), new List<DnDBackgroundFlaw>(), new List<DnDBackgroundIdeal>(), new List<DnDBackgroundBond>());
        }

        public void Create(string name, LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features
            , List<DnDBackgroundPersonalityTrait> traits, List<DnDBackgroundFlaw> flaws, List<DnDBackgroundIdeal> ideals, List<DnDBackgroundBond> bonds)
        {
            _name = name;
            _languages = languages;
            _skills = skills;
            _proficiences = proficiencies;
            _features = features;

            _traits = traits;
            _bonds = bonds;
            _ideals = ideals;
            _flaws = flaws;
        }

        public override CharacterPropertyBase Clone()
        {
            DnDCharacterBackground clone = new DnDCharacterBackground(_name, _description);
            clone._category = this._category;
            clone._languages = this._languages;
            clone._skills = this._skills;
            clone._proficiences = this._proficiences;
            clone._features = this._features;
            clone._traits = this._traits;
            clone._bonds = this._bonds;
            clone._ideals = this._ideals;
            clone._flaws = this._flaws;

            return clone;
        }

        #endregion

        #region Private Methods
        protected override void InternalInitialize()
        {
            _languages = new LanguageCollection(0);
            _skills = new SkillCollection(0);
            _proficiences = new ProficiencyCollection(0);
            _features = new List<Feature>();

            _traits = new List<DnDBackgroundPersonalityTrait>();
            _bonds = new List<DnDBackgroundBond>();
            _ideals = new List<DnDBackgroundIdeal>();
            _flaws = new List<DnDBackgroundFlaw>();
        }

        #endregion
    }
}
