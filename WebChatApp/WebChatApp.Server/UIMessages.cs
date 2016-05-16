using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChatApp.Server
{
    public class UIMessages
    {
        public const string ERROR_WRONG_NAME = "Login error. Please check the name and try again or register new name";
        public const string REG_FAILURE = "Registration error. This user is already registered";
        public const string REG_SUCCESS = "Congratulations! User successfully registered";
        public const string EMPTY_STRING = "There is no any text here... Write something and try again";
        public const string SESSION_LOST = "Current session was lost. Relogin to continue";
    }
}
