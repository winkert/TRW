using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio.Wave
{
    public static class WaveGlobals
    {
        public const double TAU = 2 * Math.PI;
        public const double BaseAmplitude = 16383;

        public const long HeaderStartPosition = 0;
        public const long HeaderTotalBytes = 12;
        public const long FormatStartPosition = 12;
        public const long FormatTotalBytes = 24;
        public const long DataStartPosition = 36;
        public const long DataSizePosition = 40;

        public const long ChunkSizePosition = 4;
        public const long WaveIdPosition = 8;

    }
}
