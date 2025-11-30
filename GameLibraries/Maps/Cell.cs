using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRW.CommonLibraries.Core;
using TRW.CommonLibraries.ProceduralAlgorithms;

namespace TRW.GameLibraries.Maps
{
    public class Cell:IEquatable<Cell>, ICell
    {
        #region Fields
        protected readonly int _sides;
        private bool _bitState;
        private object _content;
        private int _x;
        private int _y;
        internal protected Position _position;
        private CellCollection _myCollection;
        #endregion

        #region Constructors
        public Cell()
        {
            _sides = -1;
        }
        public Cell(CellCollection collection, int sides, int x, int y)
            :this(collection, sides, x, y, null)
        {
            
        }
        public Cell(CellCollection collection, int sides, int x, int y, object content)
        {
            _myCollection = collection;
            _sides = sides;
            Content = content;
            _x = x;
            _y = y;
            _position = new Position(x, y);
        }
        #endregion

        #region Properties
        public object Content
        {
            get
            {
                return _content;
            }
            set
            {
                //if(this.Position != null)
                //    Debug.WriteLine($"[{this.Position.X}, {this.Position.Y}]={value}");
                if (value is bool)
                    _bitState = Convert.ToBoolean(value);
                _content = value;
            }
        }
        public decimal Value { get { return Convert.ToDecimal(Content); } set { Content = value; } }

        /// <summary>
        /// Returns true if the Content is non-null and either a bool with value true or any other non-null object.
        /// </summary>
        public bool BitState
        {
            get
            {
                if (Content != null && (Content is bool))
                    return Convert.ToBoolean(Content);
                else if (Content != null)
                    return true;
                else
                    return _bitState;
            }
            set
            {
                _bitState = value;
            }
        }
        public string Name { get; set; }
        public bool OnNorthEdge { get { return _y == 0; } }
        public bool OnEastEdge { get { return _y == _myCollection.Height - 1; } }
        public bool OnSouthEdge { get { return _x == _myCollection.Width - 1; } }
        public bool OnWestEdge { get { return _x == 0; } }

        public Position Position => _position;

        public ICell NorthNeighbor => _myCollection[Position.X, Position.Y - 1];

        public ICell NorthEastNeighbor => _myCollection[Position.X + 1, Position.Y - 1];

        public ICell EastNeighbor => _myCollection[Position.X + 1, Position.Y];

        public ICell SouthEastNeighbor => _myCollection[Position.X + 1, Position.Y + 1];

        public ICell SouthNeighbor => _myCollection[Position.X, Position.Y + 1];

        public ICell SouthWestNeighbor => _myCollection[Position.X - 1, Position.Y + 1];

        public ICell WestNeighbor => _myCollection[Position.X - 1, Position.Y];

        public ICell NorthWestNeighbor => _myCollection[Position.X - 1, Position.Y - 1];
        #endregion

        #region Publics
        public override bool Equals(object obj)
        {
            return Equals((Cell)obj);
        }

        public bool Equals(Cell other)
        {
            CellComparer comparer = new CellComparer();
            if (comparer.Compare(this, other) == 0)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Content.GetHashCode();
        }

        public override string ToString()
        {
            if (Content != null)
                return Content.ToString();
            else if (BitState)
                return "1";
            else
                return " ";
        }

        public int GetNeighborsByBitState(bool value)
        {
            int activeNeighbors = 0;
            if (NorthNeighbor != null && ((Cell)NorthNeighbor).BitState.Equals(value))
                activeNeighbors++;
            if (NorthEastNeighbor != null && ((Cell)NorthEastNeighbor).BitState.Equals(value))
                activeNeighbors++;
            if (EastNeighbor != null && ((Cell)EastNeighbor).BitState.Equals(value))
                activeNeighbors++;
            if (SouthEastNeighbor != null && ((Cell)SouthEastNeighbor).BitState.Equals(value))
                activeNeighbors++;
            if (SouthNeighbor != null && ((Cell)SouthNeighbor).BitState.Equals(value))
                activeNeighbors++;
            if (SouthWestNeighbor != null && ((Cell)SouthWestNeighbor).BitState.Equals(value))
                activeNeighbors++;
            if (WestNeighbor != null && ((Cell)WestNeighbor).BitState.Equals(value))
                activeNeighbors++;
            if (NorthWestNeighbor != null && ((Cell)NorthWestNeighbor).BitState.Equals(value))
                activeNeighbors++;

            return activeNeighbors;
        }

        public int GetNeighborsByValue(object value)
        {
            if (value is bool)
                return GetNeighborsByBitState((bool)value);

            int activeNeighbors = 0;
            if (NorthNeighbor != null && ((Cell)NorthNeighbor).Content.Equals(value))
                activeNeighbors++;
            if (NorthEastNeighbor != null && ((Cell)NorthEastNeighbor).Content.Equals(value))
                activeNeighbors++;
            if (EastNeighbor != null && ((Cell)EastNeighbor).Content.Equals(value))
                activeNeighbors++;
            if (SouthEastNeighbor != null && ((Cell)SouthEastNeighbor).Content.Equals(value))
                activeNeighbors++;
            if (SouthNeighbor != null && ((Cell)SouthNeighbor).Content.Equals(value))
                activeNeighbors++;
            if (SouthWestNeighbor != null && ((Cell)SouthWestNeighbor).Content.Equals(value))
                activeNeighbors++;
            if (WestNeighbor != null && ((Cell)WestNeighbor).Content.Equals(value))
                activeNeighbors++;
            if (NorthWestNeighbor != null && ((Cell)NorthWestNeighbor).Content.Equals(value))
                activeNeighbors++;

            return activeNeighbors;
        }

        public int GetNeighborsWithValue()
        {
            int activeNeighbors = 0;
            if (NorthNeighbor != null && ((Cell)NorthNeighbor).BitState)
                activeNeighbors++;
            if (NorthEastNeighbor != null && ((Cell)NorthEastNeighbor).BitState)
                activeNeighbors++;
            if (EastNeighbor != null && ((Cell)EastNeighbor).BitState)
                activeNeighbors++;
            if (SouthEastNeighbor != null && ((Cell)SouthEastNeighbor).BitState)
                activeNeighbors++;
            if (SouthNeighbor != null && ((Cell)SouthNeighbor).BitState)
                activeNeighbors++;
            if (SouthWestNeighbor != null && ((Cell)SouthWestNeighbor).BitState)
                activeNeighbors++;
            if (WestNeighbor != null && ((Cell)WestNeighbor).BitState)
                activeNeighbors++;
            if (NorthWestNeighbor != null && ((Cell)NorthWestNeighbor).BitState)
                activeNeighbors++;

            return activeNeighbors;
        }

        public ICell GetNeighborByVector(Vector vector)
        {
            Position newPos = this.Position + vector;
            if(_myCollection.CellExists(newPos.X, newPos.Y))
            {
                return _myCollection[newPos.X, newPos.Y];
            }

            return null;
        }
        #endregion
    }

    internal class CellComparer : IComparer<Cell>
    {
        public int Compare(Cell x, Cell y)
        {
            return x.GetHashCode().CompareTo(y.GetHashCode());
        }
    }
}
