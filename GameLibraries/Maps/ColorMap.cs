using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Maps
{
    [Serializable]
    public class ColorMap : Dictionary<decimal, Color>, IComparable
    {
        #region Internal Subs
        internal enum DungeonColorMap
        {
            Floor = 5,
            Wall = 10,
            Hall = 30,
            Void = 100
        }
        #endregion

        #region Statics
        public static ColorMap GrayScale = new ColorMap("Gray Scale 100")
                {
                    {-15, Color.White },
                    {0, "#F4F4F4"},
                    {15, "#DCDCDC" },
                    {30, Color.Silver },
                    {45, "#B1B1B1" },
                    {60, Color.DarkGray },
                    {75, Color.Gray},
                    {90, Color.Black }
                };

        public static ColorMap GrayScaleLarge = new ColorMap("Gray Scale 500")
                {
                    {-50, Color.White },
                    {0, "#F4F4F4"},
                    {75, "#DCDCDC" },
                    {150, Color.Silver },
                    {225, "#B1B1B1" },
                    {300, Color.DarkGray },
                    {375, Color.Gray},
                    {450, Color.Black }
                };

        public static ColorMap Terra = new ColorMap("Terra 500")
                {
                    {-50, Color.DarkCyan },
                    {0, Color.LightBlue},
                    {35, Color.Khaki },
                    {150, Color.DarkOliveGreen },
                    {225, Color.DarkKhaki },
                    {300, Color.DarkGray },
                    {375, Color.LightSlateGray},
                    {450, Color.White }
                };

        public static ColorMap Dungeon = new ColorMap("Dungeon")
        {
            {(int)DungeonColorMap.Floor, Color.Beige},
            {(int)DungeonColorMap.Wall, Color.Beige},
            {(int)DungeonColorMap.Hall, Color.BlanchedAlmond },
            {(int)DungeonColorMap.Void, Color.Gray}
        };

        #endregion


        private decimal _lowerBound;
        private Color _baseColor;

        public ColorMap(string name)
            : base()
        {
            Name = name;

            _lowerBound = decimal.MinValue;
            _baseColor = Color.Empty;
        }

        protected ColorMap(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            Name = serializationInfo.GetString("Name");
            RefreshOrder();
        }

        public string Name { get; }

        #region Public Methods
        public Color GetColor(decimal key, MapParser.ColorMapStyle style)
        {
            Color color = _baseColor;
            switch (style)
            {
                case MapParser.ColorMapStyle.Exact:
                    color = this[key];
                    break;
                case MapParser.ColorMapStyle.Between:
                    decimal lastMapKey = _lowerBound;
                    foreach (var c in this.OrderBy(t => t.Key))
                    {
                        if (key > lastMapKey && key < c.Key)
                        {
                            color = c.Value;
                            break;
                        }

                        lastMapKey = c.Key;
                    }
                    break;
                case MapParser.ColorMapStyle.None:
                    break; // this is a super strange condition
            }
            return color;
        }

        public new void Add(decimal key, Color value)
        {
            base.Add(key, value);

            RefreshOrder();
        }

        public void Add(decimal key, int r, int g, int b)
        {
            Add(key, Color.FromArgb(r, g, b));
        }

        public void Add(decimal key, string hex)
        {
            Add(key, ColorTranslator.FromHtml(hex));
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion

        private void RefreshOrder()
        {
            if (this.Count == 0)
                return;

            KeyValuePair<decimal, Color> lowest = this.OrderBy(t => t.Key).First();

            _lowerBound = lowest.Key;
            _baseColor = lowest.Value;
        }

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo(((ColorMap)obj).Name);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Name", Name);
        }

        public static ColorMap GetGrayScale256Bits()
        {
            ColorMap gray256 = new ColorMap("256 Bit Grayscale");

            for (int i = 0; i < 256; i++)
                gray256.Add(i, i, i, i);

            return gray256;
        }

        /// <summary>
        /// returns a colormap for all 16m colors
        /// </summary>
        /// <returns></returns>
        public static ColorMap GetFullColorScale()
        {
            ColorMap fullColor = new ColorMap("Full Color");

            for (int i = 0; i < 16777216; i++)
                fullColor.Add(i, $"#{i:X6}");

            return fullColor;
        }
    }
}
