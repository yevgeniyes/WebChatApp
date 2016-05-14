using System;
using NFX.ApplicationModel;
using NFX;

namespace WebChatApp.ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var application = new ServiceBaseApplication(args, null))
                {
                    Console.WriteLine("Chat Server 1.0\n\nserver is running...\n");
                    foreach (var server in App.Glue.Servers)
                        Console.WriteLine(server);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error:");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
