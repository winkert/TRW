using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.Apps.TrwAppsBase;

namespace DungeonGenerator.Dialogs
{
    public partial class EditComponentsDialog<ComponentType, P> : Form where ComponentType : Form, IDungeonComponentDetail, new() where P : IDungeonComponentBase
    {


        public ComponentType ComponentDetail { get; set; }

        public EditComponentsDialog()
        {
            InitializeComponent();
        }
        public EditComponentsDialog(ComponentType detailSubForm)
            : this()
        {
            SetUpDetailPanel(detailSubForm);
            FillListOfComponents();
        }

        private void FillListOfComponents()
        {
            ComponentDetail.FillParentListView(uxComponentListView);

        }

        private void SetUpDetailPanel(ComponentType detailSubForm)
        {
            ComponentDetail = detailSubForm;
            uxComponentDetailsHost.AddSubForm(ComponentDetail);
        }

        private void SetEditMode(bool edit)
        {
            ComponentDetail.SetEditMode(edit);
            uxComponentListView.Enabled = !edit;
            uxAddComponentButton.Enabled = !edit;
            uxEditComponentButton.Enabled = true;
            if (edit)
            {
                uxEditComponentButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.SaveButtonImage;
                uxEditComponentButton.Text = "Save";
                uxEditComponentButton.ToolTipText = "Save";
            }
            else
            {
                uxEditComponentButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.EditButtonImage;
                uxEditComponentButton.Text = "Edit";
                uxEditComponentButton.ToolTipText = "Edit";
            }


            uxDeleteComponentButton.Enabled = !edit;
            uxCloseButton.Enabled = !edit;
        }

        private void EditComponentsDialog_Load(object sender, EventArgs e)
        {
            uxAddComponentButton.Image = TrwFormBase.AddButtonImage;
            uxEditComponentButton.Image = TrwFormBase.EditButtonImage;
            uxDeleteComponentButton.Image = TrwFormBase.DeleteButtonImage;
            SetEditMode(false);
        }

        private void uxCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uxAddComponentButton_Click(object sender, EventArgs e)
        {
            ComponentDetail.CopyNew();
            ComponentDetail.FillParentListView(uxComponentListView);
            uxComponentListView.Select(uxComponentListView.Rows.Count - 1);
            SetEditMode(true);
        }

        private void uxEditComponentButton_Click(object sender, EventArgs e)
        {
            if (uxComponentListView.SelectedRows.Count > -1)
            {
                int selected = uxComponentListView.SelectedRow().Index;
                switch (((ToolStripButton)sender).Text)
                {
                    case "Save":
                        if (ComponentDetail.ValidateScreen())
                        {
                            ComponentDetail.Save(); // interface expects to return the object saved, but we are passing the object around in a list
                            ComponentDetail.FillParentListView(uxComponentListView);
                            uxComponentListView.Select(selected);
                        }
                        SetEditMode(false);
                        break;
                    case "Edit":
                        SetEditMode(true);
                        break;
                    default:
                        throw new Exception($"Unrecognized command from edit/save button [{((ToolStripButton)sender).Text}]");
                }
            }
        }

        private void uxDeleteComponentButton_Click(object sender, EventArgs e)
        {
            if (uxComponentListView.SelectedRows.Count > -1)
            {
                P selected = (P)uxComponentListView.SelectedRow().Tag;
                if (MessageBox.Show($"Are you sure you want to delete {selected.Name}? You will not be able to recover it.", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ComponentDetail.Remove(selected);
                    ComponentDetail.FillParentListView(uxComponentListView);
                }
            }

        }

        private void uxComponentListView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId > -1)
            {
                P component = (P)uxComponentListView.Rows[rowId].Tag;
                if (component == null)
                    return;
                ComponentDetail.LoadDetailScreen(component, null);  // interface expects to save to file, but we are passing the object around in a list
            }
        }
    }
}
