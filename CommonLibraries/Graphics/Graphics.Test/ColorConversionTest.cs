using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TRW.CommonLibraries.Graphics.Test
{
    [TestClass]
    public class ColorConversionTest
    {
        [TestMethod]
        public void RgbToHslTest()
        {
            // RED
            Color red = Color.Red;
            TRWColor target = new TRWColor(red);

            Assert.AreEqual(Color.FromArgb(red.R, red.G, red.B), target.GetColor());
            Assert.AreEqual(red.R, target.Red);
            Assert.AreEqual(red.G, target.Green);
            Assert.AreEqual(red.B, target.Blue);

            Assert.AreEqual(0, target.Hue);
            Assert.AreEqual(100, target.Saturation);
            Assert.AreEqual(50, target.Lightness);

            // VIOLET
            Color violet = Color.Violet;
            target = new TRWColor(violet);

            Assert.AreEqual(Color.FromArgb(violet.R, violet.G, violet.B), target.GetColor());
            Assert.AreEqual(violet.R, target.Red);
            Assert.AreEqual(violet.G, target.Green);
            Assert.AreEqual(violet.B, target.Blue);

            Assert.AreEqual(300, target.Hue);
            Assert.AreEqual(76.1m, Math.Round(target.Saturation, 1));
            Assert.AreEqual(72.2m, Math.Round(target.Lightness, 1));
        }

        [TestMethod]
        public void HslToRgbTest()
        {
            TRWColor target = new TRWColor(0m, 1m, 80m);
            Assert.AreEqual(255, target.Red);
            Assert.AreEqual(153, target.Green);
            Assert.AreEqual(153, target.Blue);

            target = new TRWColor(45m, 1m, 80m);
            Assert.AreEqual(255, target.Red);
            Assert.AreEqual(230, target.Green);
            Assert.AreEqual(153, target.Blue);

            target = new TRWColor(60m, 1m, 80m);
            Assert.AreEqual(255, target.Red);
            Assert.AreEqual(255, target.Green);
            Assert.AreEqual(153, target.Blue);

            target = new TRWColor(105m, 1m, 80m);
            Assert.AreEqual(178, target.Red);
            Assert.AreEqual(255, target.Green);
            Assert.AreEqual(153, target.Blue);

            target = new TRWColor(130m, 1m, 80m);
            Assert.AreEqual(153, target.Red);
            Assert.AreEqual(255, target.Green);
            Assert.AreEqual(170, target.Blue);

            target = new TRWColor(180m, 1m, 80m);
            Assert.AreEqual(153, target.Red);
            Assert.AreEqual(255, target.Green);
            Assert.AreEqual(255, target.Blue);

            target = new TRWColor(200m, 1m, 80m);
            Assert.AreEqual(153, target.Red);
            Assert.AreEqual(221, target.Green);
            Assert.AreEqual(255, target.Blue);

            target = new TRWColor(240m, 1m, 80m);
            Assert.AreEqual(153, target.Red);
            Assert.AreEqual(153, target.Green);
            Assert.AreEqual(255, target.Blue);

            target = new TRWColor(300m, 1m, 80m);
            Assert.AreEqual(255, target.Red);
            Assert.AreEqual(153, target.Green);
            Assert.AreEqual(255, target.Blue);

            target = new TRWColor(310m, 1m, 80m);
            Assert.AreEqual(255, target.Red);
            Assert.AreEqual(153, target.Green);
            Assert.AreEqual(238, target.Blue);

            target = new TRWColor(359m, 1m, 80m);
            Assert.AreEqual(255, target.Red);
            Assert.AreEqual(153, target.Green);
            Assert.AreEqual(155, target.Blue);

            target = new TRWColor(360m, 1m, 80m);
            Assert.AreEqual(255, target.Red);
            Assert.AreEqual(153, target.Green);
            Assert.AreEqual(153, target.Blue);

        }

        [TestMethod]
        public void GetHueTest()
        {
            decimal target = ColorConverter.GetHue(255, 0, 0);
            Assert.AreEqual(0, target);

            target = ColorConverter.GetHue(238, 130, 238);
            Assert.AreEqual(300, target);

            target = ColorConverter.GetHue(255, 128, 0);
            Assert.AreEqual(30, Math.Round(target, 0));

            target = ColorConverter.GetHue(255, 255, 0);
            Assert.AreEqual(60, target);

            target = ColorConverter.GetHue(126, 255, 0);
            Assert.AreEqual(90, Math.Round(target, 0));

            target = ColorConverter.GetHue(64, 128, 128);
            Assert.AreEqual(180, Math.Round(target, 0));

            target = ColorConverter.GetHue(218, 163, 245);
            Assert.AreEqual(280, Math.Round(target, 0));

            target = ColorConverter.GetHue(0, 0, 0);
            Assert.AreEqual(0, target);

            target = ColorConverter.GetHue(255, 255, 255);
            Assert.AreEqual(0, target);
        }

        [TestMethod]
        public void GetSaturationTest()
        {
            decimal target = ColorConverter.GetSaturation(255, 255, 255);
            Assert.AreEqual(0m, target);

            target = ColorConverter.GetSaturation(255, 0, 0);
            Assert.AreEqual(100m, target);

            target = ColorConverter.GetSaturation(255, 0, 255);
            Assert.AreEqual(100m, target);

            target = ColorConverter.GetSaturation(255, 255, 0);
            Assert.AreEqual(100m, target);

            target = ColorConverter.GetSaturation(126, 255, 0);
            Assert.AreEqual(100m, Math.Round(target, 0));

            target = ColorConverter.GetSaturation(64, 128, 128);
            Assert.AreEqual(33.3m, Math.Round(target, 1));

            target = ColorConverter.GetSaturation(245, 164, 165);
            Assert.AreEqual(80, Math.Round(target, 0));

        }

        [TestMethod]
        public void GetLightnessTest()
        {
            decimal target = ColorConverter.GetLightness(255, 255, 255);
            Assert.AreEqual(100, target);

            target = ColorConverter.GetLightness(64, 128, 128);
            Assert.AreEqual(37.6m, Math.Round(target, 1));

            target = ColorConverter.GetLightness(255, 0, 0);
            Assert.AreEqual(50, target);

            target = ColorConverter.GetLightness(255, 0, 255);
            Assert.AreEqual(50, target);

            target = ColorConverter.GetLightness(255, 255, 0);
            Assert.AreEqual(50, target);

            target = ColorConverter.GetLightness(245, 164, 165);
            Assert.AreEqual(80, Math.Round(target, 0));

            target = ColorConverter.GetLightness(126, 255, 0);
            Assert.AreEqual(50, Math.Round(target, 0));

            target = ColorConverter.GetLightness(0, 0, 0);
            Assert.AreEqual(0, target);

        }

        [TestMethod]
        public void GetFrequencyFromHueTest()
        {
            Color target = ColorConverter.GetColorFromFrequency(480);
            
        }

        [TestMethod]
        public void GetColorFromWavelengthTest()
        {
            Color target = ColorConverter.GetColorFromWavelength(400);
            Assert.AreEqual(228, target.R);
            Assert.AreEqual(153, target.G);
            Assert.AreEqual(255, target.B);

            target = ColorConverter.GetColorFromWavelength(600);
            Assert.AreEqual(153, target.R);
            Assert.AreEqual(255, target.G);
            Assert.AreEqual(183, target.B);
        }

        [TestMethod]
        public void WavelengthConversionTest()
        {
            decimal target = ColorConverter.GetWavelengthFromColor(Color.Red);
            Color cTarget = ColorConverter.GetColorFromWavelength(target);

            Assert.AreEqual(Color.Red.R, cTarget.R, $"Color Red didn't match. GetWavelengthFromColor result for Color.Red = {target}");
            Assert.AreEqual(Color.Red.G, cTarget.G, $"Color Green didn't match. GetWavelengthFromColor result for Color.Red = {target}");
            Assert.AreEqual(Color.Red.B, cTarget.B, $"Color Blue didn't match. GetWavelengthFromColor result for Color.Red = {target}");
        }

    }
}
