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
            PrepareTable();
        }

        //кнопка добавления учетной единицы
        private void ButtonAddItem(object sender, EventArgs e)
        {
            var values = dataGridView2.Rows[0];
            var item = new InventoryItem()
            {
            Status = (values.Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString(),
            Type = values.Cells[1].Value.ToString(),
            Model = values.Cells[2].Value.ToString(),
            SerialNumber = Convert.ToInt32(values.Cells[3].Value),
            Employee = values.Cells[4].Value.ToString(),
            JobTitle = values.Cells[5].Value.ToString(),
            EmployeeEmail = values.Cells[6].Value.ToString(),
            Branch = (values.Cells[7] as DataGridViewComboBoxCell).FormattedValue.ToString(),
            Location = values.Cells[8].Value.ToString(),
            Comment = values.Cells[9].Value.ToString()
            };
            
            DataBase.AddRow(item.ToString());
            Close();
        }

        //кнопка отмены
        private void ButtonCancel(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Внимание! Данные не будут сохранены", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
                Close();
        }

        //подготовка интерфейса к работе
        private void PrepareTable()
        {
            dataGridView2.RowCount = 1;
            (dataGridView2.Rows[0].Cells[0] as DataGridViewComboBoxCell).DataSource = new List<string>() { "Работает", "Сломан", "На складе", "Отправлен", "Списан" };
            (dataGridView2.Rows[0].Cells[7] as DataGridViewComboBoxCell).DataSource = DataBase.LoadBranchesData();
        }
    }
}
