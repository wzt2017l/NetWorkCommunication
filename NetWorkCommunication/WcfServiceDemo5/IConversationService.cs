using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo5
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IConversationService”。
    [ServiceContract(SessionMode=SessionMode.Required)]//开启会话模式
    public interface IConversationService
    {
        [OperationContract(Action ="start",IsOneWay =true,IsInitiating =true,IsTerminating =false)]
        void Start();
        [OperationContract(Action ="add_1",IsOneWay =true,IsInitiating =false,IsTerminating =false)]
        void Add1(int m);
        [OperationContract(Action="add_2",IsOneWay =true,IsInitiating = false, IsTerminating = false)]
        void Add2(int n);
        [OperationContract(Action ="get_result", IsInitiating = false, IsTerminating = false)]
        int GetResult();
        [OperationContract(Action = "end", IsInitiating = false, IsTerminating = true)]
        void End();
    }
}
