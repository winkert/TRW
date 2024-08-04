using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TRW.GameLibraries.Character.DnD
{
    [Serializable]
    public class DnDCharacter : CharacterBase
    {
        #region Fields
        private readonly DnDCharacterRace _race;
        private readonly DnDCharacterClass _class;
        private readonly DnDCharacterBackground _background;

        private int _level;

        private List<bool> _deathSaves;
        private bool _dying = false;
        #endregion

        #region Constructors
        public DnDCharacter()
            : base()
        {

        }
        public DnDCharacter(DnDCharacterRace oRace, DnDCharacterClass oClass, DnDCharacterBackground oBackground)
            : this(oRace, oClass, oBackground, 1, CharacterBase.RollAttributes<DnDCharacter>())
        {

        }
        public DnDCharacter(DnDCharacterRace oRace, DnDCharacterClass oClass, DnDCharacterBackground oBackground, int iLevel)
            : this(oRace, oClass, oBackground, iLevel, CharacterBase.RollAttributes<DnDCharacter>())
        {

        }
        public DnDCharacter(DnDCharacterRace oRace, DnDCharacterClass oClass, DnDCharacterBackground oBackground, int iLevel, int[] attributes)
            : this(oRace, oClass, oBackground, iLevel, attributes[0], attributes[1], attributes[2], attributes[3], attributes[4], attributes[5])
        {

        }
        public DnDCharacter(DnDCharacterRace oRace, DnDCharacterClass oClass, DnDCharacterBackground oBackground, int iLevel, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
            : base()
        {
            _race = oRace;
            _class = oClass;
            _background = oBackground;

            _level = iLevel;

            _attributes.Add(Attributes.Strength, strength);
            _attributes.Add(Attributes.Dexterity, dexterity);
            _attributes.Add(Attributes.Constitution, constitution);
            _attributes.Add(Attributes.Intelligence, intelligence);
            _attributes.Add(Attributes.Wisdom, wisdom);
            _attributes.Add(Attributes.Charisma, charisma);

            RollHitPoints();
            base.CharacterHitPoints = this.CharacterMaxHitPoints;
            _deathSaves = new List<bool>();
        }
        /// <summary>
        /// ISerializable Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DnDCharacter(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _race = (DnDCharacterRace)info.GetValue("Race", typeof(DnDCharacterRace));
            _class = (DnDCharacterClass)info.GetValue("Class", typeof(DnDCharacterClass));
            _background = (DnDCharacterBackground)info.GetValue("Background", typeof(DnDCharacterBackground));
            _level = info.GetInt32("Level");
            CharacterMaxHitPoints = info.GetInt32("HitPoints");
            _attributes = (Dictionary<Attributes, int>)info.GetValue("Attributes", typeof(Dictionary<Attributes, int>));
            _deathSaves = new List<bool>();

        }
        #endregion

        #region Properties
        protected override int TotalAttributes { get; } = 6;
        protected override string AttributeRoll { get; } = "4d6";
        protected override GameCore.DiceOptions AttributeDiceRollOptions { get; } = GameCore.DiceOptions.DropLowest;
        protected override int MinimumAttributeSum { get; } = 65;

        public string Race => _race.Name;
        public string Class => _class.Name;
        public string Background => _background.Name;

        public override int CharacterLevel => _level;
        public GameCore.Dice HitDie => _class.HitDie;
        public int CharacterMaxHitPoints { get; private set; }
        public Sizes Size => _race.Size;

        public string AttributeBonuses => _race.AttributeBonuses.ToString();
        public Attributes PrimaryAttribute => _class.PrimaryAttribute;
        public Attributes SecondaryAttribute => _class.SecondaryAttribute;
        public Attributes SpellCastingAbility => _class.SpellCastingAbility;
        public ProficiencyCollection<DnDSavingThrowProficiency> SavingThrows => _class.SavingThrows;

        public int StrengthBonus => (Strength / 2) - 5;
        public int DexterityBonus => (Dexterity / 2) - 5;
        public int ConstitutionBonus => (Constitution / 2) - 5;
        public int IntelligenceBonus => (Intelligence / 2) - 5;
        public int WisdomBonus => (Wisdom / 2) - 5;
        public int CharismaBonus => (Charisma / 2) - 5;

        public int WalkingSpeed => _race.WalkingSpeed;
        public int ClimbingSpeed => _race.ClimbingSpeed;
        public int FlyingSpeed => _race.FlyingSpeed;
        public int SwimmingSpeed => _race.SwimmingSpeed;
        public bool IsAmphibious => _race.IsAmphibious;

        public VisionTypes VisionType => _race.VisionType;
        public bool IsSunlightSensitive => _race.IsSunlightSensitive;

        public List<DnDBackgroundPersonalityTrait> BackgroundTraits => _background.Traits;
        public List<DnDBackgroundBond> BackgroundBonds => _background.Bonds;
        public List<DnDBackgroundFlaw> BackgroundFlaws => _background.Flaws;
        public List<DnDBackgroundIdeal> BackgroundIdeals => _background.Ideals;

        #endregion

        #region Public Methods
        public string GetAttributesAsString(bool multiLine)
        {
            if (multiLine)
            {
                return GetAttributesAsString(Environment.NewLine);
            }
            else
            {
                return GetAttributesAsString(" | ");
            }
        }

        public string GetAttributesAsString(string delimiter)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("ST {0}{1}", Strength, delimiter));
            builder.AppendLine(string.Format("DX {0}{1}", Dexterity, delimiter));
            builder.AppendLine(string.Format("CN {0}{1}", Constitution, delimiter));
            builder.AppendLine(string.Format("IN {0}{1}", Intelligence, delimiter));
            builder.AppendLine(string.Format("WS {0}{1}", Wisdom, delimiter));
            builder.AppendLine(string.Format("CH {0}", Charisma));
            return builder.ToString();
        }

        public List<Feature> GetFeatures()
        {
            List<Feature> features = new List<Feature>();
            features.AddRange(this._race.Features);
            features.AddRange(this._class.Features);
            features.AddRange(this._background.Features);

            return features;
        }

        public string GetFeaturesString()
        {
            StringBuilder builder = new StringBuilder();
            if (this._race.Features.Count > 0)
                builder.AppendLine(string.Join(", ", this._race.Features));
            if (this._class.Features.Count > 0)
                builder.AppendLine(string.Join(", ", this._class.Features));
            if (this._background.Features.Count > 0)
                builder.AppendLine(string.Join(", ", this._background.Features));

            return builder.ToString();
        }

        public ProficiencyCollection GetProficiencies()
        {
            ProficiencyCollection proficiencies = new ProficiencyCollection();
            proficiencies.AddRange(this._race.Proficiencies);
            proficiencies.AddRange(this._class.Proficiencies);
            proficiencies.AddRange(this._background.Proficiencies);

            return proficiencies;
        }

        public string GetProficienciesString()
        {
            StringBuilder builder = new StringBuilder();
            if (this._race.Proficiencies.Count > 0)
                builder.AppendLine(this._race.Proficiencies.ToString());
            if (this._class.Proficiencies.Count > 0)
                builder.AppendLine(this._class.Proficiencies.ToString());
            if (this._background.Proficiencies.Count > 0)
                builder.AppendLine(this._background.Proficiencies.ToString());

            return builder.ToString();
        }

        public SkillCollection GetSkills()
        {
            SkillCollection skills = new SkillCollection();
            skills.AddRange(this._race.Skills);
            skills.AddRange(this._class.Skills);
            skills.AddRange(this._background.Skills);

            return skills;
        }

        public string GetSkillsString()
        {
            StringBuilder builder = new StringBuilder();
            if (this._race.Skills.Count > 0)
                builder.AppendLine(this._race.Skills.ToString());
            if (this._class.Skills.Count > 0)
                builder.AppendLine(this._class.Skills.ToString());
            if (this._background.Skills.Count > 0)
                builder.AppendLine(this._background.Skills.ToString());

            return builder.ToString();
        }

        public LanguageCollection GetLanguages()
        {
            LanguageCollection languages = new LanguageCollection();
            languages.AddRange(this._race.Languages);
            languages.AddRange(this._class.Languages);
            languages.AddRange(this._background.Languages);

            return languages;
        }

        public string GetLanguagesString()
        {
            StringBuilder builder = new StringBuilder();
            if (this._race.Languages.Count > 0)
                builder.AppendLine(this._race.Languages.ToString());
            if (this._class.Languages.Count > 0)
                builder.AppendLine(this._class.Languages.ToString());
            if (this._background.Languages.Count > 0)
                builder.AppendLine(this._background.Languages.ToString());

            return builder.ToString();
        }


        #region Overrides
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Race", _race);
            info.AddValue("Class", _class);
            info.AddValue("Background", _background);
            info.AddValue("Level", _level);
            info.AddValue("HitPoints", CharacterMaxHitPoints);
            info.AddValue("Attributes", _attributes);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void ApplyHealthChange(int healthChange)
        {
            if (_dying && healthChange < 0)
            {
                AddDeathSave(false);
            }

            CharacterHitPoints += healthChange;

            if (base.CharacterHitPoints >= this.CharacterMaxHitPoints)
                base.CharacterHealth = HealthStates.FullHealth;
            else if ((decimal)base.CharacterHitPoints / (decimal)this.CharacterMaxHitPoints > .65m)
                base.CharacterHealth = HealthStates.Wounded;
            else if ((decimal)base.CharacterHitPoints / (decimal)this.CharacterMaxHitPoints > .25m)
                base.CharacterHealth = HealthStates.SeverelyWounded;
            else if ((decimal)base.CharacterHitPoints / (decimal)this.CharacterMaxHitPoints > 0m)
                base.CharacterHealth = HealthStates.MortallyWounded;
            else
            {
                base.CharacterHealth = HealthStates.Unconscious;
                _dying = true;
            }

            if (_dying && base.CharacterHealth != HealthStates.Unconscious)
            {
                EndDeathSaves();
            }
        }
        #endregion

        public bool MakeDeathSave()
        {
            if (!_dying)
                return true;

            bool saved = false;
            int roll = GameCore.Dice.Roll("1d20");

            if (roll >= 10)
                saved = true;

            AddDeathSave(saved);

            return saved;
        }

        #endregion

        #region Private Methods
        private void RollHitPoints()
        {
            // First Level
            this.CharacterMaxHitPoints = this._class.HitDie.DiceSides;
            this.CharacterMaxHitPoints += this.ConstitutionBonus;
            this.CharacterMaxHitPoints += this._race.HitPointBonus;
            // Subsequent Levels
            for (int i = 1; i < this.CharacterLevel; i++)
            {
                this.CharacterMaxHitPoints += this._class.HitDie.Roll(1, this.ConstitutionBonus + this._race.HitPointBonus);
            }
        }

        private void AddDeathSave(bool saved)
        {
            _deathSaves.Add(saved);
            if (_deathSaves.Where(t => t == false).Count() >= 3)
            {
                IsAlive = false;
                CharacterHealth = HealthStates.Dead;
                EndDeathSaves();
            }
            else if (_deathSaves.Where(t => t == true).Count() >= 3)
            {
                EndDeathSaves();
            }
        }

        private void EndDeathSaves()
        {
            _dying = false;
            _deathSaves.Clear();
        }
        #endregion

        #region Statics
        public readonly static Dictionary<Attributes, List<Skills>> AttributeSkills = new Dictionary<Attributes, List<Skills>>()
        {
            { Attributes.Strength, new List<Skills>() { Skills.Athletics} },
            { Attributes.Dexterity, new List<Skills>() { Skills.Acrobatics, Skills.Sleight_of_Hand, Skills.Stealth } },
            { Attributes.Constitution, new List<Skills>() { } },
            { Attributes.Intelligence, new List<Skills>() { Skills.Arcana, Skills.History, Skills.Investigation, Skills.Nature, Skills.Religion } },
            { Attributes.Wisdom, new List<Skills>() { Skills.Animal_Handling, Skills.Insight, Skills.Medicine, Skills.Perception, Skills.Survival } },
            { Attributes.Charisma, new List<Skills>() { Skills.Deception, Skills.Intimidation, Skills.Performance, Skills.Persuassion } }
        };
        #endregion
    }
}
