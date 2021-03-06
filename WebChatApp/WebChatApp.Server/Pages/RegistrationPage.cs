﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NFX;
using NFX.Wave;
using NFX.Wave.Templatization;

namespace WebChatApp.Server.Pages
{
    public class RegistrationPage : WaveTemplate
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
            Target.Write(RegistrationPage._66_S_LITERAL_0);
            if (ErrorMessage != null) Target.Write(@"<p>" + ErrorMessage + "</p>");
            Target.Write(RegistrationPage._66_S_LITERAL_1);
        }

        #region Literal blocks content

        private const string _66_S_LITERAL_0 = @"
<!DOCTYPE html>
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; Charset=UTF-8"">
<title>WebChatApp - Registration</title>
<style>
body {
    font:12px arial;
    color: #222;
    text-align:center;
    padding:35px; }
  
form, p, span {
    margin:0;
    padding:0; }
  
input { font:12px arial; }
  
#loginform {
    margin:0 auto;
    padding-bottom:25px;
    background:#EBF4FB;
    width:504px;
    border:1px solid #ACD8F0;
    padding-top:18px; }

    #loginform p { margin: 5px; }
  
#login { 
    margin-top: 10px; }  
</style>
<script src=""http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js""></script>
    <script type=""text/javascript"">
    $(document).ready(function(){
    $(""#name"").focus();
    });
    </script>
</head>
<body>
<div id=""loginform"">
    <form action=""/Registration/Register?"">
        <p>Please enter the name you want to register:</p>
        <label for=""name"">Name:</label>
        <input type=""text"" name=""name"" id=""name"" />
        <input type=""submit"" name=""enter"" id=""enter"" value=""Registration"" />";
        private const string _66_S_LITERAL_1 = @"
        </form>
	        <form action=""/Login/Index"">
            <input type=""submit"" name=""registration"" id=""login"" value=""Login"" />
        </form>
    </div>
</body>
</html>";

        #endregion
    }
}
