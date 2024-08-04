using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TRW.GameLibraries.Character;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class AddFeatureDialog : TRW.Apps.TrwAppsBase.TrwFormBase
    {
        public AddFeatureDialog()
        {
            InitializeComponent();
            this.AddNew = true;
            this.DialogResult = DialogResult.Cancel;
        }

        public AddFeatureDialog(Feature feature, int index)
            :this()
        {
            this.AddNew = false;
            this.Index = index;
            this.Feature = feature;
            this.FeatureNameTextbox.Text = feature.Name;
            this.FeatureDescriptionTextbox.Text = feature.Description;
        }

        public int Index { get; private set; }
        public bool AddNew { get; private set; }

        public Feature Feature { get; private set; }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Feature = new Feature(this.FeatureNameTextbox.Text, this.FeatureDescriptionTextbox.Text);
            this.Close();
        }
    }
}
