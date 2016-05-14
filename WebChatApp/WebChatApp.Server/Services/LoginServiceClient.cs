using System;
using NFX.Glue;
using NFX.Glue.Protocol;
using WebChatApp.Contracts.Services;

namespace WebChatApp.Server.Services
{
    class LoginServiceClient : ClientEndPoint, ILoginService
    {
        private static TypeSpec s_ts_CONTRACT;
        private static MethodSpec s_ms_Login_0;

        static LoginServiceClient()
        {
            var t = typeof(ILoginService);
            s_ts_CONTRACT = new TypeSpec(t);
            s_ms_Login_0 = new MethodSpec(t.GetMethod("Login", new Type[] { typeof(string) }));
        }

        public LoginServiceClient(string node, Binding binding = null) : base(node, binding) { ctor(); }
        public LoginServiceClient(Node node, Binding binding = null) : base(node, binding) { ctor(); }
        public LoginServiceClient(IGlue glue, string node, Binding binding = null) : base(glue, node, binding) { ctor(); }
        public LoginServiceClient(IGlue glue, Node node, Binding binding = null) : base(glue, node, binding) { ctor(); }

        private void ctor()
        {

        }

        public override Type Contract
        {
            get { return typeof(ILoginService); }
        }

        public Guid Login(string name)
        {
            var call = Async_Login(name);
            return call.GetValue<Guid>();
        }

        public CallSlot Async_Login(string name)
        {
            var request = new RequestAnyMsg(s_ts_CONTRACT, s_ms_Login_0, false, RemoteInstance, new object[] { name });
            return DispatchCall(request);
        }
    }
}
