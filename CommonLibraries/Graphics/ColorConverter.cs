using System;
using System.Drawing;

namespace TRW.CommonLibraries.Graphics
{
    public static class ColorConverter
    {
        #region Constants
        public const decimal SpeedOfLightMetersPS = 299792458m;

        public const decimal MinimumVisibleFrequency = 400m;
        public const decimal MaximumVisibleFrequency = 789m;
        public const decimal MinimumVisibleWavelength = 380m;
        public const decimal MaximumVisibleWavelength = 750m;

        internal const decimal PureRedFrequency = 400m;
        internal const decimal PureOrangeFrequency = 496m;
        internal const decimal PureYellowFrequency = 517m;
        internal const decimal PureGreenFrequency = 566m;
        internal const decimal PureBlueFrequency = 637m;
        internal const decimal PureVioletFrequency = 789m;

        internal const decimal PureRedWavelength = 750m;
        internal const decimal PureOrangeWavelength = 605m;
        internal const decimal PureYellowWavelength = 580m;
        internal const decimal PureGreenWavelength = 532.5m;
        internal const decimal PureBlueWavelength = 472.5m;
        internal const decimal PureVioletWavelength = 380m;

        internal readonly static decimal[] PureHueFrequencies = new decimal[]
        {
            400m, // red
            496m, // orange
            517m, // yellow
            566m, // green
            637m, // blue
            789m // violet
        };

        internal readonly static decimal[] PureHueWavelengths = new decimal[]
        {
            380m, // violet
            472.5m, // blue
            532.5m, // green
            580m, // yellow
            605m, // orange
            750m // red
        };

        #endregion

        public static Color GetColor(int R, int G, int B)
        {
            return GetColor(R, G, B, 255);
        }

        public static Color GetColor(int R, int G, int B, int alpha)
        {
            return Color.FromArgb(alpha, R, G, B);
        }

        public static Color GetColor(string R, string G, string B)
        {
            return GetColor(
                int.Parse(R, System.Globalization.NumberStyles.HexNumber),
                int.Parse(G, System.Globalization.NumberStyles.HexNumber),
                int.Parse(B, System.Globalization.NumberStyles.HexNumber));
        }

