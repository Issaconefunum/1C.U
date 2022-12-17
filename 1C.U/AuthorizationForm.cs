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
           
        }

        private bool IsUserExist()
        {
            
        }
    }
}
