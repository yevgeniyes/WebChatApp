using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NFX;
using NFX.Wave;
using NFX.Wave.Templatization;

namespace WebChatApp.Server.Pages
{
    public class ChatPage : WaveTemplate
    {
        public string Name { get; set; }

        public Guid Token { get; set; }

        protected override void DoRender()
        {
            base.DoRender();
            Target.Write(ChatPage._66_S_LITERAL_0);
            Target.Write(Target.Encode(Name));
            Target.Write(ChatPage._66_S_LITERAL_1);
            Target.Write(Target.Encode(Token));
            Target.Write(ChatPage._66_S_LITERAL_2);
            Target.Write(Target.Encode(Name));
            Target.Write(ChatPage._66_S_LITERAL_3);
        }

        #region Literal blocks content
        private const string _66_S_LITERAL_0 = @"
<!DOCTYPE html>
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; Charset=UTF-8"">
<title>WebChatApp - Chat</title>
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
  
a {
    color:#0000FF;
    text-decoration:none; }
  
    a:hover { text-decoration:underline; }
  
#wrapper, #loginform {
    margin:0 auto;
    padding-bottom:25px;
    background:#EBF4FB;
    width:504px;
    border:1px solid #ACD8F0; }
  
#loginform { padding-top:18px; }
  
    #loginform p { margin: 5px; }
  
#chatbox {
    text-align:left;
    margin:0 auto;
    margin-bottom:25px;
    padding:10px;
    background:#fff;
    height:270px;
    width:430px;
    border:1px solid #ACD8F0;
    overflow:auto; }
  
#usermsg {
    width:395px;
    border:1px solid #ACD8F0; }
  
#submit { width: 60px; }
  
.error { color: #ff0000; }
  
#menu { padding:12.5px 25px 12.5px 25px; }
  
.welcome { float:left; }
  
.logout { float:right; }
  
.msgln { margin:0 0 2px 0; }

</style>
<script type=""text/javascript"" src=""http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js""></script>
<script type=""text/javascript"">
var clientName = ";
        private const string _66_S_LITERAL_1 = @";
var token = ";
        private const string _66_S_LITERAL_2 = @";

$(""#submitmsg"").click(function(){
var message = $(""#usermsg"").val();
     putMessage(token, message);       

}
function putMessage(token, message) {
    var request = new XMLHttpRequest();
    request.open(""POST"", ""/Chat/PutMessage?token="" + token + ""&message="" + message);
    request.onreadystatechange = function() {
    if (request.readyState == 4 && request.status == 200) {
        
        }
    }
    request.send();
}
</script>
<script type=""text/javascript"">
// jQuery Document
$(document).ready(function(){
 
});
</script>
</head>
<body>
<div id=""wrapper"">
    <div id=""menu"">
        <p class=""welcome"">Welcome, <b>";
        private const string _66_S_LITERAL_3 = @"</b></p>
        <p class=""logout""><a id=""exit"" href=""/Chat/Login"">Exit Chat</a></p>
        <div style=""clear:both""></div>
    </div>
     
    <div id=""chatbox""></div>
     
    <form name=""message"" action="""">
        <input name=""usermsg"" type=""text"" id=""usermsg"" size=""63"" />
        <input name=""submitmsg"" type=""submit""  id=""submitmsg"" value=""Send"" />
    </form>
</div>
</body>
</html>
";
        #endregion
    }
}
