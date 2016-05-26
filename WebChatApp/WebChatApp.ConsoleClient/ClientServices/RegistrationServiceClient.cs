using System;
using NFX.Glue;
using NFX.Glue.Protocol;
using WebChatApp.Contracts.Services;

namespace WebChatApp.ConsoleClient.ClientServices
{
    class RegistrationServiceClient : ClientEndPoint, IRegistrationService
    {
        private static TypeSpec s_ts_CONTRACT;
        private static MethodSpec s_ms_Register_0;

        static RegistrationServiceClient()
        {
            var t = typeof(IRegistrationService);
            s_ts_CONTRACT = new TypeSpec(t);
            s_ms_Register_0 = new MethodSpec(t.GetMethod("Register", new Type[] { typeof(string) }));
        }

        public RegistrationServiceClient(string node, Binding binding = null) : base(node, binding) { ctor(); }
        public RegistrationServiceClient(Node node, Binding binding = null) : base(node, binding) { ctor(); }
        public RegistrationServiceClient(IGlue glue, string node, Binding binding = null) : base(glue, node, binding) { ctor(); }
        public RegistrationServiceClient(IGlue glue, Node node, Binding binding = null) : base(glue, node, binding) { ctor(); }

        private void ctor()
        {

        }

        public override Type Contract
        {
            get { return typeof(IRegistrationService); }
        }

        public bool Register(string userName)
        {
            var call = Async_Register(userName);
            return call.GetValue<bool>();
        }

        public CallSlot Async_Register(string userName)
        {
            var request = new RequestAnyMsg(s_ts_CONTRACT, s_ms_Register_0, false, RemoteInstance, new object[] { userName });
            return DispatchCall(request);
        }
    }
}
