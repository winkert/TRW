using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Runtime.InteropServices.Marshalling;
using System.Reflection.PortableExecutable;

namespace TRW.CommonLibraries.Serialization
{
    public static class BinarySerializationRoutines
    {
        /// <summary>
        /// Serialize an object to a Base64 string for compressed storage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public static string SerializeToString<T>(T objectToSerialize) where T : IBinarySerializable
        {
            using (MemoryStream memStr = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStr))
                {
                    objectToSerialize.WriteTo(writer);
                    memStr.Position = 0;

                    return Convert.ToBase64String(memStr.ToArray());
                }
            }
        }
        /// <summary>
        /// Deserialize a Base64 string to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToDerialize"></param>
        /// <returns></returns>
        public static T DeserializeFromString<T>(string objectToDerialize) where T : IBinarySerializable, new()
        {
            byte[] byteArray = Convert.FromBase64String(objectToDerialize);
            using (MemoryStream memStr = new MemoryStream(byteArray))
            {
                using (BinaryReader reader = new BinaryReader(memStr))
                {
                    T obj = new T();
                    obj.ReadFrom(reader);
                    return obj;
                }
            }
        }

        /// <summary>
        /// Serialize an object to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        public static void SerializeToFile<T>(T objectToSerialize, string filePath) where T : IBinarySerializable
        {
            SerializeToFile(objectToSerialize, filePath, FileMode.Create);
        }
        /// <summary>
        /// Serialize an object to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        /// <param name="fileMode"></param>
        public static void SerializeToFile<T>(T objectToSerialize, string filePath, FileMode fileMode) where T : IBinarySerializable
        {
            SerializeToFile(objectToSerialize, filePath, fileMode, false);
        }
        /// <summary>
        /// Serialize an object to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        /// <param name="fileMode"></param>
        /// <param name="useCompression"></param>
        public static void SerializeToFile<T>(T objectToSerialize, string filePath, FileMode fileMode, bool useCompression) where T : IBinarySerializable
        {
            if (useCompression)
                SerializeWithCompression(objectToSerialize, filePath, fileMode);
            else
                SerializeWithoutCompression(objectToSerialize, filePath, fileMode);
        }

        /// <summary>
        /// Serialize an object to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        public static void SerializeListToFile<T>(List<T> objectToSerialize, string filePath) where T : IBinarySerializable
        {
            SerializeListToFile(objectToSerialize, filePath, FileMode.Create, false);
        }
        /// <summary>
        /// Serialize an object to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        /// <param name="fileMode"></param>
        public static void SerializeListToFile<T>(List<T> objectToSerialize, string filePath, FileMode fileMode) where T : IBinarySerializable
        {
            SerializeListToFile(objectToSerialize, filePath, fileMode, false);
        }
        /// <summary>
        /// Serialize an object to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        /// <param name="fileMode"></param>
        /// <param name="useCompression"></param>
        public static void SerializeListToFile<T>(List<T> objectToSerialize, string filePath, FileMode fileMode, bool useCompression) where T : IBinarySerializable
        {
            if (useCompression)
                SerializeListWithCompression(objectToSerialize, filePath, fileMode);
            else
                SerializeListWithoutCompression(objectToSerialize, filePath, fileMode);
        }

        /// <summary>
        /// Deserialize a binary to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath) where T : IBinarySerializable, new()
        {
            return DeserializeFromFile<T>(filePath, false);
        }
        /// <summary>
        /// Deserialize a binary to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="useCompression"></param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath, bool useCompression) where T : IBinarySerializable, new()
        {
            if (useCompression)
                return DeserializeWithCompression<T>(filePath);
            else
                return DeserializeWithoutCompression<T>(filePath);
        }

        /// <summary>
        /// Deserialize a binary to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<T> DeserializeListFromFile<T>(string filePath) where T : IBinarySerializable, new()
        {
            return DeserializeListFromFile<T>(filePath, false);
        }
        /// <summary>
        /// Deserialize a binary to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="useCompression"></param>
        /// <returns></returns>
        public static List<T> DeserializeListFromFile<T>(string filePath, bool useCompression) where T : IBinarySerializable, new()
        {
            if (useCompression)
                return DeserializeListWithCompression<T>(filePath);
            else
                return DeserializeListWithoutCompression<T>(filePath);
        }
        /// <summary>
        /// Deserialize binary stream to object of Type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="useCompression"></param>
        /// <returns></returns>
        public static T DeserializeStream<T>(Stream reader, bool useCompression = false) where T : IBinarySerializable, new()
        {
            if (useCompression)
            {
                using (GZipStream gZipStream = new GZipStream(reader, CompressionMode.Decompress))
                {
                    using (BinaryReader br = new BinaryReader(gZipStream))
                    {
                        T obj = new T();
                        obj.ReadFrom(br);
                        return obj;
                    }
                }
            }
            else
            {
                using (BinaryReader br = new BinaryReader(reader))
                {
                    T obj = new T();
                    obj.ReadFrom(br);
                    return obj;
                }
            }
        }

        /// <summary>
        /// Serialize Type T to binary stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer"></param>
        /// <param name="obj"></param>
        /// <param name="useCompression"></param>
        public static void SerializeStream<T>(Stream writer, T obj, bool useCompression = false) where T : IBinarySerializable
        {
            if (useCompression)
            {
                using (GZipStream gZipStream = new GZipStream(writer, CompressionMode.Decompress))
                {
                    using (BinaryWriter br = new BinaryWriter(gZipStream))
                    {
                        obj.WriteTo(br);
                    }
                }
            }
            else
            {
                using (BinaryWriter br = new BinaryWriter(writer))
                {
                    obj.WriteTo(br);
                }
            }
        }

        public static void WriteCollection<T>(BinaryWriter writer, int count, ICollection<T> collection) where T : IBinarySerializable
        {
            writer.Write(count);
            foreach (T item in collection)
            {
                item.WriteTo(writer);
            }
        }
        public static void ReadCollection<T>(BinaryReader reader, int count, ICollection<T> collection) where T : IBinarySerializable, new()
        {
            for (int i = 0; i < count; i++)
            {
                T item = new T();
                item.ReadFrom(reader);
                collection.Add(item);
            }
        }

        #region Private Methods
        private static void SerializeWithCompression<T>(T objectToSerialize, string filePath, FileMode fileMode) where T : IBinarySerializable
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                SerializeStream(writer, objectToSerialize, true);
            }
        }
        private static void SerializeWithoutCompression<T>(T objectToSerialize, string filePath, FileMode fileMode) where T : IBinarySerializable
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                SerializeStream(writer, objectToSerialize, false);
            }
        }
        private static void SerializeListWithCompression<T>(List<T> objectToSerialize, string filePath, FileMode fileMode) where T : IBinarySerializable
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                
            }
        }
        private static void SerializeListWithoutCompression<T>(List<T> objectToSerialize, string filePath, FileMode fileMode) where T : IBinarySerializable
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                
            }
        }

        private static T DeserializeWithCompression<T>(string filePath) where T : IBinarySerializable, new()
        {
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                reader.Seek(0, SeekOrigin.Begin);
                return DeserializeStream<T>(reader, true);

            }

        }
        private static T DeserializeWithoutCompression<T>(string filePath) where T : IBinarySerializable, new()
        {
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                return DeserializeStream<T>(reader);
            }
        }

        private static List<T> DeserializeListWithCompression<T>(string filePath) where T : IBinarySerializable, new()
        {
            throw new NotImplementedException();
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                reader.Seek(0, SeekOrigin.Begin);
                

            }
        }
        private static List<T> DeserializeListWithoutCompression<T>(string filePath) where T : IBinarySerializable, new()
        {
            throw new NotImplementedException();
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                
            }
        }
        #endregion
    }
}
