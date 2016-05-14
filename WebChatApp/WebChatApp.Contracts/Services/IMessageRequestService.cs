using NFX.Glue;
using System;
using System.Collections.Generic;

namespace WebChatApp.Contracts.Services
{
    [Glued]
    public interface IMessageRequestService
    {
        List<Message> RequestMessages(Guid token, int lastMessageId);
    }
}
