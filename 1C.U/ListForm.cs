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
           
        }

        private void ButtonAdd(object sender, EventArgs e)
        {
          
        }

        private void ButtonDelete(object sender, EventArgs e)
        {
          
        }

        private void ButtonFind(object sender, EventArgs e)
        {
         

        }

        private void ButtonUsersInfo(object sender, EventArgs e)
        {
          
        }

        private void ClosedForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
