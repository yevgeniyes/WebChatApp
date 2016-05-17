using NFX;
using NFX.Environment;
using NFX.Wave.MVC;
using System;
using WebChatApp.Server.Pages;
using WebChatApp.Server.Services;

namespace WebChatApp.Server.Controllers
{
    class Registration : Controller
    {
        [Config("$chat-service-node")]
        private string m_ChatServiceNode;

        private object threadLock = new object();

        public Registration()
        {
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        [Action]
        public object Index()
        {
            return new RegistrationPage();
        }

        [Action]
        public object Register(string name)
        {
            lock (threadLock)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return new RegistrationPage { ErrorMessage = UIMessages.EMPTY_STRING };
                }
                try
                {
                    using (var client = new RegistrationServiceClient(m_ChatServiceNode))
                    {
                        if (!client.Register(name))
                        {
                            return new RegistrationPage { ErrorMessage = UIMessages.REG_FAILURE };
                        }
                        else
                        {
                            return new RegistrationPage { ErrorMessage = UIMessages.REG_SUCCESS };
                        }
                    }
                }
                catch (Exception error)
                {
                    return new RegistrationPage { ErrorMessage = "Server error: " + error.Message };
                }
            }
        }
    }
}
