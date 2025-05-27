using TRW.CommonLibraries.Data;
using TRW.CommonLibraries.Xml;

namespace TRW.Apps.NPCGenerator
{
    internal class NameData : Dictionary<string, int>, IXmlData
    {
        private CustomDataTable _internalTable;
        internal static Random _r = new Random();
        internal NameData()
        {
            _internalTable = new CustomDataTable(
                new TRW.CommonLibraries.Data.Core.CustomDataColumn("Name", CommonLibraries.Data.Core.DataType.String)
                , new TRW.CommonLibraries.Data.Core.CustomDataColumn("Frequency", CommonLibraries.Data.Core.DataType.Integer));
            _internalTable.SetIndex("Name");
        }

        internal string Name => _internalTable.Current["Name"] as string;

        internal int Frequency => Convert.ToInt32(_internalTable.Current["Frequency"]);

        public new int this[string key]
        {
            get
            {
                return base[key];
            }
            set
            {
                base[key] = value;
                int existingRows = _internalTable.ScanForMatch(key).Count();
                if(existingRows > value)
                {
                    List<CommonLibraries.Data.Core.CustomDataRow> rowsToRemove = new List<CommonLibraries.Data.Core.CustomDataRow>();
                    int countRowsToRemove = value - existingRows;
                    while(_internalTable.Seek(key))
                    {
                        rowsToRemove.Add(_internalTable.Current);
                        if (--countRowsToRemove <= 0)
                            break;
                    }
                }
                else if(existingRows < value)
                {
                    for(int r = existingRows; r < value; r++)
                    {
                        var row = _internalTable.Add();
                        row[0] = key;
                        row[1] = value;
                    }
                }
            }
        }

        public void ReadXml(string filePath)
        {
            _internalTable.Clear();
            this.Clear();
            using (XmlParser reader = new XmlParser(filePath))
            {
                XmlDocumentElement root = reader.RootElement;
                foreach (XmlDocumentElement item in root.Children)
                {
                    string name = string.Empty;
                    int count = 0;
                    if (item.SeekElement("Name"))
                        name = item.CurrentChild.Value;
                    if (item.SeekElement("Frequency"))
                        count = int.Parse(item.CurrentChild.Value);

                    if (!string.IsNullOrEmpty(name) && !this.ContainsKey(name))
                        this.Add(name, count);
                }
            }

        }

        public void WriteXml(string filePath)
        {
            using(XmlBuilder writer = new XmlBuilder(filePath))
            {
                writer.OpenElement("Names");
                foreach (KeyValuePair<string, int> pair in this)
                {
                    writer.OpenElement("Item");
                    writer.WriteElement("Name", pair.Key);
                    writer.WriteElement("Frequency", pair.Value);
                    writer.CloseElement();
                }

                writer.CloseElement();
                writer.FinalizeDocument();
            }
        }

        /// <summary>
        /// Adds a name and frequency to the collection and to the internal table weighted
        /// </summary>
        /// <param name="name"></param>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public new bool Add(string name, int frequency)
        {
            if (!this.ContainsKey(name))
            {
                base.Add(name, frequency);

                for (int i = 0; i < frequency; i++)
                {
                    var row = _internalTable.Add();
                    row[0] = name;
                    row[1] = frequency;
                }
                return true;
            }
            return false;
        }

        internal string GetRandom()
        {
            return GetRandom(1, _internalTable.Count - 1);
        }

        internal string GetRandom(int min, int max)
        {
            
            if (_internalTable.GoTo(_r.Next(min, max)))
                return _internalTable["Name"].ToString();

            return string.Empty;
        }

        internal bool First()
        {
            return _internalTable.First();
        }

        internal bool Next()
        {
            return _internalTable.Next();
        }
    }
}
