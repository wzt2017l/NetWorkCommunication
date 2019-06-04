using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zero.WcfMessage
{
    class Program
    {
        [DataContract]
        public class AB
        {
            [DataMember]
            public double a { get; set; }
            [DataMember]
            public double b { get; set; }
        }
        static void Main(string[] args)
        {
            Test2();
        }
        static void Test1()
        {
            AB aB = new AB
            {
                a = 3.1,
                b = 4.9
            };
            Message msg1 = Message.CreateMessage(MessageVersion.Soap11, "demo-opt", aB);
            MessageHeader header = MessageHeader.CreateHeader("Header1", "app-test", "自定义消息头");
            msg1.Headers.Add(header);
            Console.WriteLine(msg1);
            var s = msg1.GetBody<AB>();
            Console.ReadKey();
        }
        static void Test2()
        {
            IDictionary<string, string> m_data = new Dictionary<string, string>
            {
                ["name"]="小明",
                ["age"]="28"
            };
            CustomBodyWriter custom = new CustomBodyWriter(m_data,true);
            Message message = Message.CreateMessage(MessageVersion.Soap11,"test-data",custom);
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 写入自定义的消息 
    /// </summary>
    public class CustomBodyWriter : BodyWriter
    {
        IDictionary<string, string> m_data;
        public CustomBodyWriter(IDictionary<string, string> data, bool isBuffered) :base(isBuffered)
        {
            m_data = data;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            //writer.WriteStartElement("student_info");
            foreach (var k in m_data.Keys)
            {
                writer.WriteElementString(k,m_data[k]);
            }
            //writer.WriteEndElement();
            writer.Flush();
        }
    }
}
