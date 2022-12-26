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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        //кнопка добавления пользователя
        private void ButtonAddUser(object sender, EventArgs e)
        {
            string rights = checkBox1.Checked ? "1" : "0";
            string name = textBox1.Text;
            string password = textBox2.Text;
            
            string newUserInfo = GetNewUserInfo(name, password, rights);
            if (newUserInfo != null)
            {
                DataBase.AddUser(newUserInfo);
                Close();
            }
            else
            {
                var result = MessageBox.Show("Неправильно введенные данные", "", MessageBoxButtons.OK);
            }
        }

        //выдает строку запроса для БД, если данные введены корректно
        public static string GetNewUserInfo(string name, string password, string rights)
        {
            if (name == "" || name.Length > 50 || password.Length > 50 || (rights == "1" && password == ""))
                return null;

            var usersData = DataBase.LoadUsersData();
            foreach (var user in usersData)
                if (user.NickName == name)
                    return null;

            return $"'{name}', '{password}', {rights}";
        }
    }
}
