using System;
using NFX.Wave.MVC;
using WebChatApp.Server.Pages;
using NFX.ApplicationModel;
using NFX;
using NFX.Environment;
using WebChatApp.Server.Services;

namespace WebChatApp.Server.Controllers
{
    class Chat : Controller
    {
        [Config("$test-service-node")]
        private string m_TestServiceNode = "sync://localhost:8040";

        [Action]
        public object Login()
        {
            return new LoginPage();
        }

        [Action]
        public object Registration()
        {
            return new RegistrationPage();
        }

        [Action]
        public object Register(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new RegistrationPage { ErrorMessage = UIMessages.EMPTY_STRING };
            }
            try
            {
                using (var client = new RegistrationServiceClient(m_TestServiceNode))
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

        [Action]
        public object StartChat(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new LoginPage { ErrorMessage = UIMessages.EMPTY_STRING };
            }
            try
            {
                using (var client = new LoginServiceClient(m_TestServiceNode))
                {
                    var token = client.Login(name);
                    if (token != Guid.Empty)
                    {
                        //use js for this
                        //ClientContext.Name = name;
                        //ClientContext.Token = token;
                        return new ChatPage { Name = name, Token = token };
                    }
                    else
                    {
                        return new LoginPage { ErrorMessage = UIMessages.ERROR_WRONG_NAME };
                    }
                }
            }
            catch (Exception error)
            {
                return new LoginPage { ErrorMessage = "Server error: " + error.Message };
            }
        }

        [Action]
        public void PutMessage(Guid token, string message)
        {
            try
            {
                using (var client = new ChatServiceClient(m_TestServiceNode))
                {
                    if (!client.PutMessage(token, message))
                    {
                        //Console.WriteLine(UIMessages.SESSION_LOST);
                        //Login();
                    }
                }
            }
            catch (Exception error)
            {
                return;
            }
        }
    }
}
