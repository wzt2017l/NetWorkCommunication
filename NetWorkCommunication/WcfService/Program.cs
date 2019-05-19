using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using WcfServiceDemo5;

namespace WcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:18337");
            using (ServiceHost host = new ServiceHost(typeof(ConversationService)))
            {
                Binding binding = new WSHttpBinding();
                host.AddServiceEndpoint(typeof(IConversationService), binding, uri);
                host.Open();
                Console.WriteLine("服务运行");
                Console.ReadKey();
            }
        }
    }
}
