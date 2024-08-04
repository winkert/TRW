using System;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class Region : IRegion<Region>
    {
        public Region()
            : this(null, "Region", RegionTypes.Geographic)
        {
        }

        public Region(string name)
            : this(null, name, RegionTypes.Geographic)
        {
        }

        public Region(IRegion parent, string name)
            : this(parent, name, RegionTypes.Geographic)
        {
        }

        public Region(IRegion parent, string name, RegionTypes type)
        {
            Name = name;
            Parent = parent;
            RegionType = type;
        }

        protected Region(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            Name = serializationInfo.GetString("Name");
            
            if (serializationInfo.GetBoolean("HasParent"))
                Parent = (IRegion)serializationInfo.GetValue("Parent", typeof(IRegion));

            SubRegions = (RegionCollection<Region>)serializationInfo.GetValue("SubRegions", typeof(RegionCollection<Region>));
            RegionType = (RegionTypes)serializationInfo.GetInt32("RegionTypeInt");
        }

        public string Name { get; set; }
        public IRegion Parent { get; set; }
        public RegionCollection<Region> SubRegions { get; set; }

        public RegionTypes RegionType { get; private set; }

        public Region AddSubRegion(string name, RegionTypes regionType)
        {
            Region newSub = new Region(this, name, regionType);
            SubRegions.Add(newSub);
            return newSub;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);

            info.AddValue("HasParent", Parent == null);
            if(Parent != null)
                info.AddValue("Parent", Parent);

            info.AddValue("SubRegions", SubRegions);
            info.AddValue("RegionTypeInt", (int)RegionType);
        }
    }
}
