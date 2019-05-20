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
            channel.Start();
            channel.Add1(12);
            channel.Add2(13);
            Console.WriteLine(channel.GetResult());
            channel.End();

            channel = ChannelFactory<IConversationService>.CreateChannel(binding, new EndpointAddress(uri));
            channel.Start();
            channel.Add1(12);
            channel.Add2(13);
            channel.Add2(13);
            Console.WriteLine(channel.GetResult());
            channel.End();
            Console.ReadKey();
        }
    }
    [ServiceContract(SessionMode = SessionMode.Required)]//开启会话模式
    public interface IConversationService
    {
        [OperationContract(Action = "start", IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Start();
        [OperationContract(Action = "add_1", IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void Add1(int m);
        [OperationContract(Action = "add_2", IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void Add2(int n);
        [OperationContract(Action = "get_result", IsInitiating = false, IsTerminating = false)]
        int GetResult();
        [OperationContract(Action = "end", IsInitiating = false, IsTerminating = true)]
        void End();
    }
}
