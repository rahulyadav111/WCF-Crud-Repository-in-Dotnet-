using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wcf_Crud
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.  
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        public string InsertEmpDetails(EmpDetails eDetails)
        {
            string Status;
            SqlCommand cmd = new SqlCommand("USP_Emp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", eDetails.Name);
            cmd.Parameters.AddWithValue("@Salary", eDetails.Salary);
            cmd.Parameters.AddWithValue("@DeptId", eDetails.DeptId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = eDetails.Name + " " + eDetails.Salary + " registered successfully";
            }
            else
            {
                Status = eDetails.Name + " " + eDetails.Salary + " could not be registered";
            }
            con.Close();
            return Status;
        }
        public DataSet GetEmpDetails(EmpDetails eDetails)
        {
            SqlCommand cmd = new SqlCommand("Get_AllEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.Id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public DataSet FetchUpdatedRecords(EmpDetails eDetails)
        {
            SqlCommand cmd = new SqlCommand("Get_AllEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.DeptId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public string UpdateEmpDetails(EmpDetails eDetails)
        {
            string Status;
            SqlCommand cmd = new SqlCommand("USP_Emp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.Id);
            cmd.Parameters.AddWithValue("@Name", eDetails.Name);
            cmd.Parameters.AddWithValue("@Salary", eDetails.Salary);
            cmd.Parameters.AddWithValue("@DeptId", eDetails.DeptId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = "Record updated successfully";
            }
            else
            {
                Status = "Record could not be updated";
            }
            con.Close();
            return Status;
        }
        public bool DeleteEmpDetails(EmpDetails eDetails)
        {
            SqlCommand cmd = new SqlCommand("USP_Emp_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.DeptId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
    }

}
