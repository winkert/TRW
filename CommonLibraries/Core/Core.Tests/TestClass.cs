using System;
namespace TRW.CommonLibraries.Core.Tests
{
    public class TestClass : IEquatable<TestClass>, IComparable<TestClass>
    {
        public string Prop { get; set; }
        public string OtherProp { get; set; }

        public TestClass()
        {
            Prop = string.Empty;
        }
        public TestClass(string prop)
        {
            Prop = prop;
        }

        public TestClass(string prop, string otherProp)
        {
            Prop = prop;
            OtherProp = otherProp;
        }

        public bool Equals(TestClass other)
        {
            return this.Prop == other.Prop && this.OtherProp == other.OtherProp;
        }

        public int CompareTo(TestClass obj)
        {
            int val = Prop.CompareTo(obj.Prop);

            if (val == 0)
                val = OtherProp.CompareTo(obj.OtherProp);

            return val;
        }
    }

}
