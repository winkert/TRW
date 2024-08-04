using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TRW.GameLibraries.Character;
using TRW.Apps;
using TRW.Apps.TrwAppsBase;

namespace TRW.Apps.RandomCharacterGenerator
{
    public partial class AddAttributeBonusDialog : TRW.Apps.TrwAppsBase.TrwFormBase
    {
        public AddAttributeBonusDialog()
        {
            InitializeComponent();
            this.AddNew = true;
            PopulateComboBoxWithEnum<Attributes>(AttributesCombo);
            this.DialogResult = DialogResult.Cancel;
            this.AttributesCombo.SelectedIndex = 0;
        }

        public AddAttributeBonusDialog(DnDAttributeBonus bonus, int index)
            : this()
        {
            this.AddNew = false;
            this.Index = index;
            this.AttributeBonus = bonus;
            this.AttributesCombo.SetSelectedItem(bonus.Attribute);
            this.BonusNumeric.Value = bonus.Bonus;
            this.RequiredCheckbox.Checked = bonus.Requried;
        }

        public int Index { get; private set; }
        public bool AddNew { get; private set; }

        public DnDAttributeBonus AttributeBonus { get; private set; }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Attributes attribute = this.AttributesCombo.GetSelectedItem<Attributes>();
            AttributeBonus = new DnDAttributeBonus(attribute, Convert.ToInt32(this.BonusNumeric.Value), this.RequiredCheckbox.Checked);
            this.Close();
        }
    }
}
