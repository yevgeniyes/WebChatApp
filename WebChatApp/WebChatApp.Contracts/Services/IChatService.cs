using NFX.Glue;
using System;

namespace WebChatApp.Contracts.Services
{
    [Glued]
    public interface IChatService
    {
        bool PutMessage(Guid token, string message);
    }
}
