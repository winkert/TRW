using System;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    /// <summary>
    /// A World is made up of Regions, each Region has SubRegions
    /// </summary>
    [Serializable]
    public class World : ISerializable
    {
        #region Constructors
        public World(string name)
        {
            Name = name;
            Regions = new RegionCollection<Region>();
        }

        protected World(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            Name = serializationInfo.GetString("Name");
            Regions = (RegionCollection<Region>)serializationInfo.GetValue("Regions", typeof(RegionCollection<Region>));
        }
        #endregion

        #region Properties
        public string Name { get; private set; }
        public RegionCollection<Region> Regions { get; private set; }
        #endregion

        #region Public Methods
        public Region AddRegion(string name, RegionTypes regionType)
        {
            Region region = new Region(null, name, regionType);
            Regions.Add(region);
            return region;
        }
        #endregion

        #region Private Methods

        #endregion

        #region Implementations
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Regions", Regions);
        }
        #endregion

    }
}
