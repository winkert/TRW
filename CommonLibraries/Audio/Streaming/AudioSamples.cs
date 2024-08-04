using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio.Streaming
{
    public class AudioSamples : IEnumerable<AudioSample>
    {
        private List<AudioSample> _items;

        public AudioSamples(short channels)
        {
            _items = new List<AudioSample>();
            NumberOfChannels = channels;
        }

        public short NumberOfChannels { get; }
        public int Count => _items.Count;

        public void Add(params byte[] sample)
        {
            _items.Add(new AudioSample(NumberOfChannels, sample));
        }

        public IEnumerator<AudioSample> GetEnumerator()
        {
            return ((IEnumerable<AudioSample>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_items).GetEnumerator();
        }
    }
}
