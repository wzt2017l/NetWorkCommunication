using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Zero.ServiceInterface
{
    [ServiceContract(Namespace ="math",Name ="Math")]//Name远程引用映射的名字
   public  interface IMath
    {
        [OperationContract(Action ="add",Name ="Add")]
        double Add(double a,double b);
        [OperationContract]
        double Sub(double a,double b);
        [OperationContract]
        double Mult(double a, double b);
        [OperationContract]
        double Divi(double a, double b);
    }
}
