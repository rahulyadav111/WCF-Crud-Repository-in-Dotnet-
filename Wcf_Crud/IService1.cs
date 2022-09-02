using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace Wcf_Crud
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string InsertEmpDetails(EmpDetails eDatils);
        [OperationContract]
        DataSet GetEmpDetails(EmpDetails eDatils);
        [OperationContract]
        DataSet FetchUpdatedRecords(EmpDetails eDatils);
        [OperationContract]
        string UpdateEmpDetails(EmpDetails eDatils);
        [OperationContract]
        bool DeleteEmpDetails(EmpDetails eDatils);
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.  
    [DataContract]
    public class EmpDetails
    {
        int? eId;
        string eName = string.Empty;
        string eSalary = string.Empty;
        string eDeptId = string.Empty;
        string eDeptName = string.Empty;
        [DataMember]
        public int? Id
        {
            get
            {
                return eId;
            }
            set
            {
                eId = value;
            }
        }
        [DataMember]
        public string Name
        {
            get
            {
                return eName;
            }
            set
            {
                eName = value;
            }
        }
        [DataMember]
        public string Salary
        {
            get
            {
                return eSalary;
            }
            set
            {
                eSalary = value;
            }
        }
        [DataMember]
        public string DeptId
        {
            get
            {
                return eDeptId;
            }
            set
            {
                eDeptId = value;
            }
        }
        [DataMember]
        public string DeptName
        {
            get
            {
                return eDeptName;
            }
            set
            {
                eDeptName = value;
            }
        }
    }
}
