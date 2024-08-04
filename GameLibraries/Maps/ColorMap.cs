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

        public static ColorMap RGB256 = new ColorMap("256 Bit")
        {
            {0, 0, 0, 0}
            ,{1, 1, 1, 1}
            ,{2, 2, 2, 2}
            ,{3, 3, 3, 3}
            ,{4, 4, 4, 4}
            ,{5, 5, 5, 5}
            ,{6, 6, 6, 6}
            ,{7, 7, 7, 7}
            ,{8, 8, 8, 8}
            ,{9, 9, 9, 9}
            ,{10, 10, 10, 10}
            ,{11, 11, 11, 11}
            ,{12, 12, 12, 12}
            ,{13, 13, 13, 13}
            ,{14, 14, 14, 14}
            ,{15, 15, 15, 15}
            ,{16, 16, 16, 16}
            ,{17, 17, 17, 17}
            ,{18, 18, 18, 18}
            ,{19, 19, 19, 19}
            ,{20, 20, 20, 20}
            ,{21, 21, 21, 21}
            ,{22, 22, 22, 22}
            ,{23, 23, 23, 23}
            ,{24, 24, 24, 24}
            ,{25, 25, 25, 25}
            ,{26, 26, 26, 26}
            ,{27, 27, 27, 27}
            ,{28, 28, 28, 28}
            ,{29, 29, 29, 29}
            ,{30, 30, 30, 30}
            ,{31, 31, 31, 31}
            ,{32, 32, 32, 32}
            ,{33, 33, 33, 33}
            ,{34, 34, 34, 34}
            ,{35, 35, 35, 35}
            ,{36, 36, 36, 36}
            ,{37, 37, 37, 37}
            ,{38, 38, 38, 38}
            ,{39, 39, 39, 39}
            ,{40, 40, 40, 40}
            ,{41, 41, 41, 41}
            ,{42, 42, 42, 42}
            ,{43, 43, 43, 43}
            ,{44, 44, 44, 44}
            ,{45, 45, 45, 45}
            ,{46, 46, 46, 46}
            ,{47, 47, 47, 47}
            ,{48, 48, 48, 48}
            ,{49, 49, 49, 49}
            ,{50, 50, 50, 50}
            ,{51, 51, 51, 51}
            ,{52, 52, 52, 52}
            ,{53, 53, 53, 53}
            ,{54, 54, 54, 54}
            ,{55, 55, 55, 55}
            ,{56, 56, 56, 56}
            ,{57, 57, 57, 57}
            ,{58, 58, 58, 58}
            ,{59, 59, 59, 59}
            ,{60, 60, 60, 60}
            ,{61, 61, 61, 61}
            ,{62, 62, 62, 62}
            ,{63, 63, 63, 63}
            ,{64, 64, 64, 64}
            ,{65, 65, 65, 65}
            ,{66, 66, 66, 66}
            ,{67, 67, 67, 67}
            ,{68, 68, 68, 68}
            ,{69, 69, 69, 69}
            ,{70, 70, 70, 70}
            ,{71, 71, 71, 71}
            ,{72, 72, 72, 72}
            ,{73, 73, 73, 73}
            ,{74, 74, 74, 74}
            ,{75, 75, 75, 75}
            ,{76, 76, 76, 76}
            ,{77, 77, 77, 77}
            ,{78, 78, 78, 78}
            ,{79, 79, 79, 79}
            ,{80, 80, 80, 80}
            ,{81, 81, 81, 81}
            ,{82, 82, 82, 82}
            ,{83, 83, 83, 83}
            ,{84, 84, 84, 84}
            ,{85, 85, 85, 85}
            ,{86, 86, 86, 86}
            ,{87, 87, 87, 87}
            ,{88, 88, 88, 88}
            ,{89, 89, 89, 89}
            ,{90, 90, 90, 90}
            ,{91, 91, 91, 91}
            ,{92, 92, 92, 92}
            ,{93, 93, 93, 93}
            ,{94, 94, 94, 94}
            ,{95, 95, 95, 95}
            ,{96, 96, 96, 96}
            ,{97, 97, 97, 97}
            ,{98, 98, 98, 98}
            ,{99, 99, 99, 99}
            ,{100, 100, 100, 100}
            ,{101, 101, 101, 101}
            ,{102, 102, 102, 102}
            ,{103, 103, 103, 103}
            ,{104, 104, 104, 104}
            ,{105, 105, 105, 105}
            ,{106, 106, 106, 106}
            ,{107, 107, 107, 107}
            ,{108, 108, 108, 108}
            ,{109, 109, 109, 109}
            ,{110, 110, 110, 110}
            ,{111, 111, 111, 111}
            ,{112, 112, 112, 112}
            ,{113, 113, 113, 113}
            ,{114, 114, 114, 114}
            ,{115, 115, 115, 115}
            ,{116, 116, 116, 116}
            ,{117, 117, 117, 117}
            ,{118, 118, 118, 118}
            ,{119, 119, 119, 119}
            ,{120, 120, 120, 120}
            ,{121, 121, 121, 121}
            ,{122, 122, 122, 122}
            ,{123, 123, 123, 123}
            ,{124, 124, 124, 124}
            ,{125, 125, 125, 125}
            ,{126, 126, 126, 126}
            ,{127, 127, 127, 127}
            ,{128, 128, 128, 128}
            ,{129, 129, 129, 129}
            ,{130, 130, 130, 130}
            ,{131, 131, 131, 131}
            ,{132, 132, 132, 132}
            ,{133, 133, 133, 133}
            ,{134, 134, 134, 134}
            ,{135, 135, 135, 135}
            ,{136, 136, 136, 136}
            ,{137, 137, 137, 137}
            ,{138, 138, 138, 138}
            ,{139, 139, 139, 139}
            ,{140, 140, 140, 140}
            ,{141, 141, 141, 141}
            ,{142, 142, 142, 142}
            ,{143, 143, 143, 143}
            ,{144, 144, 144, 144}
            ,{145, 145, 145, 145}
            ,{146, 146, 146, 146}
            ,{147, 147, 147, 147}
            ,{148, 148, 148, 148}
            ,{149, 149, 149, 149}
            ,{150, 150, 150, 150}
            ,{151, 151, 151, 151}
            ,{152, 152, 152, 152}
            ,{153, 153, 153, 153}
            ,{154, 154, 154, 154}
            ,{155, 155, 155, 155}
            ,{156, 156, 156, 156}
            ,{157, 157, 157, 157}
            ,{158, 158, 158, 158}
            ,{159, 159, 159, 159}
            ,{160, 160, 160, 160}
            ,{161, 161, 161, 161}
            ,{162, 162, 162, 162}
            ,{163, 163, 163, 163}
            ,{164, 164, 164, 164}
            ,{165, 165, 165, 165}
            ,{166, 166, 166, 166}
            ,{167, 167, 167, 167}
            ,{168, 168, 168, 168}
            ,{169, 169, 169, 169}
            ,{170, 170, 170, 170}
            ,{171, 171, 171, 171}
            ,{172, 172, 172, 172}
            ,{173, 173, 173, 173}
            ,{174, 174, 174, 174}
            ,{175, 175, 175, 175}
            ,{176, 176, 176, 176}
            ,{177, 177, 177, 177}
            ,{178, 178, 178, 178}
            ,{179, 179, 179, 179}
            ,{180, 180, 180, 180}
            ,{181, 181, 181, 181}
            ,{182, 182, 182, 182}
            ,{183, 183, 183, 183}
            ,{184, 184, 184, 184}
            ,{185, 185, 185, 185}
            ,{186, 186, 186, 186}
            ,{187, 187, 187, 187}
            ,{188, 188, 188, 188}
            ,{189, 189, 189, 189}
            ,{190, 190, 190, 190}
            ,{191, 191, 191, 191}
            ,{192, 192, 192, 192}
            ,{193, 193, 193, 193}
            ,{194, 194, 194, 194}
            ,{195, 195, 195, 195}
            ,{196, 196, 196, 196}
            ,{197, 197, 197, 197}
            ,{198, 198, 198, 198}
            ,{199, 199, 199, 199}
            ,{200, 200, 200, 200}
            ,{201, 201, 201, 201}
            ,{202, 202, 202, 202}
            ,{203, 203, 203, 203}
            ,{204, 204, 204, 204}
            ,{205, 205, 205, 205}
            ,{206, 206, 206, 206}
            ,{207, 207, 207, 207}
            ,{208, 208, 208, 208}
            ,{209, 209, 209, 209}
            ,{210, 210, 210, 210}
            ,{211, 211, 211, 211}
            ,{212, 212, 212, 212}
            ,{213, 213, 213, 213}
            ,{214, 214, 214, 214}
            ,{215, 215, 215, 215}
            ,{216, 216, 216, 216}
            ,{217, 217, 217, 217}
            ,{218, 218, 218, 218}
            ,{219, 219, 219, 219}
            ,{220, 220, 220, 220}
            ,{221, 221, 221, 221}
            ,{222, 222, 222, 222}
            ,{223, 223, 223, 223}
            ,{224, 224, 224, 224}
            ,{225, 225, 225, 225}
            ,{226, 226, 226, 226}
            ,{227, 227, 227, 227}
            ,{228, 228, 228, 228}
            ,{229, 229, 229, 229}
            ,{230, 230, 230, 230}
            ,{231, 231, 231, 231}
            ,{232, 232, 232, 232}
            ,{233, 233, 233, 233}
            ,{234, 234, 234, 234}
            ,{235, 235, 235, 235}
            ,{236, 236, 236, 236}
            ,{237, 237, 237, 237}
            ,{238, 238, 238, 238}
            ,{239, 239, 239, 239}
            ,{240, 240, 240, 240}
            ,{241, 241, 241, 241}
            ,{242, 242, 242, 242}
            ,{243, 243, 243, 243}
            ,{244, 244, 244, 244}
            ,{245, 245, 245, 245}
            ,{246, 246, 246, 246}
            ,{247, 247, 247, 247}
            ,{248, 248, 248, 248}
            ,{249, 249, 249, 249}
            ,{250, 250, 250, 250}
            ,{251, 251, 251, 251}
            ,{252, 252, 252, 252}
            ,{253, 253, 253, 253}
            ,{254, 254, 254, 254}
            ,{255, 255, 255, 255}
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

    }
}
