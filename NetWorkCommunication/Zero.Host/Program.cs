using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Zero.Service;
using Zero.ServiceInterface;

namespace Zero.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8866");//
            using (ServiceHost host=new ServiceHost(typeof(MathService),baseAddress))
            {
                //如果服务没有公开元数据则可使用通道工厂引用
                //ServiceMetadataBehavior metadata = null;//描述元数据的行为
                //var t= host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                //if (metadata==null)
                //{
                //    metadata = new ServiceMetadataBehavior();
                //}
                //metadata.HttpGetEnabled = true;
                //host.Description.Behaviors.Add(metadata);
                BasicHttpBinding basicHttp = new BasicHttpBinding();
                host.AddServiceEndpoint(typeof(IMath), basicHttp, "Math");//显式添加终结点
                host.Open();
                Console.WriteLine("服务启动");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
