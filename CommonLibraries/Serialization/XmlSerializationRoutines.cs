using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TRW.CommonLibraries.Serialization
{
    public static class XmlSerializationRoutines
    {
        /// <summary>
        /// Serialize an object to an XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        public static void SerializeToFile<T>(T objectToSerialize, string filePath) where T : IXmlSerializable
        {
            SerializeToFile(objectToSerialize, filePath, false);
        }
        /// <summary>
        /// Serialize an object to an XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public static void SerializeToFile<T>(T objectToSerialize, string filePath, bool overwrite) where T : IXmlSerializable
        {
            if (overwrite)
                SerializeToFile(objectToSerialize, filePath, FileMode.Create);
            else
                SerializeToFile(objectToSerialize, filePath, FileMode.CreateNew);
        }
        /// <summary>
        /// Serialize an object to an XML file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="filePath"></param>
        /// <param name="fileMode"></param>
        public static void SerializeToFile<T>(T objectToSerialize, string filePath, FileMode fileMode) where T : IXmlSerializable
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream writer = File.Open(filePath, fileMode))
            {
                serializer.Serialize(writer, objectToSerialize);
            }
        }
        /// <summary>
        /// Deserialize an XML file to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath) where T : IXmlSerializable
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream reader = File.Open(filePath, FileMode.Open))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
