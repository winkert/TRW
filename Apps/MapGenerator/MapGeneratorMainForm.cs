using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.Apps.TrwAppsBase;
using TRW.CommonLibraries.Core;
using TRW.GameLibraries.Maps;

namespace TRW.Apps.MapGenerator
{
    public partial class MapGeneratorMainForm : TrwFormBase
    {
        Map _map;

        public MapGeneratorMainForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
            InitializeToolTips();
        }

        protected override bool HasConfigFile => true;

        protected override void UpdateStatus(Control mainForm, string message)
        {
            mainForm.Invoke(new UpdateUIStatus(AddStatusMessage), (TextBox)txtStatus, message);
        }

        private void InitializeComboBoxes()
        {
            GetColorMaps();

            cmbColorMapStyle.Items.Add(MapParser.ColorMapStyle.None);
            cmbColorMapStyle.Items.Add(MapParser.ColorMapStyle.Exact);
            cmbColorMapStyle.Items.Add(MapParser.ColorMapStyle.Between);
            cmbColorMapStyle.SelectedIndex = 2;
        }

        private void InitializeToolTips()
        {
            // diamond square
            txtDiamondValueSpread.SetToolTip("Seed. Should be less than the max value of color map");
            txtDiamondBaseValue.SetToolTip("Starting value of cells. Base on Color Map.");
            txtDiamondMapWidth.SetToolTip("Width of the map. Must be a power of 2 + 1 (e.g. 33, 257, 1025, etc.)");
            txtDiamondMapHeight.SetToolTip("Height of the map. Must be a power of 2 + 1 (e.g. 33, 257, 1025, etc.)");
            cmbColorMap.SetToolTip("Color map to use when rendering the map.");
            cmbColorMapStyle.SetToolTip("How to apply the color map to the map values.");
            // random walk
            txtRandomWalkHeight.SetToolTip("Height of the map.");
            txtRandomWalkWidth.SetToolTip("Width of the map.");
            txtRandomWalkIterations.SetToolTip("Number of iterations to perform.");
            txtRandomWalkStart.SetToolTip("Starting position in format x,y. If blank, a random position will be used.");
            chkRandomWalkAvoidEdges.SetToolTip("Avoid edges of the map.");
            chkRandomWalkAvoidClusters.SetToolTip("Avoid clusters of filled cells.");
            // cellular automata
            txtCellAutomataHeight.SetToolTip("Height of the map.");
            txtCellAutomataWidth.SetToolTip("Width of the map.");
            txtCellAutomataIterations.SetToolTip("Number of iterations to perform.");
            chkCellAutomataAvoidEdges.SetToolTip("Avoid edges of the map.");
            // perlin noise
            uxPerlinNoiseHeight.SetToolTip("Height of the map.");
            uxPerlinNoiseWidth.SetToolTip("Width of the map.");
            uxPerlinNoiseOctaves.SetToolTip("The number of iterations to do - impacts smoothness");
            uxPerlinNoisePersistence.SetToolTip("0 to 1 value indicating how the slope changes between iterations");
            uxPerlinNoiseFreq.SetToolTip("The frequency determines how rapidly the noise oscillates or repeats.");
            uxPerlinNoiseAmp.SetToolTip("The amplitude represents the strength or magnitude of the noise.");
            uxPerlinNoiseGrid.SetToolTip("Type of grid to use.");
            // random dungeon
            uxDungeonHeight.SetToolTip("Height of the map.");
            uxDungeonWidth.SetToolTip("Width of the map.");
            uxNumOfRooms.SetToolTip("Number of rooms to create.");
            uxMinXOfRooms.SetToolTip("Minimum width of rooms.");
            uxMinYOfRooms.SetToolTip("Minimum height of rooms.");
            uxMaxXOfRooms.SetToolTip("Maximum width of rooms.");
            uxMaxYOfRooms.SetToolTip("Maximum height of rooms.");
        }

        private void GetColorMaps()
        {
            if (!_settings.ContainsKey("ColorMaps"))
            {
                string newPath = System.IO.Path.Combine(Environment.CurrentDirectory, "ColorMaps");
                _settings.Add("ColorMaps", newPath);
                if (!System.IO.Directory.Exists(newPath))
                    System.IO.Directory.CreateDirectory(newPath);

                ManageColorMapDialog.SerializeColorMaps(newPath, ColorMap.GrayScale, ColorMap.GrayScaleLarge, ColorMap.Terra);
            }

            cmbColorMap.Items.Clear();

            string mapFiles = _settings["ColorMaps"];

            foreach (ColorMap map in ManageColorMapDialog.DeserializeColorMaps(mapFiles))
            {
                cmbColorMap.AddItem(map);
            }

            cmbColorMap.SelectedIndex = 0;

        }

