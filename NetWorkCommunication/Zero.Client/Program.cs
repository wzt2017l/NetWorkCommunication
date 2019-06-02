using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zero.ServiceInterface;

namespace Zero.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8866/Math");
            EndpointAddress endpoint = new EndpointAddress(uri);
            BasicHttpBinding binding = new BasicHttpBinding();
            IMath math = ChannelFactory<IMath>.CreateChannel(binding,endpoint);
            math.Divi(3.5,6.3);
            Console.WriteLine(math.Add(3.2, 4.6));
            ((IClientChannel)math).Close();
            Console.Read();
        }
    }
}
