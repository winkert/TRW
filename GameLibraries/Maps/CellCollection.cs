using System;
using System.Text;
using TRW.CommonLibraries.Core;
using TRW.CommonLibraries.ProceduralAlgorithms;

namespace TRW.GameLibraries.Maps
{
    public class CellCollection : RectangularCollection<Cell>
    {
        #region Fields
        private readonly int _cellSize;
        #endregion

        #region Constructors
        public CellCollection(int x, int y) : base(x, y)
        {
            _cellSize = 4;
            InitializeCollection();
        }

        public CellCollection(int x, int y, int cellSize) : base(x, y)
        {
            _cellSize = cellSize;
            InitializeCollection();
        }

        #endregion

        #region Properties
        protected override bool ThrowIndexExceptions => false;
        public Cell NorthNeighbor
        {
            get
            {
                return _enumerator[Position.X, Position.Y - 1];
            }
        }
        public Cell NorthEastNeighbor
        {
            get
            {
                return _enumerator[Position.X + 1, Position.Y - 1];
            }
        }
        public Cell EastNeighbor
        {
            get
            {
                return _enumerator[Position.X + 1, Position.Y];
            }
        }
        public Cell SouthEastNeighbor
        {
            get
            {
                return _enumerator[Position.X + 1, Position.Y + 1];
            }
        }
        public Cell SouthNeighbor
        {
            get
            {
                return _enumerator[Position.X, Position.Y + 1];
            }
        }
        public Cell SouthWestNeighbor
        {
            get
            {
                return _enumerator[Position.X - 1, Position.Y + 1];
            }
        }
        public Cell WestNeighbor
        {
            get
            {
                return _enumerator[Position.X - 1, Position.Y];
            }
        }
        public Cell NorthWestNeighbor
        {
            get
            {
                return _enumerator[Position.X - 1, Position.Y - 1];
            }
        }

        #endregion

        #region Publics
        public void GoTo(Cell cell)
        {
            base.GoTo(cell._position.X, cell._position.Y);
        }

        public int GetNumberOfLiveNeighbors()
        {
            int activeNeighbors = 0;
            if (NorthNeighbor != null && NorthNeighbor.BitState)
                activeNeighbors++;
            if (NorthEastNeighbor != null && NorthEastNeighbor.BitState)
                activeNeighbors++;
            if (EastNeighbor != null && EastNeighbor.BitState)
                activeNeighbors++;
            if (SouthEastNeighbor != null && SouthEastNeighbor.BitState)
                activeNeighbors++;
            if (SouthNeighbor != null && SouthNeighbor.BitState)
                activeNeighbors++;
            if (SouthWestNeighbor != null && SouthWestNeighbor.BitState)
                activeNeighbors++;
            if (WestNeighbor != null && WestNeighbor.BitState)
                activeNeighbors++;
            if (NorthWestNeighbor != null && NorthWestNeighbor.BitState)
                activeNeighbors++;

            return activeNeighbors;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (this[x, y].Content is bool)
                        builder.Append(this[x, y].BitState ? 1 : 0);
                    else if (this[x, y].Content != null)
                        builder.Append(this[x, y].Content);
                    else
                        builder.Append(" "); // empty cell
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
        #endregion

        #region Privates
        private void InitializeCollection()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    this[x, y] = new Cell(this, _cellSize, x, y);

            First();
        }
        #endregion
    }
}