        private bool ValidateDiamondSquareFields(out int width, out int height, out decimal baseValue, out decimal spread)
        {
            width = 0;
            height = 0;
            baseValue = 0;
            spread = 0;

            if (string.IsNullOrWhiteSpace(txtDiamondMapWidth.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDiamondMapHeight.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDiamondBaseValue.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDiamondValueSpread.Text))
            {
                return false;
            }

            if (!int.TryParse(txtDiamondMapWidth.Text, out width))
            {
                return false;
            }
            else if (!int.TryParse(txtDiamondMapHeight.Text, out height))
            {
                return false;
            }
            else if (!decimal.TryParse(txtDiamondBaseValue.Text, out baseValue))
            {
                return false;
            }
            else if (!decimal.TryParse(txtDiamondValueSpread.Text, out spread))
            {
                return false;
            }

            if(height != width || width < 3 || height < 3 || !height.IsPowerOfTwoPlusOne())
            {
                UpdateStatus("Width and height must be equal and a power of 2 + 1 (e.g. 33, 257, etc.).");
                return false;
            }

            return true;
        }

        private void RunDiamondSquare(Map map, decimal baseValue, decimal spread, ColorMap colorMap, MapParser.ColorMapStyle colorMapStyle)
        {
            map.UpdateMap += UpdateMapHandler;
            map.FillDiamondSquare(baseValue, spread);
            map.MapColorMap = colorMap;
            map.ColorStyle = colorMapStyle;
            _map = map;
        }

        private bool ValidateRandomWalkFields(out int width, out int height, out int iterations, out Position startPosition, out bool avoidEdges, out bool avoidClusters)
        {
            width = 0;
            height = 0;
            iterations = 0;
            startPosition = Position.Null;
            avoidEdges = false;
            avoidClusters = false;

            if (string.IsNullOrWhiteSpace(txtRandomWalkWidth.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtRandomWalkHeight.Text))
            {
                return false;
            }

            if (!int.TryParse(txtRandomWalkWidth.Text, out width))
            {
                return false;
            }
            else if (!int.TryParse(txtRandomWalkHeight.Text, out height))
            {
                return false;
            }

            iterations = Convert.ToInt32(txtRandomWalkIterations.Value);

            if (!string.IsNullOrWhiteSpace(txtRandomWalkStart.Text))
            {
                string[] position = txtRandomWalkStart.Text.Split(',');
                if (position.Length == 2)
                {
                    int x, y;
                    if (!int.TryParse(position[0], out x))
                        return false;
                    else if (!int.TryParse(position[1], out y))
                        return false;

                    startPosition = new Position(x, y);
                }
                else
                    return false;
            }

            if (chkRandomWalkAvoidEdges.Checked)
                avoidEdges = true;
            if (chkRandomWalkAvoidClusters.Checked)
                avoidClusters = true;

            return true;
        }

        private void RunRandomWalk(Map map, Position position, int iterations, bool avoidEdges, bool avoidClusters)
        {
            map.UpdateMap += UpdateMapHandler;
            if (position == Position.Null)
                map.FillRandomWalk(iterations, avoidEdges, avoidClusters);
            else
                map.FillRandomWalk(position, iterations, avoidEdges, avoidClusters);
            UpdateStatus(map.ToString());

            _map = map;
        }

        private bool ValidateCellAutomataFields(out int width, out int height, out int iterations, out bool avoidEdges)
        {
            width = 0;
            height = 0;
            iterations = 0;
            avoidEdges = false;

            if (string.IsNullOrWhiteSpace(txtCellAutomataWidth.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCellAutomataHeight.Text))
            {
                return false;
            }

            if (!int.TryParse(txtCellAutomataWidth.Text, out width))
            {
                return false;
            }
            else if (!int.TryParse(txtCellAutomataHeight.Text, out height))
            {
                return false;
            }

            iterations = Convert.ToInt32(txtCellAutomataIterations.Value);


            if (chkCellAutomataAvoidEdges.Checked)
                avoidEdges = true;


            return true;
        }

        private void RunCellAutomata(Map map, int iterations, bool avoidEdges)
        {
            map.UpdateMap += UpdateMapHandler;
            CommonLibraries.ProceduralAlgorithms.CellularAutomataRulesSet<bool> rules = CommonLibraries.ProceduralAlgorithms.CellularAutomataRulesSet<bool>.DefaultRuleSetBool();
            map.FillCellAutomata(rules, iterations, avoidEdges, false);

            _map = map;
        }

