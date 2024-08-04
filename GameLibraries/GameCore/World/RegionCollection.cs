using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TRW.GameLibraries.GameCore
{
    [Serializable]
    public class RegionCollection<R> : IEnumerable<R>, ISerializable 
        where R: IRegion
    {
        [NonSerialized]
        private List<R> _regions;

        public RegionCollection()
        {
            _regions = new List<R>();
        }

        protected RegionCollection(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            _regions = new List<R>();
            int total = serializationInfo.GetInt32("RegionCount");
            for (int i = 0; i < total; i++)
            {
                _regions.Add((R)serializationInfo.GetValue($"Region{i}", typeof(R)));
            }
        }

        public int Count => _regions.Count;

        public IEnumerator<R> GetEnumerator()
        {
            return ((IEnumerable<R>)_regions).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<R>)_regions).GetEnumerator();
        }

        public void Clear()
        {
            _regions.Clear();
        }

        public void Add(R region)
        {
            _regions.Add(region);
        }

        public void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            serializationInfo.AddValue("RegionCount", _regions.Count);
            int counter = 0;
            foreach (IRegion region in this)
                serializationInfo.AddValue($"Region{counter}", region);
        }

    }
}
