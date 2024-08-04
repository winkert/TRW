using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.GameLibraries.Maps
{
    public class Hall : MapComponentBase
    {
        private Position[] _points;
        public Hall(Map map, Position start, Position end, HallCreationModes createMode)
        {
            StartPoint = start;
            EndPoint = end;

            if (start.X == end.X || start.Y == end.Y)
            {
                // straight line
                _points = Position.GetLine(start, end);
            }
            else
            {
                HashSet<Position> points = new HashSet<Position>();

                switch (createMode)
                {
                    case HallCreationModes.StraightLine:
                        foreach (Position point in Position.GetLine(start, end))
                        {
                            points.Add(point);
                        }
                        break;
                    case HallCreationModes.SingleTurn:
                        Position turn = Position.Create(start.X, end.Y);
                        foreach(Position point in Position.GetLine(start, turn))
                        {
                            points.Add(point);
                        }
                        foreach(Position point in Position.GetLine(turn, end))
                        {
                            points.Add(point);
                        }
                        break;
                    case HallCreationModes.SBend:
                        int dX = start.X > end.X ? start.X - end.X : end.X - start.X;
                        Position mid1 = Position.Create(dX, start.Y);
                        Position mid2 = Position.Create(dX, end.Y);
                        foreach (Position point in Position.GetLine(start, mid1))
                        {
                            points.Add(point);
                        }
                        foreach (Position point in Position.GetLine(mid1, mid2))
                        {
                            points.Add(point);
                        }
                        foreach (Position point in Position.GetLine(mid2, end))
                        {
                            points.Add(point);
                        }

                        break;
                    case HallCreationModes.RandomWalk:
                        TRW.CommonLibraries.ProceduralAlgorithms.RandomWalkAlgorithm<CellCollection, Cell> randomWalk = new CommonLibraries.ProceduralAlgorithms.RandomWalkAlgorithm<CellCollection, Cell>(this, map.Grid.Cells, map.Dimensions.Item1, map.Dimensions.Item2);
                        foreach (Position point in randomWalk.RandomWalkToTarget(start, end, map.Dimensions.Item1 / 2))
                        {
                            points.Add(point);
                        }

                        break;
                }

                List<Position> pointsOffMap = new List<Position>();
                foreach (Position p in points)
                {
                    if (!map.IsOnMap(p))
                        pointsOffMap.Add(p);
                }
                foreach (Position p in pointsOffMap)
                    points.Remove(p);


                _points = points.ToArray();
            }
        }

        public override Position[] Points => _points;
        protected override int SortOrder => 50;
        public Position StartPoint { get; }
        public Position EndPoint { get; }

        public override void Draw(Map map)
        {
            foreach (Position p in Points)
            {
                map.Grid.Cells[p.X, p.Y].Content = (int)ColorMap.DungeonColorMap.Hall;
            }
        }
    }
}
