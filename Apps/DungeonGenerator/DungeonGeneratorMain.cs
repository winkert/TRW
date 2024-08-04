using DungeonGenerator.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.GameLibraries.Maps;

namespace DungeonGenerator
{
    public partial class DungeonGeneratorMain : TRW.Apps.TrwAppsBase.TrwFormBase
    {
        public DungeonGeneratorMain()
        {
            InitializeComponent();
            InitializeComboboxes();
            this.BackgroundTaskComplete_Event += DungeonGeneratorMain_GenerationTaskComplete;
            string includesPath = Path.Combine(Application.StartupPath, "Includes");
            if (!Directory.Exists(includesPath))
                Directory.CreateDirectory(includesPath);

            if (!_settings.ContainsKey(_npcFileKey))
            {
                _settings.Add(_npcFileKey, Path.Combine(includesPath, _npcFileName));
            }

            if (!_settings.ContainsKey(_lootFileKey))
            {
                _settings.Add(_lootFileKey, Path.Combine(includesPath, _lootFileName));
            }

            LoadDungeonItems();
        }

        #region Fields
        private const string _exportFileFilter = "PNG|*.png|PDF|*.pdf";
        private const string _saveLoadFileFilter = "Dungeon File|*.dng";
        private const string _npcFileKey = "NpcFile";
        private const string _npcFileName = "DungeonNpcs.dcl";
        private const string _lootFileKey = "LootFile";
        private const string _lootFileName = "DungeonLoot.dcl";

        private DungeonNpcCollection _npcCollection;
        private DungeonLootCollection _lootCollection;
        #endregion

        #region Initialization Methods
        private void LoadDungeonItems()
        {
            if (System.IO.File.Exists(_settings[_npcFileKey]))
                _npcCollection = TRW.CommonLibraries.Serialization.BinarySerializationRoutines.DeserializeFromFile<DungeonNpcCollection>(_settings[_npcFileKey]);
            else
            {
                _npcCollection = new DungeonNpcCollection();
                TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeToFile(_npcCollection, _settings[_npcFileKey]);
            }

            if (System.IO.File.Exists(_settings[_lootFileKey]))
                _lootCollection = TRW.CommonLibraries.Serialization.BinarySerializationRoutines.DeserializeFromFile<DungeonLootCollection>(_settings[_lootFileKey]);
            else
            {
                _lootCollection = new DungeonLootCollection();
                TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeToFile(_lootCollection, _settings[_lootFileKey]);
            }


        }

        private void SaveDungeonItems()
        {
            TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeToFile(_npcCollection, _settings[_npcFileKey]);
            TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeToFile(_lootCollection, _settings[_lootFileKey]);
        }

        private void InitializeComboboxes()
        {
            foreach (HallCreationModes mode in Enum.GetValues(typeof(HallCreationModes)))
            {
                uxHallwayStyleCombo.Items.Add(mode);
            }

            foreach (RoomShapes shape in Enum.GetValues(typeof(RoomShapes)))
            {
                uxRoomTypeCombo.Items.Add(shape);
            }

            uxHallwayStyleCombo.SelectedIndex = 0;
            uxRoomTypeCombo.SelectedIndex = 0;
        }
        #endregion

        #region Save and Load Handlers
        private void SaveDungeonFile(string fileName)
        {

        }

        private void LoadDungeonFile(string fileName)
        {

        }
        #endregion

        #region Export Handlers
        private void ExportDungeonAsPng(string fileName)
        {

        }

        private void ExportDungeonAsPdf(string fileName)
        {

        }
        #endregion

        #region Private Methods
        private void EditDungeonItems<T, P>(EditComponentsDialog<T, P> dialog) where T : Form, IDungeonComponentDetail, new() where P : IDungeonComponentBase
        {
            dialog.FormClosed += EditDungeonItemDialog_FormClosed;
            dialog.Show();
        }

        private void DrawMap(Map map)
        {
            Bitmap bmp = MapRenderEngine.DrawMap(map, uxDungeonPreviewPictureBox.Width, uxDungeonPreviewPictureBox.Height);
            uxDungeonPreviewPictureBox.Image = bmp;

            // repaint PictureBox
            uxDungeonPreviewPictureBox.Invalidate();
        }

        private void RunGenerateMap()
        {
            // get map size and features from UI
            int w = (int)uxDungeonWidth.Value;
            int h = (int)uxDungeonHeight.Value;
            int numOfRooms = (int)uxNumberOfRooms.Value;
            int roomMinW = (int)uxMinWOfRooms.Value;
            int roomMinH = (int)uxMinHOfRooms.Value;
            int roomMaxW = (int)uxMaxWOfRooms.Value;
            int roomMaxH = (int)uxMaxHOfRooms.Value;
            bool allowIntersectingRooms = uxAllowIntersectingRoomsCheck.Checked;
            HallCreationModes hallCreationMode = (HallCreationModes)uxHallwayStyleCombo.SelectedItem;
            RoomShapes roomShape = (RoomShapes)uxRoomTypeCombo.SelectedItem;

            // create map and task
            Map map = new Map(w, h);
            map.MapColorMap = ColorMap.Dungeon;
            DungeonGenerationTask task = new DungeonGenerationTask(map, () => GenerateMap(map, numOfRooms, Tuple.Create(roomMinW, roomMinH), Tuple.Create(roomMaxW, roomMaxH), hallCreationMode, roomShape, allowIntersectingRooms));
            StartTask(task);

        }

