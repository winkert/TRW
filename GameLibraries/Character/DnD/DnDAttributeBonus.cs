using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class DnDAttributeBonus : CharacterPropertyBase
    {
        #region Fields
        private Attributes _attribute;
        private int _bonus;
        private bool _required;
        #endregion

        #region Constructors
        public DnDAttributeBonus() : base() { }
        public DnDAttributeBonus(Attributes attribute, int bonus, bool required)
            : base(string.Format("{0}{1} to {2}", bonus > 0 ? "+" : "-", bonus, attribute), string.Empty)
        {
            _attribute = attribute;
            _bonus = bonus;
            _required = required;
        }
        public DnDAttributeBonus(Attributes attribute, int bonus)
            :this(attribute, bonus, true)
        {

        }
        #endregion

        #region Properties
        public Attributes Attribute => _attribute;
        public int Bonus => _bonus;
        public bool Requried => _required;
        #endregion

        #region Public Methods
        public override CharacterPropertyBase Clone()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return string.Format("{0}{1} to {2}", _bonus > 0 ? "+" : "-", _bonus, TRW.CommonLibraries.Core.EnumExtensions.GetDescription(_attribute));
        }

        public override void WriteTo(BinaryWriter writer)
        {
            writer.Write((int)_attribute);
            writer.Write(_bonus);
            writer.Write(_required);

            WriteToBase(writer);
        }

        public override void ReadFrom(BinaryReader reader)
        {
            _attribute = (Attributes)reader.ReadInt32();
            _bonus = reader.ReadInt32();
            _required = reader.ReadBoolean();

            ReadFromBase(reader);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
