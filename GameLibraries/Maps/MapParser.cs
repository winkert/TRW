using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.GameLibraries.Maps
{
    public static class MapParser
    {
        public enum MapCellContent
        {
            Null = -1,
            Wall = 0,
            Room = 100,
            Hall = 200
        }

        public enum ColorMapStyle
        {
            None = -1,
            Exact = 0,
            Between = 1
        }

        /// <summary>
        /// Value to multiply random decimal between 0 and 1
        /// </summary>
        public const int CellContentMultiplier = 250;

        public readonly static Dictionary<char, MapCellContent> CharacterMap = new Dictionary<char, MapCellContent>()
        {
            {'n', MapCellContent.Null },
            {'N', MapCellContent.Null },
            {(char)10, MapCellContent.Null },
            {(char)13, MapCellContent.Null },
            {(char)0, MapCellContent.Null },
            {(char)9, MapCellContent.Null },
            {(char)255, MapCellContent.Null },
            {'w', MapCellContent.Wall },
            {'W', MapCellContent.Wall },
            {'|', MapCellContent.Wall },
            {'r', MapCellContent.Room },
            {'R', MapCellContent.Room },
            {' ', MapCellContent.Room },
            {'h', MapCellContent.Hall },
            {'H', MapCellContent.Hall }
        };
        public static MapCellContent GetCellContent(decimal value)
        {
            return GetCellContent((int)value);
        }
        public static MapCellContent GetCellContent(int value)
        {
            MapCellContent retVal = MapCellContent.Wall;

            if (value >= CellContentMultiplier)
                retVal = MapCellContent.Hall;
            else if (value >= (int)MapCellContent.Hall)
                retVal = MapCellContent.Hall;
            else if (value >= (int)MapCellContent.Room)
                retVal = MapCellContent.Room;
            else
                retVal = MapCellContent.Wall;

            return retVal;
        }

    }
}
