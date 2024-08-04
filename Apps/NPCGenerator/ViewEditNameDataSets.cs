using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.NPCGenerator
{
    public partial class ViewEditNameDataSets : Form
    {
        NPCGenerator _mainForm;

        public ViewEditNameDataSets()
        {
            InitializeComponent();
        }

        public ViewEditNameDataSets(NPCGenerator mainForm)
            : this()
        {
            _mainForm = mainForm;
            PopulateListView();
            if (this.NameDataSetListView.Items.Count > 0)
                this.NameDataSetListView.SelectedIndex = 0;
        }

        private void PopulateListView()
        {
            this.NameDataSetListView.Items.Clear();
            foreach (KeyValuePair<string, string> nameDataSet in _mainForm._nameDataSets)
            {
                NameDataSet item = new NameDataSet(nameDataSet);
                this.NameDataSetListView.Items.Add(item);
            }
        }

        private void PopulateGridView(DataGridView grid, NameData dataSet)
        {
            grid.Rows.Clear();
            foreach(KeyValuePair<string, int> name in dataSet)
            {
                AddRow(grid, name.Key, name.Value);
            }
        }

        private void AddRow(DataGridView grid, string data)
        {
            string[] splitData = data.Split('|', ',', (char)9);
            AddRow(grid, splitData[0], int.Parse(splitData[1]));
        }

        private void AddRow(DataGridView grid, string name, int frequency)
        {
            // not sure but I may want to ditch Order as a field you can set and use it internally
            grid.Rows.Add(name, frequency);
        }

        private void AppendLines(string[] data)
        {
            TabPage selectedTab = NameDataSetDetailsTab.SelectedTab;
            DataGridView grid;
            if (selectedTab.Equals(tabPage1))
            {
                grid = MaleNamesGridView;
            }
            else if (selectedTab.Equals(tabPage2))
            {
                grid = FemaleNamesGridView;
            }
            else
            {
                grid = SurnameGridView;
            }
            foreach (string line in data)
            {
                AddRow(grid, line);
            }
        }

        private void UpdateXmlFiles(string rootPath)
        {
            NameData maleNamesDataSet = new NameData();
            foreach (DataGridViewRow row in MaleNamesGridView.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                maleNamesDataSet.Add(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value));
            }
            maleNamesDataSet.WriteXml(System.IO.Path.Combine(rootPath, NPCGenerator._maleNameFileName));
            NameData femaleNamesDataSet = new NameData();
            foreach (DataGridViewRow row in FemaleNamesGridView.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                femaleNamesDataSet.Add(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value));
            }
            femaleNamesDataSet.WriteXml(System.IO.Path.Combine(rootPath, NPCGenerator._femaleNameFileName));
            NameData surnameNamesDataSet = new NameData();
            foreach (DataGridViewRow row in SurnameGridView.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                surnameNamesDataSet.Add(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value));
            }
            surnameNamesDataSet.WriteXml(System.IO.Path.Combine(rootPath, NPCGenerator._surnameFileName));
        }

        private void CreateXmlFiles(string rootPath)
        {
            if (!System.IO.Directory.Exists(rootPath))
                System.IO.Directory.CreateDirectory(rootPath);

            NameData maleNamesDataSet = new NameData();
            maleNamesDataSet.WriteXml(System.IO.Path.Combine(rootPath, NPCGenerator._maleNameFileName));
            NameData femaleNamesDataSet = new NameData();
            femaleNamesDataSet.WriteXml(System.IO.Path.Combine(rootPath, NPCGenerator._femaleNameFileName));
            NameData surnameNamesDataSet = new NameData();
            surnameNamesDataSet.WriteXml(System.IO.Path.Combine(rootPath, NPCGenerator._surnameFileName));
        }
        private void AddNewDataSet(string name)
        {
            string subFolder = System.IO.Path.Combine(_mainForm._includesPath, name);
            _mainForm._nameDataSets.Add(name, subFolder);
            CreateXmlFiles(subFolder);
            PopulateListView();
        }

        private void NameDataSetListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameDataSet selectedItem = this.NameDataSetListView.SelectedItem as NameDataSet;
            string rootPath = selectedItem.Item2;
            NameData dataSet = new NameData();
            dataSet.ReadXml(System.IO.Path.Combine(rootPath, NPCGenerator._maleNameFileName));
            PopulateGridView(MaleNamesGridView, dataSet);
            dataSet.ReadXml(System.IO.Path.Combine(rootPath, NPCGenerator._femaleNameFileName));
            PopulateGridView(FemaleNamesGridView, dataSet);
            dataSet.ReadXml(System.IO.Path.Combine(rootPath, NPCGenerator._surnameFileName));
            PopulateGridView(SurnameGridView, dataSet);

        }

        internal class NameDataSet : Tuple<string, string>
        {
            internal NameDataSet(KeyValuePair<string, string> pair)
                : base(pair.Key, pair.Value)
            {

            }

            public override string ToString()
            {
                return base.Item1;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //need to transfer the datagridviews to the internal table of each set and save
            if (this.NameDataSetListView.SelectedItem == null)
                return;

            NameDataSet item = this.NameDataSetListView.SelectedItem as NameDataSet;
            if (!_mainForm._nameDataSets.ContainsKey(item.Item1))
            {
                _mainForm._nameDataSets.Add(item.Item1, item.Item2);
            }
            UpdateXmlFiles(item.Item2);

            _mainForm.RefreshData();
        }

        private void ImportNewFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNameDataSetDialog dialog = new NewNameDataSetDialog(_mainForm._nameDataSets.Keys.ToHashSet<string>(), true);
            dialog.FormClosed += NewNameDataSetDialog_FormClosed;
            dialog.Show();
        }

        private void AppendFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string file;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                file = ofd.FileName;
                AppendLines(System.IO.File.ReadAllLines(file));
            }
        }

        private void AppendFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string data = Clipboard.GetText();
                string[] lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                AppendLines(lines);
            }
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the new name and create the new set
            NewNameDataSetDialog dialog = new NewNameDataSetDialog(_mainForm._nameDataSets.Keys.ToHashSet<string>(), false);
            dialog.FormClosed += NewNameDataSetDialog_FormClosed;
            dialog.Show();
        }

        private void NewNameDataSetDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            NewNameDataSetDialog dialog = sender as NewNameDataSetDialog;

            if (string.IsNullOrEmpty(dialog.NameDataSetName))
                return;

            AddNewDataSet(dialog.NameDataSetName);
            _mainForm.RefreshData();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NameDataSetListView.SelectedItem != null)
            {
                NameDataSet setToDelete = NameDataSetListView.SelectedItem as NameDataSet;
                _mainForm._nameDataSets.Remove(setToDelete.Item1);
                if (System.IO.Directory.Exists(setToDelete.Item2))
                    System.IO.Directory.Delete(setToDelete.Item2, true);

                PopulateListView();
                _mainForm.RefreshData();
            }
        }
    }
}
