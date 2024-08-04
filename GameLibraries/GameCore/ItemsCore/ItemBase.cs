using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public abstract class ItemBase : ISerializable, IGameObject
    {
        public ItemBase(string name, string description, decimal weight)
        {
            this.Name = name;
            this.Description = description;
            this.Weight = weight;
        }

        protected ItemBase(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetString("Name");
            this.Description = info.GetString("Description");
            this.Weight = info.GetDecimal("Weight");
            DeserializeObject(info);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public bool IsPlayable => false;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Description", this.Description);
            info.AddValue("Weight", this.Weight);
            SerializeObject(info);
        }

        protected abstract void SerializeObject(SerializationInfo info);

        protected abstract void DeserializeObject(SerializationInfo info);

        public virtual void GameTimerTick()
        {

        }

    }
}
