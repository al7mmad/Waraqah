using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Configuration;


namespace WebServiceProject.Models
{
    public class DBConnection
    {
        public string ConnectionString
        {
            get
            {
                return "Data Source=Server:LAPTOP-TI968TFO; catalog=WaraqahDB;user id=test; password=test;";
            }
        }
    }
}