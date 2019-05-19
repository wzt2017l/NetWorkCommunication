using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            Uri uri = new Uri("http://localhost:18337");
            Binding binding = new WSHttpBinding();
            IConversationService channel = ChannelFactory<IConversationService>.CreateChannel(binding, new EndpointAddress(uri));
            channel.Add1(12);
            channel.Add2(13);
            Console.WriteLine(channel.GetResult());
            Console.ReadKey();
        }
    }
    [ServiceContract(SessionMode = SessionMode.Allowed)]//开启会话模式
    public interface IConversationService
    {
        [OperationContract(Action = "add_1", IsOneWay = true)]
        void Add1(int m);
        [OperationContract(Action = "add_2", IsOneWay = true)]
        void Add2(int n);
        [OperationContract(Action = "get_result")]
        int GetResult();
    }
}