        private bool ValidatePerlinNoiseFields(out int width, out int height, out int octaves, out decimal persistence, out decimal frequency, out decimal amplitude, out bool useComplexGrid)
        {
            width = 0;
            height = 0;
            octaves = 0;
            persistence = 0;
            frequency = 0;
            amplitude = 0;
            useComplexGrid = false;

            if (string.IsNullOrEmpty(uxPerlinNoiseWidth.Text))
                return false;
            if (string.IsNullOrEmpty(uxPerlinNoiseHeight.Text))
                return false;

            if (!int.TryParse(uxPerlinNoiseWidth.Text, out width))
                return false;
            if (!int.TryParse(uxPerlinNoiseHeight.Text, out height))
                return false;

            if (uxPerlinNoiseGrid.SelectedIndex < 0)
                return false;

            if (!decimal.TryParse(uxPerlinNoisePersistence.Text, out persistence))
                return false;

            octaves = (int)uxPerlinNoiseOctaves.Value;
            frequency = uxPerlinNoiseFreq.Value;
            amplitude = uxPerlinNoiseAmp.Value;
            useComplexGrid = uxPerlinNoiseGrid.SelectedIndex == 1;

            return true;
        }

        private void RunPerlinNoise(Map map, int octaves, decimal persistence, decimal frequency, decimal amplitude, bool useComplexGrid)
        {
            map.UpdateMap += UpdateMapHandler;
            map.ColorStyle = MapParser.ColorMapStyle.Exact;
            map.MapColorMap = ColorMap.GetGrayScale256Bits();
            map.FillPerlinNoise(octaves, persistence, frequency, amplitude, useComplexGrid);

            // for debug purposes only
            //UpdateStatus(map.ToString());

            _map = map;
        }

        private bool ValidateRandomDungeonFields(out int width, out int height, out int numOfRooms, out Tuple<int, int> minSizeOfRooms, out Tuple<int, int> maxSizeOfRooms)
        {
            width = 0;
            height = 0;
            numOfRooms = 0;
            minSizeOfRooms = null;
            maxSizeOfRooms = null;

            if (string.IsNullOrWhiteSpace(uxDungeonWidth.Text) || !int.TryParse(uxDungeonWidth.Text, out width))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(uxDungeonHeight.Text) || !int.TryParse(uxDungeonHeight.Text, out height))
            {
                return false;
            }

            numOfRooms = (int)uxNumOfRooms.Value;
            minSizeOfRooms = Tuple.Create((int)uxMinXOfRooms.Value, (int)uxMinYOfRooms.Value);
            maxSizeOfRooms = Tuple.Create((int)uxMaxXOfRooms.Value, (int)uxMaxYOfRooms.Value);

