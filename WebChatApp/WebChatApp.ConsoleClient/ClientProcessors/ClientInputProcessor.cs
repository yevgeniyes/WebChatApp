using System;

namespace WebChatApp.ConsoleClient
{
    class ClientInputProcessor
    {
        public string ReadCommandInput()
        {
            Console.Write("Login or Registration: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(UIMessages.COMMAND_ERROR);
                return null;
            }
            if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                Console.WriteLine(UIMessages.COMMAND_ERROR);
                return null;
            }
            return input;
        }

        public string ReadLoginInput()
        {
            Console.Clear();
            Console.Write(":::::::::::::::::LOGIN:::::::::::::::::\nDefault names: zero, alpha, smoke, xman\nEnter registered user name: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(UIMessages.LOGIN_ERROR);
                return null;
            }
            if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                Console.WriteLine(UIMessages.LOGIN_ERROR);
                return null;
            }
            return input;
        }

        public string ReadRegistrationInput()
        {
            Console.Clear();
            Console.Write("::::REGISTRATION::::\nEnter new user name: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(UIMessages.REG_ERROR);
                return null;
            }
            if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                Console.WriteLine(UIMessages.REG_ERROR);
                return null;
            }
            return input;
        }

        public string ReadMessageInput()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(UIMessages.EMPTY_STRING);
                return null;
            }
            Console.CursorTop -= 1;
            return input;
        }
    }
}
