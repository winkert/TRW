using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CommonLibraries.Data")]

namespace TRW.CommonLibraries.Data.Core
{

    public class CustomDataRow : IDataRow, IComparable<CustomDataRow>
    {
        #region Fields
        protected RowStates _rowState;
        internal CustomDataTableBase<CustomDataRow> _parentTable;
        #endregion
        /// <summary>
        /// Parameterless constructor for Generic
        /// </summary>
        public CustomDataRow()
        {
            _rowState = RowStates.Unknown;
        }

        public CustomDataRow(CustomDataColumnCollection columns, CustomDataTableBase<CustomDataRow> parentTable)
            : this()
        {
            InitializeRow(columns, parentTable);
        }

        #region Properties
        public CustomDataColumnCollection Columns { get; private set; }

        public object this[int col]
        {
            get
            {
                if (col < 0 || col > Columns.Count)
                    throw new IndexOutOfRangeException();

                if (Items[col] is DBNull)
                {
                    return null;
                }

                if (Items[col] != null)
                {
                    switch (Columns.GetColumnType(col))
                    {
                        case DataType.String:
                            return Convert.ToString(Items[col]);
                        case DataType.Integer:
                            return Convert.ToInt32(Items[col]);
                        case DataType.SmallInt:
                            return Convert.ToInt16(Items[col]);
                        case DataType.Decimal:
                            return Convert.ToDecimal(Items[col]);
                        case DataType.Boolean:
                            return Convert.ToBoolean(Items[col]);
                        case DataType.DateTime:
                            return Convert.ToDateTime(Items[col]);
                    }
                }
                return Items[col];
            }
            set
            {
                if (col < 0 || col > Columns.Count)
                    throw new IndexOutOfRangeException();

                switch (Columns.GetColumnType(col))
                {
                    case DataType.String:
                        Items[col] = Convert.ToString(value);
                        break;
                    case DataType.Integer:
                        Items[col] = Convert.ToInt32(value);
                        break;
                    case DataType.SmallInt:
                        Items[col] = Convert.ToInt16(value);
                        break;
                    case DataType.Decimal:
                        Items[col] = Convert.ToDecimal(value);
                        break;
                    case DataType.Boolean:
                        Items[col] = Convert.ToBoolean(value);
                        break;
                    case DataType.DateTime:
                        Items[col] = Convert.ToDateTime(value);
                        break;
                    default:
                        Items[col] = value;
                        break;
                }
                SetRowState(RowStates.Update);
            }
        }

        public object this[string colName]
        {
            get
            {
                return this[Columns[colName]];
            }
            set
            {
                this[Columns[colName]] = value;
            }
        }

        public bool Deleted { get; protected set; }

        public object[] Items { get; private set; }
        #endregion

        #region Publics
        public void Delete()
        {
            SetRowState(RowStates.Delete);
            this.Deleted = true;
        }

