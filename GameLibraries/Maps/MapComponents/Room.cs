using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.GameLibraries.Maps
{
    public class Room : MapComponentBase
    {
        private Position[] _points;
        public Room(Map map, Position center, int sizeX, int sizeY)
            : this(map, center, sizeX, sizeY, RoomShapes.Rectangle)
        {

        }
        public Room(Map map, Position center, int sizeX, int sizeY, RoomShapes shape)
        {
            Center = center;
            HashSet<Position> points;
            SizeX = sizeX;
            SizeY = sizeY;

            int resolution = (int)(Math.Ceiling((sizeX + sizeY) / 2d));

            switch (shape)
            {
                case RoomShapes.Rectangle:
                    points = new HashSet<Position>(Map.GetCornersFromSize(Center, sizeX, sizeY));
                    break;
                case RoomShapes.Oval:
                    points = new HashSet<Position>(Map.GetOvalFromSize(Center, resolution, sizeX, sizeY));
                    break;
                case RoomShapes.Uneven:
                    points = new HashSet<Position>(Map.GetUnevenShapeFromSize(Center, resolution, sizeX, sizeY));
                    break;
                default:
                    throw new ArgumentException($"Unexpected RoomeShapes value {shape}", nameof(shape));
            }

            foreach (Position p in points)
            {
                if (!map.IsOnMap(p, out Position newPos))
                {
                    p.UpdatePosition(newPos.X, newPos.Y);
                }
            }

            _points = points.ToArray();
        }
        public Room(Position center, Position[] points)
        {
            Center = center;
            _points = points;
        }

        public Position Center { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public override Position[] Points => _points;
        protected override int SortOrder => 100;

        public override void Draw(Map map)
        {
            map.AddShape(Points, (int)ColorMap.DungeonColorMap.Wall, (int)ColorMap.DungeonColorMap.Floor, true);
        }

    }
}
