using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo5
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IConversationService”。
    [ServiceContract(SessionMode=SessionMode.Allowed)]//开启会话模式
    public interface IConversationService
    {
        [OperationContract(Action ="add_1",IsOneWay =true)]
        void Add1(int m);
        [OperationContract(Action="add_2",IsOneWay =true)]
        void Add2(int n);
        [OperationContract(Action ="get_result")]
        int GetResult();
    }
}
