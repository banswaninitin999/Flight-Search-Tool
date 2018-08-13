using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightInfo
{
    public class DLApplication
    {
        public static string DataSource = "";
        public static String InitialCatalog = "";
        public static String DBServerUser = "";
        public static String DBServerPass = "";
        public readonly MySqlCommand Cmd;
        public readonly MySqlConnection Conn;
        private DataSet _ds;
        public MySqlParameterCollection Parms;
        public static Boolean ConnectionStatus { get; set; }


        public DLApplication()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DataSource"]))
                DLApplication.DataSource = ConfigurationManager.AppSettings["DataSource"];

            //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["InitialCatalog"]))
            //    DLApplication.InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"];

            //   var connString = @"Data Source=.;Initial Catalog=IRS;Integrated Security=True";

            //if (Conn == null || Conn.State != ConnectionState.Open)
            Conn = new MySqlConnection(ConfigurationManager.AppSettings["DataSource"]);

            Cmd = Conn.CreateCommand();
            //Cmd.CommandTimeout = 0;//till the end sec
            Conn.Open();
            Parms = Cmd.Parameters;
            ConnectionStatus = true;
        }


        public DataTable GetDt(string query)
        {
            Cmd.CommandText = query;
            Cmd.Connection = Conn;
            var da = new MySqlDataAdapter(Cmd);
            _ds = new DataSet("test");
            da.Fill(_ds);
            DataTable ddt = _ds.Tables[0];
            return ddt;
        }

      
      

    }
}
