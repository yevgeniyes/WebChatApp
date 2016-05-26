using NFX;
using NFX.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebChatApp.ConsoleClient.ClientServices;
using WebChatApp.Contracts;

namespace WebChatApp.ConsoleClient
{
    class MessageRequestProcessor
    {
        [Config("$test-service-node")]
        private string m_ChatServiceNode;

        public MessageRequestProcessor()
        {
            ConfigAttribute.Apply(this, App.ConfigRoot);
            new Thread(Start) { IsBackground = true }.Start();
        }

        public void Start()
        {
            int lastMessageId = 0;

            while (true)
            {
                if (ClientContext.ChatSession.Any<Message>())
                {
                    lastMessageId = ClientContext.ChatSession.Last().Id;
                }
                try
                {
                    using (var client = new MessageServiceClient(m_ChatServiceNode))
                    {
                        List<Message> newMessages = client.RequestMessages(ClientContext.Token, lastMessageId);

                        if (newMessages == null) return;
                        if (newMessages.Any<Message>())
                        {
                            ClientContext.ChatSession.AddRange(newMessages);

                            var buffer = 0;
                            foreach (Message message in newMessages)
                            {
                                var name = message.Name;
                                var time = message.Time;
                                var content = message.Content;

                                if (message.Name != ClientContext.Name)
                                {
                                    Console.MoveBufferArea(0, Console.CursorTop, Console.BufferWidth, 1, 0, Console.CursorTop + 1);
                                    buffer = Console.CursorLeft;
                                }

                                Console.CursorLeft = 0;
                                Console.WriteLine("{0}: {1} ({2})", name, content, time);
                            }
                            Console.CursorLeft = buffer;
                        }
                    }
                }
                catch (Exception error)
                {
                    Console.Write("\nServer error: ");
                    Console.WriteLine(error.Message + "\n");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