        private void GenerateMap(Map map, int numberOfRooms, Tuple<int, int> minRoomSizes, Tuple<int, int> maxRoomSizes, HallCreationModes hallCreationMode, RoomShapes roomShape, bool allowIntersectingRooms)
        {
            try
            {
                List<MapComponentBase> resultingParts = map.GenerateRandomDungeon(numberOfRooms, minRoomSizes, maxRoomSizes, hallCreationMode, roomShape, allowIntersectingRooms);
                Dictionary<Room, List<IDungeonComponentBase>> roomsAndThings = new Dictionary<Room, List<IDungeonComponentBase>>();
                Random r = new Random();
                foreach (MapComponentBase part in resultingParts)
                {
                    if (part is Room)
                    {
                        Room thisRoom = (Room)part;
                        roomsAndThings.Add(thisRoom, new List<IDungeonComponentBase>());
                        // determine the number of "things" a room can hold
                        //  NPC CR
                        //  Items
                        //  Containers can hold more items
                        decimal roomCapacity = (thisRoom.SizeX * thisRoom.SizeY) / 3m;
                        int tVal = r.Next(100, 10000);
                        ComponentType itemTypeToAdd;
                        if (tVal % 3 == 0)
                        {
                            itemTypeToAdd = ComponentType.Loot;
                        }
                        else if (tVal % 5 == 0)
                        {
                            itemTypeToAdd = ComponentType.NonPlayerCharacter;
                        }
                        else
                        {
                            itemTypeToAdd = ComponentType.Container;
                        }

                        decimal roomContent = 0m;
                        while(true)
                        {
                            switch(itemTypeToAdd)
                            {
                                case ComponentType.Container:
                                    DungeonLootContainer container = new DungeonLootContainer();
                                    roomsAndThings[thisRoom].Add(container);
                                    roomContent++;
                                    break;
                                case ComponentType.Loot:
                                    DungeonLoot loot = new DungeonLoot();
                                    roomsAndThings[thisRoom].Add(loot);
                                    roomContent++;
                                    break;
                                case ComponentType.NonPlayerCharacter:
                                    DungeonNpc npc = DungeonNpc.GenerateRandom();
                                    roomsAndThings[thisRoom].Add(npc);
                                    roomContent++;
                                    break;
                            }

                            roomsAndThings[thisRoom].Add(null);

                            if (roomContent >= roomCapacity)
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                WriteLog(e.ToString());
            }
        }
        #endregion

        private void uxMinXYOfRooms_ValueChanged(object sender, EventArgs e)
        {
            uxMaxWOfRooms.Minimum = uxMinWOfRooms.Value + 1;
            uxMaxHOfRooms.Minimum = uxMinHOfRooms.Value + 1;
        }

        private void EditDungeonItemDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= EditDungeonItemDialog_FormClosed;
            SaveDungeonItems();// we passed the lists by ref to the dialog for editing
            LoadDungeonItems();
        }

        private void DungeonGeneratorMain_GenerationTaskComplete(Task task)
        {
            if (task.Status == TaskStatus.RanToCompletion)
            {
                if (((DungeonGenerationTask)task).Map != null)
                {
                    DrawMap(((DungeonGenerationTask)task).Map);
                }
            }
        }

        #region Menu Event Handlers
        private void saveDungeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile(_saveLoadFileFilter, out string fileName))
            {
                SaveDungeonFile(fileName);
            }
        }

        private void loadDungeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadFile(_saveLoadFileFilter, out string fileName))
            {
                LoadDungeonFile(fileName);
            }
        }

        private void exportDungeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile(_exportFileFilter, out string fileName))
            {
                string extension = System.IO.Path.GetExtension(fileName);
                if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    ExportDungeonAsPng(fileName);
                }
                else if (extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    ExportDungeonAsPdf(fileName);
                }
                else
                {
                    throw new ArgumentException($"{fileName} has extension that is not supported");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to exit?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void editLootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemComponentDetail detail = new ItemComponentDetail() { Collection = _lootCollection };
            EditComponentsDialog<ItemComponentDetail, DungeonLoot> dialog = new EditComponentsDialog<ItemComponentDetail, DungeonLoot>(detail);
            EditDungeonItems(dialog);
        }

        private void editCreaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NpcComponentDetail detail = new NpcComponentDetail() { Collection = _npcCollection };
            EditComponentsDialog<NpcComponentDetail, DungeonNpc> dialog = new EditComponentsDialog<NpcComponentDetail, DungeonNpc>(detail);
            EditDungeonItems(dialog);
        }
        #endregion

        private void uxGenerateDungeonButton_Click(object sender, EventArgs e)
        {
            RunGenerateMap();
        }

        #region Internal Classes
        public class DungeonGenerationTask : Task
        {
            public DungeonGenerationTask(Map map, Action action) : base(action)
            {
                Map = map;
            }

            public DungeonGenerationTask(Action action, CancellationToken cancellationToken) : base(action, cancellationToken)
            {

            }

            public Map Map { get; set; }

        }
        #endregion

        protected override bool HasConfigFile => true;

        private void DungeonGeneratorMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDungeonItems();
        }
    }
}
