using System;
using TRW.CommonLibraries.Core;

namespace TRW.CommonLibraries.ProceduralAlgorithms
{
    public interface ICell
    {
        object Content { get; set; }
        Position Position { get; }
        bool OnNorthEdge { get; }
        bool OnEastEdge { get; }
        bool OnSouthEdge { get; }
        bool OnWestEdge { get; }

        ICell NorthNeighbor { get; }
        ICell NorthEastNeighbor { get; }
        ICell EastNeighbor { get; }
        ICell SouthEastNeighbor { get; }
        ICell SouthNeighbor { get; }
        ICell SouthWestNeighbor { get; }
        ICell WestNeighbor { get; }
        ICell NorthWestNeighbor { get; }

        int GetNeighborsByValue(object value);
        int GetNeighborsWithValue();
        ICell GetNeighborByVector(Vector vector);
    }
}
