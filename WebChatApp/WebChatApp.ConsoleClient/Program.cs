using System;
using NFX.ApplicationModel;
using NFX;

namespace WebChatApp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = new ServiceBaseApplication(args, null))
            {
                try
                {
                    var clientLogin = new ClientLoginProcessor();
                    clientLogin.Run();
                }
                catch
                {
                    Console.WriteLine("CRITICAL ERROR");
                    Console.ReadKey();
                }
            }
        }
    }
}
