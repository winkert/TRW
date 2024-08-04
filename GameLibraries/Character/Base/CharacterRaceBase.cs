using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Xml;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public abstract class CharacterRaceBase : CharacterPropertyBase, IXmlData, ISerializable
    {
        #region Constructors
        public CharacterRaceBase() : base(string.Empty, string.Empty)
        {
            InternalInitialize();
        }
        public CharacterRaceBase(string name, string description)
            : base(name, description)
        {
            InternalInitialize();
        }
        /// <summary>
        /// ISerializable Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public CharacterRaceBase(SerializationInfo info, StreamingContext context)
            :this()
        {
            _name = info.GetString("Name");
            _description = info.GetString("Description");
        }
        #endregion

        #region Properties
        public abstract Sizes Size { get; }

        public abstract int WalkingSpeed { get; }
        public abstract bool IsWalking { get; }

        public abstract int ClimbingSpeed { get; }
        public abstract bool IsClimbing { get; }

        public abstract int FlyingSpeed { get; }
        public abstract bool IsFlying { get; }

        public abstract int SwimmingSpeed { get; }
        public abstract bool IsSwimming { get; }
        public abstract bool IsAmphibious { get; }

        public abstract LanguageCollection Languages { get; }
        public abstract SkillCollection Skills { get; }
        public abstract ProficiencyCollection Proficiencies { get; }

        public abstract List<Feature> Features { get; }

        #endregion

        #region Public Methods

        public abstract void ReadXml(string filePath);

        public abstract void WriteXml(string filePath);

        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        public abstract void Create(string name, Sizes size, DnDAttributeBonusCollection attributeBonuses, int walkingSpeed, int climbingSpeed, int flyingSpeed, int swimmingSpeed, VisionTypes vision, bool amphibious, bool sunlightSensitive
            , LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features, int hitpointBonus);
        #endregion

        #region Protected Methods
        protected abstract void InternalInitialize();
        #endregion
    }
}
