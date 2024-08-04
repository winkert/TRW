using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TRW.GameLibraries.Maps
{
    public class MapFile
    {

        #region Fields
        private const string _headerExp = @"(^H)(\d{1,})(,(\d{1,}))*$";
        private HashSet<char> _excludedChars = new HashSet<char>() { (char)10, (char)13 };
        private string _filePath;
        #endregion

        #region Constructors
        public MapFile(string filePath)
        {
            _filePath = filePath;
            LoadFromFile();
        }
        #endregion

        #region Properties
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string[] Lines { get; private set; }
        #endregion

        #region Publics
        public void FillGrid(Grid grid)
        {
            grid.Cells.First();
            do
            {
                char cellContent = Lines[grid.Cells.Position.Y][grid.Cells.Position.X];
                if(MapParser.CharacterMap.ContainsKey(cellContent))
                    grid.Cells.Current.Content = MapParser.CharacterMap[cellContent];
                else
                    grid.Cells.Current.Content = cellContent;

            } while (grid.Cells.Next());

            StringBuilder mapTextBuilder = new StringBuilder();
            foreach (string line in Lines)
                mapTextBuilder.AppendLine(line);

            grid.MapText = mapTextBuilder.ToString();
        }

        public override string ToString()
        {
            return string.Join("\r", Lines);
        }
        #endregion

        #region Private Methods
        private void LoadFromFile()
        {
            if (!File.Exists(_filePath))
                throw new IOException(string.Format("Unable to access file {0}", _filePath));

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string headerLine = reader.ReadLine();
                if (string.IsNullOrEmpty(headerLine))
                    throw new ArgumentNullException(string.Format("File {0} is empty or is missing header line", _filePath));

                Regex headerRegex = new Regex(_headerExp);
                Match headerMatch = headerRegex.Match(headerLine);

                if (!headerMatch.Success)
                    throw new ArgumentException(string.Format("File {0} does not have valid header line {1}", _filePath, headerLine));

                Width = int.Parse(headerMatch.Groups[2].Value);
                if (string.IsNullOrEmpty(headerMatch.Groups[4].Value))
                    Height = Width;
                else
                    Height = int.Parse(headerMatch.Groups[4].Value);

                Lines = new string[Height];

                // we accept at face value that the header line is correct
                int y = 0;
                int x = 0;
                try
                {
                    for (y = 0; y < Height; y++)
                    {
                        // read one character at a time on each line and then add that to the Lines array
                        string mapLine = string.Empty;
                        for (x = 0; x < Width; x++)
                        {
                            mapLine += ReadNext(reader);
                        }
                        Lines[y] = mapLine;
                    }
                }
                catch(Exception readerException)
                {
                    throw new ArgumentException(string.Format("Error reader line {0}, position {1} in file {2}", x, y, _filePath), readerException);
                }
            }

        }

        private char ReadNext(StreamReader reader)
        {
            char nextChar = (char)reader.Read();
            if (_excludedChars.Contains(nextChar))
                nextChar = ReadNext(reader);

            return nextChar;
        }
        #endregion
    }
}
