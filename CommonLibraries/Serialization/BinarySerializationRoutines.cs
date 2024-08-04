using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace TRW.CommonLibraries.Serialization
{
    public static class BinarySerializationRoutines
    {
        private readonly static BinaryFormatter _binaryFormatter = new BinaryFormatter();
        /// <summary>
        /// Serialize an object to a Base64 string for compressed storage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public static string SerializeToString<T>(T objectToSerialize) where T : ISerializable
        {
            using (MemoryStream memStr = new MemoryStream())
            {
                _binaryFormatter.Serialize(memStr, objectToSerialize);
                memStr.Position = 0;

                return Convert.ToBase64String(memStr.ToArray());
            }
        }
        /// <summary>
        /// Deserialize a Base64 string to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToDerialize"></param>
        /// <returns></returns>
        public static T DeserializeFromString<T>(string objectToDerialize) where T : ISerializable
        {
            byte[] byteArray = Convert.FromBase64String(objectToDerialize);
            using (MemoryStream memStr = new MemoryStream(byteArray))
            {
                return (T)_binaryFormatter.Deserialize(memStr);
            }
        }

        /// <summary>
        /// Serialize an object to a binary file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        public static void SerializeToFile<T>(T objectToSerialize, string filePath) where T : ISerializable
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
        public static void SerializeToFile<T>(T objectToSerialize, string filePath, FileMode fileMode) where T : ISerializable
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
        public static void SerializeToFile<T>(T objectToSerialize, string filePath, FileMode fileMode, bool useCompression) where T : ISerializable
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
        public static void SerializeListToFile<T>(List<T> objectToSerialize, string filePath) where T : ISerializable
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
        public static void SerializeListToFile<T>(List<T> objectToSerialize, string filePath, FileMode fileMode) where T : ISerializable
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
        public static void SerializeListToFile<T>(List<T> objectToSerialize, string filePath, FileMode fileMode, bool useCompression) where T : ISerializable
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
        public static T DeserializeFromFile<T>(string filePath) where T : ISerializable
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
        public static T DeserializeFromFile<T>(string filePath, bool useCompression) where T : ISerializable
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
        public static List<T> DeserializeListFromFile<T>(string filePath) where T : ISerializable
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
        public static List<T> DeserializeListFromFile<T>(string filePath, bool useCompression) where T : ISerializable
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
        public static T DeserializeStream<T>(Stream reader, bool useCompression = false)
        {
            if (useCompression)
            {
                using (GZipStream gZipStream = new GZipStream(reader, CompressionMode.Decompress))
                {
                    return (T)_binaryFormatter.Deserialize(gZipStream);
                }
            }
            else
            {
                return (T)_binaryFormatter.Deserialize(reader);
            }
        }
        #region Private Methods
        private static void SerializeWithCompression<T>(T objectToSerialize, string filePath, FileMode fileMode)
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                using (GZipStream gZipStream = new GZipStream(writer, CompressionMode.Compress))
                {
                    _binaryFormatter.Serialize(gZipStream, objectToSerialize);
                }
            }
        }
        private static void SerializeWithoutCompression<T>(T objectToSerialize, string filePath, FileMode fileMode)
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                _binaryFormatter.Serialize(writer, objectToSerialize);
            }
        }
        private static void SerializeListWithCompression<T>(List<T> objectToSerialize, string filePath, FileMode fileMode)
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                using (GZipStream gZipStream = new GZipStream(writer, CompressionMode.Compress))
                {
                    _binaryFormatter.Serialize(gZipStream, objectToSerialize);
                }
            }
        }
        private static void SerializeListWithoutCompression<T>(List<T> objectToSerialize, string filePath, FileMode fileMode)
        {
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                _binaryFormatter.Serialize(writer, objectToSerialize);
            }
        }

        private static T DeserializeWithCompression<T>(string filePath)
        {
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                reader.Seek(0, SeekOrigin.Begin);
                return DeserializeStream<T>(reader, true);
                
            }

        }
        private static T DeserializeWithoutCompression<T>(string filePath)
        {
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                return DeserializeStream<T>(reader);
            }
        }

        private static List<T> DeserializeListWithCompression<T>(string filePath)
        {
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                reader.Seek(0, SeekOrigin.Begin);
                return DeserializeStream<List<T>>(reader, true);
                
            }
        }
        private static List<T> DeserializeListWithoutCompression<T>(string filePath)
        {
            using (MemoryStream reader = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                return DeserializeStream<List<T>>(reader);
            }
        }
        #endregion
    }
}