        public static Color GetColor(string hexValue)
        {
            if (hexValue.StartsWith("#"))
            {
                hexValue = hexValue.Substring(1);
            }

            int r, g, b, a;
            switch (hexValue.Length)
            {
                case 3:
                    r = int.Parse(hexValue[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                    g = int.Parse(hexValue[1].ToString(), System.Globalization.NumberStyles.HexNumber);
                    b = int.Parse(hexValue[2].ToString(), System.Globalization.NumberStyles.HexNumber);
                    a = 0;
                    break;
                case 4:
                    r = int.Parse(hexValue[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                    g = int.Parse(hexValue[1].ToString(), System.Globalization.NumberStyles.HexNumber);
                    b = int.Parse(hexValue[2].ToString(), System.Globalization.NumberStyles.HexNumber);
                    a = int.Parse(hexValue[3].ToString(), System.Globalization.NumberStyles.HexNumber);
                    break;
                case 6:
                    r = int.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    g = int.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    b = int.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                    a = 0;
                    break;
                case 8:
                    r = int.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    g = int.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                    b = int.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                    a = int.Parse(hexValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                    break;
                default:
                    throw new ArgumentException($"Unexpected length of Hexidecimal String [{hexValue}]", "hexValue.Length");
            }

            return GetColor(r, g, b, a);
        }

        public static string GetHexFromColor(Color color, bool withAlpha = false)
        {
            if (withAlpha)
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
            else
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        #region RGB to HSL
        /// <summary>
        /// Get the Hue value from the RGB
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns>Degree value as decimal between 0 and 300</returns>
        public static decimal GetHue(int r, int g, int b)
        {
            GetConversionValues(r, g, b, out decimal r1, out decimal g1, out decimal b1, out decimal cMax, out decimal cMin);
            if (cMax != cMin)
            {
                decimal delta = cMax - cMin;

                if (cMax == r1)
                {
                    decimal result = (g1 - b1) / delta;
                    decimal mod6 = result % 6;
                    result = mod6;
                    if (result > 0)
                        return result * 60m;
                }

                if (cMax == g1)
                {
                    decimal result = ((b1 - r1) / delta) + 2;
                    if (result > 0)
                        return result * 60m;
                }

                if (cMax == b1)
                {
                    decimal result = ((r1 - g1) / delta) + 4;
                    if (result > 0)
                        return result * 60m;
                }
            }

            // at this point, we are probably requesting a hue value between 300 and 360 (pink)
            // this doesn't really work because pink is really Red but lighter
            return 0;
        }
        /// <summary>
        /// Get the Saturation value from the RGB
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns>Percent value as decimal between 0 and 100</returns>
        public static decimal GetSaturation(int r, int g, int b)
        {
            GetConversionValues(r, g, b, out _, out _, out _, out decimal cMax, out decimal cMin);
            if (cMax == cMin)
                return 0;

            decimal delta = cMax - cMin;
            decimal L = GetLightness(r, g, b) / 100m;
            decimal divisor = (1 - Math.Abs((2 * L) - 1));
            return (delta / divisor) * 100m;

        }
        /// <summary>
        /// Get the Lghtness value from the RGB
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns>Percent value as decimal between 0 and 100</returns>
        public static decimal GetLightness(int r, int g, int b)
        {
            GetConversionValues(r, g, b, out _, out _, out _, out decimal cMax, out decimal cMin);
            decimal result = (cMax + cMin) / 2m;
            return 100m * result;
        }

        public static void GetRGBFromHSL(decimal h, decimal s, decimal l, out int r, out int g, out int b)
        {
            r = 0;
            g = 0;
            b = 0;

            // C = (1 - |2L - 1|) × S
            // X = C × (1 - | (H / 60°) mod 2 - 1 |)
            // m = L - C / 2
            decimal localS = s > 1 ? s / 100 : s;
            decimal localL = l > 1 ? l / 100 : l;

            decimal c = (1m - Math.Abs(2m * localL - 1m)) * localS;
            decimal hueInt = (h / 60m);
            decimal mod2 = hueInt % 2m;
            decimal x = c * (1m - Math.Abs(mod2 - 1m));
            decimal m = localL - c / 2m;

            decimal r1;
            decimal g1;
            decimal b1;
            if (h >= 300)
            {
                r1 = c;
                g1 = 0;
                b1 = x;
            }
            else if (h >= 240)
            {
                r1 = x;
                g1 = 0;
                b1 = c;
            }
            else if (h >= 180)
            {
                r1 = 0;
                g1 = x;
                b1 = c;
            }
            else if (h >= 120)
            {
                r1 = 0;
                g1 = c;
                b1 = x;
            }
            else if (h >= 60)
            {
                r1 = x;
                g1 = c;
                b1 = 0;
            }
            else if (h >= 0)
            {
                r1 = c;
                g1 = x;
                b1 = 0;
            }
            else
            {
                throw new ArgumentException();
            }

            r = (int)Math.Round((r1 + m) * 255m, 0);
            g = (int)Math.Round((g1 + m) * 255m, 0);
            b = (int)Math.Round((b1 + m) * 255m, 0);
        }

        private static void GetConversionValues(int r, int g, int b, out decimal r1, out decimal g1, out decimal b1, out decimal cMax, out decimal cMin)
        {
            r1 = r / 255m;
            g1 = g / 255m;
            b1 = b / 255m;

            cMax = Math.Max(Math.Max(r1, g1), b1);
            cMin = Math.Min(Math.Min(r1, g1), b1);
        }
        #endregion

        public static void GetWavelengthAndFrequencyFromColor(Color color, out decimal wavelength, out decimal frequency)
        {
            GetWavelengthAndFrequencyFromColor(color.R, color.G, color.B, out wavelength, out frequency);
        }

        public static void GetWavelengthAndFrequencyFromColor(int r, int g, int b, out decimal wavelength, out decimal frequency)
        {
            decimal hue = GetHue(r, g, b);
            wavelength = MaximumVisibleWavelength - ((MaximumVisibleWavelength - MinimumVisibleWavelength) / 270) * hue;
            frequency = GetFrequencyFromWavelength(wavelength);
        }

        /// <summary>
        /// Get the color from the frequency of the light
        /// </summary>
        /// <param name="frequency">Terahertz (THz)</param>
        /// <returns></returns>
        public static Color GetColorFromFrequency(decimal frequency)
        {
            // given a frequency on the visible light spectrum, you should be able to get the hue of the color
            // from there, you can use some baseline values for Saturation and Lightness to get the RGB values



            if (frequency >= MinimumVisibleFrequency && frequency <= MaximumVisibleFrequency)
            {
                // colors closer to the minimum frequency are red
                // this means that around 400nm is close to FF0000 and around 700nm is FF00FF
                int r, g, b;
                if (frequency > PureHueFrequencies[4])
                {
                    // Violet
                    r = GetBitValueForColor(255, frequency, PureHueFrequencies[4], MaximumVisibleFrequency);
                    g = 0;
                    b = 255;
                }
                else if (frequency >= PureHueFrequencies[3])
                {
                    // Blue
                    r = 0;
                    g = GetBitValueForColor(255, frequency, PureHueFrequencies[3], PureHueFrequencies[5]);
                    b = 255;
                }
                else if (frequency >= PureHueFrequencies[2])
                {
                    // Green
                    r = 0;
                    g = 255;
                    b = GetBitValueForColor(255, frequency, PureHueFrequencies[2], PureHueFrequencies[4]);
                }
                else if (frequency >= PureHueFrequencies[1])
                {
                    // Yellow
                    r = GetBitValueForColor(255, frequency, PureHueFrequencies[1], PureHueFrequencies[3]);
                    g = 255;
                    b = 0;
                }
                else if (frequency >= PureHueFrequencies[1])
                {
                    // Orange
                    r = 255;
                    g = GetBitValueForColor(255, frequency, PureHueFrequencies[1], PureHueFrequencies[2]);
                    b = 0;
                }
                else
                {
                    // Red
                    r = GetBitValueForColor(255, frequency, MinimumVisibleFrequency, PureHueFrequencies[1]);
                    g = 0;
                    b = 0;
                }

                return GetColor(r, g, b);
            }

            return Color.Empty;
        }

        public static decimal GetWavelengthFromColor(Color color)
        {
            TRWColor c = new TRWColor(color);
            decimal h = c.Hue;
            decimal l = MaximumVisibleWavelength - MinimumVisibleWavelength / 270m * h;
            return l;
        }

        /// <summary>
        /// Get the color from the wavelength of the light
        /// </summary>
        /// <param name="wavelength">Nanometers (nm)</param>
        /// <returns></returns>
        public static Color GetColorFromWavelength(decimal wavelength)
        {
            if (wavelength >= MinimumVisibleWavelength && wavelength <= MaximumVisibleWavelength)
            {
                // L = 650 - 250 / 270 * H
                // Wavelength L equals MaximumVisibleWavelength minus Range Length of Wavelengths divided by Range of Hue Degrees Times Hue
                decimal wavelengthRange = MaximumVisibleWavelength - MinimumVisibleWavelength;
                decimal hue = ((MaximumVisibleWavelength - wavelength) * 270m) / wavelengthRange;
                //hue = hue * 180m / (decimal)Math.PI;
                TRWColor color = new TRWColor(hue, 1m, 1m);
                return color.GetColor();
            }

            return Color.Empty;
        }

        public static Color GetColorFromWavelength_Manual(decimal wavelength)
        {
            if (wavelength >= MinimumVisibleWavelength && wavelength <= MaximumVisibleWavelength)
            {
                // L = 650 - 250 / 270 * H
                // Wavelength L equals MaximumVisibleWavelength minus Range Length of Wavelengths divided by Range of Hue Degrees Times Hue
                decimal wavelengthRange = MaximumVisibleWavelength - MinimumVisibleWavelength;
                decimal hue = ((MaximumVisibleWavelength - wavelength) * 270m) / wavelengthRange;
                //hue = hue * 180m / (decimal)Math.PI;
                // colors closer to the minimum wavelenght are violet
                int r, g, b;
                if (wavelength >= PureHueWavelengths[5])
                {
                    // Red
                    r = GetBitValueForColor(255, wavelength, MinimumVisibleWavelength, PureHueWavelengths[1]);
                    g = 0;
                    b = 0;
                }
                else if (wavelength >= PureHueWavelengths[4])
                {
                    // Orange
                    r = 255;
                    g = GetBitValueForColor(255, wavelength, PureHueWavelengths[1], PureHueWavelengths[2]);
                    b = 0;
                }
                else if (wavelength >= PureHueWavelengths[3])
                {
                    // Yellow
                    r = GetBitValueForColor(255, wavelength, PureHueWavelengths[2], PureHueWavelengths[3]);
                    g = 255;
                    b = 0;
                }
                else if (wavelength >= PureHueFrequencies[2])
                {
                    // Green
                    r = 0;
                    g = 255;
                    b = GetBitValueForColor(255, wavelength, PureHueWavelengths[3], PureHueWavelengths[4]);
                }
                else if (wavelength >= PureHueFrequencies[1])
                {
                    // Blue
                    r = 0;
                    g = GetBitValueForColor(255, wavelength, PureHueWavelengths[4], PureHueWavelengths[5]);
                    b = 255;
                }
                else
                {
                    // Violet
                    r = GetBitValueForColor(255, wavelength, PureHueWavelengths[5], MaximumVisibleWavelength);
                    g = 0;
                    b = 255;
                }

                return GetColor(r, g, b);
            }

            return Color.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency">THz</param>
        /// <returns>nm</returns>
        public static decimal GetWavelengthFromFrequency(decimal frequency)
        {
            //λ = C / f
            return SpeedOfLightMetersPS / frequency / 1000;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wavelength">nm</param>
        /// <returns>THz</returns>
        public static decimal GetFrequencyFromWavelength(decimal wavelength)
        {
            //f = C / λ
            return SpeedOfLightMetersPS / wavelength / 1000;
        }


        private static int GetBitValueForColor(int maxBit, decimal value, decimal minValue, decimal maxValue)
        {
            return (int)(maxBit * (value - minValue) / (maxValue - minValue));
        }
    }
}
