using System;
using System.Runtime.Serialization;
using TRW.CommonLibraries.Xml;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public abstract class EquipmentBase : ItemBase, IXmlData
    {
        public EquipmentBase(string name, string description, decimal weight) : this(name, description, weight, 0)
        {

        }

        public EquipmentBase(string name, string description, decimal weight, int value) : base(name, description, weight)
        {
            this.Value = value;
        }
        
        protected EquipmentBase(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {

        }

        public int Value { get; set; }
        public abstract string EquipmentType { get; }

        protected override void SerializeObject(SerializationInfo info)
        {
            info.AddValue("Value", this.Value);
        }

        protected override void DeserializeObject(SerializationInfo info)
        {
            this.Value = info.GetInt32("Value");
        }


        public void ReadXml(string filePath)
        {
            bool loaded = false;
            using (XmlParser xmlParser = new XmlParser(filePath))
            {
                if (xmlParser.RootElement.Value == "Equipment")
                {
                    if (xmlParser.RootElement.HasAttribute("EquipmentType") && xmlParser.RootElement.Attributes["EquipmentType"].Value == this.EquipmentType)
                    {
                        XmlDocumentElement root = xmlParser.RootElement;
                        if (root.SeekElement("Name"))
                            this.Name = root.CurrentChild.Value;
                        if (root.SeekElement("Description"))
                            this.Description = root.CurrentChild.Value;
                        if (root.SeekElement("Weight"))
                            this.Weight = decimal.Parse(root.CurrentChild.Value);
                        if (root.SeekElement("Value"))
                            this.Value = int.Parse(root.CurrentChild.Value);

                        ReadXmlToItem(xmlParser);
                        loaded = true;
                    }
                }

            }
            // validate
            if (!loaded)
                throw new Exception(string.Format("Unable to parse file [{0}] as EquipmentType [{1}]", filePath, this.EquipmentType));
        }

        public void WriteXml(string filePath)
        {
            using (XmlBuilder xmlBuilder = new XmlBuilder(filePath))
            {
                xmlBuilder.OpenElement("Equipment");
                xmlBuilder.AddAttribute("EquipmentType", this.EquipmentType);

                xmlBuilder.WriteElement("Name", this.Name);
                xmlBuilder.WriteElement("Description", this.Description);
                xmlBuilder.WriteElement("Weight", this.Weight);
                xmlBuilder.WriteElement("Value", this.Value);

                WriteItemToXml(xmlBuilder);

                xmlBuilder.FinalizeDocument();
            }
        }

        protected abstract void ReadXmlToItem(XmlParser xmlParser);
        protected abstract void WriteItemToXml(XmlBuilder xmlBuilder);

    }
}
