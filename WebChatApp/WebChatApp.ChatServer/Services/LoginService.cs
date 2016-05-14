using System;
using System.Collections.Generic;
using WebChatApp.Contracts.Services;

namespace WebChatApp.ChatServer.Services
{
    class LoginService : ILoginService
    {
        private object threadLock = new object();

        public Guid Login(string name)
        {
            lock (threadLock)
            {
                foreach (string user in ChatServerContext.RegistredUsers)
                {
                    if (name == user)
                    {
                        ICollection<string> onlineUsers = ChatServerContext.OnlineUsers.Values;
                        foreach (string onlineUser in onlineUsers)
                        {
                            if (name == onlineUser)
                                return Guid.Empty;
                        }
                        var token = Guid.NewGuid();
                        ChatServerContext.OnlineUsers.Add(token, name);
                        return token;
                    }
                }
                return Guid.Empty;
            }
        }
    }
}
