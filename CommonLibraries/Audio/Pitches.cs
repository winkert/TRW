using System.Collections.Generic;

namespace TRW.CommonLibraries.Audio
{
    public static class Pitches
    {
        public static Pitch C = new Pitch("C", 0);
        public static Pitch CSharp = new Pitch("CSharp", 1);
        public static Pitch DFlat = new Pitch("DFlat", 1);
        public static Pitch D = new Pitch("D", 2);
        public static Pitch DSharp = new Pitch("DSharp", 3);
        public static Pitch EFlat = new Pitch("EFlat", 3);
        public static Pitch E = new Pitch("E", 4);
        public static Pitch ESharp = new Pitch("ESharp", 5);
        public static Pitch FFlat = new Pitch("FFlat", 5);
        public static Pitch F = new Pitch("F", 5);
        public static Pitch FSharp = new Pitch("FSharp", 6);
        public static Pitch GFlat = new Pitch("GFlat", 6);
        public static Pitch G = new Pitch("G", 7);
        public static Pitch GSharp = new Pitch("GSharp", 8);
        public static Pitch AFlat = new Pitch("AFlat", 8);
        public static Pitch A = new Pitch("A", 9);
        public static Pitch ASharp = new Pitch("ASharp", 10);
        public static Pitch BFlat = new Pitch("BFlat", 10);
        public static Pitch B = new Pitch("B", 11);
        public static Pitch BSharp = new Pitch("BSharp", 0);
        public static Pitch CFlat = new Pitch("CFlat", 0);

        private static Dictionary<int, Pitch> _pitchSteps;
        public static Dictionary<int, Pitch> PitchSteps
        {
            get
            {
                if (_pitchSteps == null)
                {
                    _pitchSteps = new Dictionary<int, Pitch>()
                    {
                        {0, C },
                        {1, CSharp },
                        {2, D },
                        {3, DSharp },
                        {4, E },
                        {5, F },
                        {6, FSharp },
                        {7, G },
                        {8, GSharp },
                        {9, A },
                        {10, ASharp },
                        {11, B },
                        {12, C }
                    };
                }
                return _pitchSteps;
            }
        }

        public static string GetPitchName(int halfStep)
        {
            int smallestHalfStep = halfStep % 12;

            if (PitchSteps.ContainsKey(smallestHalfStep))
                return PitchSteps[smallestHalfStep].Name;

            return string.Empty;
        }
    }
}