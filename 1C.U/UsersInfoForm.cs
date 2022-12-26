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
    public partial class UsersInfoForm : Form
    {
        public UsersInfoForm()
        {
            InitializeComponent();
            UpdateDataGridView();
        }

        //обновление данных о пользователях в таблице
        private void UpdateDataGridView()
        {
            var usersData = DataBase.LoadUsersData();
            dataGridView1.Rows.Clear();
            foreach (var e in usersData)
                dataGridView1.Rows.Add(e.Id, e.NickName, e.Password);
        }

        //кнопка добавления пользователя
        private void ButtonAddUser(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.ShowDialog();
            UpdateDataGridView();
        }
    }
}
