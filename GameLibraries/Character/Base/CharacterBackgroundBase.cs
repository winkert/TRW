using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Xml;
using TRW.GameLibraries.GameCore;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public abstract class CharacterBackgroundBase : CharacterPropertyBase, IXmlData, ISerializable
    {
        #region Constructors
        public CharacterBackgroundBase() : base(string.Empty, string.Empty)
        {
            InternalInitialize();
        }
        public CharacterBackgroundBase(string name, string description)
            : base(name, description)
        {
            InternalInitialize();
        }
        /// <summary>
        /// ISerializable Constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public CharacterBackgroundBase(SerializationInfo info, StreamingContext context)
            : this()
        {
            _name = info.GetString("Name");
            _description = info.GetString("Description");
        }
        #endregion

        #region Properties
        public abstract LanguageCollection Languages { get; }
        public abstract SkillCollection Skills { get; }
        public abstract ProficiencyCollection Proficiencies { get; }
        public abstract List<Feature> Features { get; }
        #endregion

        #region Public Methods

        public abstract void ReadXml(string filePath);

        public abstract void WriteXml(string filePath);

        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        public abstract void Create(string name, LanguageCollection languages, SkillCollection skills, ProficiencyCollection proficiencies, List<Feature> features);

        #endregion

        #region Protected Methods
        protected abstract void InternalInitialize();
        #endregion
    }
}
