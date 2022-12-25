using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1C.U
{
    public partial class AddItemForm : Form
    {
        public AddItemForm()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
        }

        private void ButtonAddItem(object sender, EventArgs e)
        {
            string values = $"'{dataGridView1.Rows[0].Cells[0].Value}', {dataGridView1.Rows[0].Cells[1].Value}";
            DataBase.AddRow(values);
            Close();
        }

        private void ButtonCancel(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Внимание! Данные не будут сохранены", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
                Close();
        }
    }
}
