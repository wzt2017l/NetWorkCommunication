using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Zero.ServiceInterface;

namespace Zero.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MathService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MathService.svc 或 MathService.svc.cs，然后开始调试。
    public class MathService :IMath
    {
        public MathService()
        {
            Console.WriteLine("初始化");
        }
        public double Add(double a, double b)
        {
            Console.WriteLine("Add");
            return a + b;
        }
        public double Sub(double a, double b)
        {
            Console.WriteLine("Sub");
            return a - b;
        }
        public double Mult(double a, double b)
        {
            Console.WriteLine("Mult");
            return a * b;
        }
        public double Divi(double a, double b)
        {
            Console.WriteLine("Divi");
            return a / b;
        }
    }
}
