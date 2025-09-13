using System;
using System.Collections.Generic;
using System.Linq;
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
                        new ProceduralAlgorithmParameter<Position>(StartPositionParamName),
                        new ProceduralAlgorithmParameter<int>(IterationsParamName),
                        new ProceduralAlgorithmParameter<bool>(AvoidEdgesParamName),
                        new ProceduralAlgorithmParameter<bool>(AvoidClustersParamName)
                    };
                }
                return _parameters;
            }
        }

        public Position[] RandomWalkToTarget(Position startPosition, Position endPosition, int maxIterations)
        {
            HashSet<Position> points = [startPosition];
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
            Position startPosition = Parameters.GetParameterValue<Position>(args, StartPositionParamName);
            int iterations = Parameters.GetParameterValue<int>(args, IterationsParamName);
            bool avoidEdges = Parameters.GetParameterValue<bool>(args, AvoidEdgesParamName);
            bool avoidClusters = Parameters.GetParameterValue<bool>(args, AvoidClustersParamName);

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
            if (attempt > 10)
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
            List<Position> positions = new List<Position>();

            if (IncludeNeighbor(cell.NorthNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.NorthNeighbor.Position);
            if (IncludeNeighbor(cell.NorthEastNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.NorthEastNeighbor.Position);
            if (IncludeNeighbor(cell.EastNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.EastNeighbor.Position);
            if (IncludeNeighbor(cell.SouthEastNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.SouthEastNeighbor.Position);
            if (IncludeNeighbor(cell.SouthNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.SouthNeighbor.Position);
            if (IncludeNeighbor(cell.SouthWestNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.SouthWestNeighbor.Position);
            if (IncludeNeighbor(cell.WestNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.WestNeighbor.Position);
            if (IncludeNeighbor(cell.NorthWestNeighbor, avoidEdges, avoidClustering))
                positions.Add(cell.NorthWestNeighbor.Position);

            if (positions.Count > 0)
                return positions[R.Next(positions.Count)];

            throw new ArgumentException();
        }
    }
}
