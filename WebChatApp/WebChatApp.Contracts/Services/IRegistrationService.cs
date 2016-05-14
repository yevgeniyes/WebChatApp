using NFX.Glue;
using System;

namespace WebChatApp.Contracts.Services
{
    [Glued]
    public interface IRegistrationService
    {
        bool Register(string userName);
    }
}
