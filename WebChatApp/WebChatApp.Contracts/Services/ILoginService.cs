using NFX.Glue;
using System;

namespace WebChatApp.Contracts.Services
{
    [Glued]
    public interface ILoginService
    {
        Guid Login(string name);
    }
}
