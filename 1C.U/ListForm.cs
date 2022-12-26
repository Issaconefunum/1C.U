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
    public partial class ListForm : Form
    {
        public static List<InventoryItem> TableData { set; get; }

        public ListForm()
        {
            InitializeComponent();
            UpdateDataGridView();
            PrepareInterface();
        }

        //Обновление данных таблицы
        private void UpdateDataGridView()
        {
            DataBase.LoadItemsData();
            dataGridView1.Rows.Clear();
            foreach (var item in TableData)
                dataGridView1.Rows.Add(item.Id, item.Status, item.Type, item.Model, item.SerialNumber, item.Employee, item.JobTitle, item.EmployeeEmail, item.Branch, item.Location, item.Comment);
        }

        //Обработка события добавления учетной единицы для администратора
        private void ButtonAdd(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm();
            addItemForm.ShowDialog();
            UpdateDataGridView();
        }

        //Обработка события удаления учетной единицы для администратора
        private void ButtonDelete(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1 ||
                dataGridView1.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Выберите одну строку!", "Ошибка!");
                return;
            }

            DataBase.DeleteRow(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            UpdateDataGridView();
        }

        //Поиск учетной единицы
        private void ButtonFind(object sender, EventArgs e)
        {
            var query = textBox1.Text;
            var filteredList = Filter.FilterByModel(query, TableData);
            if(filteredList != null)
            {
                dataGridView1.Rows.Clear();
                foreach (var item in filteredList)
                    dataGridView1.Rows.Add(item.Id, item.Status, item.Type, item.Model, item.SerialNumber, item.Employee, item.JobTitle, item.EmployeeEmail, item.Branch, item.Location, item.Comment);
            }
            else
                UpdateDataGridView();
        }

        //информация о пользователях для администратора
        private void ButtonUsersInfo(object sender, EventArgs e)
        {
            UsersInfoForm usersInfoForm = new UsersInfoForm();
            usersInfoForm.ShowDialog();
        }

        //предупреждение об удалении УЕ
        private void DeleteWarning(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        //закрытие главной формы
        private void ClosedForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //подготовка интерфейса к работе
        private void PrepareInterface()
        {
            roleStatus.Text += SessionInfo.CurrentUser is Admin ? "Админ" : "Пользователь";
            nickStatus.Text += SessionInfo.CurrentUser.NickName;

            if (SessionInfo.CurrentUser is Admin)
                toolStripMenuItem2.Visible = true;
        }

        //открытие формы создания перемещения
        private void ButtonAddTransfer(object sender, EventArgs e)
        {
            TransferForm transferForm = new TransferForm();
            transferForm.ShowDialog();
        }
    }
}
