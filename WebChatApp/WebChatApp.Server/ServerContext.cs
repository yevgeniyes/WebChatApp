using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChatApp.Server
{
    static class ServerContext
    {
        private readonly static List<string> _registredUsers = new List<string>() { "zero", "alpha", "smoke", "xman" };

        public static List<string> RegistredUsers
        {
            get { return _registredUsers; }
        }
    }
}
