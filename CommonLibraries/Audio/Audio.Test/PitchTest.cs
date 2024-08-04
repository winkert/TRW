using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TRW.CommonLibraries.Audio.Test
{
    [TestClass]
    public class PitchTest
    {
        [TestMethod]
        public void PitchEngineGetOctaveTest()
        {
            Assert.AreEqual(0.125d, PitchEngine.GetOctaveMultiplier(4, 1));
            Assert.AreEqual(0.25d, PitchEngine.GetOctaveMultiplier(4, 2));
            Assert.AreEqual(0.5d, PitchEngine.GetOctaveMultiplier(4, 3));
            Assert.AreEqual(1d, PitchEngine.GetOctaveMultiplier(4, 4));
            Assert.AreEqual(2d, PitchEngine.GetOctaveMultiplier(4, 5));
            Assert.AreEqual(4d, PitchEngine.GetOctaveMultiplier(4, 6));
            Assert.AreEqual(8d, PitchEngine.GetOctaveMultiplier(4, 7));
            Assert.AreEqual(16d, PitchEngine.GetOctaveMultiplier(4, 8));
        }

        [TestMethod]
        public void PitchEngineGetIntervalTest()
        {
            Assert.AreEqual(Intervals.Fifth, PitchEngine.GetInterval(Pitches.A, Pitches.E));
            Assert.AreEqual(Intervals.Fourth, PitchEngine.GetInterval(Pitches.E, Pitches.A));
            Assert.AreEqual(Intervals.AugmentedFourth, PitchEngine.GetInterval(Pitches.C, Pitches.FSharp)); // Tritone is a Perfect Interval
            Assert.AreEqual(Intervals.AugmentedFourth, PitchEngine.GetInterval(Pitches.GFlat, Pitches.C));  // Tritone is a Perfect Interval
            Assert.AreEqual(Intervals.MajorSeventh, PitchEngine.GetInterval(Pitches.D, Pitches.CSharp));
        }

        [TestMethod]
        public void PitchOperatorsTest()
        {
            Pitch left = Pitches.A;
            Pitch right = Pitches.A;

            Assert.IsTrue(left == right);
            Assert.IsFalse(left != right);

            Assert.AreEqual(Pitches.C, left + 3);
            Assert.AreEqual(Pitches.G, left - 2);

            Assert.AreEqual(0, left - right);
            right = Pitches.DSharp;
            Assert.AreEqual(6, left - right);
            Assert.AreEqual(12, left + right);

            Assert.AreEqual(right, left - Intervals.AugmentedFourth);
            Assert.AreEqual(right, left + Intervals.AugmentedFourth);

            Assert.AreEqual(Pitches.C, Pitches.C + Intervals.Octave);
        }
    }
}
