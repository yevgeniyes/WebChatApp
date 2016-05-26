using System;
using NFX;
using NFX.Environment;
using WebChatApp.ConsoleClient.ClientServices;

namespace WebChatApp.ConsoleClient
{
    class ClientLoginProcessor
    {
        [Config("$test-service-node")]
        private string m_ChatServiceNode;

        public ClientLoginProcessor()
        {
            Console.WriteLine(UIMessages.WELCOME_TEXT);
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        public void Run()
        {
            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                var command = inputProc.ReadCommandInput();
                if (command == null) continue;

                switch (command)
                {
                    case "log":
                        RunLogin();
                        break;
                    case "reg":
                        RunRegistration();
                        break;
                    default:
                        Console.WriteLine(UIMessages.COMMAND_ERROR);
                        continue;
                }
            }
        }

        public void RunLogin()
        {
            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                var name = inputProc.ReadLoginInput();
                if (name == null) continue;

                try
                {
                    using (var client = new LoginServiceClient(m_ChatServiceNode))
                    {
                        var token = client.Login(name);
                        if (token != Guid.Empty)
                        {
                            ClientContext.Name = name;
                            ClientContext.Token = token;
                            Console.Clear();
                            ClientChatProcessor chat = new ClientChatProcessor();
                            chat.StartChat();
                        }
                        else
                        {
                            Console.WriteLine(UIMessages.LOGIN_ERROR);
                            return;
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

        public void RunRegistration()
        {
            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                var regInput = inputProc.ReadRegistrationInput();
                if (regInput == null) continue;

                try
                {
                    using (var client = new RegistrationServiceClient(m_ChatServiceNode))
                    {
                        if (!client.Register(regInput))
                        {
                            Console.WriteLine(UIMessages.REG_FAILURE);
                            return;
                        }
                        else
                        {
                            Console.WriteLine(UIMessages.REG_SUCCESS);
                            return;
                        }
                    }
                }
                catch (Exception error)
                {
                    Console.Write("\nServer error: ");
                    Console.WriteLine(error.Message + "\n");
                    continue;
                }
            }
        }
    }
}
