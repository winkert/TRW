using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Character
{
    [Serializable]
    public class Feature: CharacterPropertyBase
    {
        #region Fields
        
        #endregion

        #region Constructors
        public Feature():base() { }
        public Feature(string name, string description):base(name, description)
        {

        }
        #endregion

        #region Properties

        #endregion

        #region Public Methods
        public override CharacterPropertyBase Clone()
        {
            throw new NotImplementedException();
        }

        public override void ReadFrom(BinaryReader reader)
        {
            _name = reader.ReadString();
            _description = reader.ReadString();
            _category = reader.ReadString();
        }

        public override void WriteTo(BinaryWriter writer)
        {
            writer.Write(this._name);
            writer.Write(this._description);
            writer.Write(this._category);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
