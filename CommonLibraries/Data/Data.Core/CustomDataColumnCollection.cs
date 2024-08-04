using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Data.Core
{
    [Serializable]
    public class CustomDataColumnCollection : SortedDictionary<int, CustomDataColumn>
    {
        private int _primaryKey = -1;

        public CustomDataColumnCollection()
            : base()
        { }

        public CustomDataColumnCollection(int length)
            : base()
        {
            for (int i = 0; i < length; i++)
                this.Add(i, new CustomDataColumn());
        }

        public int this[string name]
        {
            get
            {
                foreach (KeyValuePair<int, CustomDataColumn> column in this)
                {
                    if (column.Value.Name.Equals(name))
                        return column.Key;
                }
                return -1;
            }
        }

        public override bool Equals(object obj)
        {
            var columnCol = obj as CustomDataColumnCollection;
            bool areEqual = true;
            foreach (KeyValuePair<int, CustomDataColumn> pair in this)
            {
                if (columnCol.ContainsKey(pair.Key))
                {
                    if (!pair.Value.Equals(columnCol[pair.Key]))
                    {
                        areEqual = false;
                    }
                }
                else
                {
                    areEqual = false;
                }
            }

            return areEqual && this.Count.Equals(columnCol.Count);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public byte[] Serialize()
        {
            byte[] bytes;
            using (System.IO.MemoryStream writer = new System.IO.MemoryStream())
            {
                using (System.IO.BinaryWriter sw = new System.IO.BinaryWriter(writer))
                {
                    sw.Write(this.Count);
                    for (int i = 0; i < this.Count; i++)
                    {
                        sw.Write((byte)this[i].Type);
                        sw.Write(this[i].Name);
                    }
                }
                bytes = writer.ToArray();
            }
            return bytes;
        }

        public void Deserialize(byte[] columns)
        {
            using (System.IO.MemoryStream reader = new System.IO.MemoryStream(columns))
            {
                using (System.IO.BinaryReader sr = new System.IO.BinaryReader(reader))
                {
                    int count = sr.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        CustomDataColumn column = new CustomDataColumn();
                        byte colType = sr.ReadByte();
                        column.SetType((DataType)colType);
                        column.Name = sr.ReadString();
                        this.Add(i, column);
                    }
                }
            }
        }

        public bool HasColumn(CustomDataColumn column)
        {
            return Values.Contains(column);
        }

        public bool HasColumn(string name)
        {
            return this[name] >= 0;
        }

        public DataType GetColumnType(string name)
        {
            return GetColumnType(this[name]);
        }

        public DataType GetColumnType(int ordinal)
        {
            return this[ordinal].Type;
        }

        public void MakePrimaryKey(int columnIndex)
        {
            if (_primaryKey != -1)
            {
                foreach (var col in this)
                {
                    col.Value.ClearPrimaryKey();
                }
            }

            _primaryKey = columnIndex;
            this[_primaryKey].MakePrimaryKey();
        }

        public int GetPrimaryKeyOrdinal()
        {
            return _primaryKey;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<int, CustomDataColumn> pair in this)
                builder.AppendFormat("{0} ({1}) ", pair.Value.Name, pair.Value.Type);
            
            return builder.ToString();
        }
    }
}
