namespace TRW.GameLibraries.GameCore
{
    public interface IRegion<R> : IRegion
        where R:IRegion
    {
        RegionCollection<R> SubRegions { get; set; }

    }

    public interface IRegion : System.Runtime.Serialization.ISerializable
    {
        string Name { get; set; }
        IRegion Parent { get; set; }

    }
}
