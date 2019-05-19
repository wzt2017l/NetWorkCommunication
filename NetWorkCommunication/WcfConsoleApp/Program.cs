using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;


namespace WcfConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Callback callback = new Callback();
            //callback.Run();
            //Console.WriteLine("发送请求");
            //Console.ReadKey();
            //callback.Close();
            //Console.ReadKey();

        }

    
    }
    /// <summary>
    /// 双工通讯
    /// </summary>
    //public class Callback : IDuplexServiceCallback
    //{
    //    private DuplexServiceClient client = null;
    //    public  void Run()
    //    {
    //        InstanceContext context = new InstanceContext(this);
    //        client = new DuplexServiceClient(context);
    //        Console.WriteLine("等待接收");
    //        client.Login("张三");
    //        //while (login.IsCanceled == false)
    //        //{
    //        //    await Task.Delay(TimeSpan.FromMilliseconds(500));
    //        //}
    //        //await login;

    //    }
    //    public void Receive(string response)
    //    {
    //        Console.WriteLine(response);
    //    }
    //    public void Close()
    //    {
    //        client.Close();
    //    }
    //}
}
