using System;
using WebChatApp.Contracts;
using WebChatApp.Contracts.Services;

namespace WebChatApp.ChatServer.Services
{
    class ChatService : IChatService
    {
        private object threadLock = new object();

        public bool PutMessage(Guid token, string message)
        {
            lock (threadLock)
            {
                AuthenticationProcessor auth = new AuthenticationProcessor();
                var name = auth.ValidateNameByToken(token);
                if (name != null)
                {
                    Message newMessage = new Message();
                    newMessage.Id = ChatServerContext.ChatSession.Count + 1;
                    newMessage.Name = name;
                    newMessage.Time = DateTime.Now;
                    newMessage.Content = message;
                    ChatServerContext.ChatSession.Add(newMessage);
                    return true;
                }
                return false;
            }
        }
    }
}
