using System;
using NFX.Wave.MVC;
using WebChatApp.Server.Pages;
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
        [Config("$chat-service-node")]
        private string m_ChatServiceNode;

        private object threadLock = new object();

        public Chat()
        {
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        [Action]
        public object Launch(string name)
        {
            lock (threadLock)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    //use js
                    return new LoginPage { ErrorMessage = UIMessages.EMPTY_STRING };
                }
                try
                {
                    using (var client = new LoginServiceClient(m_ChatServiceNode))
                    {
                        var token = client.Login(name);
                        if (token != Guid.Empty)
                        {
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
        public string PutMessage(string guid, string msg)
        {
            lock (threadLock)
            {
                Guid token = Guid.Parse(guid);
                try
                {
                    using (var client = new ChatServiceClient(m_ChatServiceNode))
                    {
                        if (client.PutMessage(token, msg))
                        {
                            return "delivered";
                        }
                        else return null;
                    }
                }
                catch (Exception error)
                {
                    return null;
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
                    using (var client = new MessageServiceClient(m_ChatServiceNode))
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

        [Action]
        public void Logout(string guid)
        {
            lock (threadLock)
            {
                Guid token = Guid.Parse(guid);
                try
                {
                    using(var client = new LogoutServiceClient(m_ChatServiceNode))
                    {
                        client.Logout(token);
                    }
                }
                catch(Exception error)
                {
                    
                }
            }
        }
    }
}
