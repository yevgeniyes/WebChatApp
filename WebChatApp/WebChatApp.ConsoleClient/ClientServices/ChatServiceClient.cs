using System;
using NFX.Glue;
using NFX.Glue.Protocol;
using WebChatApp.Contracts.Services;

namespace WebChatApp.ConsoleClient.ClientServices
{
    class ChatServiceClient : ClientEndPoint, IChatService
    {
        private static TypeSpec s_ts_CONTRACT;
        private static MethodSpec s_ms_PutMessage_0;

        static ChatServiceClient()
        {
            var t = typeof(IChatService);
            s_ts_CONTRACT = new TypeSpec(t);
            s_ms_PutMessage_0 = new MethodSpec(t.GetMethod("PutMessage", new Type[] { typeof(Guid), typeof(string) }));
        }

        public ChatServiceClient(string node, Binding binding = null) : base(node, binding) { ctor(); }
        public ChatServiceClient(Node node, Binding binding = null) : base(node, binding) { ctor(); }
        public ChatServiceClient(IGlue glue, string node, Binding binding = null) : base(glue, node, binding) { ctor(); }
        public ChatServiceClient(IGlue glue, Node node, Binding binding = null) : base(glue, node, binding) { ctor(); }

        private void ctor()
        {

        }

        public override Type Contract
        {
            get { return typeof(IChatService); }
        }

        public bool PutMessage(Guid token, string message)
        {
            var call = Async_PutMessage(token, message);
            return call.GetValue<bool>();
        }

        public CallSlot Async_PutMessage(Guid token, string message)
        {
            var request = new RequestAnyMsg(s_ts_CONTRACT, s_ms_PutMessage_0, false, RemoteInstance, new object[] { token, message });
            return DispatchCall(request);
        }
    }
}
