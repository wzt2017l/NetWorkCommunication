﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("net.msmq://localhost/private/WcfMsmqExampleTransacted");//队列侦听地址
            Uri baseUri = new Uri("http://localhost:8933/Design_Time_Addresses/AirportService/");
            string q1 = ConfigurationManager.AppSettings["queueNameTransacted"];
            if (!MessageQueue.Exists(q1)) MessageQueue.Create(q1,true);
            using (ServiceHost host = new ServiceHost(typeof(MSMQ.Service.AirportService)))
            {
                //如果服务没有公开元数据则可使用通道工厂引用
                //ServiceMetadataBehavior metadata = null;//描述元数据的行为
                //var t = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                //if (metadata == null)
                //{
                //    metadata = new ServiceMetadataBehavior();
                //}
                //metadata.HttpGetEnabled = true;
                //metadata.HttpGetUrl = new Uri("http://localhost:8933/");
                //host.Description.Behaviors.Add(metadata);
                //NetMsmqBinding msmqBinding = new NetMsmqBinding();
                //msmqBinding.Security.Mode = NetMsmqSecurityMode.None;
                //host.AddServiceEndpoint(typeof(MSMQ.Service.IAirportService), msmqBinding, baseUri, uri);
                host.Open();
                foreach (var v in host.Description.Endpoints)
                {
                    Console.WriteLine($"服务已启动{v.ListenUri.ToString()}");
                }
                Console.ReadKey();
               
            }
        }
    }
}
