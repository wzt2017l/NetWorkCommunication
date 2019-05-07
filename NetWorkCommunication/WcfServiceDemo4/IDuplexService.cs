using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo4
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDuplexService”。
    [ServiceContract(Namespace ="Duplex",SessionMode =SessionMode.Required,CallbackContract =typeof(IDuplexCallback))]
    public interface IDuplexService
    {
        [OperationContract(IsOneWay =true)]
        void Login(string name);
    }

    public interface IDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Receive(string response);
    }
}
