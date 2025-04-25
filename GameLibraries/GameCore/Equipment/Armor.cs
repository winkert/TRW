using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using TRW.CommonLibraries.Xml;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class Armor : EquipmentBase
    {
        public Armor(string name, string description, decimal weight, int value, int ac) : base(name, description, weight, value)
        {
            this.ArmorClass = ac;
        }

        public override string EquipmentType => "Armor";
        public int ArmorClass { get; private set; }

        protected override void SerializeObject(BinaryWriter writer)
        {
            writer.Write(ArmorClass);
            base.SerializeObject(writer);
        }

        protected override void DeserializeObject(BinaryReader reader)
        {
            this.ArmorClass = reader.ReadInt32();
            base.DeserializeObject(reader);
        }

        protected override void ReadXmlToItem(XmlParser xmlParser)
        {
            if (xmlParser.RootElement.SeekElement("ArmorClass"))
                this.ArmorClass = int.Parse(xmlParser.RootElement.CurrentChild.Value);
        }

        protected override void WriteItemToXml(XmlBuilder xmlBuilder)
        {
            xmlBuilder.WriteElement("ArmorClass", this.ArmorClass);
        }

    }
}
