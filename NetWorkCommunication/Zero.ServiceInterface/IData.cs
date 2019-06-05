using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Zero.ServiceInterface
{
    [ServiceContract(Namespace = "data", Name = "Data")]
    public interface IData
    {
        [OperationContract]
        DataTable GetDataTable(DataTable dataTable);
        [OperationContract]
        DataSet GetDataSet(DataSet dataSet);
    }
}
