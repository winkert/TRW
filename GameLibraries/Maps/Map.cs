using System;
using System.Collections.Generic;
using System.Linq;
using TRW.CommonLibraries.Core;
using TRW.CommonLibraries.ProceduralAlgorithms;

namespace TRW.GameLibraries.Maps
{
    public class Map
    {
        #region Fields
        private int _yDimension;
        private int _xDimension;
        private Random _r;
        private const int _totalAllowedRetries = 50;
        #endregion

        #region Constructors
        public Map()
            : this(32, 32)
        {

        }
        public Map(int size)
            : this(size, size)
        {

        }
        public Map(int width, int height)
        {
            InternalInit(width, height);
        }
        public Map(string mapFilePath)
        {
            LoadMapFromFile(mapFilePath);
        }
        #endregion

        #region Properties
        public Tuple<int, int> Dimensions { get; private set; }
        public Grid Grid { get; private set; }
        public bool FromFile { get; set; }
        public ColorMap MapColorMap { get; set; }
        public MapParser.ColorMapStyle ColorStyle { get; set; }
        #endregion

        #region Events
        /// <summary>
        /// Event to fire when a step is made in the procedural generation
        /// </summary>
        public event ProceduralAlgorithmCallbackEvent UpdateMap;
        #endregion

        #region Publics
        /// <summary>
        /// Set content for all cells in the map to the specified content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        public void FillMap<T>(T content)
        {
            Grid.Cells.First();
            do
            {
                Grid.Cells.Current.Content = content;
            } while (Grid.Cells.Next());
        }

        /// <summary>
        /// Set the content for all cells in a map to a random value from the specified array of content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        public void FillRandom<T>(T[] content)
        {
            Grid.Cells.First();
            do
            {
                T cellContent = content[_r.Next(content.Length)];
                if (cellContent is bool)
                    Grid.Cells.Current.BitState = Convert.ToBoolean(cellContent);
                else
                    Grid.Cells.Current.Content = cellContent;
            } while (Grid.Cells.Next());
        }

        /// <summary>
        /// Populate the map from a file using the MapFile and parsing logic
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadMapFromFile(string filePath)
        {
            MapFile file = new MapFile(filePath);
            InternalInit(file.Width, file.Height);

            file.FillGrid(Grid);
            FromFile = true;
        }

        /// <summary>
        /// Fills the map with decimal values using the diamond square algorithm
        /// </summary>
        /// <param name="baseValue"></param>
        /// <param name="spread"></param>
        public void FillDiamondSquare(decimal baseValue, decimal spread)
        {
            int step = _xDimension / 2;
            // set corners to base value
            Grid.Cells[0, 0].Value = baseValue + GetNextDecimal(spread);
            Grid.Cells[0, _yDimension - 1].Value = baseValue + GetNextDecimal(spread);
            Grid.Cells[_xDimension - 1, 0].Value = baseValue + GetNextDecimal(spread);
            Grid.Cells[_xDimension - 1, _yDimension - 1].Value = baseValue + GetNextDecimal(spread);

            DiamondSquareAlgorithm<CellCollection, Cell> diamondSquare = new DiamondSquareAlgorithm<CellCollection, Cell>(this, Grid.Cells, _xDimension, _yDimension);
            if (UpdateMap != null)
                diamondSquare.Callback += UpdateMap;

            diamondSquare.DoAlgorithm(_xDimension, _yDimension, step, spread);
        }

        public void FillRandomWalk(int iterations, bool avoidEdges = false, bool avoidClusters = false)
        {
            FillRandomWalk(_r.Next(0, _xDimension), _r.Next(0, _yDimension), iterations, avoidEdges, avoidClusters);
        }

        public void FillRandomWalk(int startX, int startY, int iterations, bool avoidEdges = false, bool avoidClusters = false)
        {
            FillRandomWalk(new Position(startX, startY), iterations, avoidEdges, avoidClusters);
        }

        public void FillRandomWalk(Position startPosition, int iterations, bool avoidEdges, bool avoidClusters)
        {
            // set default value in the map.
            FillMap(false);
            RandomWalkAlgorithm<CellCollection, Cell> randomWalk = new RandomWalkAlgorithm<CellCollection, Cell>(this, Grid.Cells, _xDimension, _yDimension);
            if (UpdateMap != null)
                randomWalk.Callback += UpdateMap;

            randomWalk.DoAlgorithm(startPosition, iterations, avoidEdges, avoidClusters);
        }

