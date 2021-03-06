﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IJjccService”。
    [ServiceContract(Namespace ="http://127.0.0.1",Name ="MyTask")]
    public interface IJjccService
    {
        [OperationContract(Name ="add",Action ="add",ReplyAction ="addResponse")]
        double Add(double a,double b);
        [OperationContract]
        double Sub(double a, double b);
        [OperationContract]
        double Muit(double a, double b);
        [OperationContract]
        double Divi(double a, double b);
    }
}
