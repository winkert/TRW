using System;
using System.Collections.Generic;
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
        #endregion

        #region Private Methods

        #endregion
    }
}
