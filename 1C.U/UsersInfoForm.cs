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

        private void UpdateDataGridView()
        {
            
        }

        private void ButtonAddUser(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.ShowDialog();
            UpdateDataGridView();
        }
    }
}
