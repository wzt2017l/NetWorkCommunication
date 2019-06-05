using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Zero.ServiceInterface;

namespace Zero.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DataService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DataService.svc 或 DataService.svc.cs，然后开始调试。
    public class DataService :IData
    {
        public  DataTable GetDataTable(DataTable dataTable)
        {
            Console.WriteLine("dt行数"+dataTable.Rows.Count);
            return GetData.GetTable("1"); 
        }
        public DataSet GetDataSet(DataSet dataSet)
        {
            Console.WriteLine("ds表格数" + dataSet.Tables.Count);
            return GetData.GetDataSet();
        }
        
    }
    public static class GetData
    {
        public static DataTable GetTable(string name)
        {
            DataTable dt = new DataTable();
            DataColumn column1 = new DataColumn("Id",Type.GetType("System.Int32"));
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
            dt.TableName = name;
            return dt;
        }
        public static DataSet GetDataSet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(GetTable("2"));
            ds.Tables.Add(GetTable("5"));
            return ds;
        }
    }
}
