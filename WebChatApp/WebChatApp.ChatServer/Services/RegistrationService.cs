using WebChatApp.Contracts.Services;

namespace WebChatApp.ChatServer.Services
{
    class RegistrationService : IRegistrationService
    {
        private object threadLock = new object();

        public bool Register(string userName)
        {
            lock (threadLock)
            {
                var registred = ChatServerContext.RegistredUsers.Contains(userName);
                if (registred) return false;
                else
                {
                    ChatServerContext.RegistredUsers.Add(userName);
                    return true;
                }
            }
        }
    }
}
