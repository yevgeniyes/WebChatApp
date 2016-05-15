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
var clientName = '";
        private const string _66_S_LITERAL_1 = @"';
var token = '";
        private const string _66_S_LITERAL_2 = @"';
var clientChatSession = [];

function requestNewMessages(){
	var lastMsgID = getLastMessageID();
	var request = new XMLHttpRequest();
	request.open(""GET"", '/Chat/RequestNewMessages?guid=' + token + '&lastMsgID=' + lastMsgID, true);
	request.send();
	request.onreadystatechange = function() {
    if (request.readyState == 4 && request.status == 200) {
            if(request.responseText != null) {
			    var newMessages = JSON.parse(request.responseText);
			    clientChatSession.push(newMessages);
                }
        }
    }
}

function getLastMessageID(){
	if (clientChatSession.length == 0){
		return 0;
	}
	else{
		return clientChatSession[clientChatSession.length - 1].Id;
	}
}
</script>
<script type=""text/javascript"">
// jQuery Document
$(document).ready(function(){

setInterval(requestNewMessages(), 1000);

$(""#submitmsg"").click(function(){
var clientmsg = $(""#usermsg"").val();
	var request = new XMLHttpRequest();
	request.open(""GET"", '/Chat/PutMessage?guid=' + token + '&msg=' + clientmsg, true);
    request.send();
	request.onreadystatechange = function() {
    if (request.readyState == 4 && request.status == 200) {
        
        }
    }
    $(""#usermsg"").attr(""value"", """");
});

$(""#exit"").click(function(){
		var exit = confirm(""Are you sure you want to end the session?"");
		if(exit==true){
        window.location = '/Chat/Login';
        }
        else return;
});

});
</script>
</head>
<body>
<div id=""wrapper"">
    <div id=""menu"">
        <p class=""welcome"">Welcome, <b>";
        private const string _66_S_LITERAL_3 = @"</b></p>
        <p class=""logout""><a id=""exit"" href="""">Exit Chat</a></p>
        <div style=""clear:both""></div>
    </div>
     
    <div id=""chatbox""></div>
     
    <form name=""message"">
        <input name=""usermsg"" type=""text"" id=""usermsg"" size=""63"" />
        <input name=""submitmsg"" type=""button""  id=""submitmsg"" value=""Send"" />
    </form>
</div>
</body>
</html>
";
        #endregion
    }
}
