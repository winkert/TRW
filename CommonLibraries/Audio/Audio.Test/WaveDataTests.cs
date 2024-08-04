using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TRW.CommonLibraries.Audio.Test
{
    [TestClass]
    public class WaveDataTests
    {
        [TestMethod]
        public void WaveReaderTest()
        {
            string testAudioFile = GetTestAudioFile();
            using (Streaming.WaveReader reader = new Streaming.WaveReader(testAudioFile))
            {
                var header = reader.ReadHeaderChunk();
                Assert.AreEqual("RIFF", header.ChunkId);
                Assert.AreEqual("WAVE", header.ChunkFormat);

                var subheader = reader.ReadFormatChunk();
                Assert.AreEqual("fmt ", subheader.SubChunkId);
                Assert.AreEqual(1, subheader.Channels);
                Assert.AreEqual(16000, subheader.SampleRate);
                Assert.AreEqual(16, subheader.BitsPerSample);
                Assert.AreEqual(32000, subheader.ByteRate);
                Assert.AreEqual(2, subheader.BlockAlign);

                //ByteRate == SampleRate * NumChannels * BitsPerSample/8
                //BlockAlign == NumChannels * BitsPerSample / 8
                Assert.AreEqual(32000, subheader.SampleRate * subheader.Channels * subheader.BitsPerSample / 8);
                Assert.AreEqual(2, subheader.Channels * subheader.BitsPerSample / 8);

                var data = reader.ReadDataChunk(header, subheader);
                Assert.AreEqual("data", data.DataChunkId);
                //Subchunk2Size = NumSamples * NumChannels * BitsPerSample/8
                //num of samples = SampleRate * Length
                Assert.AreEqual((subheader.SampleRate * 1.8) * subheader.Channels * subheader.BitsPerSample / 8, data.DataChunkSize);
                Assert.IsNotNull(data.GetData());
                Assert.AreEqual(data.DataChunkSize, data.GetData().Length);

                byte[] sample = null;
                for (int i = 1; i < data.DataChunkSize / subheader.Channels; i++)
                {
                    sample = data.GetSample(subheader.Channels, i);
                    Assert.IsNotNull(sample);
                }

                Assert.AreEqual(data.DataChunkSize, data.Samples.Count);
                Assert.AreEqual(subheader.Channels, data.Samples.NumberOfChannels);
            }
        }

        [TestMethod]
        public void WaveReaderGetDetailsTest()
        {
            string testAudioFile = GetTestAudioFile();
            Assert.IsTrue(System.IO.File.Exists(testAudioFile), testAudioFile);
            using (Streaming.WaveReader reader = new Streaming.WaveReader(testAudioFile))
            {
                var details = reader.GetDetails();
                Assert.AreEqual("WAVE", details.FileFormat);
                Assert.AreEqual(1, details.AudioFormat);
                Assert.AreEqual(57600, details.Samples.Count);
            }
        }

        [TestMethod]
        public void WaveWriterTest()
        {
            string tempPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Temp");
            if (!System.IO.Directory.Exists(tempPath))
                System.IO.Directory.CreateDirectory(tempPath);

            string savePathTemp = System.IO.Path.Combine(tempPath, "test.wav");
            using (Streaming.WaveWriter writer = new Streaming.WaveWriter(savePathTemp))
            {
                writer.WriteHeader();
                writer.WriteFormat(1, 16000, 16);
                writer.WriteSampleDataHeader(1, 1, 16);
                writer.WriteSample(16000, 440d, 1000);
                writer.FinalizeSampleData(1, 1, 16);
                writer.FinalizeWaveFile(1, 1, 16);
            }

            Assert.IsTrue(System.IO.File.Exists(savePathTemp));

            using (Streaming.WaveReader reader = new Streaming.WaveReader(savePathTemp))
            {
                var details = reader.GetDetails();
                Assert.AreEqual("WAVE", details.FileFormat);
                Assert.AreEqual(1, details.AudioFormat);
                Assert.AreEqual(16, details.Samples.Count);
            }

            // clean up
            System.IO.File.Delete(savePathTemp);
        }

        private string GetTestAudioFile()
        {
            string currentExecutingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            // there is a better way to do this (loop through and go back until you get to where we want)
            System.IO.DirectoryInfo executionPath = new System.IO.DirectoryInfo(currentExecutingAssemblyPath);
            string testAudioFile = System.IO.Path.Combine(executionPath.Parent.Parent.Parent.FullName, "TestFiles", "Diceroll.wav");
            Assert.IsTrue(System.IO.File.Exists(testAudioFile), testAudioFile);
            return testAudioFile;
        }
    }
}
