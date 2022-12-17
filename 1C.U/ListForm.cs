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
        }

        private void UpdateDataGridView()
        {
           DataBase.LoadItemsData();
            dataGridView1.Rows.Clear();
            foreach (var e in TableData)
                dataGridView1.Rows.Add(e.Id, e.Name, e.Count);
        }

        private void ButtonAdd(object sender, EventArgs e)
        {
          AddItemForm addItemForm = new AddItemForm();
            addItemForm.ShowDialog();
            UpdateDataGridView();
        }

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

        private void ButtonFind(object sender, EventArgs e)
        {
         var query = textBox1.Text;
            if (query != "")
            {
                dataGridView1.Rows.Clear();
                foreach (var item in TableData)
                    if (item.Name == query)
                        dataGridView1.Rows.Add(item.Id, item.Name, item.Count);
            }
            else
                UpdateDataGridView();

        }

        private void ButtonUsersInfo(object sender, EventArgs e)
        {
          
        }

        private void ClosedForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
		
		private void DeleteWarning(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
		
		private void PrepareInterface()
        {
            roleStatus.Text += SessionInfo.CurrentUser is Admin ? "Админ" : "Пользователь";
            nickStatus.Text += SessionInfo.CurrentUser.NickName;

            if (SessionInfo.CurrentUser is Admin)
                toolStripMenuItem2.Visible = true;
        }
    }
}
