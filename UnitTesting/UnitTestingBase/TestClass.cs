using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TRW.UnitTesting
{
    [Serializable]
    public class TestClass : ISerializable
    {
        private string _privateString;

        public TestClass()
        {

        }

        public TestClass(SerializationInfo info, StreamingContext context)
        {
            _privateString = info.GetString("PS");
            AvailableString = info.GetString("AS");
        }

        public string AvailableString { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AS", AvailableString);
            info.AddValue("PS", _privateString);
        }

        public override bool Equals(object obj)
        {
            TestClass other = obj as TestClass;
            return this.AvailableString == other.AvailableString && this._privateString == other._privateString;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
