using System;
using System.Collections.Generic;
using TRW.CommonLibraries.Core;

namespace TRW.GameLibraries.Maps
{
    public class Grid
    {

        #region Fields
        #endregion

        #region Constructors
        public Grid(int sizeX, int sizeY)
        {
            Cells = new CellCollection(sizeX, sizeY);
        }
        #endregion

        #region Properties
        public CellCollection Cells { get; private set; }
        public string MapText { get; set; }
        #endregion

        #region Publics
        public void AddShape<T>(Position[] points, T val)
        {
            AddShape(points, val, false, false);
        }
        
        public void AddShape<T, R>(Position[] points, T val, R fillVal, bool fill)
        {
            if (fill)
            {
                AddFilledShape(points, val, fillVal);
            }
            else
            {
                AddShapeOutline(points, val);
            }
        }

        public void ConnectPoints<T>(Position a, Position b, T val)
        {
            Position[] points = Position.GetLine(a, b);
            foreach(Position point in points)
            {
                Cells[point.X, point.Y].Content = val;
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(MapText))
                return Cells.ToString();
            else
                return MapText;
        }

        #endregion

        internal void AddShapeOutline<T>(Position[] points, T outline)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (i < points.Length - 1)
                {
                    ConnectPoints(points[i], points[i + 1], outline);
                }
                else
                {
                    ConnectPoints(points[i], points[0], outline); // complete loop
                }
            }
        }

        internal void AddFilledShape<T, R>(Position[] points, T outline, R fill)
        {
            AddShapeOutline(points, outline);

            // fill in the void
            foreach(Cell c in Cells)
            {
                if (Position.Within(c.Position, points, false))
                {
                    c.Content = fill;
                }
            }
        }
    }
}
