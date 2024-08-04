using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRW.Apps.RandomCharacterGenerator.SubForms
{
    public partial class PropertyManagerStartingEquipmentGroup : Form
    {
        public PropertyManagerStartingEquipmentGroup()
        {
            InitializeComponent();
            StartingEquipment = new List<object>();
        }

        public List<object> StartingEquipment { get; private set; }

        private void AddEquipmentButton_Click(object sender, EventArgs e)
        {

        }

        private void EditEquipmentButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteEquipmentButton_Click(object sender, EventArgs e)
        {

        }

        private void AddEquipmentDialog_Close(object sender, EventArgs e)
        {

        }

        private void EditEquipmentDialog_Close(object sender, EventArgs e)
        {

        }

        private void DeleteEquipmentDialog_Close(object sender, EventArgs e)
        {

        }
    }
}
