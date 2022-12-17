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
    public partial class AuthorizationForm : Form
    {
        private string Nick { set; get; }
        private string Password { set; get; }

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void CheckUserData(object sender, EventArgs e)
        {
           Nick = textBox1.Text;
            Password = textBox2.Text;
            if (IsUserExist())
            {
                Hide();
                var listForm = new ListForm();
                listForm.Show();
            }
            else
            {
                var result = MessageBox.Show("Неверный логин или пароль", "", MessageBoxButtons.OK);
            }
        }

        private bool IsUserExist()
        {
             var usersData = DataBase.LoadUsersData();
            foreach (var e in usersData)
                if (e.NickName == Nick && e.Password == Password)
                {
                    SessionInfo.CurrentUser = e;
                    SessionInfo.SessionStart = DateTime.Now;
                    return true;
                }
            return false;
        }
    }
}
