using System;
using System.Collections.Generic;
using WebChatApp.Contracts.Services;

namespace WebChatApp.ChatServer.Services
{
    class LogoutService : ILogoutService
    {
        private object threadLock = new object();

        public bool Logout(Guid token)
        {
            lock (threadLock)
            {
                AuthenticationProcessor auth = new AuthenticationProcessor();
                if (auth.ValidateNameByToken(token) != null)
                {
                    ChatServerContext.OnlineUsers.Remove(token);
                    return true;
                }
            }
            return false;
        }
    }
}
