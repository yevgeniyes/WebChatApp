using System;
using NFX.Glue;
using NFX.Glue.Protocol;
using WebChatApp.Contracts.Services;

namespace WebChatApp.Server.Services
{
    class LogoutServiceClient : ClientEndPoint, ILogoutService
    {
        private static TypeSpec s_ts_CONTRACT;
        private static MethodSpec s_ms_Logout_0;

        static LogoutServiceClient()
        {
            var t = typeof(ILogoutService);
            s_ts_CONTRACT = new TypeSpec(t);
            s_ms_Logout_0 = new MethodSpec(t.GetMethod("Logout", new Type[] { typeof(Guid) }));
        }

        public LogoutServiceClient(string node, Binding binding = null) : base(node, binding) { ctor(); }
        public LogoutServiceClient(Node node, Binding binding = null) : base(node, binding) { ctor(); }
        public LogoutServiceClient(IGlue glue, string node, Binding binding = null) : base(glue, node, binding) { ctor(); }
        public LogoutServiceClient(IGlue glue, Node node, Binding binding = null) : base(glue, node, binding) { ctor(); }

        private void ctor()
        {

        }

        public override Type Contract
        {
            get { return typeof(ILogoutService); }
        }

        public bool Logout(Guid token)
        {
            var call = Async_Logout(token);
            return call.GetValue<bool>();
        }

        public CallSlot Async_Logout(Guid token)
        {
            var request = new RequestAnyMsg(s_ts_CONTRACT, s_ms_Logout_0, false, RemoteInstance, new object[] { token });
            return DispatchCall(request);
        }
    }
}
