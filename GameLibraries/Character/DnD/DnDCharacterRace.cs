using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Xml;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDCharacterRace : CharacterRaceBase
    {
        #region Fields
        private Sizes _size;
        private DnDAttributeBonusCollection _attributeBonuses;

        private int _walkingSpeed;
        private int _climbingSpeed;
        private int _flyingSpeed;
        private int _swimmingSpeed;
        private bool _amphibious;

        private VisionTypes _visionType;
        private bool _sunlightSensitive;

        private LanguageCollection _languages;
        private SkillCollection _skills;
        private ProficiencyCollection _proficiences;

        private List<Feature> _features;

        private int _hitPointBonus;
        #endregion

        #region Constructors
        public DnDCharacterRace() : base(string.Empty, string.Empty)
        {
            InternalInitialize();
        }
        public DnDCharacterRace(string name, string description)
            : base(name, description)
        {
            InternalInitialize();
        }
        /// <summary>
        /// ISerializable Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public DnDCharacterRace(SerializationInfo info, StreamingContext context)
            :this()
        {
            _attributeBonuses = (DnDAttributeBonusCollection)info.GetValue("AttributeBonuses", typeof(DnDAttributeBonusCollection));
            _languages = (LanguageCollection)info.GetValue("Languages", typeof(LanguageCollection));
            _skills = (SkillCollection)info.GetValue("Skills", typeof(SkillCollection));
            _proficiences = (ProficiencyCollection)info.GetValue("Proficiencies", typeof(ProficiencyCollection));
            _features = (List<Feature>)info.GetValue("Features", typeof(List<Feature>));
            _walkingSpeed = info.GetInt32("WalkingSpeed");
            _climbingSpeed = info.GetInt32("ClimbingSpeed");
            _flyingSpeed = info.GetInt32("FlyingSpeed");
            _swimmingSpeed = info.GetInt32("SwimmingSpeed");
            _amphibious = info.GetBoolean("Amphibious");
            _visionType = (VisionTypes)info.GetValue("VisionType", typeof(VisionTypes));
            _sunlightSensitive = info.GetBoolean("SunlightSensitive");
            _hitPointBonus = info.GetInt32("HitPointBonus");

            _name = info.GetString("Name");
            _description = info.GetString("Description");
            _category = info.GetString("Category");
        }
        #endregion

        #region Properties
        public override Sizes Size => _size;
        public DnDAttributeBonusCollection AttributeBonuses => _attributeBonuses;

        public override int WalkingSpeed => _walkingSpeed;
        public override bool IsWalking => _walkingSpeed > 0;

        public override int ClimbingSpeed => _climbingSpeed;
        public override bool IsClimbing => _climbingSpeed > 0;

        public override int FlyingSpeed => _flyingSpeed;
        public override bool IsFlying => _flyingSpeed > 0;

        public override int SwimmingSpeed => _swimmingSpeed;
        public override bool IsSwimming => _swimmingSpeed > 0;
        public override bool IsAmphibious => _amphibious;

        public VisionTypes VisionType => _visionType;
        public bool IsSunlightSensitive => _sunlightSensitive;

        public int HitPointBonus => _hitPointBonus;

        public override LanguageCollection Languages => _languages;
        public override SkillCollection Skills => _skills;
        public override ProficiencyCollection Proficiencies => _proficiences;

        public override List<Feature> Features => _features;

        #endregion

        #region Public Methods

        public override void ReadXml(string filePath)
        {
            using (XmlParser reader = new XmlParser(filePath))
            {
                XmlDocumentElement root = reader.RootElement;
                if (root.Name != "Race")
                    throw new ArgumentException(string.Format("Unexpected root node name {0} found in xml file {1}. Expected 'Race'", root.Name, filePath));

                if (root.SeekElement(XmlNameElement))
                    this._name = root.CurrentChild.Value;

                if (root.SeekElement(XmlCategoryElement))
                    this._category = root.CurrentChild.Value;

                if (root.SeekElement(XmlSizeElement))
                    this._size = root.CurrentChild.GetEnumFromValue<Sizes>();

                if (root.SeekElement(XmlAttributeBonusesElement))
                {
                    // attribute bonuses...
                    XmlDocumentElement attributeBonuses = root.CurrentChild;
                    if (attributeBonuses.HasAttribute(XmlAttributeBonusesBonusesAttribute))
                        _attributeBonuses = new DnDAttributeBonusCollection(int.Parse(attributeBonuses.GetAttributeString(XmlAttributeBonusesBonusesAttribute)));
                    else
                        _attributeBonuses = new DnDAttributeBonusCollection(attributeBonuses.Children.Count);

                    foreach (XmlDocumentElement attributeBonus in attributeBonuses.Children)
                    {
                        Attributes attribute = attributeBonus.GetEnumFromValue<Attributes>();
                        int bonus = 0;
                        bool required = true;

                        if (attributeBonus.HasAttribute(XmlAttributeBonusBonusAttribute))
                            bonus = int.Parse(attributeBonus.GetAttributeString(XmlAttributeBonusBonusAttribute));

                        if (attributeBonus.HasAttribute(XmlAttributeBonusRequiredAttribute))
                            required = Convert.ToBoolean(attributeBonus.GetAttributeString(XmlAttributeBonusRequiredAttribute));

                        _attributeBonuses.Add(new DnDAttributeBonus(attribute, bonus, required));
                    }
                }

                if (root.SeekElement(XmlWalkingSpeedElement))
                    this._walkingSpeed = int.Parse(root.CurrentChild.Value);
                if (root.SeekElement(XmlSwimmingSpeedElement))
                    this._swimmingSpeed = int.Parse(root.CurrentChild.Value);
                if (root.SeekElement(XmlFlyingSpeedElement))
                    this._flyingSpeed = int.Parse(root.CurrentChild.Value);
                if (root.SeekElement(XmlClimbingSpeedElement))
                    this._climbingSpeed = int.Parse(root.CurrentChild.Value);
                if (root.SeekElement(XmlAmphibiousElement))
                    this._amphibious = Convert.ToBoolean(root.CurrentChild.Value);

                // backwards compatibility...
                if (root.SeekElement(XmlDarkVisionElement))
                {
                    if (string.IsNullOrEmpty(root.CurrentChild.Value))
                        this._visionType = VisionTypes.Normal;
                    else
                        this._visionType = root.CurrentChild.GetEnumFromValue<VisionTypes>();
                }
                if (root.SeekElement(XmlVisionTypeElement))
                    this._visionType = root.CurrentChild.GetEnumFromValue<VisionTypes>();
                if (root.SeekElement(XmlSunlightSensitivityElement))
                    this._sunlightSensitive = Convert.ToBoolean(root.CurrentChild.Value);

                this._hitPointBonus = 0;
                if (root.SeekElement(XmlHitPointBonusElement))
                    this._hitPointBonus = int.Parse(root.CurrentChild.Value);

                if (root.SeekElement(XmlLanguagesElement))
                {
                    // languages...
                    XmlDocumentElement languages = root.CurrentChild;
                    _languages = new LanguageCollection(languages.Children.Count);

                    foreach (XmlDocumentElement language in languages.Children)
                    {
                        _languages.Add(new LanguageProficiency(language.GetEnumFromValue<Languages>()));
                    }
                }

                if (root.SeekElement(XmlSkillsElement))
                {
                    // skills...
                    XmlDocumentElement skills = root.CurrentChild;
                    _skills = new SkillCollection(skills.Children.Count);

                    foreach (XmlDocumentElement skill in skills.Children)
                    {
                        _skills.Add(new SkillProficiency(skill.GetEnumFromValue<Skills>()));
                    }
                }

                if (root.SeekElement(XmlProficienciesElement))
                {
                    // proficiences...
                    XmlDocumentElement proficiencies = root.CurrentChild;
                    _proficiences = new ProficiencyCollection(proficiencies.Children.Count);

                    foreach (XmlDocumentElement proficiency in proficiencies.Children)
                    {
                        ProficiencyTypes type = ProficiencyTypes.Unkown;
                        if (proficiency.HasAttribute(XmlProficiencyTypeAttribute))
                            type = proficiency.GetEnumFromAttributeValue<ProficiencyTypes>(XmlProficiencyTypeAttribute);
                        _proficiences.Add(new Proficiency(proficiency.Value, type));
                    }
                }

                if (root.SeekElement(XmlRaceFeaturesElement))
                {
                    XmlDocumentElement raceFeatures = root.CurrentChild;
                    _features = new List<Feature>();
                    FillCollectionFromChildElements<Feature>(_features, raceFeatures, (n, d) => new Feature(n, d));
                }
            }

        }

        public override void WriteXml(string filePath)
        {
            using (XmlBuilder writer = new XmlBuilder(filePath))
            {
                writer.OpenElement("Race");
                writer.WriteElement(XmlNameElement, this.Name);

                writer.WriteElement(XmlCategoryElement, this.Category);

                writer.WriteElement(XmlSizeElement, this.Size.ToString());

                if (AttributeBonuses.Count > 0)
                {
                    writer.OpenElement(XmlAttributeBonusesElement);
                    writer.AddAttribute(XmlAttributeBonusesBonusesAttribute, AttributeBonuses.TotalBonuses);
                    foreach (DnDAttributeBonus bonus in AttributeBonuses)
                    {
                        writer.WriteElement(XmlAttributeBonusElement, bonus.Attribute.ToString(),
                            new Tuple<string, string>(XmlAttributeBonusBonusAttribute, bonus.Bonus.ToString())
                            , new Tuple<string, string>(XmlAttributeBonusRequiredAttribute, bonus.Requried.ToString()));
                    }
                    writer.CloseElement();
                }

                if(WalkingSpeed > 0)
                    writer.WriteElement(XmlWalkingSpeedElement, WalkingSpeed);
                if(SwimmingSpeed > 0)
                    writer.WriteElement(XmlSwimmingSpeedElement, SwimmingSpeed);
                if (FlyingSpeed > 0)
                    writer.WriteElement(XmlFlyingSpeedElement, FlyingSpeed);
                if (ClimbingSpeed > 0)
                    writer.WriteElement(XmlClimbingSpeedElement, ClimbingSpeed);
                if(IsAmphibious)
                    writer.WriteElement(XmlAmphibiousElement, IsAmphibious);

                writer.WriteElement(XmlVisionTypeElement, VisionType);

                if (IsSunlightSensitive)
                    writer.WriteElement(XmlSunlightSensitivityElement, IsSunlightSensitive);
                
                if(HitPointBonus > 0)
                    writer.WriteElement(XmlHitPointBonusElement, HitPointBonus);

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
                    writer.OpenElement(XmlRaceFeaturesElement);
                    foreach (Feature feature in Features)
                    {
                        writer.WriteElement(XmlRaceFeatureElement, feature.Description
                            , new Tuple<string, string>(XmlNameAttribute, feature.Name));
                    }
                    writer.CloseElement();
                }

                writer.FinalizeDocument();
            }
        }
        
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AttributeBonuses", _attributeBonuses);
            info.AddValue("Languages", _languages);
            info.AddValue("Skills", _skills);
            info.AddValue("Proficiencies", _proficiences);
            info.AddValue("Features", _features);
            info.AddValue("WalkingSpeed", _walkingSpeed);
            info.AddValue("ClimbingSpeed", _climbingSpeed);
            info.AddValue("FlyingSpeed", _flyingSpeed);
            info.AddValue("SwimmingSpeed", _swimmingSpeed);
            info.AddValue("Amphibious", _amphibious);
            info.AddValue("VisionType", _visionType);
            info.AddValue("SunlightSensitive", _sunlightSensitive);
            info.AddValue("HitPointBonus", _hitPointBonus);

            info.AddValue("Name", _name);
            info.AddValue("Description", _description);
            info.AddValue("Category", _category);
        }

        public override void Create(string name, Sizes size, DnDAttributeBonusCollection attributeBonuses, int walkingSpeed, int climbingSpeed, int flyingSpeed, int swimmingSpeed, VisionTypes vision, bool amphibious, bool sunlightSensitive
            , LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features, int hitpointBonus)
        {
            _name = name;
            _size = size;
            _attributeBonuses = attributeBonuses;
            _languages = languages;
            _skills = skills;
            _proficiences = proficiencies;
            _features = features;

            _walkingSpeed = walkingSpeed;
            _climbingSpeed = climbingSpeed;
            _flyingSpeed = flyingSpeed;
            _swimmingSpeed = swimmingSpeed;
            _amphibious = amphibious;

            _visionType = vision;
            _sunlightSensitive = sunlightSensitive;

            _hitPointBonus = hitpointBonus;
        }

        public override CharacterPropertyBase Clone()
        {
            DnDCharacterRace clone = new DnDCharacterRace(_name, _description);
            clone._category = this._category;
            clone._size = this._size;
            clone._attributeBonuses = this._attributeBonuses;
            clone._walkingSpeed = this._walkingSpeed;
            clone._climbingSpeed = this._climbingSpeed;
            clone._flyingSpeed = this._flyingSpeed;
            clone._swimmingSpeed = this._swimmingSpeed;
            clone._amphibious = this._amphibious;
            clone._visionType = this._visionType;
            clone._sunlightSensitive = this._sunlightSensitive;
            clone._languages = new LanguageCollection( this._languages);
            clone._skills = this._skills;
            clone._proficiences = this._proficiences;
            clone._features = this._features;
            clone._hitPointBonus = this._hitPointBonus;

            return clone;
        }

        #endregion

        #region Private Methods
        protected override void InternalInitialize()
        {
            _size = Sizes.Medium;
            _attributeBonuses = new DnDAttributeBonusCollection(0);
            _languages = new LanguageCollection(0);
            _skills = new SkillCollection(0);
            _proficiences = new ProficiencyCollection(0);
            _features = new List<Feature>();

            _walkingSpeed = 0;
            _climbingSpeed = 0;
            _flyingSpeed = 0;
            _swimmingSpeed = 0;
            _amphibious = false;

            _visionType = VisionTypes.Normal;
            _sunlightSensitive = false;

            _hitPointBonus = 0;
        }
        #endregion
    }
}
