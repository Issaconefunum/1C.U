using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C.U
{
    class SessionInfo
    {
        public static User CurrentUser { set; get; }//информация о текущем пользователе
        public static DateTime SessionStart { set; get; } //время начала сессии
    }
}
