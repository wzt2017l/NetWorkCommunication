using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo4
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DuplexService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DuplexService.svc 或 DuplexService.svc.cs，然后开始调试。
    //对于多端通讯需要有保存上下文的类
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerSession)]
    public class DuplexService : IDuplexService
    {
        private IDuplexCallback callback;//回调接口
        private string SessionId = "";
        public DuplexService()//这里只能保存一个连接信息
        {
            OperationContext context = OperationContext.Current;
            SessionId = context.SessionId;
            callback = context.GetCallbackChannel<IDuplexCallback>();
        }
        public void Login(string name)
        {
            callback.Receive("你好，"+name);
            System.Threading.Thread.Sleep(1000);
            callback.Receive("你好，我是服务端"+SessionId);
        }

    }
}
