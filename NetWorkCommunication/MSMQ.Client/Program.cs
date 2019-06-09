using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSMQ.Client.AirportService;
using System.Transactions;

namespace MSMQ.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AirportServiceClient client = new AirportServiceClient())
            {
                Console.WriteLine(".....");
                client.SubmitInfo("例1");
                AirportMessage message = new AirportMessage
                {
                    AirportId="0001",
                    ForecastTime=DateTime.Now,
                    ShortMessage="0356 1157Z"
                };
                for (var i=0;i<1000;i++)
                {
                    message.AirportId = i.ToString();
                    using (TransactionScope t = new TransactionScope(TransactionScopeOption.Required))
                    {
                        client.SubmitAirportMessage(message);
                        t.Complete();
                    }
                }
               
            }
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}
