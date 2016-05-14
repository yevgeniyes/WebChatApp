using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChatApp.ChatServer
{
    class AuthenticationProcessor
    {
        public string ValidateNameByToken(Guid token)
        {
            string name;
            ChatServerContext.OnlineUsers.TryGetValue(token, out name);
            return name;
        }
    }
}
