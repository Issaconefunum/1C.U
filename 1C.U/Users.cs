using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C.U
{
    class User
    {
        public int Id { set; get; }
        public string NickName { set; get; }
        public string Password { set; get; }
    }

    class Admin : User
    {

    }
}