        /// <summary>
        /// Serialize Row Data
        /// </summary>
        /// <returns></returns>
        public string SerializeRow()
        {
            // use byte[]
            // write data type of column, then write value
            // if null, write DataType.Null and no value
            byte[] bytes;
            using (System.IO.MemoryStream writer = new System.IO.MemoryStream())
            {
                using (System.IO.BinaryWriter sw = new System.IO.BinaryWriter(writer))
                {
                    for (int i = 0; i < Items.Length; i++)
                    {
                        try
                        {
                            if (Items[i] == null || Items[i] == DBNull.Value)
                            {
                                sw.Write((byte)DataType.Null);
                                continue;
                            }

                            sw.Write((byte)Columns[i].Type);
                            switch (Columns[i].Type)
                            {
                                case DataType.String:
                                    sw.Write(Convert.ToString(Items[i]));
                                    break;
                                case DataType.Integer:
                                    sw.Write(Convert.ToInt32(Items[i]));
                                    break;
                                case DataType.SmallInt:
                                    sw.Write(Convert.ToInt16(Items[i]));
                                    break;
                                case DataType.Decimal:
                                    sw.Write(Convert.ToDecimal(Items[i]));
                                    break;
                                case DataType.DateTime:
                                    sw.Write(Convert.ToDateTime(Items[i]).Ticks);
                                    break;
                                case DataType.Boolean:
                                    sw.Write(Convert.ToBoolean(Items[i]));
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("Error serializing row column [{0}], Type [{1}], Value [{2}]", Columns[i].Name, Columns[i].Type, Items[i]), ex);
                        }
                    }
                }
                bytes = writer.ToArray();
            }

            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Deserialize Row from Serialized Row Data
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="serializedData"></param>
        public void DeserializeRow(CustomDataColumnCollection columns, string serializedData)
        {
            Columns = columns;
            Items = new object[columns.Count];
            byte[] bytes = Convert.FromBase64String(serializedData);
            using (System.IO.MemoryStream reader = new System.IO.MemoryStream(bytes))
            {
                using (System.IO.BinaryReader sw = new System.IO.BinaryReader(reader))
                {
                    for (int i = 0; i < Items.Length; i++)
                    {
                        try
                        {
                            byte colType = sw.ReadByte();
                            DataType column = (DataType)colType;

                            switch (column)
                            {
                                case DataType.Null:
                                    continue;
                                case DataType.String:
                                    Items[i] = sw.ReadString();
                                    break;
                                case DataType.Integer:
                                    Items[i] = sw.ReadInt32();
                                    break;
                                case DataType.SmallInt:
                                    Items[i] = sw.ReadInt16();
                                    break;
                                case DataType.Decimal:
                                    Items[i] = sw.ReadDecimal();
                                    break;
                                case DataType.DateTime:
                                    // we write the ticks as a long
                                    long ticks = sw.ReadInt64();
                                    Items[i] = new DateTime(ticks);
                                    break;
                                case DataType.Boolean:
                                    Items[i] = sw.ReadBoolean();
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("Error deserializing row column [{0}], Type [{1}], Value [{2}]", Columns[i].Name, Columns[i].Type, Items[i]), ex);
                        }
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            // TODO: Create equals method
            CustomDataRow other = (CustomDataRow)obj;
            return this.Columns.Equals(other.Columns) && this.Items.Equals(other.Items);
        }

        public override int GetHashCode()
        {
            // TODO: Create hashing method
            return base.GetHashCode();
        }

        public int CompareTo(CustomDataRow obj)
        {
            if (this.Equals(obj))
                return 0;

            if (obj._parentTable == null || this._parentTable == null)
            {
                return CompareToRow(obj);
            }

            if (this._parentTable._rowEnum._currentIndex != null || obj._parentTable._rowEnum._currentIndex != null)
            {
                // if either row is on an index, compare by the index in the BinaryTree of Enumerator
                if (this._parentTable._rowEnum._currentIndex != null)
                {
                    return this._parentTable._rowEnum._currentIndex.Compare(this, obj);
                }
                else
                {
                    return obj._parentTable._rowEnum._currentIndex.Compare(obj, this) * -1;
                }
            }
            else
            {
                return CompareToRow(obj);
            }
        }

        private int CompareToRow(CustomDataRow obj)
        {
            // compare the entire row
            for (int i = 0; i < this.Items.Length; i++)
            {
                if (this.Items[i] == null && obj.Items[i] == null)
                    continue;

                if (this.Items[i] == null)
                    return -1;
                if(obj.Items[i] == null)
                    return 1;

                IComparable xValue = this.Items[i] as IComparable;
                IComparable yValue = obj.Items[i] as IComparable;
                int compareResult = xValue.CompareTo(yValue);
                if (compareResult !=0)
                    return compareResult;
            }
            return 0; // they are equal
        }

        public void InitializeRow<DataRow>(CustomDataColumnCollection columns, CustomDataTableBase<DataRow> parent) where DataRow : CustomDataRow, new()
        {
            Columns = columns;
            Items = new object[Columns.Count];
            _parentTable = parent as CustomDataTableBase<CustomDataRow>;
        }

        public void SetRowState(RowStates rowState)
        {
            switch (this._rowState)
            {
                case RowStates.Update:
                    switch (rowState)
                    {
                        case RowStates.None: // allow for the possibility of undoing changes
                        case RowStates.Delete:
                            this._rowState = rowState;
                            break;
                        case RowStates.Update:
                            // do nothing
                            break;
                        case RowStates.Insert:
                            throw new ArgumentException(string.Format("Invalid Row State [{0}]. Current Row State [{1}]", rowState, _rowState), nameof(rowState));
                    }
                    break;
                case RowStates.Insert:
                    switch (rowState)
                    {
                        case RowStates.None: // allow for the possibility of undoing changes
                        case RowStates.Delete: // if we have inserted the row and now we are deleting the row, it is actually more complicated
                            this._rowState = rowState;
                            break;
                        case RowStates.Insert:
                        case RowStates.Update:
                            // do nothing
                            break;
                    }
                    break;
                case RowStates.Delete:
                    switch (rowState)
                    {
                        case RowStates.None: // allow for the possibility of undoing changes
                            this._rowState = rowState;
                            break;
                        case RowStates.Insert: // should be impossible?
                        case RowStates.Update:
                        case RowStates.Delete:
                            throw new ArgumentException(string.Format("Invalid Row State [{0}]. Current Row State [{1}]", rowState, _rowState), nameof(rowState));
                    }
                    break;
                case RowStates.None:
                case RowStates.Unknown:
                    this._rowState = rowState;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Privates

        #endregion

        #region Enums
        public enum RowStates
        {
            Unknown = 0,
            None = 1,
            Update = 2,
            Insert = 3,
            Delete = 4
        }
        #endregion
    }
}
