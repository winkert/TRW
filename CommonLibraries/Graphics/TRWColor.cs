using System;
using System.Drawing;

namespace TRW.CommonLibraries.Graphics
{
    public struct TRWColor
    {
        public TRWColor(int r, int g, int b)
        {
            Red = r;
            Green = g;
            Blue = b;

            Hue = ColorConverter.GetHue(r, g, b);
            Saturation = ColorConverter.GetSaturation(r, g, b);
            Lightness = ColorConverter.GetLightness(r, g, b);
        }

        public TRWColor(decimal h)
            : this(h, 1m, 0.8m)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="h">Hue</param>
        /// <param name="s">Saturation</param>
        /// <param name="l">LIghtness</param>
        public TRWColor(decimal h, decimal s, decimal l)
        {
            Hue = h;

            decimal localS = s > 1 ? s / 100 : s;
            decimal localL = l > 1 ? l / 100 : l;
            Saturation = localS;
            Lightness = localL;

            ColorConverter.GetRGBFromHSL(h, s, l, out int r, out int g, out int b);
            Red = r;
            Green = g;
            Blue = b;
        }

        public TRWColor(Color color)
            : this(color.R, color.G, color.B)
        {
            
        }

        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public decimal Hue { get; }
        public decimal Saturation { get; }
        public decimal Lightness { get; }

        public Color GetColor()
        {
            return Color.FromArgb(Red, Green, Blue);
        }

        public string GetHex()
        {
            return ColorConverter.GetHexFromColor(GetColor());
        }

    }

}