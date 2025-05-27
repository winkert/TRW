using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.GameLibraries.Maps;

namespace TRW.Apps.MapGenerator
{
    public partial class ManageColorMapDialog : Form
    {
        public ManageColorMapDialog()
        {
            InitializeComponent();
            CreateNewButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.AddButtonImage;
            DeleteButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.DeleteButtonImage;
        }

        public ManageColorMapDialog(string colorMapFilePath)
            : this()
        {
            _colorMaps = new List<ColorMap>();
            _colorMapFilePath = colorMapFilePath;
        }

        private List<ColorMap> _colorMaps;
        private string _colorMapFilePath;
        private ColorMap _selectedMap;
        private bool _editMode;

        public static IEnumerable<ColorMap> DeserializeColorMaps(string folderPath)
        {
            foreach (string file in System.IO.Directory.EnumerateFiles(folderPath, "*.ColorMap"))
            {
                yield return TRW.CommonLibraries.Serialization.BinarySerializationRoutines.DeserializeFromFile<ColorMap>(file);
            }
        }

        public static void SerializeColorMaps(string folderPath, params ColorMap[] maps)
        {
            foreach (ColorMap map in maps)
            {
                TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeToFile(map, System.IO.Path.Combine(folderPath, $"{map.Name}.ColorMap"));
            }
        }

        private void SaveGridToMap(ColorMap map)
        {
            map.Clear();
            foreach (DataGridViewRow row in ColorMapDetailDataGridView.Rows)
            {
                if (row.IsNewRow)
                    break;

                GetColorFromRow(row.Index, out int r, out int g, out int b);
                map.Add(Convert.ToDecimal(row.Cells[ValueColumn.Index].Value), r, g, b);
            }
        }

        private void LoadDetailsFromMap(ColorMap map)
        {
            ColorMapDetailDataGridView.Rows.Clear();
            foreach (KeyValuePair<decimal, Color> color in map)
            {
                int row = ColorMapDetailDataGridView.Rows.Add();
                ColorMapDetailDataGridView.Rows[row].Cells[ValueColumn.Index].Value = color.Key;
                SetColorForRow(row, color.Value);
            }
        }

        private Bitmap GetColorPreview(Color color)
        {
            Bitmap colorPreview = new Bitmap(50, 20);
            using (Graphics g = Graphics.FromImage(colorPreview))
                g.Clear(color);
            return colorPreview;
        }

        private void SetEditMode(bool isEditMode)
        {
            if (isEditMode)
            {
                EditSaveButton.Text = "Save";
            }
            else
            {
                EditSaveButton.Text = "Edit";
            }

            CancelEditButton.Enabled = isEditMode;
            uxColorMapList.Enabled = !isEditMode;
            CreateNewButton.Enabled = !isEditMode;
            DeleteButton.Enabled = !isEditMode;
            ColorMapDetailDataGridView.Enabled = isEditMode;
            _editMode = isEditMode;
        }

        private void GetColorFromRow(int rowIndex, out int r, out int g, out int b)
        {
            DataGridViewRow row = ColorMapDetailDataGridView.Rows[rowIndex];
            r = Convert.ToInt32(row.Cells[RColumn.Index].Value);
            b = Convert.ToInt32(row.Cells[BColumn.Index].Value);
            g = Convert.ToInt32(row.Cells[GColumn.Index].Value);
        }
        private void SetColorForRow(int rowIndex, Color color)
        {
            SetColorForRow(rowIndex, color.R, color.G, color.B);
        }
        private void SetColorForRow(int rowIndex, int r, int g, int b)
        {
            DataGridViewRow row = ColorMapDetailDataGridView.Rows[rowIndex];
            row.Cells[RColumn.Index].Value = r;
            row.Cells[GColumn.Index].Value = g;
            row.Cells[BColumn.Index].Value = b;

            DataGridViewImageCell colorPreviewCell = (DataGridViewImageCell)row.Cells[ColorPreviewColumn.Index];
            colorPreviewCell.Value = GetColorPreview(Color.FromArgb(r, g, b));
        }

        private void ManageColorMapDialog_Load(object sender, EventArgs e)
        {
            foreach (ColorMap map in DeserializeColorMaps(_colorMapFilePath))
            {
                _colorMaps.Add(map);
                var item = uxColorMapList.Items.Add(map.Name);
                item.Tag = map;
            }

            SetEditMode(false);
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            if (_selectedMap != null)
            {
                if (_editMode)
                {
                    SaveGridToMap(_selectedMap);
                    SetEditMode(false);
                }
                else
                {
                    SetEditMode(true);
                }
            }
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            if (_selectedMap != null)
                LoadDetailsFromMap(_selectedMap);

            SetEditMode(false);
        }

        private void uxColorMapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxColorMapList.SelectedIndices.Count > 0)
            {
                _selectedMap = (ColorMap)uxColorMapList.SelectedItems[0].Tag;
                LoadDetailsFromMap(_selectedMap);
                SetEditMode(false);
            }
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            TRW.Apps.TrwAppsBase.Forms.TextInputDialog textInput = new TrwAppsBase.Forms.TextInputDialog();
            if (textInput.ShowDialog("New Map", "Enter name for a new color map") == DialogResult.OK)
            {
                ColorMap map = new ColorMap(textInput.Value);
                _colorMaps.Add(map);
                uxColorMapList.Items.Add(map.Name).Tag = map;
                uxColorMapList.SelectedIndices.Add(uxColorMapList.Items.Count - 1);
                SetEditMode(true);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (uxColorMapList.SelectedIndices.Count > 0)
            {
                int selected = uxColorMapList.SelectedIndices[0];
                _colorMaps.RemoveAt(selected);
                uxColorMapList.Items.RemoveAt(selected);
            }
            SetEditMode(false);
        }

        private void ColorMapDetailDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColorPreviewColumn.Index)
            {
                int row = e.RowIndex;
                GetColorFromRow(row, out int r, out int g, out int b);
                colorDialog1.Color = Color.FromArgb(r, g, b);
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    SetColorForRow(row, colorDialog1.Color);
                }
            }
        }

        private void ManageColorMapDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (MessageBox.Show("Would you like to save changes to all maps?", "Save to Disk", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    string[] files = System.IO.Directory.GetFiles(_colorMapFilePath, "*.ColorMap");
                    foreach (string file in files)
                    {
                        try
                        {
                            if (System.IO.File.Exists(file))
                                System.IO.File.Delete(file);
                        }
                        catch (System.IO.IOException)
                        {
                            continue;
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                    SerializeColorMaps(_colorMapFilePath, _colorMaps.ToArray());
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
