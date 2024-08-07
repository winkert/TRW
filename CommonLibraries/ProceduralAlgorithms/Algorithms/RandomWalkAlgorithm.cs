using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public class RandomWalkAlgorithm<M, C> : ProceduralAlgorithmBase<M, C> where C : ICell where M : IMatrix<C>
    {
        public RandomWalkAlgorithm(object sender, M grid, int xDim, int yDim) : base(sender, grid, xDim, yDim)
        {

        }

        private static ProceduralAlgorithmParameterCollection _parameters;
        public override ProceduralAlgorithmParameterCollection Parameters
        {
            get
            {
                if (_parameters == null)
                {
                    _parameters = new ProceduralAlgorithmParameterCollection(4)
                    {
                        new ProceduralAlgorithmParameter<Position>(),
                        new ProceduralAlgorithmParameter<int>(),
                        new ProceduralAlgorithmParameter<bool>(),
                        new ProceduralAlgorithmParameter<bool>()
                    };
                }
                return _parameters;
            }
        }

        public Position[] RandomWalkToTarget(Position startPosition, Position endPosition, int maxIterations)
        {
            HashSet<Position> points = new HashSet<Position>();
            points.Add(startPosition);
            ICell cell = _grid[startPosition.X, startPosition.Y];
            
            Position newPlace = MakeTurn(cell, true, 1, true);
            
            while (--maxIterations > 0)
            {
                points.Add(newPlace);

                cell = _grid[newPlace.X, newPlace.Y];
                
                if (newPlace.Equals(endPosition))
                    break;

                MakeTurn(cell, true, 1, true);
            }

            if(!newPlace.Equals(endPosition))
            {
                // just draw a line to the end from here
                foreach (var p in Position.GetLine(newPlace, endPosition))
                    points.Add(p);
            }

            points.Add(endPosition);
            return points.ToArray();
        }

        protected override void DoAlgorithmInternal(params object[] args)
        {
            Position startPosition = Parameters.GetParameterValue<Position>(args, 0);
            int iterations = Parameters.GetParameterValue<int>(args, 1);
            bool avoidEdges = Parameters.GetParameterValue<bool>(args, 2);
            bool avoidClusters = Parameters.GetParameterValue<bool>(args, 3);

            // go to the selected position and set the cell to "On"
            ICell cell = _grid[startPosition.X, startPosition.Y];
            cell.Content = true;

            Position newPlace = MakeTurn(cell, avoidEdges, 1, avoidClusters);

            if (--iterations > 0)
            {
                cell = _grid[newPlace.X, newPlace.Y];
                DoAlgorithmInternal(cell.Position, iterations, avoidEdges, avoidClusters);
                InvokeCallback(0);
            }
        }

        private bool IncludeNeighbor(ICell neighbor, bool avoidEdges, bool avoidClustering)
        {
            bool include = true;
            if (neighbor == null)
            {
                include = false;
            }
            else if (avoidEdges && (neighbor.OnNorthEdge || neighbor.OnEastEdge || neighbor.OnSouthEdge || neighbor.OnWestEdge))
            {
                include = false;
            }
            else if (avoidClustering)
            {
                // check neighbohood for a cluster; A cluster is 2 or more "live" neighbors
                if (neighbor.GetNeighborsWithValue() > 2)
                {
                    include = false;
                }
            }

            return include;
        }

        private Position MakeTurn(ICell cell, bool avoidEdges, int attempt = 1, bool avoidClustering = false)
        {
            // override to avoid stack overflow
            if (attempt > 20)
            {
                return GetValidNeighboringPosition(cell, avoidEdges, avoidClustering);
            }

            double angle = R.NextDouble() * (2d * Math.PI);

            ICell targetNeighbor;
            targetNeighbor = GetNeighborFromAngle(cell, angle);

            if (targetNeighbor != null && IncludeNeighbor(targetNeighbor, avoidEdges, avoidClustering))
                return targetNeighbor.Position;
            else // recursive
                return MakeTurn(cell, avoidEdges, attempt + 1);
        }
        
        private Position GetValidNeighboringPosition(ICell cell, bool avoidEdges, bool avoidClustering)
        {
            if (R.Next() % 2 == 0)
            {
                if (IncludeNeighbor(cell.NorthNeighbor, avoidEdges, avoidClustering))
                    return cell.NorthNeighbor.Position;
                if (IncludeNeighbor(cell.NorthEastNeighbor, avoidEdges, avoidClustering))
                    return cell.NorthEastNeighbor.Position;
                if (IncludeNeighbor(cell.EastNeighbor, avoidEdges, avoidClustering))
                    return cell.EastNeighbor.Position;
                if (IncludeNeighbor(cell.SouthEastNeighbor, avoidEdges, avoidClustering))
                    return cell.SouthEastNeighbor.Position;
                if (IncludeNeighbor(cell.SouthNeighbor, avoidEdges, avoidClustering))
                    return cell.SouthNeighbor.Position;
                if (IncludeNeighbor(cell.SouthWestNeighbor, avoidEdges, avoidClustering))
                    return cell.SouthWestNeighbor.Position;
                if (IncludeNeighbor(cell.WestNeighbor, avoidEdges, avoidClustering))
                    return cell.WestNeighbor.Position;
                if (IncludeNeighbor(cell.NorthWestNeighbor, avoidEdges, avoidClustering))
                    return cell.NorthWestNeighbor.Position;
            }
            else
            {
                if (IncludeNeighbor(cell.NorthWestNeighbor, avoidEdges, avoidClustering))
                    return cell.NorthWestNeighbor.Position;
                if (IncludeNeighbor(cell.WestNeighbor, avoidEdges, avoidClustering))
                    return cell.WestNeighbor.Position;
                if (IncludeNeighbor(cell.SouthWestNeighbor, avoidEdges, avoidClustering))
                    return cell.SouthWestNeighbor.Position;
                if (IncludeNeighbor(cell.SouthNeighbor, avoidEdges, avoidClustering))
                    return cell.SouthNeighbor.Position;
                if (IncludeNeighbor(cell.SouthEastNeighbor, avoidEdges, avoidClustering))
                    return cell.SouthEastNeighbor.Position;
                if (IncludeNeighbor(cell.EastNeighbor, avoidEdges, avoidClustering))
                    return cell.EastNeighbor.Position;
                if (IncludeNeighbor(cell.NorthEastNeighbor, avoidEdges, avoidClustering))
                    return cell.NorthEastNeighbor.Position;
                if (IncludeNeighbor(cell.NorthNeighbor, avoidEdges, avoidClustering))
                    return cell.NorthNeighbor.Position;
            }

            throw new ArgumentException();
        }
    }
}
