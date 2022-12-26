using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C.U
{
    public class InventoryItem
    {
        public int Id { set; get; }
        public string Status { set; get; }
        public string Type { set; get; }
        public string Model { set; get; }
        public int SerialNumber { set; get; }
        public string Employee { set; get; }
        public string JobTitle { set; get; }
        public string EmployeeEmail { set; get; }
        public string Branch { set; get; }
        public string Location { set; get; }
        public string Comment { set; get; }

        public override string ToString()
        {
            return $"'{Status}', '{Type}', '{Model}', {SerialNumber}, '{Employee}', '{JobTitle}', '{EmployeeEmail}', '{Branch}', '{Location}', '{Comment}'";
        }
    }
}
