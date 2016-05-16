using NFX;
using NFX.Environment;
using NFX.Wave.MVC;
using System;
using WebChatApp.Server.Pages;

namespace WebChatApp.Server.Controllers
{
    class Login : Controller
    {
        [Config("$chat-service-node")]
        private string m_ChatServiceNode;

        private object threadLock = new object();

        public Login()
        {
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        [Action]
        public object Index()
        {
            return new LoginPage();
        }
    }
}
