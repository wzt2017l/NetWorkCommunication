using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ChannelConsoleApp
{
    /// <summary>
    /// 通道工厂服务端
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Uri listUri = new Uri("http://127.0.0.1:900");
            BasicHttpBinding binding = new BasicHttpBinding();
            IChannelListener<IReplyChannel> listener = null;
            if (binding.CanBuildChannelListener<IReplyChannel>())
            {
                listener = binding.BuildChannelListener<IReplyChannel>(listUri);
                listener.Open();
                while (true)
                {
                    IReplyChannel reply = listener.AcceptChannel();
                    reply.Open();
                    RequestContext request = reply.ReceiveRequest();
                    string msg = request.RequestMessage.GetBody<string>();
                    Console.WriteLine(msg);
                    Message replymsg = Message.CreateMessage(binding.MessageVersion,"test-reply","已收到消息");
                    request.Reply(replymsg);
                    request.Close();
                    Console.WriteLine("请按任意键继续，Esc键退出");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key==ConsoleKey.Escape)
                    {
                        break;
                    }
                }
                listener.Close();
            }
        }
    }
}
