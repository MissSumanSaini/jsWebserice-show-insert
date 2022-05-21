using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace jsWebserice_show_insert
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection Con = new SqlConnection("data source=SUMAN\\SQLEXPRESS; initial catalog=JQueryAjaxInsert14520;integrated security=true");


        [WebMethod]
        public string EmployeeGet()
        {
            string data = "";
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Employee ", Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Con.Close();
            data = JsonConvert.SerializeObject(dt);
            return data;

        }


        [WebMethod]
        public void EmployeeInsert(string A, string B, int C)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Usp_Employee_Insert", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", A);
            cmd.Parameters.AddWithValue("@Address", B);
            cmd.Parameters.AddWithValue("@Age", C);
            cmd.ExecuteNonQuery();
            Con.Close();

        }

    }
}

