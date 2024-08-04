using System;
using System.Collections.Generic;
using System.Text;

namespace TRW.CommonLibraries.Audio
{
    public static class TemperamentFactory
    {
        private static EqualTemperament _equalTemperamentStatic;
        private static PythagoreanTemperament _pythagoreanTemperamentStatic;
        private static MeanToneTemperament _meanToneTemperamentStatic;
        private static WerckmeisterTemperament _werckmeisterTemperamentStatic;

        public static ITemperament GetTemperament(TemperamentStyles temperament)
        {
            switch (temperament)
            {
                case TemperamentStyles.EqualTemperament:
                    if (_equalTemperamentStatic == null)
                        _equalTemperamentStatic = new EqualTemperament();
                    return _equalTemperamentStatic;
                case TemperamentStyles.PythagoreanTuning:
                    if(_pythagoreanTemperamentStatic == null)
                        _pythagoreanTemperamentStatic = new PythagoreanTemperament();
                    return _pythagoreanTemperamentStatic;
                case TemperamentStyles.MeanToneTemperament:
                    if (_meanToneTemperamentStatic == null)
                        _meanToneTemperamentStatic = new MeanToneTemperament();
                    return _meanToneTemperamentStatic;
                case TemperamentStyles.WerckmeisterTemperament:
                    if(_werckmeisterTemperamentStatic == null)
                        _werckmeisterTemperamentStatic = new WerckmeisterTemperament();
                    return _werckmeisterTemperamentStatic;
                default:
                    throw new ArgumentException($"Unknown TemperamentStyles [{temperament}]", "temperament");
            }

        }
    }
}
