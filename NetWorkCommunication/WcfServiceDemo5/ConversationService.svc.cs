using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo5
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ConversationService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ConversationService.svc 或 ConversationService.svc.cs，然后开始调试。
    public class ConversationService : IConversationService
    {
        int myValue;
        public ConversationService()
        {
            myValue = 0;
        }
        public void Add1(int m)
        {
            PrintSessionID();
            myValue += m;
        }
        public void Add2(int n)
        {
            PrintSessionID();
            myValue += n;
        }
        public int GetResult()
        {
            PrintSessionID();
            return myValue;
        }
        private void PrintSessionID()
        {
            var context = OperationContext.Current;
            string msg = $"{context.IncomingMessageHeaders.Action,-10}操作被调用，会话ID为{context.SessionId}";
            Console.WriteLine(msg);
        }
    }
}
