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

        private void ButtonAddUser(object sender, EventArgs e)
        {
            string rights = checkBox1.Checked ? "1" : "0";
            string values = $"'{textBox1.Text}', '{textBox2.Text}', {rights}";
            DataBase.AddUser(values);
            Close();
        }
    }
}
