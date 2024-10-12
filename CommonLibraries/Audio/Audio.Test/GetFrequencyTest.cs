using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Audio.Test
{
    [TestClass]
    public class GetFrequencyTest
    {
        [TestMethod]
        public void TestGetFrequency()
        {
            Pitch target = Pitches.A;
            int octave = 4;
            // A4 = 440

            double frequencyFromTemperament = PitchEngine.GetFrequency(target, octave);

            Assert.AreEqual(440d, frequencyFromTemperament);
            Assert.AreEqual(frequencyFromTemperament, PitchEngine.GetFrequency(target, TemperamentStyles.EqualTemperament, octave));
        }
    }
}