        public void FillCellAutomata(CellularAutomataRulesSet<bool> neighborhoodRules, int iterations, bool avoidEdges = false, bool makeSquare = false)
        {
            FillRandom(new bool[] { true, false });
            if (this.UpdateMap != null)
                UpdateMap(this, new ProceduralAlgorithmCallbackEventArgs());
            CellularAutomataAlgorithm<CellCollection, Cell> cellAutomata = new CellularAutomataAlgorithm<CellCollection, Cell>(this, Grid.Cells, _xDimension, _yDimension);
            if (UpdateMap != null)
                cellAutomata.Callback += UpdateMap;

            cellAutomata.DoAlgorithm(neighborhoodRules, iterations, avoidEdges, makeSquare);
        }

        public void FillPerlinNoise(int octaves, decimal persistence, decimal frequency, decimal amplitude)
        {
            PerlinNoiseAlgorithm<CellCollection, Cell> perlinNoise = new PerlinNoiseAlgorithm<CellCollection, Cell>(this, Grid.Cells, _xDimension, _yDimension);
            if (UpdateMap != null)
                perlinNoise.Callback += UpdateMap;

            perlinNoise.DoAlgorithm(octaves, persistence, frequency, amplitude);
        }

        public List<MapComponentBase> GenerateRandomDungeon(int numOfRooms, Tuple<int, int> minSizeOfRooms, Tuple<int, int> maxSizeOfRooms, HallCreationModes hallCreationMode, RoomShapes roomShape, bool allowIntersectingRooms)
        {
            List<MapComponentBase> mapParts = new List<MapComponentBase>();
            List<Position> thresholds = new List<Position>();
            // STEP 1: Create Rooms
            for (int i = 0; i < numOfRooms; i++)
            {
                // need to check if the room intersects with any existing rooms
                Room room = CreateRoom(minSizeOfRooms, maxSizeOfRooms, out Position roomCenter, out Tuple<int, int> size, roomShape);
                // this recursive stuff is....potentially dangerous because it could loop through forever.
                if(!allowIntersectingRooms)
                    room = CheckForAndAdjustIntersectingRooms(mapParts, room, () => { return CreateRoom(minSizeOfRooms, maxSizeOfRooms, out roomCenter, out size, roomShape); });

                mapParts.Add(room);

                // add threshold for paths
                Vector door;
                int doorX, doorY;
                if (_r.Next() % 2 == 0)
                {
                    doorX = size.Item1 / 2;
                    doorY = _r.Next((size.Item2 - 1) / -2, (size.Item2 - 1) / 2);
                }
                else
                {
                    doorY = size.Item2 / 2;
                    doorX = _r.Next((size.Item1 - 1) / -2, (size.Item1 - 1) / 2);
                }
                door = new Vector(doorX, doorY);
                thresholds.Add(GetAdjustPosition(roomCenter + door));
            }
            // STEP 2: Create paths between rooms
            if (thresholds.Count > 1)
            {
                for (int i = 0; i < thresholds.Count; i++)
                {
                    int e = i;
                    while (e == i)
                    {
                        e = _r.Next(0, thresholds.Count - 1);
                    }
                    Hall hall = CreateHall(thresholds[i], thresholds[e], hallCreationMode);
                    mapParts.Add(hall);

                }
            }

            mapParts.Sort();

            // STEP 3: Draw
            this.FillMap((int)ColorMap.DungeonColorMap.Void);
            foreach (MapComponentBase comp in mapParts)
                comp.Draw(this);

            return mapParts;
        }

        public void AddSquare<T>(int x, int y, int size, T val)
        {
            AddSquare(Position.Create(x, y), size, val);
        }

        public void AddSquare<T>(Position target, int size, T val)
        {
            AddRectangle(target, size, size, val);
        }

        public void AddRectangle<T>(Position target, int sizeX, int sizeY, T val)
        {
            Position[] corners = GetCornersFromSize(target, sizeX, sizeY);
            AddShape(corners, val);
        }

        public void AddShape<T>(Position[] points, T val)
        {
            AddShape(points, val, val, false);
        }

        public void AddShape<T, R>(Position[] points, T val, R fillVal, bool fill)
        {
            Grid.AddShape(points, val, fillVal, fill);
        }

        public void Clear()
        {
            Grid.Cells.Clear();
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return Grid.Cells.GetEnumerator();
        }

        public bool TryGetCellRelativeToCurrent(int xOffset, int yOffset, out Cell cell)
        {
            cell = null;
            int xOutPosition = Grid.Cells.Position.X + xOffset;
            int yOutPosition = Grid.Cells.Position.Y + yOffset;

            if (0 <= xOutPosition && xOutPosition > this._xDimension)
                return false;
            if (0 <= yOutPosition && yOutPosition > this._yDimension)
                return false;

            cell = Grid.Cells[xOutPosition, yOutPosition];

            return true;
        }

        public bool IsOnMap(Position position)
        {
            return IsOnMap(position, out _);
        }
        public bool IsOnMap(Position position, out Position newPos)
        {
            if (position.X >= 0 && position.Y >= 0)
            {
                if (position.X < this._xDimension && position.Y < this._yDimension)
                {
                    newPos = position;
                    return true;
                }
            }

            newPos = GetAdjustPosition(position);

            return false;
        }

