using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NFX;
using NFX.Wave;
using NFX.Wave.Templatization;

namespace WebChatApp.Server.Pages
{
    public class LoginPage : WaveTemplate
    {
        private string _errorMessage = null;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        protected override void DoRender()
        {
            base.DoRender();
            Target.Write(LoginPage._66_S_LITERAL_0);
            if (ErrorMessage != null) Target.Write(@"<p>" + ErrorMessage + "</p>");
            Target.Write(LoginPage._66_S_LITERAL_1);
        }

        #region Literal blocks content

        private const string _66_S_LITERAL_0 = @"
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv=""Content-Type"" content=""text/html; Charset=UTF-8"">
    <title>WebChatApp - Login</title>
    <style>
        body {
            font: 12px arial;
            color: #222;
            text-align: center;
            padding: 35px;
        }

        form, p, span {
            margin: 0;
            padding: 0;
        }

        input {
            font: 12px arial;
        }

        a {
            color: #0000FF;
            text-decoration: none;
        }

            a:hover {
                text-decoration: underline;
            }

        #wrapper, #loginform {
            margin: 0 auto;
            padding-bottom: 25px;
            background: #EBF4FB;
            width: 504px;
            border: 1px solid #ACD8F0;
        }

        #loginform {
            padding-top: 18px;
        }

            #loginform p {
                margin: 5px;
            }

        #chatbox {
            text-align: left;
            margin: 0 auto;
            margin-bottom: 25px;
            padding: 10px;
            background: #fff;
            height: 270px;
            width: 430px;
            border: 1px solid #ACD8F0;
            overflow: auto;
        }

        #usermsg {
            width: 395px;
            border: 1px solid #ACD8F0;
        }

        #submit {
            width: 60px;
        }
        
        #registration { 
        margin-top: 10px;
        }

        .error {
            color: #ff0000;
        }

        #menu {
            padding: 12.5px 25px 12.5px 25px;
        }

        .welcome {
            float: left;
        }

        .logout {
            float: right;
        }

        .msgln {
            margin: 0 0 2px 0;
        }
    </style>
    <script src=""http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js""></script>
    <script type=""text/javascript"">
    // jQuery Document
    $(document).ready(function(){
    $(""#name"").focus();
    });
    </script>
</head>
<body>
    <div id=""loginform"">
        <form action=""/Chat/StartChat?"">
            <p>Please enter your name to start chat:</p>
            <label for=""name"">Name:</label>
            <input type=""text"" name=""name"" id=""name"" />
            <input type=""submit"" name=""enter"" id=""enter"" value=""Login"" />";
        private const string _66_S_LITERAL_1 = @"
        </form>
        <form action=""/Chat/Registration"">
            <input type=""submit"" name=""registration"" id=""registration"" value=""Registration"" />
        </form>
    </div>
</body>
</html>";

        #endregion
    }
}
