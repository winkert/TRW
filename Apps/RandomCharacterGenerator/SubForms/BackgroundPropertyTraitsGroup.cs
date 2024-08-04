using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.GameLibraries.Character;
using TRW.GameLibraries.Character.DnD;
using TRW.Apps.TrwAppsBase;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class BackgroundPropertyTraitsGroup : TrwFormBase
    {
        public BackgroundPropertyTraitsGroup()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.TraitsListBox.Items.Clear();
            this.FlawsListBox.Items.Clear();
            this.BondsListBox.Items.Clear();
            this.IdealsListBox.Items.Clear();
        }

        public void Populate(List<DnDBackgroundPersonalityTrait> traits, List<DnDBackgroundFlaw> flaws, List<DnDBackgroundIdeal> ideals, List<DnDBackgroundBond> bonds)
        {
            foreach (DnDBackgroundPersonalityTrait trait in traits)
            {
                AddPersonalityTrait(trait);
            }
            foreach (DnDBackgroundFlaw flaw in flaws)
            {
                AddFlaw(flaw);
            }
            foreach (DnDBackgroundBond bond in bonds)
            {
                AddBond(bond);
            }
            foreach (DnDBackgroundIdeal ideal in ideals)
            {
                AddIdeal(ideal);
            }
        }

        public List<DnDBackgroundPersonalityTrait> GetPersonalityTraits()
        {
            return GetItemsAsList<DnDBackgroundPersonalityTrait>(this.TraitsListBox);
        }

        public List<DnDBackgroundFlaw> GetFlaws()
        {
            return GetItemsAsList<DnDBackgroundFlaw>(this.FlawsListBox);
        }

        public List<DnDBackgroundBond> GetBonds()
        {
            return GetItemsAsList<DnDBackgroundBond>(this.BondsListBox);
        }

        public List<DnDBackgroundIdeal> GetIdeals()
        {
            return GetItemsAsList<DnDBackgroundIdeal>(this.IdealsListBox);
        }

        public void AddPersonalityTrait(DnDBackgroundPersonalityTrait trait)
        {
            this.TraitsListBox.Items.Add(trait);
        }

        public void AddFlaw(DnDBackgroundFlaw flaw)
        {
            this.FlawsListBox.Items.Add(flaw);
        }

        public void AddBond(DnDBackgroundBond bond)
        {
            this.BondsListBox.Items.Add(bond);
        }

        public void AddIdeal(DnDBackgroundIdeal ideal)
        {
            this.IdealsListBox.Items.Add(ideal);
        }

        #region Event Handlers
        private void AddTraitButton_Click(object sender, EventArgs e)
        {
            AddFeatureDialog dialog = new AddFeatureDialog();
            dialog.FormClosed += AddTraitDialog_FormClosed;
            dialog.Show();
        }

        private void AddTraitDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddFeatureDialog dialog = sender as AddFeatureDialog;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddPersonalityTrait(new DnDBackgroundPersonalityTrait(dialog.Feature.Name, dialog.Feature.Description));
                }
                else
                {
                    this.TraitsListBox.Items[dialog.Index] = new DnDBackgroundPersonalityTrait(dialog.Feature.Name, dialog.Feature.Description);
                }
            }
        }

        private void EditTraitButton_Click(object sender, EventArgs e)
        {
            if (this.TraitsListBox.SelectedIndex > -1)
            {
                AddFeatureDialog dialog = new AddFeatureDialog((DnDBackgroundPersonalityTrait)this.TraitsListBox.SelectedItem, this.TraitsListBox.SelectedIndex);
                dialog.FormClosed += AddTraitDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeletetTraitButton_Click(object sender, EventArgs e)
        {
            if (this.TraitsListBox.SelectedIndex > -1)
                this.TraitsListBox.Items.RemoveAt(this.TraitsListBox.SelectedIndex);
        }

        private void AddFlawButton_Click(object sender, EventArgs e)
        {
            AddFeatureDialog dialog = new AddFeatureDialog();
            dialog.FormClosed += AddFlawDialog_FormClosed;
            dialog.Show();
        }

        private void AddFlawDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddFeatureDialog dialog = sender as AddFeatureDialog;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddFlaw(new DnDBackgroundFlaw(dialog.Feature.Name, dialog.Feature.Description));
                }
                else
                {
                    this.FlawsListBox.Items[dialog.Index] = new DnDBackgroundFlaw(dialog.Feature.Name, dialog.Feature.Description);
                }
            }
        }

        private void EditFlawButton_Click(object sender, EventArgs e)
        {
            if (FlawsListBox.SelectedIndex > -1)
            {
                AddFeatureDialog dialog = new AddFeatureDialog((DnDBackgroundFlaw)FlawsListBox.SelectedItem, FlawsListBox.SelectedIndex);
                dialog.FormClosed += AddFlawDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteFlawButton_Click(object sender, EventArgs e)
        {
            if (this.FlawsListBox.SelectedIndex > -1)
                this.FlawsListBox.Items.RemoveAt(this.FlawsListBox.SelectedIndex);
        }

        private void AddBondButton_Click(object sender, EventArgs e)
        {
            AddFeatureDialog dialog = new AddFeatureDialog();
            dialog.FormClosed += AddBondDialog_FormClosed;
            dialog.Show();
        }

        private void AddBondDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddFeatureDialog dialog = sender as AddFeatureDialog;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddBond(new DnDBackgroundBond(dialog.Feature.Name, dialog.Feature.Description));
                }
                else
                {
                    this.BondsListBox.Items[dialog.Index] = new DnDBackgroundBond(dialog.Feature.Name, dialog.Feature.Description);
                }
            }
        }

        private void EditBondButton_Click(object sender, EventArgs e)
        {
            if (this.BondsListBox.SelectedIndex > -1)
            {
                AddFeatureDialog dialog = new AddFeatureDialog((DnDBackgroundBond)BondsListBox.SelectedItem, this.BondsListBox.SelectedIndex);
                dialog.FormClosed += AddBondDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteBondButton_Click(object sender, EventArgs e)
        {
            if (this.BondsListBox.SelectedIndex > -1)
                this.BondsListBox.Items.RemoveAt(this.BondsListBox.SelectedIndex);
        }

        private void AddIdealButton_Click(object sender, EventArgs e)
        {
            AddFeatureDialog dialog = new AddFeatureDialog();
            dialog.FormClosed += AddIdealDialog_FormClosed;
            dialog.Show();
        }

        private void AddIdealDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddFeatureDialog dialog = sender as AddFeatureDialog;
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.AddNew)
                {
                    AddIdeal(new DnDBackgroundIdeal(dialog.Feature.Name, dialog.Feature.Description));
                }
                else
                {
                    this.IdealsListBox.Items[dialog.Index] = new DnDBackgroundIdeal(dialog.Feature.Name, dialog.Feature.Description);
                }
            }
        }

        private void EditIdealButton_Click(object sender, EventArgs e)
        {
            if (this.IdealsListBox.SelectedIndex > -1)
            {
                AddFeatureDialog dialog = new AddFeatureDialog((Feature)this.IdealsListBox.SelectedItem, this.IdealsListBox.SelectedIndex);
                dialog.FormClosed += AddIdealDialog_FormClosed;
                dialog.Show();
            }
        }

        private void DeleteIdealButton_Click(object sender, EventArgs e)
        {
            if (this.IdealsListBox.SelectedIndex > -1)
                this.IdealsListBox.Items.RemoveAt(this.IdealsListBox.SelectedIndex);
        }
        #endregion
    }
}
