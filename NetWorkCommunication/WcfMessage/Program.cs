using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WcfMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Message message = Message.CreateMessage(MessageVersion.Soap12,"test-action","你好，这是一条soap消息。");
            Console.WriteLine(message);
            MessageHeader header = MessageHeader.CreateHeader("ItemNumber", "app-test", 11);
            message.Headers.Add(header);
            MessageHeader header1 = MessageHeader.CreateHeader("ItemNumber1", "app-test1", "abc");
            message.Headers.Add(header1);
            Console.WriteLine(message);
            Console.WriteLine(message.Headers.GetHeader<string>("ItemNumber1","app-test1"));
            Console.WriteLine("");
            IDictionary<string, string> dic = new Dictionary<string, string>()
            {
                ["name"] = "小赵",
                ["age"] = "28",
                ["city"] = "广州"
            };
            CustomBodyWriter custom = new CustomBodyWriter(dic);
            Message message1 = Message.CreateMessage(MessageVersion.Default,"test-data",custom);
            Console.WriteLine(message1);
            Console.ReadKey();
        }
    }
    public class CustomBodyWriter : BodyWriter
    {
        IDictionary<string, string> dic;
        public CustomBodyWriter(IDictionary<string,string> dic) : base(true)
        {
            this.dic = dic;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("student_info");
            foreach (var k in dic.Keys)
            {
                writer.WriteElementString(k,dic[k]);
            }
            writer.WriteEndElement();
            writer.Flush();
        }
    } 
    [ServiceContract(Namespace="sv-test")]
    interface IService
    {
        [OperationContract(Action = "compute")]
        double Compute(double i);
    }
}
