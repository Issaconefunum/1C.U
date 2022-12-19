using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C.U
{
    class SessionInfo
    {
        public static User CurrentUser { set; get; }
        public static DateTime SessionStart { set; get; }
    }
}
