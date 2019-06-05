using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Zero.ServiceInterface;

namespace Zero.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContractDescription ctdesc = ContractDescription.GetContract(typeof(IMath));
            //Console.WriteLine($"名字：{ctdesc.Name},命名空间：{ctdesc.Namespace}");
            //Uri uri = new Uri("http://localhost:8866/Math");
            //EndpointAddress endpoint = new EndpointAddress(uri);
            //BasicHttpBinding binding = new BasicHttpBinding();
            //IMath math = ChannelFactory<IMath>.CreateChannel(binding,endpoint);
            //math.Divi(3.5,6.3);
            //Console.WriteLine(math.Add(3.2, 4.6));
            //((IClientChannel)math).Close();
            //Console.Read();
            Console.ReadKey();
            var dt= GetData.GetTable("2");
            var ds = GetData.GetDataSet();
            Uri uri = new Uri("http://localhost:8867/Data");
            EndpointAddress endpoint = new EndpointAddress(uri);
            BasicHttpBinding binding = new BasicHttpBinding();
            IData data = ChannelFactory<IData>.CreateChannel(binding, endpoint);

            var dt1= data.GetDataTable(dt);
            var dt2= data.GetDataSet(ds);
            ((IClientChannel)data).Close();
            Console.Read();
            Console.ReadKey();
        }
    }
    public static class GetData
    {
        public static DataTable GetTable(string name)
        {
            DataTable dt = new DataTable();
            DataColumn column1 = new DataColumn("Id", Type.GetType("System.Int32"));
            DataColumn column2 = new DataColumn("Name", Type.GetType("System.String"));
            dt.Columns.Add(column1);
            dt.Columns.Add(column2);
            DataRow dr1 = dt.NewRow();
            dr1["Id"] = 1;
            dr1["Name"] = "小明";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["Id"] = 2;
            dr2["Name"] = "小张";
            dt.Rows.Add(dr2);
            Random rd = new Random();
            dt.TableName =name;
            return dt;
        }
        public static DataSet GetDataSet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(GetTable("0"));
            ds.Tables.Add(GetTable("1"));
            return ds;
        }
    }
}
