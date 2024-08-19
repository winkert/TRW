using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TRW.CommonLibraries.Audio.Test
{
    [TestClass]
    public class TemperamentTest
    {
        [TestMethod]
        public void GetTemperamentTest()
        {
            foreach (TemperamentStyles style in Enum.GetValues(typeof(TemperamentStyles)))
            {
                var target = TemperamentFactory.GetTemperament(style);
                Assert.IsNotNull(target, $"Unsupported TemperamentStyle: {style}");
            }
        }

        [TestMethod]
        public void EqualTemperamentTests()
        {
            EqualTemperament target = new EqualTemperament();
            double result = target.GetFrequency(Pitches.A, 4);
            Assert.AreEqual(440d, result);

            result = target.GetFrequency(Pitches.A, 3);
            Assert.AreEqual(219.99999999999989d, result);

            result = target.GetFrequency(Pitches.A, 5);
            Assert.AreEqual(880.00000000000034d, result);

            // test the crazy lady thing
            target = new EqualTemperament(Pitches.A, 420d, 4);
        }

        [TestMethod]
        public void EqualTemperamentTest_KeyboardKeys()
        {
            EqualTemperament target = new EqualTemperament();
            AssertKeyboardKey(target, Pitches.C, 8, 88);
            AssertKeyboardKey(target, Pitches.B, 7, 87);
            AssertKeyboardKey(target, Pitches.ASharp, 7, 86);
            AssertKeyboardKey(target, Pitches.BFlat, 7, 86);
            AssertKeyboardKey(target, Pitches.A, 7, 85);
            AssertKeyboardKey(target, Pitches.GSharp, 7, 84);
            AssertKeyboardKey(target, Pitches.AFlat, 7, 84);
            AssertKeyboardKey(target, Pitches.G, 7, 83);
            AssertKeyboardKey(target, Pitches.FSharp, 7, 82);
            AssertKeyboardKey(target, Pitches.GFlat, 7, 82);
            AssertKeyboardKey(target, Pitches.F, 7, 81);
            AssertKeyboardKey(target, Pitches.E, 7, 80);
            AssertKeyboardKey(target, Pitches.DSharp, 7, 79);
            AssertKeyboardKey(target, Pitches.EFlat, 7, 79);
            AssertKeyboardKey(target, Pitches.D, 7, 78);
            AssertKeyboardKey(target, Pitches.CSharp, 7, 77);
            AssertKeyboardKey(target, Pitches.DFlat, 7, 77);
            AssertKeyboardKey(target, Pitches.C, 7, 76);
            AssertKeyboardKey(target, Pitches.B, 6, 75);
            AssertKeyboardKey(target, Pitches.ASharp, 6, 74);
            AssertKeyboardKey(target, Pitches.BFlat, 6, 74);
            AssertKeyboardKey(target, Pitches.A, 6, 73);
            AssertKeyboardKey(target, Pitches.GSharp, 6, 72);
            AssertKeyboardKey(target, Pitches.AFlat, 6, 72);
            AssertKeyboardKey(target, Pitches.G, 6, 71);
            AssertKeyboardKey(target, Pitches.FSharp, 6, 70);
            AssertKeyboardKey(target, Pitches.GFlat, 6, 70);
            AssertKeyboardKey(target, Pitches.F, 6, 69);
            AssertKeyboardKey(target, Pitches.E, 6, 68);
            AssertKeyboardKey(target, Pitches.DSharp, 6, 67);
            AssertKeyboardKey(target, Pitches.EFlat, 6, 67);
            AssertKeyboardKey(target, Pitches.D, 6, 66);
            AssertKeyboardKey(target, Pitches.CSharp, 6, 65);
            AssertKeyboardKey(target, Pitches.DFlat, 6, 65);
            AssertKeyboardKey(target, Pitches.C, 6, 64);
            AssertKeyboardKey(target, Pitches.B, 5, 63);
            AssertKeyboardKey(target, Pitches.ASharp, 5, 62);
            AssertKeyboardKey(target, Pitches.BFlat, 5, 62);
            AssertKeyboardKey(target, Pitches.A, 5, 61);
            AssertKeyboardKey(target, Pitches.GSharp, 5, 60);
            AssertKeyboardKey(target, Pitches.AFlat, 5, 60);
            AssertKeyboardKey(target, Pitches.G, 5, 59);
            AssertKeyboardKey(target, Pitches.FSharp, 5, 58);
            AssertKeyboardKey(target, Pitches.GFlat, 5, 58);
            AssertKeyboardKey(target, Pitches.F, 5, 57);
            AssertKeyboardKey(target, Pitches.E, 5, 56);
            AssertKeyboardKey(target, Pitches.DSharp, 5, 55);
            AssertKeyboardKey(target, Pitches.EFlat, 5, 55);
            AssertKeyboardKey(target, Pitches.D, 5, 54);
            AssertKeyboardKey(target, Pitches.CSharp, 5, 53);
            AssertKeyboardKey(target, Pitches.DFlat, 5, 53);
            AssertKeyboardKey(target, Pitches.C, 5, 52);
            AssertKeyboardKey(target, Pitches.B, 4, 51);
            AssertKeyboardKey(target, Pitches.ASharp, 4, 50);
            AssertKeyboardKey(target, Pitches.BFlat, 4, 50);
            AssertKeyboardKey(target, Pitches.A, 4, 49);
            AssertKeyboardKey(target, Pitches.GSharp, 4, 48);
            AssertKeyboardKey(target, Pitches.AFlat, 4, 48);
            AssertKeyboardKey(target, Pitches.G, 4, 47);
            AssertKeyboardKey(target, Pitches.FSharp, 4, 46);
            AssertKeyboardKey(target, Pitches.GFlat, 4, 46);
            AssertKeyboardKey(target, Pitches.F, 4, 45);
            AssertKeyboardKey(target, Pitches.E, 4, 44);
            AssertKeyboardKey(target, Pitches.DSharp, 4, 43);
            AssertKeyboardKey(target, Pitches.EFlat, 4, 43);
            AssertKeyboardKey(target, Pitches.D, 4, 42);
            AssertKeyboardKey(target, Pitches.CSharp, 4, 41);
            AssertKeyboardKey(target, Pitches.DFlat, 4, 41);
            AssertKeyboardKey(target, Pitches.C, 4, 40);
            AssertKeyboardKey(target, Pitches.B, 3, 39);
            AssertKeyboardKey(target, Pitches.ASharp, 3, 38);
            AssertKeyboardKey(target, Pitches.BFlat, 3, 38);
            AssertKeyboardKey(target, Pitches.A, 3, 37);
            AssertKeyboardKey(target, Pitches.GSharp, 3, 36);
            AssertKeyboardKey(target, Pitches.AFlat, 3, 36);
            AssertKeyboardKey(target, Pitches.G, 3, 35);
            AssertKeyboardKey(target, Pitches.FSharp, 3, 34);
            AssertKeyboardKey(target, Pitches.GFlat, 3, 34);
            AssertKeyboardKey(target, Pitches.F, 3, 33);
            AssertKeyboardKey(target, Pitches.E, 3, 32);
            AssertKeyboardKey(target, Pitches.DSharp, 3, 31);
            AssertKeyboardKey(target, Pitches.EFlat, 3, 31);
            AssertKeyboardKey(target, Pitches.D, 3, 30);
            AssertKeyboardKey(target, Pitches.CSharp, 3, 29);
            AssertKeyboardKey(target, Pitches.DFlat, 3, 29);
            AssertKeyboardKey(target, Pitches.C, 3, 28);
            AssertKeyboardKey(target, Pitches.B, 2, 27);
            AssertKeyboardKey(target, Pitches.ASharp, 2, 26);
            AssertKeyboardKey(target, Pitches.BFlat, 2, 26);
            AssertKeyboardKey(target, Pitches.A, 2, 25);
            AssertKeyboardKey(target, Pitches.GSharp, 2, 24);
            AssertKeyboardKey(target, Pitches.AFlat, 2, 24);
            AssertKeyboardKey(target, Pitches.G, 2, 23);
            AssertKeyboardKey(target, Pitches.FSharp, 2, 22);
            AssertKeyboardKey(target, Pitches.GFlat, 2, 22);
            AssertKeyboardKey(target, Pitches.F, 2, 21);
            AssertKeyboardKey(target, Pitches.E, 2, 20);
            AssertKeyboardKey(target, Pitches.DSharp, 2, 19);
            AssertKeyboardKey(target, Pitches.EFlat, 2, 19);
            AssertKeyboardKey(target, Pitches.D, 2, 18);
            AssertKeyboardKey(target, Pitches.CSharp, 2, 17);
            AssertKeyboardKey(target, Pitches.DFlat, 2, 17);
            AssertKeyboardKey(target, Pitches.C, 2, 16);
            AssertKeyboardKey(target, Pitches.B, 1, 15);
            AssertKeyboardKey(target, Pitches.ASharp, 1, 14);
            AssertKeyboardKey(target, Pitches.BFlat, 1, 14);
            AssertKeyboardKey(target, Pitches.A, 1, 13);
            AssertKeyboardKey(target, Pitches.GSharp, 1, 12);
            AssertKeyboardKey(target, Pitches.AFlat, 1, 12);
            AssertKeyboardKey(target, Pitches.G, 1, 11);
            AssertKeyboardKey(target, Pitches.FSharp, 1, 10);
            AssertKeyboardKey(target, Pitches.GFlat, 1, 10);
            AssertKeyboardKey(target, Pitches.F, 1, 9);
            AssertKeyboardKey(target, Pitches.E, 1, 8);
            AssertKeyboardKey(target, Pitches.DSharp, 1, 7);
            AssertKeyboardKey(target, Pitches.EFlat, 1, 7);
            AssertKeyboardKey(target, Pitches.D, 1, 6);
            AssertKeyboardKey(target, Pitches.CSharp, 1, 5);
            AssertKeyboardKey(target, Pitches.DFlat, 1, 5);
            AssertKeyboardKey(target, Pitches.C, 1, 4);
            AssertKeyboardKey(target, Pitches.B, 0, 3);
            AssertKeyboardKey(target, Pitches.ASharp, 0, 2);
            AssertKeyboardKey(target, Pitches.BFlat, 0, 2);
            AssertKeyboardKey(target, Pitches.A, 0, 1);

        }

        private void AssertKeyboardKey(EqualTemperament target, Pitch pitch, int octave, int expectedKey)
        {
            int keyboardKey = target.GetKeyboardKeyFromPitchOctave(pitch, octave);
            Assert.AreEqual(expectedKey, keyboardKey, $"Unexpected Keyboard Key [{keyboardKey}] from Key [{pitch}{octave}]");
        }

        [TestMethod]
        public void PythagoreanTests()
        {
            PythagoreanTemperament target = new PythagoreanTemperament();

            Assert.AreEqual(220d, target.GetFrequency(Pitches.A, 3));
            Assert.AreEqual(440d, target.GetFrequency(Pitches.A, 4));
            Assert.AreEqual(880d, target.GetFrequency(Pitches.A, 5));
            Assert.AreEqual(3520d, target.GetFrequency(Pitches.A, 7));
            Assert.AreEqual(55d, target.GetFrequency(Pitches.A, 1));

            Assert.AreEqual(660d, target.GetFrequency(Pitches.E, 4)); // A4 to E4 is a Fifth
        }

        [TestMethod]
        public void MeantoneTemperamentTests()
        {
            MeanToneTemperament target = new MeanToneTemperament();

            Assert.AreEqual(294.04d, target.GetFrequency(Pitches.D, 4));
            Assert.AreEqual(328.75d, target.GetFrequency(Pitches.E, 4));
            Assert.AreEqual(352.18d, target.GetFrequency(Pitches.F, 4));
        }
    }
}
