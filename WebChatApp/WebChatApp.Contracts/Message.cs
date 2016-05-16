using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChatApp.Contracts
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Content { get; set; }
    }
}
