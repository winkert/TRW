using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.Apps.TrwAppsBase;
using TRW.GameLibraries.GameCore;

namespace DungeonGenerator.Dialogs
{
    public partial class NpcComponentDetail : Form, IDungeonComponentDetail
    {
        internal DungeonNpcCollection Collection { get; set; }
        DungeonNpc _npc;

        public NpcComponentDetail()
        {
            InitializeComponent();
            foreach(var e in Enum.GetValues(typeof(HostilityRatings)))
            {
                uxHostility.Items.Add(e);
            }
        }

        public void Clear()
        {
            _npc = null;
        }

        public void CopyNew()
        {
            _npc = new DungeonNpc();
            Collection.Add(_npc);
            LoadDetailScreen(_npc, null);
        }

        public void LoadDetailScreen(IDungeonComponentBase property, string filePath)
        {
            _npc = (DungeonNpc)property;
            uxName.Text = _npc.Name;
            uxNotes.Text = _npc.Notes;
            uxClass.Text = _npc.Class;
            uxRace.Text = _npc.Race;
            uxChallengeRating.Text = _npc.ChallengeRating.ToString("0.##");
            uxHostility.SelectedItem = _npc.Hostility;
        }

        public IDungeonComponentBase Save()
        {
            _npc.Name = uxName.Text;
            _npc.Notes = uxNotes.Text;
            _npc.Class = uxClass.Text;
            _npc.Race = uxRace.Text;
            _npc.ChallengeRating = decimal.Parse(uxChallengeRating.Text);
            _npc.Hostility = (HostilityRatings)uxHostility.SelectedItem;


            return _npc;
        }

        public void SetEditMode(bool editMode)
        {
            uxName.Enabled = editMode;
            uxNotes.Enabled = editMode;
            uxClass.Enabled = editMode;
            uxRace.Enabled = editMode;
            uxChallengeRating.Enabled = editMode;
            uxHostility.Enabled = editMode;
        }

        public bool ValidateScreen()
        {
            return true;
        }

        public void FillParentListView(DataGridView listview)
        {
            listview.Rows.Clear();
            foreach (DungeonNpc npc in Collection)
            {
                int rowId = listview.Rows.Add(npc);
                listview.Rows[rowId].Tag = npc;
            }
        }

        public void Remove(IDungeonComponentBase itemToRemove)
        {
            Collection.Remove((DungeonNpc)itemToRemove);
        }
    }
}
