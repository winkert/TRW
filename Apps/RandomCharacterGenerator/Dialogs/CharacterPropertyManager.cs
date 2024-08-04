using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.Apps.TrwAppsBase;
using TRW.CommonLibraries.Xml;
using TRW.GameLibraries.Character;
using TRW.GameLibraries.Character.DnD;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class CharacterPropertyManager<PropertyV> : TrwFormBase where PropertyV : CharacterPropertyBase, IXmlData, new()
    {
        private string _propertyXmlPath;
        private IPropertyDetailsForm _detailsForm;
        private Dictionary<string, PropertyV> _propertiesAndFiles;
        private PropertyItem<PropertyV> _selectedItem;
        private RandomCharacterGenerator _parent;

        public CharacterPropertyManager()
        {
            InitializeComponent();
        }

        public CharacterPropertyManager(RandomCharacterGenerator parent, string path)
            : this()
        {
            this._parent = parent;
            this._propertyXmlPath = path;
            LoadPropertiesList();
            SetUpDetailPanel();
            this.SetEditMode(false);
        }

        private void LoadProperty(PropertyItem<PropertyV> item)
        {
            this._detailsForm.Clear();
            this._detailsForm.LoadDetailScreen(item.Property, item.FilePath);
            this.PropertyCategoryTextBox.Text = item.Property.Category;
            this.SetEditMode(false);
        }

        private void SetEditMode(bool edit)
        {
            this._detailsForm.SetEditMode(edit);
            this.AddPropertyButton.Enabled = !edit;
            this.EditPropertyButton.Enabled = !edit;
            this.CancelEditPropertyButton.Enabled = edit;
            this.SavePropertyButton.Enabled = edit;
            this.DeletePropertyButton.Enabled = edit;
            this.CopyPropertyButton.Enabled = !edit;
            this.PropertyListBox.Enabled = !edit;
            this.PropertyCategoryTextBox.Enabled = edit;
        }

        private void SetUpDetailPanel()
        {
            if (typeof(PropertyV) == typeof(DnDCharacterRace))
            {
                _detailsForm = this.PropertyManagerContainer.AddSubForm<CharacterRacePropertyDetails>();
            }
            else if (typeof(PropertyV) == typeof(DnDCharacterClass))
            {
                _detailsForm = this.PropertyManagerContainer.AddSubForm<CharacterClassPropertyDetails>();
            }
            else if (typeof(PropertyV) == typeof(DnDCharacterBackground))
            {
                _detailsForm = this.PropertyManagerContainer.AddSubForm<CharacterBackgroundPropertyDetails>();
            }
            else
            {
                throw new Exception(string.Format("Unable to determine property detail form for type {0}", typeof(PropertyV)));
            }
        }

        private void LoadPropertiesList()
        {
            this.PropertyListBox.Items.Clear();
            if (!string.IsNullOrWhiteSpace(_propertyXmlPath))
            {
                _propertiesAndFiles = new Dictionary<string, PropertyV>();
                foreach (string file in System.IO.Directory.EnumerateFiles(_propertyXmlPath, "*.xml", System.IO.SearchOption.AllDirectories))
                {
                    try
                    {
                        PropertyV item = new PropertyV();
                        item.ReadXml(file);
                        _propertiesAndFiles.Add(file, item);
                    }
                    catch (Exception e)
                    {
                        // don't want to throw an exception just because there is a junk file in there
                        base.WriteLog(string.Format("Unexpected error create {0} from file {1}: {2}", typeof(PropertyV), file, e));
                    }
                }
                // create property collection and set up filter list
                RefreshFilterList();
                RefreshList();
            }
        }

        internal class PropertyItem<P>
        {
            private P _property;
            private string _path;

            internal PropertyItem(P property, string file)
            {
                _property = property;
                _path = file;
            }

            internal P Property { get { return _property; } set { _property = value; } }
            internal string FilePath => _path;


            public override string ToString()
            {
                return _property.ToString();
            }
        }

        private void RefreshFilterList()
        {
            CharacterPropertyCollection<PropertyV> propertyCollection = new CharacterPropertyCollection<PropertyV>(_propertiesAndFiles.Values);
            foreach (string category in propertyCollection.Categories)
            {
                if (this.CategoryFilterDropDownMenu.DropDownItems.ContainsMenuItem(category))
                    continue;

                ToolStripMenuItem filterMenu = (ToolStripMenuItem)this.CategoryFilterDropDownMenu.DropDownItems.Add(category);
                filterMenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
                filterMenu.CheckOnClick = true;
                filterMenu.Checked = true;
                filterMenu.CheckedChanged += FilterMenu_CheckedChanged;
                filterMenu.DropDown.AutoClose = false;
            }
        }

        private void RefreshList()
        {
            // need to account for filters
            List<string> filters = new List<string>();
            foreach(ToolStripMenuItem item in CategoryFilterDropDownMenu.DropDownItems)
            {
                if(item.Checked)
                {
                    filters.Add(item.Text);
                }
            }

            _selectedItem = null;
            this.PropertyListBox.Items.Clear();
            foreach (var item in _propertiesAndFiles)
            {
                if(filters.Contains(item.Value.Category))
                    this.PropertyListBox.Items.Add(new PropertyItem<PropertyV>(item.Value, item.Key));
            }
        }

        private void PropertyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _selectedItem = this.PropertyListBox.SelectedItem as PropertyItem<PropertyV>;
                if(_selectedItem != null)
                    LoadProperty(_selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddPropertyButton_Click(object sender, EventArgs e)
        {
            _detailsForm.Clear();
            this.SetEditMode(true);
            _selectedItem = null;
        }

        private void EditPropertyButton_Click(object sender, EventArgs e)
        {
            this.SetEditMode(true);
        }

        private void SavePropertyButton_Click(object sender, EventArgs e)
        {
            if (this._detailsForm.ValidateScreen())
            {
                if (_selectedItem == null)
                {
                    // we have a new file
                    PropertyV newProperty = this._detailsForm.Save() as PropertyV;
                    newProperty.Category = this.PropertyCategoryTextBox.Text;
                    string categoryPath = System.IO.Path.Combine(_propertyXmlPath, newProperty.Category);
                    if (!System.IO.Directory.Exists(categoryPath))
                        System.IO.Directory.CreateDirectory(categoryPath);

                    string newFilePath = System.IO.Path.Combine(categoryPath, string.Format("{0}.xml", newProperty.Name.Replace(' ', '_')));
                    _selectedItem = new PropertyItem<PropertyV>(newProperty, newFilePath);
                    _propertiesAndFiles.Add(newFilePath, newProperty);
                }
                else
                {
                    _selectedItem.Property = this._detailsForm.Save() as PropertyV;
                    _selectedItem.Property.Category = this.PropertyCategoryTextBox.Text;
                }
                string filePath = _selectedItem.FilePath;
                _selectedItem.Property.WriteXml(filePath);
                _propertiesAndFiles[filePath] = _selectedItem.Property;
                this.SetEditMode(false);
                RefreshFilterList();
                RefreshList();
            }
        }

        private void DeletePropertyButton_Click(object sender, EventArgs e)
        {
            _selectedItem = PropertyListBox.SelectedItem as PropertyItem<PropertyV>;
            // remove item from list
            _propertiesAndFiles.Remove(_selectedItem.FilePath);
            // delete file (try and ignore if failed?)
            try
            {
                if(System.IO.File.Exists(_selectedItem.FilePath))
                    System.IO.File.Delete(_selectedItem.FilePath);
            }
            catch { }

            RefreshFilterList();
            RefreshList();
        }

        private void CancelEditPropertyButton_Click(object sender, EventArgs e)
        {
            this.SetEditMode(false);
        }

        private void CopyPropertyButton_Click(object sender, EventArgs e)
        {
            this.SetEditMode(true);
            _detailsForm.CopyNew();
            _selectedItem = null;
        }

        private void FilterMenu_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

    }
}
