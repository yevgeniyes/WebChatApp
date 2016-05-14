using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChatApp.Contracts;
using WebChatApp.Contracts.Services;

namespace WebChatApp.ChatServer.Services
{
    class MessageRequestService : IMessageRequestService
    {
        private object threadLock = new object();

        public List<Message> RequestMessages(Guid token, int lastMessageId)
        {
            lock (threadLock)
            {
                AuthenticationProcessor auth = new AuthenticationProcessor();
                if (auth.ValidateNameByToken(token) != null)
                {
                    var newMesseges = ChatServerContext.ChatSession.Where(m => m.Id > lastMessageId).ToList<Message>();
                    return newMesseges;
                }
                else return null;
            }
        }
    }
}
