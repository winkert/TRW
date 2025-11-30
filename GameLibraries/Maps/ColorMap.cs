using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Serialization;

namespace TRW.GameLibraries.Maps
{
    [Serializable]
    public class ColorMap : Dictionary<decimal, Color>, IComparable, IBinarySerializable
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
                    {0M, 255, 255, 255},
                    {2.5M, 249, 249, 249},
                    {5M, 242, 242, 242},
                    {7.5M, 236, 236, 236},
                    {10M, 230, 230, 230},
                    {12.5M, 223, 223, 223},
                    {15M, 217, 217, 217},
                    {17.5M, 210, 210, 210},
                    {20M, 204, 204, 204},
                    {22.5M, 198, 198, 198},
                    {25M, 191, 191, 191},
                    {27.5M, 185, 185, 185},
                    {30M, 179, 179, 179},
                    {32.5M, 172, 172, 172},
                    {35M, 166, 166, 166},
                    {37.5M, 159, 159, 159},
                    {40M, 153, 153, 153},
                    {42.5M, 147, 147, 147},
                    {45M, 140, 140, 140},
                    {47.5M, 134, 134, 134},
                    {50M, 128, 128, 128},
                    {52.5M, 121, 121, 121},
                    {55M, 115, 115, 115},
                    {57.5M, 108, 108, 108},
                    {60M, 102, 102, 102},
                    {62.5M, 96, 96, 96},
                    {65M, 89, 89, 89},
                    {67.5M, 83, 83, 83},
                    {70M, 77, 77, 77},
                    {72.5M, 70, 70, 70},
                    {75M, 64, 64, 64},
                    {77.5M, 57, 57, 57},
                    {80M, 51, 51, 51},
                    {82.5M, 45, 45, 45},
                    {85M, 38, 38, 38},
                    {87.5M, 32, 32, 32},
                    {90M, 26, 26, 26},
                    {92.5M, 19, 19, 19},
                    {95M, 13, 13, 13},
                    {97.5M, 6, 6, 6},
                    {100M, 0, 0, 0}
                };

        public static ColorMap GrayScaleLarge = new ColorMap("Gray Scale 500")
                {
                    {0M, 255, 255, 255},
                    {2.5M, 254, 254, 254},
                    {5M, 252, 252, 252},
                    {7.5M, 251, 251, 251},
                    {10M, 250, 250, 250},
                    {12.5M, 249, 249, 249},
                    {15M, 247, 247, 247},
                    {17.5M, 246, 246, 246},
                    {20M, 245, 245, 245},
                    {22.5M, 244, 244, 244},
                    {25M, 242, 242, 242},
                    {27.5M, 241, 241, 241},
                    {30M, 240, 240, 240},
                    {32.5M, 238, 238, 238},
                    {35M, 237, 237, 237},
                    {37.5M, 236, 236, 236},
                    {40M, 235, 235, 235},
                    {42.5M, 233, 233, 233},
                    {45M, 232, 232, 232},
                    {47.5M, 231, 231, 231},
                    {50M, 229, 229, 229},
                    {52.5M, 228, 228, 228},
                    {55M, 227, 227, 227},
                    {57.5M, 226, 226, 226},
                    {60M, 224, 224, 224},
                    {62.5M, 223, 223, 223},
                    {65M, 222, 222, 222},
                    {67.5M, 221, 221, 221},
                    {70M, 219, 219, 219},
                    {72.5M, 218, 218, 218},
                    {75M, 217, 217, 217},
                    {77.5M, 215, 215, 215},
                    {80M, 214, 214, 214},
                    {82.5M, 213, 213, 213},
                    {85M, 212, 212, 212},
                    {87.5M, 210, 210, 210},
                    {90M, 209, 209, 209},
                    {92.5M, 208, 208, 208},
                    {95M, 207, 207, 207},
                    {97.5M, 205, 205, 205},
                    {100M, 204, 204, 204},
                    {102.5M, 203, 203, 203},
                    {105M, 201, 201, 201},
                    {107.5M, 200, 200, 200},
                    {110M, 199, 199, 199},
                    {112.5M, 198, 198, 198},
                    {115M, 196, 196, 196},
                    {117.5M, 195, 195, 195},
                    {120M, 194, 194, 194},
                    {122.5M, 193, 193, 193},
                    {125M, 191, 191, 191},
                    {127.5M, 190, 190, 190},
                    {130M, 189, 189, 189},
                    {132.5M, 187, 187, 187},
                    {135M, 186, 186, 186},
                    {137.5M, 185, 185, 185},
                    {140M, 184, 184, 184},
                    {142.5M, 182, 182, 182},
                    {145M, 181, 181, 181},
                    {147.5M, 180, 180, 180},
                    {150M, 178, 178, 178},
                    {152.5M, 177, 177, 177},
                    {155M, 176, 176, 176},
                    {157.5M, 175, 175, 175},
                    {160M, 173, 173, 173},
                    {162.5M, 172, 172, 172},
                    {165M, 171, 171, 171},
                    {167.5M, 170, 170, 170},
                    {170M, 168, 168, 168},
                    {172.5M, 167, 167, 167},
                    {175M, 166, 166, 166},
                    {177.5M, 164, 164, 164},
                    {180M, 163, 163, 163},
                    {182.5M, 162, 162, 162},
                    {185M, 161, 161, 161},
                    {187.5M, 159, 159, 159},
                    {190M, 158, 158, 158},
                    {192.5M, 157, 157, 157},
                    {195M, 156, 156, 156},
                    {197.5M, 154, 154, 154},
                    {200M, 153, 153, 153},
                    {202.5M, 152, 152, 152},
                    {205M, 150, 150, 150},
                    {207.5M, 149, 149, 149},
                    {210M, 148, 148, 148},
                    {212.5M, 147, 147, 147},
                    {215M, 145, 145, 145},
                    {217.5M, 144, 144, 144},
                    {220M, 143, 143, 143},
                    {222.5M, 142, 142, 142},
                    {225M, 140, 140, 140},
                    {227.5M, 139, 139, 139},
                    {230M, 138, 138, 138},
                    {232.5M, 136, 136, 136},
                    {235M, 135, 135, 135},
                    {237.5M, 134, 134, 134},
                    {240M, 133, 133, 133},
                    {242.5M, 131, 131, 131},
                    {245M, 130, 130, 130},
                    {247.5M, 129, 129, 129},
                    {250M, 127, 127, 127},
                    {252.5M, 126, 126, 126},
                    {255M, 125, 125, 125},
                    {257.5M, 124, 124, 124},
                    {260M, 122, 122, 122},
                    {262.5M, 121, 121, 121},
                    {265M, 120, 120, 120},
                    {267.5M, 119, 119, 119},
                    {270M, 117, 117, 117},
                    {272.5M, 116, 116, 116},
                    {275M, 115, 115, 115},
                    {277.5M, 113, 113, 113},
                    {280M, 112, 112, 112},
                    {282.5M, 111, 111, 111},
                    {285M, 110, 110, 110},
                    {287.5M, 108, 108, 108},
                    {290M, 107, 107, 107},
                    {292.5M, 106, 106, 106},
                    {295M, 105, 105, 105},
                    {297.5M, 103, 103, 103},
                    {300M, 102, 102, 102},
                    {302.5M, 101, 101, 101},
                    {305M, 99, 99, 99},
                    {307.5M, 98, 98, 98},
                    {310M, 97, 97, 97},
                    {312.5M, 96, 96, 96},
                    {315M, 94, 94, 94},
                    {317.5M, 93, 93, 93},
                    {320M, 92, 92, 92},
                    {322.5M, 91, 91, 91},
                    {325M, 89, 89, 89},
                    {327.5M, 88, 88, 88},
                    {330M, 87, 87, 87},
                    {332.5M, 85, 85, 85},
                    {335M, 84, 84, 84},
                    {337.5M, 83, 83, 83},
                    {340M, 82, 82, 82},
                    {342.5M, 80, 80, 80},
                    {345M, 79, 79, 79},
                    {347.5M, 78, 78, 78},
                    {350M, 76, 76, 76},
                    {352.5M, 75, 75, 75},
                    {355M, 74, 74, 74},
                    {357.5M, 73, 73, 73},
                    {360M, 71, 71, 71},
                    {362.5M, 70, 70, 70},
                    {365M, 69, 69, 69},
                    {367.5M, 68, 68, 68},
                    {370M, 66, 66, 66},
                    {372.5M, 65, 65, 65},
                    {375M, 64, 64, 64},
                    {377.5M, 62, 62, 62},
                    {380M, 61, 61, 61},
                    {382.5M, 60, 60, 60},
                    {385M, 59, 59, 59},
                    {387.5M, 57, 57, 57},
                    {390M, 56, 56, 56},
                    {392.5M, 55, 55, 55},
                    {395M, 54, 54, 54},
                    {397.5M, 52, 52, 52},
                    {400M, 51, 51, 51},
                    {402.5M, 50, 50, 50},
                    {405M, 48, 48, 48},
                    {407.5M, 47, 47, 47},
                    {410M, 46, 46, 46},
                    {412.5M, 45, 45, 45},
                    {415M, 43, 43, 43},
                    {417.5M, 42, 42, 42},
                    {420M, 41, 41, 41},
                    {422.5M, 40, 40, 40},
                    {425M, 38, 38, 38},
                    {427.5M, 37, 37, 37},
                    {430M, 36, 36, 36},
                    {432.5M, 34, 34, 34},
                    {435M, 33, 33, 33},
                    {437.5M, 32, 32, 32},
                    {440M, 31, 31, 31},
                    {442.5M, 29, 29, 29},
                    {445M, 28, 28, 28},
                    {447.5M, 27, 27, 27},
                    {450M, 25, 25, 25},
                    {452.5M, 24, 24, 24},
                    {455M, 23, 23, 23},
                    {457.5M, 22, 22, 22},
                    {460M, 20, 20, 20},
                    {462.5M, 19, 19, 19},
                    {465M, 18, 18, 18},
                    {467.5M, 17, 17, 17},
                    {470M, 15, 15, 15},
                    {472.5M, 14, 14, 14},
                    {475M, 13, 13, 13},
                    {477.5M, 11, 11, 11},
                    {480M, 10, 10, 10},
                    {482.5M, 9, 9, 9},
                    {485M, 8, 8, 8},
                    {487.5M, 6, 6, 6},
                    {490M, 5, 5, 5},
                    {492.5M, 4, 4, 4},
                    {495M, 3, 3, 3},
                    {497.5M, 1, 1, 1},
                    {500M, 0, 0, 0}
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
        public ColorMap():base(){}

        public ColorMap(string name)
            : base()
        {
            Name = name;

            _lowerBound = decimal.MinValue;
            _baseColor = Color.Empty;
        }

        public string Name { get; private set; }

        #region Public Methods
        public Color GetColor(decimal key, MapParser.ColorMapStyle style)
        {
            Color color = _baseColor;
            switch (style)
            {
                case MapParser.ColorMapStyle.Exact:
                    if (this.ContainsKey(key))
                        color = this[key];
                    else throw new ArgumentOutOfRangeException(nameof(key), $"The specified value {key:F3} does not exists in the colormap.");
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

        public byte[] ToByteArray()
        {
            using(MemoryStream ms = new MemoryStream())
                using (BinaryWriter bw = new BinaryWriter(ms))
            {
                this.WriteTo(bw);
                return ms.ToArray();
            }
        }

        public void WriteTo(BinaryWriter writer)
        {
            writer.Write(Name);

            writer.Write(this.Count);
            foreach (KeyValuePair<decimal, Color> key in this)
            {
                writer.Write(key.Key);
                writer.Write(key.Value.A);
                writer.Write(key.Value.R);
                writer.Write(key.Value.B);
                writer.Write(key.Value.G);
            }
        }

        public void ReadFrom(BinaryReader reader)
        {
            Name = reader.ReadString();

            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                decimal a = reader.ReadDecimal();
                byte al = reader.ReadByte();
                byte r = reader.ReadByte();
                byte b = reader.ReadByte();
                byte g = reader.ReadByte();
                Color v = Color.FromArgb(al, r, b, g);
                this.Add(a, v);
            }

            RefreshOrder();
        }
    }
}
