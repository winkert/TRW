using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using TRW.CommonLibraries.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class Card<T> : IBinarySerializable where T : IComparable
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

        public string Title { get; private set; }
        public string Description { get; private set; }
        public T Value { get; private set; }
        public Bitmap Image { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Card<T> card &&
                   EqualityComparer<T>.Default.Equals(Value, card.Value);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public void WriteTo(BinaryWriter writer)
        {
            writer.Write(Title);
            writer.Write(Description);
            // todo - figure out writing binary T where IComparable
            writer.Write(Value.ToString());

            writer.Write(Image != null);
            if (Image != null)
            {
                Image.Save(writer.BaseStream, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public void ReadFrom(BinaryReader reader)
        {
            Title = reader.ReadString();
            Description = reader.ReadString();
            // this may not be safe
            Value = (T)Convert.ChangeType(reader.ReadString(), typeof(T));
            if (reader.ReadBoolean())
            {
                Image = (Bitmap)Bitmap.FromStream(reader.BaseStream);
            }
        }
        public byte[] ToByteArray()
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                WriteTo(bw);
                return ms.ToArray();
            }
        }
        public override string ToString()
        {
            return Title;
        }

    }
}