            return true;
        }

        private void RunRandomDungeonCreator(Map map, int numOfRooms, Tuple<int, int> minSizeOfRooms, Tuple<int, int> maxSizeOfRooms)
        {
            map.GenerateRandomDungeon(numOfRooms, minSizeOfRooms, maxSizeOfRooms, HallCreationModes.SBend, RoomShapes.Rectangle, false);
            map.MapColorMap = ColorMap.Dungeon;
            map.ColorStyle = MapParser.ColorMapStyle.Exact;
            _map = map;
        }

        delegate void DrawMapDelegate(Map map);

        private void DrawMap(Map map)
        {
            Bitmap bmp = MapRenderEngine.DrawMap(map, pctPreview.Width, pctPreview.Height);
            pctPreview.Image = bmp;

            // repaint PictureBox
            pctPreview.Invalidate();
        }

        private void SaveImage()
        {
            Map map = (Map)pctPreview.Tag;
            SaveMapDialog dialog = new SaveMapDialog(map);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pctPreview.Image = null;
                pctPreview.Tag = null;
                pctPreview.Invalidate();
                txtMapFilePath.Text = string.Empty;
                UpdateStatus(string.Format("Map saved to {0}", dialog.SavedFile));
            }
        }

        private void UpdateMapHandler(object map, CommonLibraries.ProceduralAlgorithms.ProceduralAlgorithmCallbackEventArgs e)
        {
            //Thread.Sleep((int)(e.DelayInSeconds * 1000));
            //pctPreview.Invoke(new DrawMapDelegate(DrawMap), map);
        }

        private void MapGenerationComplete(Task task)
        {
            if (task.IsFaulted)
            {
                UpdateStatus("An error occurred while generating the map: " + task.Exception.Message);
            }
            else if (task.IsCanceled)
            {
                UpdateStatus("Map generation was canceled.");
            }
            else
            {
                if (_map != null)
                {
                    DrawMap(_map);
                    pctPreview.Tag = _map;
                    UpdateStatus("Map generation completed successfully.");
                }
                else
                {
                    UpdateStatus("Map generation completed, but no map was returned.");
                }
            }

            this.BackgroundTaskComplete_Event -= MapGenerationComplete;
        }

        private void btnGetMapFile_Click(object sender, EventArgs e)
        {
            string filePath;
            if (LoadFile("Maps|*.txt", out filePath))
            {
                try
                {
                    Map map = new Map(filePath);
                    UpdateStatus(map.Grid.MapText);
                    DrawMap(map);
                    pctPreview.Tag = map;
                }
                catch (Exception)
                {
                    UpdateStatus(string.Format("Unable to use file {0}", filePath));
                    return;
                }
                txtMapFilePath.Text = filePath;
            }
        }

        private void btnGenerateDiamondSquare_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            decimal baseValue;
            decimal spread;

            if (ValidateDiamondSquareFields(out width, out height, out baseValue, out spread))
            {
                _map = null;
                ColorMap colorMap = cmbColorMap.GetSelectedItem<ColorMap>();
                MapParser.ColorMapStyle colorMapStyle = (MapParser.ColorMapStyle)cmbColorMapStyle.SelectedItem;
                Map map = new Map(width, height);
                this.BackgroundTaskComplete_Event += MapGenerationComplete;
                StartTaskInNewThread(() => { RunDiamondSquare(map, baseValue, spread, colorMap, colorMapStyle); });
            }
            else
            {
                UpdateStatus("Unable to generate map from entered values. Please enter valid values in the fields.");
            }
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pctPreview.Tag != null)
            {
                SaveImage();
            }
            else
            {
                UpdateStatus("Please generate a map before saving.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pctPreview.Image != null)
            {
                Clipboard.SetImage(pctPreview.Image);
            }
            else
            {
                UpdateStatus("Please generate a map before saving.");
            }
        }

        private void btnRandomWalkGenerate_Click(object sender, EventArgs e)
        {
            Position position = Position.Null;
            bool avoidEdges = false;
            bool avoidClusters = false;
            if (ValidateRandomWalkFields(out int width, out int height, out int iterations, out position, out avoidEdges, out avoidClusters))
            {
                _map = null;
                Map m = new Map(width, height);
                this.BackgroundTaskComplete_Event += MapGenerationComplete;
                StartTaskInNewThread(() => { RunRandomWalk(m, position, iterations, avoidEdges, avoidClusters); });
            }
            else
            {
                UpdateStatus("Unable to generate map from entered values. Please enter valid values in the fields.");
            }
        }

        private void btnGenerateCellAutomata_Click(object sender, EventArgs e)
        {
            bool avoidEdges = false;
            if (ValidateCellAutomataFields(out int width, out int height, out int iterations, out avoidEdges))
            {
                _map = null;
                Map m = new Map(width, height);
                this.BackgroundTaskComplete_Event += MapGenerationComplete;
                StartTaskInNewThread(() => { RunCellAutomata(m, iterations, avoidEdges); });
            }
            else
            {
                UpdateStatus("Unable to generate map from entered values. Please enter valid values in the fields.");
            }
        }

        private void btn_ManageColorMaps_Click(object sender, EventArgs e)
        {
            ManageColorMapDialog dialog = new ManageColorMapDialog(_settings["ColorMaps"]);
            dialog.FormClosed += Dialog_FormClosed;
            dialog.Show();
        }

        private void Dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManageColorMapDialog dialog = sender as ManageColorMapDialog;
            GetColorMaps();

            dialog.FormClosed -= Dialog_FormClosed;
        }

        private void uxGenerateRandomDungeon_Click(object sender, EventArgs e)
        {
            int x, y, numOfRooms;
            Tuple<int, int> minSizeOfRooms;
            Tuple<int, int> maxSizeOfRooms;
            if (ValidateRandomDungeonFields(out x, out y, out numOfRooms, out minSizeOfRooms, out maxSizeOfRooms))
            {
                _map = null;
                Map map = new Map(x, y);
                this.BackgroundTaskComplete_Event += MapGenerationComplete;
                StartTaskInNewThread(() => RunRandomDungeonCreator(map, numOfRooms, minSizeOfRooms, maxSizeOfRooms));
            }
            else
            {
                UpdateStatus("Unable to generate map from entered values. Please enter valid values in the fields.");
            }

        }

        private void uxMinXYOfRooms_ValueChanged(object sender, EventArgs e)
        {
            uxMaxXOfRooms.Minimum = uxMinXOfRooms.Value + 1;
            uxMaxYOfRooms.Minimum = uxMinYOfRooms.Value + 1;
        }

        private void uxGeneratePerlinNoise_Click(object sender, EventArgs e)
        {
            if (ValidatePerlinNoiseFields(out int width, out int height, out int octaves, out decimal persistence, out decimal frequency, out decimal amplitude, out bool useComplexGrid))
            {
                _map = null;
                Map m = new Map(width, height);
                this.BackgroundTaskComplete_Event += MapGenerationComplete;
                StartTaskInNewThread(() => { RunPerlinNoise(m, octaves, persistence, frequency, amplitude, useComplexGrid); });
            }
            else
            {
                UpdateStatus("Unable to generate map from entered values. Please enter valid values in the fields.");
            }
        }
    }
}
