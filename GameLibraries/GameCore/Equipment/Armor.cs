using System;
using System.Collections.Generic;
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

        protected Armor(SerializationInfo serializationInfo, StreamingContext streamingContext)
            :base(serializationInfo, streamingContext)
        {
            
        }

        public override string EquipmentType => "Armor";
        public int ArmorClass { get; private set; }

        protected override void SerializeObject(SerializationInfo info)
        {
            info.AddValue("ArmorClass", this.ArmorClass);
            base.SerializeObject(info);
        }

        protected override void DeserializeObject(SerializationInfo info)
        {
            this.ArmorClass = info.GetInt32("ArmorClass");
            base.DeserializeObject(info);
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
