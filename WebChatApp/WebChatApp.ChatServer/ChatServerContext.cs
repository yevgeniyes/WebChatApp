using System;
using System.Collections.Generic;
using WebChatApp.Contracts;

namespace WebChatApp.ChatServer
{
    static class ChatServerContext
    {
        private readonly static List<string> _registredUsers = new List<string>() { "zero", "alpha", "smoke", "xman" };
        private readonly static Dictionary<Guid, string> _onlineUsers = new Dictionary<Guid, string>();
        private readonly static List<Message> _serverChatSession = new List<Message>();

        public static List<string> RegistredUsers
        {
            get { return _registredUsers; }
        }
        public static Dictionary<Guid, string> OnlineUsers
        {
            get { return _onlineUsers; }
        }
        public static List<Message> ChatSession
        {
            get { return _serverChatSession; }
        }
    }
}
