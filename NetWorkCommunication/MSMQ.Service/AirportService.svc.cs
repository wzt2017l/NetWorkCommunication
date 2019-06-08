using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MSMQ.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AirportService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AirportService.svc 或 AirportService.svc.cs，然后开始调试。
    public class AirportService : IAirportService
    {
        [OperationBehavior(TransactionScopeRequired =true,TransactionAutoComplete =true)]
        public void SubmitInfo(string info)
        {
            Console.WriteLine($"收到:{info}");
        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitAirportMessage(AirportMessage message)
        {
            Console.WriteLine($"收到:{message.OriginalMessage}");
            AirportMessages.Add(message);
        }
    }
    [DataContract(Namespace ="WcfMsmqExamples")]
    public class AirportMessage
    {
        public string AirportId;
        public DateTime ForecastTime;
        public string ShortMessage;
        public string MessageId
        {
            get
            {
                return $"{AirportId},{ForecastTime:yyMM HHmm}";
            }
        }
        public string OriginalMessage
        {
            get
            {
                return $"{MessageId} {ShortMessage}";
            }
        }
        public string Status { get; internal set; }
    }
    public class AirportMessages
    {
        static Dictionary<string, AirportMessage> messages = new Dictionary<string, AirportMessage>();
        public static void Add(AirportMessage message)
        {
            if (!messages.ContainsKey(message.AirportId))
            {
                messages.Add(message.AirportId,message);
            }
        }
        public static void DeleteMessage(string id)
        {
            if (messages[id]!=null)
            {
                messages.Remove(id);
            }
        }
    }
}
