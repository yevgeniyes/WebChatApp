using System;
using NFX.Wave.MVC;
using WebChatApp.Server.Pages;
using NFX.ApplicationModel;
using NFX;
using NFX.Environment;
using WebChatApp.Server.Services;
using WebChatApp.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace WebChatApp.Server.Controllers
{
    class Chat : Controller
    {
        [Config("$test-service-node")]
        private string m_TestServiceNode = "sync://localhost:8040";

        private object threadLock = new object();

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
            lock (threadLock)
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
        }

        [Action]
        public object StartChat(string name)
        {
            lock (threadLock)
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
        }

        [Action]
        public void PutMessage(string guid, string msg)
        {
            lock (threadLock)
            {
                Guid token = Guid.Parse(guid);
                try
                {
                    using (var client = new ChatServiceClient(m_TestServiceNode))
                    {
                        if (!client.PutMessage(token, msg))
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

        [Action]
        public object RequestNewMessages(string guid, int lastMsgID)
        {
            lock (threadLock)
            {
                Guid token = Guid.Parse(guid);
                try
                {
                    using (var client = new MessageServiceClient(m_TestServiceNode))
                    {
                        List<Message> newMessages = client.RequestMessages(token, lastMsgID);

                        if (newMessages == null) return null;
                        if (newMessages.Any<Message>())
                        {
                            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Message>));
                            using (MemoryStream stream = new MemoryStream())
                            {
                                jsonFormatter.WriteObject(stream, newMessages);
                                var bytes = stream.ToArray();
                                var str = Encoding.UTF8.GetString(bytes);
                                return str;
                            }
                        }
                        return null;
                    }
                }
                catch (Exception error)
                {
                    return null;
                }
            }
        }
    }
}
