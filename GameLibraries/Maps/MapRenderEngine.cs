using System;
using System.Drawing;

namespace TRW.GameLibraries.Maps
{
    public static class MapRenderEngine
    {
        private readonly static Brush _wallBrush = Brushes.Black;
        private readonly static Brush _roomBrush = Brushes.Beige;

        /// <summary>
        /// Draw map using default rendering instructions from the MapParser
        /// </summary>
        /// <param name="map"></param>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        /// <returns></returns>
        public static Bitmap DrawMap(Map map, int imageWidth, int imageHeight)
        {
            return DrawMap(map, imageWidth, imageHeight, true);
        }
        /// <summary>
        /// Draw map using default rendering instructions from the MapParser
        /// </summary>
        /// <param name="map"></param>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        /// <param name="maintainAspectRatio"></param>
        /// <returns></returns>
        public static Bitmap DrawMap(Map map, int imageWidth, int imageHeight, bool maintainAspectRatio)
        {
            int cellWidth = (imageWidth / map.Grid.Cells.Width);
            int cellHeight = (imageHeight / map.Grid.Cells.Height);

            if (maintainAspectRatio && cellHeight != cellWidth)
            {
                // in order to maintain aspect ratio, cell dimension must be equal; use the smaller of the two
                cellHeight = Math.Min(cellHeight, cellWidth);
                cellWidth = Math.Min(cellHeight, cellWidth);
            }

            Bitmap bmp = new Bitmap(imageWidth, imageHeight);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                map.Grid.Cells.First();
                do
                {
                    if (map.Grid.Cells.Current.Content == null)
                    {
                        // this seems like a problem, but may just skip
                        continue;
                    }


                    if (map.MapColorMap != null)
                    {
                        Brush cellBrush = new SolidBrush(map.MapColorMap.GetColor(map.Grid.Cells.Current.Value, map.ColorStyle));
                        DrawCellContent(g, map.Grid.Cells.Position, cellWidth, cellHeight, cellBrush);
                    }
                    else
                    {
                        MapParser.MapCellContent content = MapParser.MapCellContent.Null;
                        if (map.Grid.Cells.Current.Content is MapParser.MapCellContent)
                        {
                            content = (MapParser.MapCellContent)map.Grid.Cells.Current.Content;

                        }
                        else if (map.Grid.Cells.Current.Content is decimal)
                        {
                            content = MapParser.GetCellContent(map.Grid.Cells.Current.Value);
                        }
                        else if (map.Grid.Cells.Current.Content is int)
                        {
                            content = MapParser.GetCellContent((int)map.Grid.Cells.Current.Content);
                        }
                        else if(map.Grid.Cells.Current.Content is bool)
                        {
                            if (map.Grid.Cells.Current.BitState)
                                content = MapParser.MapCellContent.Room;
                            else
                                content = MapParser.MapCellContent.Wall;
                        }
                        DrawCellContent(g, map.Grid.Cells.Position, content, cellWidth, cellHeight);
                    }

                } while (map.Grid.Cells.Next());

            }

            return bmp;
        }

        public static void DrawCellContent(Graphics g, TRW.CommonLibraries.Core.Position position, int cellWidth, int cellHeight, Brush cellColor)
        {
            g.FillRectangle(cellColor, position.X * cellWidth, position.Y * cellHeight, cellWidth, cellHeight);
        }

        public static void DrawCellContent(Graphics g, TRW.CommonLibraries.Core.Position position, MapParser.MapCellContent content, int cellWidth, int cellHeight)
        {
            switch (content)
            {
                case MapParser.MapCellContent.Wall:
                    DrawCellContent(g, position, cellWidth, cellHeight, _wallBrush);
                    break;
                case MapParser.MapCellContent.Room:
                case MapParser.MapCellContent.Hall:
                    DrawCellContent(g, position, cellWidth, cellHeight, _roomBrush);
                    break;
            }
        }

    }
}
