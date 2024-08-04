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
    public abstract class CharacterClassBase : CharacterPropertyBase, IXmlData, ISerializable
    {
        #region Constructors
        public CharacterClassBase() : base(string.Empty, string.Empty)
        {
            InternalInitialize();
        }
        public CharacterClassBase(string name, string description)
            : base(name, description)
        {
            InternalInitialize();
        }
        /// <summary>
        /// ISerializable Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public CharacterClassBase(SerializationInfo info, StreamingContext context)
            : this()
        {
            _name = info.GetString("Name");
            _description = info.GetString("Description");
        }
        #endregion

        #region Properties
        public abstract Attributes PrimaryAttribute { get; }
        public abstract Attributes SecondaryAttribute { get; }
        public abstract Attributes SpellCastingAbility { get; }
        public abstract LanguageCollection Languages { get; }
        public abstract SkillCollection Skills { get; }
        public abstract ProficiencyCollection Proficiencies { get; }
        public abstract List<Feature> Features { get; }
        #endregion

        #region Public Methods

        public abstract void ReadXml(string filePath);

        public abstract void WriteXml(string filePath);

        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        public abstract void Create(string name, GameCore.Dice hitDie, Attributes primaryAttribute, Attributes secondaryAttribute, Attributes spellCastingAbility
            , LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features);
        #endregion

        #region Private Methods
        protected abstract void InternalInitialize();
        #endregion
    }
}
