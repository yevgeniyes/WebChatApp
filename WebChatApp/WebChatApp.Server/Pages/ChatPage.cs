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
  
    a:hover { font-weight: bolder; }
  
#wrapper {
    margin:0 auto;
    padding-bottom:25px;
    background:#EBF4FB;
    width:504px;
    border:1px solid #ACD8F0; }
  
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
  
#menu { padding:12.5px 25px 12.5px 25px; }
  
.welcome { float:left; }
  
.logout { float:right; }

</style>
<script type=""text/javascript"" src=""http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js""></script>
<script type=""text/javascript"">
var clientName = '";
        private const string _66_S_LITERAL_1 = @"';
var token = '";
        private const string _66_S_LITERAL_2 = @"';
var clientChatSession = [];

function submitMessage(){
	var clientmsg = $(""#usermsg"").val();
    if(clientmsg.replace(/\s/g,"""") == """"){
        $(""#usermsg"").attr(""value"", """").focus();
    }
    else{
        var request = new XMLHttpRequest();
	    request.open(""GET"", '/Chat/PutMessage?guid=' + token + '&msg=' + clientmsg, true);
        request.send();
	    $(""#usermsg"").attr(""value"", """").focus();
        request.onreadystatechange = function() {
        if (request.readyState == 4 && request.status == 200) {
                if(request.responseText != 'delivered'){
                    window.location.href = 'http://' + window.location.host + '/Login/Index';
                    }
                }
            }
    }
}

function requestNewMessages(){
    var oldscrollHeight = $('#chatbox').attr('scrollHeight') - 20;
	var lastMsgID = getLastMessageID();
	var request = new XMLHttpRequest();
	request.open(""GET"", '/Chat/RequestNewMessages?guid=' + token + '&lastMsgID=' + lastMsgID, true);
	request.send();
	request.onreadystatechange = function() {
    if (request.readyState == 4 && request.status == 200) {
            if(request.responseText != null) {
			    var newMessages = JSON.parse(request.responseText);
			    for (var i = 0; i < newMessages.length; i++){
	                    clientChatSession.push(newMessages[i])
                    }
                updateMessageBox(newMessages, oldscrollHeight);
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

function updateMessageBox(newMessages, oldscrollHeight){
	var msgBox = document.getElementById('chatbox');
	for (var i = 0; i < newMessages.length; i++){
	var newMsg = document.createElement('div');
	var content = newMessages[i].Content;
	var name = newMessages[i].Name;
	var time = newMessages[i].Time;
	newMsg.innerHTML = '<b>' + name + '</b>: <i>' + content + '</i> (' + time + ')';
	msgBox.appendChild(newMsg);
    }
    var newscrollHeight = $('#chatbox').attr('scrollHeight') - 20;
    if(newscrollHeight > oldscrollHeight){
					$('#chatbox').animate({ scrollTop: newscrollHeight }, 'normal');
				}
}

function endSession(){
	var request = new XMLHttpRequest();
	request.open(""GET"", '/Chat/Logout?guid=' + token, false);
    request.send();
}

$(document).ready(function(){

    $(""#usermsg"").focus();

    setInterval(requestNewMessages, 2500);

    $(""#submitmsg"").click(function(){
        submitMessage();
    });

    $(""#exit"").click(function(){
		    var exit = confirm(""Are you sure you want to end session?"");
		    if(exit==true){
            window.location.href = 'http://' + window.location.host + '/Login/Index';
            endSession();
            }
            else {
            $(""#usermsg"").focus();
            return false;
            }
    });

    $('#usermsg').keyup(function(event){
        if(event.keyCode == 13){
            submitMessage();
            }
        });

});
</script>
</head>
<body>
<div id=""wrapper"">
    <div id=""menu"">
        <p class=""welcome"">Welcome, <b>";
        private const string _66_S_LITERAL_3 = @"</b></p>
        <p class=""logout""><a id=""exit"" href=""/Login/Index"" >Logout</a></p>
        <div style=""clear:both""></div>
    </div>
     
    <div id=""chatbox""></div>
     
    <form name=""message"" onsubmit=""return false;"">
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
