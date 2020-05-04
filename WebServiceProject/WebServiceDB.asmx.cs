using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;

using System.ComponentModel;

using System.Web.Services.Protocols;
using WebServiceProject.Models;



namespace WebServiceProject
{
    /// <summary>
    /// Summary description for WebServiceDB
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceDB : System.Web.Services.WebService
    {

       


        [WebMethod]
        public Result Login(string UserName, string UserPassword)
        {

            SqlConnection con = new SqlConnection(new DBConnection().ConnectionString);


            Result ress = new Result();
            try
            {

                SqlCommand com = new SqlCommand("Login", con);

                com.Parameters.AddWithValue("UserNameLogin", UserName);
                com.Parameters.AddWithValue("UserPasswordLogin", UserPassword);
                com.Connection = con;

                if( con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                SqlDataReader rd = com.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                   
                    ress.vaildUser = true;
                    return ress;

                }

                else
                {
                    ress.vaildUser = false; 
                }
             
            }
            catch(Exception ex)
            {
                ress.Error = ex.ToString();
            }
            finally
            {
                con.Close();

            }
            return ress;

        }

    }
}
