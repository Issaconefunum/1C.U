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
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
            PrepareForm();
        }

        private void PrepareForm()
        {
            comboBox1.DataSource = DataBase.LoadBranchesData();
            comboBox2.DataSource = DataBase.LoadBranchesData();
        }

        private void SenderChanged(object sender, EventArgs e)
        {
            var filteredList = Filter.FilterByBranch(comboBox1.Text, ListForm.TableData);
            dataGridView1.Rows.Clear();
            foreach (var item in filteredList)
                dataGridView1.Rows.Add(item.Id, item.Status, item.Type, item.Model, item.SerialNumber, item.Employee, item.JobTitle, item.EmployeeEmail, item.Branch, item.Location, item.Comment);
        }
    }
}
