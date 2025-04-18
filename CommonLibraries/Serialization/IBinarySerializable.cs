using System.IO;

namespace TRW.CommonLibraries.Serialization
{
    public interface IBinarySerializable
    {
        byte[] ToByteArray();
        void WriteTo(BinaryWriter writer);
        void ReadFrom(BinaryReader reader);
    }
}
