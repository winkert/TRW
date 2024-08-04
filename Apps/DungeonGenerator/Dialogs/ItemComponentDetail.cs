using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DungeonGenerator.Dialogs
{
    public partial class ItemComponentDetail : Form, IDungeonComponentDetail
    {
        internal DungeonLootCollection Collection { get; set; }
        DungeonLoot _loot;

        public ItemComponentDetail()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _loot = null;
        }

        public void CopyNew()
        {
            _loot = new DungeonLoot() { Name = "New" };
            Collection.Add(_loot);
            LoadDetailScreen(_loot, null);
        }

        public void LoadDetailScreen(IDungeonComponentBase property, string filePath)
        {
            _loot = (DungeonLoot)property;
            uxName.Text = _loot.Name;
            uxDescription.Text = _loot.Description;
            uxValue.Text = _loot.Value.ToString("0.00");
            uxWeight.Text = _loot.Weight.ToString("0.00");
        }

        public IDungeonComponentBase Save()
        {
            _loot.Name = uxName.Text;
            _loot.Description = uxDescription.Text;
            _loot.Value = decimal.Parse(uxValue.Text);
            _loot.Weight = decimal.Parse(uxWeight.Text);

            return _loot;
        }

        public void SetEditMode(bool editMode)
        {
            uxName.Enabled = editMode;
            uxDescription.Enabled = editMode;
            uxValue.Enabled = editMode;
            uxWeight.Enabled = editMode;
        }

        public bool ValidateScreen()
        {
            if(!string.IsNullOrEmpty(uxValue.Text))
            {
                if(!decimal.TryParse(uxValue.Text, out _))
                {
                    errorProvider1.SetError(uxValue, "Value must be a decimal");
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(uxWeight.Text))
            {
                if (!decimal.TryParse(uxWeight.Text, out _))
                {
                    errorProvider1.SetError(uxWeight, "Weight must be a decimal");
                    return false;
                }
            }
            return true;
        }

        public void FillParentListView(DataGridView listview)
        {
            listview.Rows.Clear();
            foreach (DungeonLoot loot in Collection)
            {
                int rowId = listview.Rows.Add(loot);
                listview.Rows[rowId].Tag = loot;
            }
        }

        public void Remove(IDungeonComponentBase itemToRemove)
        {
            Collection.Remove((DungeonLoot)itemToRemove);
        }
    }
}
