using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using TRW.CommonLibraries.Serialization;
using TRW.CommonLibraries.Xml;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public abstract class CharacterPropertyBase : IComparable<CharacterPropertyBase>, IBinarySerializable
    {
        #region Constants
        protected const string XmlNameElement = "Name";
        protected const string XmlCategoryElement = "Category";
        protected const string XmlSizeElement = "Size";
        protected const string XmlHitDieElement = "HitDie";
        protected const string XmlSaveProficienciesElement = "SaveProficiencies";
        protected const string XmlSaveProficiencyElement = "SaveProficiency";
        protected const string XmlAttributeBonusesElement = "AttributeBonuses";
        protected const string XmlAttributeBonusesBonusesAttribute = "Bonuses";
        protected const string XmlAttributeBonusElement = "AttributeBonus";
        protected const string XmlAttributeBonusBonusAttribute = "Bonus";
        protected const string XmlAttributeBonusRequiredAttribute = "Required";
        protected const string XmlPrimaryAttributeElement = "PrimaryAttribute";
        protected const string XmlSecondaryAttributeElement = "SecondaryAttribute";
        protected const string XmlSpellcastingAbilityElement = "SpellcastingAbility";
        protected const string XmlWalkingSpeedElement = "WalkingSpeed";
        protected const string XmlDarkVisionElement = "DarkVision";
        protected const string XmlVisionTypeElement = "VisionType";
        protected const string XmlSunlightSensitivityElement = "SunlightSensitivity";
        protected const string XmlHitPointBonusElement = "HitPointBonus";
        protected const string XmlAmphibiousElement = "Amphibious";
        protected const string XmlSwimmingSpeedElement = "SwimmingSpeed";
        protected const string XmlFlyingSpeedElement = "FlyingSpeed";
        protected const string XmlClimbingSpeedElement = "ClimbingSpeed";
        protected const string XmlLanguagesElement = "Languages";
        protected const string XmlLanguageElement = "Language";
        protected const string XmlSkillsElement = "Skills";
        protected const string XmlSkillsTotalAttribute = "TotalSkills";
        protected const string XmlSkillOptionElement = "SkillOption";
        protected const string XmlProficienciesElement = "Proficiencies";
        protected const string XmlProficiencyElement = "Proficiency";
        protected const string XmlProficiencyTypeAttribute = "Type";
        protected const string XmlRaceFeaturesElement = "RaceFeatures";
        protected const string XmlRaceFeatureElement = "RaceFeature";
        protected const string XmlNameAttribute = "Name";
        protected const string XmlDescriptionAttribute = "Description";
        protected const string XmlFeaturesElement = "Features";
        protected const string XmlFeatureElement = "Feature";
        protected const string XmlBackgroundTraitsElement = "CharacterTraits";
        protected const string XmlBackgroundTraitElement = "CharacterTrait";
        protected const string XmlBackgroundBondsElement = "Bonds";
        protected const string XmlBackgroundBondElement = "Bond";
        protected const string XmlBackgroundIdealsElement = "Ideals";
        protected const string XmlBackgroundIdealElement = "Ideal";
        protected const string XmlBackgroundFlawsElement = "Flaws";
        protected const string XmlBackgroundFlawElement = "Flaw";
        #endregion

        #region Fields
        protected string _name;
        protected string _description;
        protected string _category;
        #endregion

        #region Constructors
        internal CharacterPropertyBase() : this(string.Empty, string.Empty) { }
        public CharacterPropertyBase(string name, string description)
        {
            this._name = name;
            this._description = description;
        }
        #endregion

        #region Properties
        public string Name => _name;
        public string Description => _description;
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Populate a collection with child elements fitting the following pattern:
        /// &lt;ParentElement&gt;
        ///    &lt;ChildElement Name="Property Name"&gt;Property Description&lt;/ChildElement&gt;
        /// &lt;/ParentElement&gt;
        /// 
        /// Has legacy support for "Description" attribute but that should not be used moving forward
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="parentElement"></param>
        /// <param name="createDel">(n, d) => new T(n, d)</param>
        protected void FillCollectionFromChildElements<T>(ICollection<T> collection, XmlDocumentElement parentElement, Func<string, string, T> createDel)
            where T : CharacterPropertyBase
        {
            foreach (XmlDocumentElement child in parentElement.Children)
            {
                string name = string.Empty;
                string description = string.Empty;
                if (child.HasAttribute(XmlFeatureElement))
                    name = child.GetAttributeString(XmlNameAttribute);
                else
                    name = child.Value;

                if (child.HasAttribute(XmlDescriptionAttribute))
                    description = child.GetAttributeString(XmlDescriptionAttribute);
                else
                    description = child.Value;

                collection.Add(createDel(name, description));
            }
        }

        public abstract CharacterPropertyBase Clone();

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(CharacterPropertyBase other)
        {
            return (Name + Category).CompareTo((other.Name + other.Category));
        }

        public byte[] ToByteArray()
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                WriteTo(writer);
                return ms.ToArray(); // Return serialized data as byte array
            }
        }
        public abstract void WriteTo(BinaryWriter writer);
        public abstract void ReadFrom(BinaryReader reader);
        #endregion

        protected internal void WriteToBase(BinaryWriter writer)
        {
            writer.Write(_name);
            writer.Write(_description);
            writer.Write(_category);
        }
        protected internal void ReadFromBase(BinaryReader reader)
        {
            _name = reader.ReadString();
            _description = reader.ReadString();
            _category = reader.ReadString();
        }
    }
}
