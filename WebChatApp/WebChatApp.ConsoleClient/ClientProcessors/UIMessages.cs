namespace WebChatApp.ConsoleClient
{
    public class UIMessages
    {
        public const string WELCOME_TEXT = ":::::::::::::::::::::::::::::::::::::::::::::::\n::::::::::::WELCOME TO CHATAPP 1.0!::::::::::::\n::::::::::::LOGIN TO START CHATTING::::::::::::\n:::::::::::::::::::::::::::::::::::::::::::::::\n\nUse command 'log' to start login with registered user name\nUse command 'reg' to register new user name\n";
        public const string LOGIN_ERROR = "\nLogin error. Please check the name and try again\n";
        public const string EMPTY_STRING = "There is no any message here... Write something and try again\n";
        public const string CHAT_HEADER = ":::::::::::::::::::::::::::::::::::::::::::::::\n:::::::::::::::::CHAT STARTED::::::::::::::::::\n:::::::::::::::::::::::::::::::::::::::::::::::";
        public const string SESSION_LOST = "Current session was lost. Re-login to continue\n";
        public const string REG_ERROR = "\nRegistration error. Please check the input data and try again\n";
        public const string REG_FAILURE = "\nRegistration error. This user is already registered\n";
        public const string REG_SUCCESS = "\nCongratulations! User successfully registered\n";
        public const string COMMAND_ERROR = "\nWrong command. Available only 'log' or 'reg' commands\n";
    }
}
