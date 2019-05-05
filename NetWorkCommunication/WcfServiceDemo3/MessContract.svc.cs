using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo3
{
    //消息协定在客户端生成的方法
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MessContract”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MessContract.svc 或 MessContract.svc.cs，然后开始调试。
    public class MessContract : IMessContract
    {
        public ProductItem NewProduct(ProductItem item)
       {
            var p = item;
            p.PId = 124;
            p.PostTime = DateTime.Now;
            return p;
       }
       public ProductItem GetProduct()
        {
            return new ProductItem()
            {
                PostTime = DateTime.Now,
                Name = "颜色",
                Color = "red",
                PId = 123
            };
        }
    }
    [MessageContract]
    public class ProductItem
    {
        [MessageBodyMember]
        public string Name { get; set; }
        [MessageBodyMember]
        public string Color { get; set; }
        [MessageBodyMember]
        public int PId { get; set; }
        [MessageHeader]
        public DateTime PostTime { get; set; }
    }
}