        public override string ToString()
        {
            return Grid.ToString();
        }
        #endregion

        #region Private Methods
        private void InternalInit(int width, int height)
        {
            _r = new Random();
            _yDimension = height;
            _xDimension = width;
            Grid = new Grid(width, height);

            Dimensions = new Tuple<int, int>(width, height);
        }

        private decimal GetNextDecimal(decimal spread)
        {
            return _r.NextDecimal() * spread;
        }

        private Position GetAdjustPosition(Position p)
        {
            int newX = p.X;
            int newY = p.Y;
            if (p.X < 0)
                newX = 0;
            if (p.Y < 0)
                newY = 0;
            if (p.X >= this._xDimension)
                newX = this._xDimension - 1;
            if (p.Y >= this._yDimension)
                newY = this._yDimension - 1;

            return Position.Create(newX, newY);
        }

        private Room CheckForAndAdjustIntersectingRooms(List<MapComponentBase> mapParts, Room room, Func<Room> createRoomAction, int totalRetries = 0)
        {
            if (totalRetries++ > _totalAllowedRetries)
                return room;

            // need to check that this room is actually on the map
            foreach (Position point in room.Points)
            {
                if (!IsOnMap(point, out Position newPos))
                {
                    point.UpdatePosition(newPos.X, newPos.Y);
                }
            }

            foreach (MapComponentBase part in mapParts)
            {
                if (part.Intersects(room))
                {
                    return CheckForAndAdjustIntersectingRooms(mapParts, createRoomAction(), createRoomAction, totalRetries);
                }
            }

            return room;
        }

        private Room CreateRoom(Tuple<int, int> minSizeOfRooms, Tuple<int, int> maxSizeOfRooms, out Position roomCenter, out Tuple<int, int> size, RoomShapes roomShape)
        {
            int x = _r.Next(0, _xDimension - (maxSizeOfRooms.Item1 / 2));
            int y = _r.Next(0, _yDimension - (maxSizeOfRooms.Item2 / 2));
            roomCenter = Position.Create(x, y);
            size = Tuple.Create(_r.Next(minSizeOfRooms.Item1, maxSizeOfRooms.Item1), _r.Next(minSizeOfRooms.Item2, maxSizeOfRooms.Item2));

            return new Room(this, roomCenter, size.Item1, size.Item2, roomShape);
        }

        private Hall CreateHall(Position start, Position end, HallCreationModes hallCreationMode)
        {
            return new Hall(this, start, end, hallCreationMode);
        }
        #endregion

        #region Statics
        public static Position[] GetCornersFromSize(Position center, int sizeX, int sizeY)
        {
            Vector[] centrifugalVectors = new Vector[4];
            centrifugalVectors[0] = new Vector(sizeX / 2, sizeY / 2);    // Upper Left
            centrifugalVectors[1] = new Vector(sizeX / 2, -sizeY / 2);   // Lower Left
            centrifugalVectors[2] = new Vector(-sizeX / 2, -sizeY / 2);  // Lower Right
            centrifugalVectors[3] = new Vector(-sizeX / 2, sizeY / 2);   // Upper Right

            return ConvertVectorsToPositions(center, centrifugalVectors);
        }

        public static Position[] GetOvalFromSize(Position center, int resolution, int sizeX, int sizeY)
        {
            // take 360/resolution
            int degreeStep = 360 / resolution;
            double degree = 0;
            Vector[] centrifugalVectors = new Vector[resolution];
            for (int i = 0; i < resolution; i++)
            {
                int x = (int)(sizeX * Math.Cos(degree));
                int y = (int)(sizeY * Math.Sin(degree));
                centrifugalVectors[i] = new Vector(x, y);

                degree += degreeStep;
            }

            return ConvertVectorsToPositions(center, centrifugalVectors);
        }

        public static Position[] GetUnevenShapeFromSize(Position center, int resolution, int sizeX, int sizeY)
        {
            Random R = new Random();

            Vector[] centrifugalVectors = new Vector[resolution];
            for (int i = 0; i < resolution; i++)
            {
                int x = (int)(sizeX * R.NextDecimal(-1m, 1m));
                int y = (int)(sizeY * R.NextDecimal(-1m, 1m));
                centrifugalVectors[i] = new Vector(x, y);
            }

            return ConvertVectorsToPositions(center, centrifugalVectors);
        }

        public static Position[] ConvertVectorsToPositions(Position center, Vector[] centrifugalVectors)
        {
            Position[] corners = new Position[centrifugalVectors.Length];
            for (int i = 0; i < centrifugalVectors.Length; i++)
            {
                corners[i] = center + centrifugalVectors[i];
            }
            return corners;
        }

        #endregion
    }
}
