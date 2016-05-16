using NFX.Glue;
using System;

namespace WebChatApp.Contracts.Services
{
    [Glued]
    public interface ILogoutService
    {
        bool Logout(Guid token);
    }
}
