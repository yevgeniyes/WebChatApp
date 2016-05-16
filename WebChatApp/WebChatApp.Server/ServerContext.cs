using System.Collections.Generic;

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
