using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class Card<T> : ISerializable where T : IComparable
    {
        public Card()
            : this(string.Empty, string.Empty, default)
        { }

        public Card(T value)
            : this(string.Empty, string.Empty, value)
        { }

        public Card(string title, T value)
            : this(title, string.Empty, value)
        { }

        public Card(string title, string description, T value)
        {
            Title = title;
            Description = description;
            Value = value;
        }

        protected Card(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            Title = serializationInfo.GetString("Title");
            Description = serializationInfo.GetString("Description");
            Value = (T)serializationInfo.GetValue("Value", typeof(T));

            if(serializationInfo.GetBoolean("HasImage"))
                Image = (System.Drawing.Bitmap)serializationInfo.GetValue("Image", typeof(System.Drawing.Bitmap));
        }

        public string Title { get; }
        public string Description { get; }
        public T Value { get; }
        public System.Drawing.Bitmap Image { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Card<T> card &&
                   EqualityComparer<T>.Default.Equals(Value, card.Value);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Description", Description);
            info.AddValue("Value", Value);

            info.AddValue("HasImage", Image != null);
            if(Image != null)
                info.AddValue("Image", Image);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
