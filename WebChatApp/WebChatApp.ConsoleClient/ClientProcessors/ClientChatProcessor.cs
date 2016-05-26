using NFX;
using NFX.Environment;
using System;
using System.Linq;
using WebChatApp.ConsoleClient.ClientServices;
using WebChatApp.Contracts;

namespace WebChatApp.ConsoleClient
{
    class ClientChatProcessor
    {
        [Config("$test-service-node")]
        private string m_ChatServiceNode;

        public ClientChatProcessor()
        {
            Console.WriteLine(UIMessages.CHAT_HEADER);
            Console.Write("Logged as '" + ClientContext.Name + "'\n" + Environment.NewLine);
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        public void StartChat()
        {
            if (ClientContext.ChatSession.Any<Message>()) ClientContext.ChatSession.Clear();

            MessageRequestProcessor backgroundRequest = new MessageRequestProcessor();

            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                string message = inputProc.ReadMessageInput();
                if (message == null) continue;

                try
                {
                    using (var client = new ChatServiceClient(m_ChatServiceNode))
                    {
                        if (!client.PutMessage(ClientContext.Token, message))
                        {
                            Console.Clear();
                            Console.WriteLine(UIMessages.SESSION_LOST);
                            Console.WriteLine("Last login was made by '" + ClientContext.Name + "'" + Environment.NewLine);
                            ClientLoginProcessor login = new ClientLoginProcessor();
                            login.Run();
                        }
                    }
                }
                catch (Exception error)
                {
                    Console.Write("\nServer error: ");
                    Console.WriteLine(error.Message + "\n");
                }
            }
        }
    }
}
