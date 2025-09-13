using System;
using System.Windows.Forms;

namespace TRW.Apps.TrwAppsBase
{
    public static class FormExtensions
    {
        #region ComboBox
        public static void AddItem<T>(this ComboBox box, T value) where T : IComparable
        {
            AddItem<T>(box, value, value.ToString());
        }

        public static void AddItem<T>(this ComboBox box, T value, string description) where T : IComparable
        {
            Item<T> item = new Item<T>(value, description);
            box.Items.Add(item);
        }

        public static T GetSelectedItem<T>(this ComboBox box) where T : IComparable
        {
            Item<T> item = box.SelectedItem as Item<T>;
            return item.Value;
        }

        public static void SetSelectedItem<T>(this ComboBox box, T value) where T : IComparable
        {
            foreach (Item<T> item in box.Items)
            {
                if (item.Value.Equals(value))
                {
                    box.SelectedItem = item;
                    break;
                }
            }
        }
        #endregion

        #region DropDownItems
        public static bool ContainsMenuItem(this ToolStripItemCollection toolStrip, string value)
        {
            bool hasValue = false;
            foreach(ToolStripMenuItem item in toolStrip)
            {
                if(item.Text == value)
                {
                    hasValue = true;
                    break;
                }
            }

            return hasValue;
        }
        #endregion

        #region DataGridViews
        public static DataGridViewRow SelectedRow(this DataGridView dataGridView)
        {
            return dataGridView.SelectedRows[0];
        }
        /// <summary>
        /// Select a DataGridView Row
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="row"></param>
        public static void Select(this DataGridView dataGridView, int row)
        {
            dataGridView.Rows[row].Selected = true;
        }
        #endregion

        public static void SetToolTip(this Control control, string text)
        {
            if (control == null)
                return;
            ToolTip toolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip.SetToolTip(control, text);
        }

        public static F AddSubForm<F>(this Control mainForm)
            where F: Form, new()
        {
            F subForm = new F();
            AddSubForm(mainForm, subForm);
            return subForm;
        }

        public static void AddSubForm<F>(this Control mainForm, F subForm)
            where F : Form, new()
        {
            subForm.Dock = DockStyle.Fill;
            subForm.TopLevel = false;
            mainForm.Controls.Add(subForm);
            subForm.Show();
        }

        internal class Item<T> where T : IComparable
        {
            internal T Value { get; set; }
            internal string Description { get; set; }

            public Item(T value, string description)
            {
                Value = value;
                Description = description;
            }

            public override string ToString()
            {
                return Description;
            }
        }
    }
}
