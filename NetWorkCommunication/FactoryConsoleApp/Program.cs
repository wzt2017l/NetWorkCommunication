using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FactoryConsoleApp
{
    /// <summary>
    /// 通道工厂客户端,示例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            Uri uri = new Uri("http://127.0.0.1:900");
            BasicHttpBinding binding = new BasicHttpBinding();
            IChannelFactory<IRequestChannel> reqfac = null;
            if (binding.CanBuildChannelFactory<IRequestChannel>())
            {
                reqfac = binding.BuildChannelFactory<IRequestChannel>();//创建工厂
            }
            if (reqfac != null)
            {
                reqfac.Open();
                EndpointAddress endpoint = new EndpointAddress(uri);
                IRequestChannel channel = reqfac.CreateChannel(endpoint);
                channel.Open();
                Message msg = Message.CreateMessage(binding.MessageVersion, "test-request","你好我是客户端");
                Message rmsg = channel.Request(msg);
                string r = rmsg.GetBody<string>();
                Console.WriteLine(r);
                channel.Close();
            }
            Console.Read();
            reqfac.Close();
        }
    }
}
