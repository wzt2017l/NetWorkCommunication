using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Zero.ServiceInterface
{
    [ServiceContract]
   public  interface IMath
    {
        [OperationContract]
        double Add(double a,double b);
        [OperationContract]
        double Sub(double a,double b);
        [OperationContract]
        double Mult(double a, double b);
        [OperationContract]
        double Divi(double a, double b);
    }
}
