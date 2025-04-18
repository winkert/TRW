using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class Proficiency: CharacterPropertyBase
    {
        #region Fields
        private ProficiencyTypes _type;
        #endregion

        #region Constructors
        public Proficiency()
            :base (string.Empty, string.Empty)
        {

        }
        public Proficiency(string name, ProficiencyTypes type)
            :base(name, string.Empty)
        {
            this._type = type;
        }
        #endregion

        #region Properties
        public ProficiencyTypes ProficiencyType => _type;
        #endregion

        #region Public Methods
        public void Initialize(string name, ProficiencyTypes type)
        {
            this._name = name;
            this._type = type;
        }
        public override CharacterPropertyBase Clone()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            if (_name == "Players_Choice")
                return string.Format("Any {0}",_type);
            else
                return _name.Replace('_',' ');
        }

        public override void WriteTo(BinaryWriter writer)
        {
            writer.Write((int)_type);

            WriteToBase(writer);
        }

        public override void ReadFrom(BinaryReader reader)
        {
            _type = (ProficiencyTypes)reader.ReadInt32();

            ReadFromBase(reader);
        }
        #endregion

        #region Private Methods

        #endregion

    }
}
