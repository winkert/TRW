using System;
using System.IO;
using System.Runtime.Serialization;
using TRW.CommonLibraries.Xml;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class Weapon : EquipmentBase
    {
        public Weapon(string name, string description, decimal weight, int value, int damageDiceType, WeaponTypes weaponType) : this(name, description, weight, value, damageDiceType, weaponType, 1)
        {

        }

        public Weapon(string name, string description, decimal weight, int value, int damageDiceType, WeaponTypes weaponType, int damageDiceCount) : base(name, description, weight, value)
        {
            DamageDice = new Dice(damageDiceType);
            DamageDiceCount = damageDiceCount;
            WeaponType = weaponType;
        }

        public Weapon(string name, string description, decimal weight, int value, string damageDice, WeaponTypes weaponType) : base(name, description, weight, value)
        {
            int attackBonus, damageDiceCount;
            DamageDice = Dice.Parse(damageDice, out attackBonus, out damageDiceCount);
            AttackBonus = attackBonus;
            DamageDiceCount = damageDiceCount;
            WeaponType = weaponType;
        }

        public override string EquipmentType => "Weapon";
        public Dice DamageDice { get; private set; }
        public int DamageDiceCount { get; private set; }
        public int AttackBonus { get; private set; }
        public WeaponTypes WeaponType { get; private set; }

        public virtual int DoDamage()
        {
            return DamageDice.Roll(DamageDiceCount);
        }

        protected override void SerializeObject(BinaryWriter writer)
        {
            writer.Write(DamageDice.DiceSides);
            writer.Write(DamageDiceCount);
            writer.Write(AttackBonus);
            writer.Write((int)WeaponType);
            base.SerializeObject(writer);
        }

        protected override void DeserializeObject(BinaryReader reader)
        {
            this.DamageDice = new Dice(reader.ReadInt32());
            this.DamageDiceCount = reader.ReadInt32();
            this.AttackBonus = reader.ReadInt32();
            this.WeaponType = (WeaponTypes)reader.ReadInt32();
            base.DeserializeObject(reader);
        }

        protected override void ReadXmlToItem(XmlParser xmlParser)
        {
            XmlDocumentElement root = xmlParser.RootElement;
            if(root.SeekElement("DamageDice"))
            {
                this.DamageDice = new Dice(int.Parse(root.CurrentChild.Attributes["Sides"].Value));
                this.DamageDiceCount = int.Parse(root.CurrentChild.Attributes["Count"].Value);
            }
            if (root.SeekElement("AttackBonus"))
                this.AttackBonus = int.Parse(root.CurrentChild.Value);
            if (root.SeekElement("WeaponType"))
                this.WeaponType = (WeaponTypes)Enum.Parse(typeof(WeaponTypes), root.CurrentChild.Value);
        }

        protected override void WriteItemToXml(XmlBuilder xmlBuilder)
        {
            xmlBuilder.WriteElement("DamageDice", string.Empty, new Tuple<string, string>("Sides", DamageDice.DiceSides.ToString()), new Tuple<string, string>("Count", DamageDiceCount.ToString()));
            xmlBuilder.WriteElement("AttackBonus", AttackBonus);
            xmlBuilder.WriteElement("WeaponType", WeaponType);
        }

        
    }
}
