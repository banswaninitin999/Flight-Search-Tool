
using FlightInfo.ServiceReference1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;

using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlightInfo
{
    public partial class _Default : Page
    {
        private DLApplication _db;
        private string _query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (_db == null || _db.Conn.State != ConnectionState.Open)
                {
                    _db = new DLApplication();
                }

                _query = "Select Name, IATA from test.airports order by Name asc;";
                DataTable dt = _db.GetDt(_query);

                origin.DataSource = dt;
                origin.DataTextField = "Name";
                origin.DataValueField = "IATA";
                origin.DataBind();
                //origin.Items.Insert(0, new ListItem("Select ", "0"));

                destination.DataSource = dt;
                destination.DataTextField = "Name";
                destination.DataValueField = "IATA";
                destination.DataBind();

                origin.SelectedValue = "JFK";
                destination.SelectedValue = "PIT";


            }

            //destination.Items.Insert(0, new ListItem("Select ", "0"));

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
          //  FlightXML2SoapClient client = new FlightXML2SoapClient();
          //  client.ClientCredentials.UserName.UserName = "asafonov";
          //  client.ClientCredentials.UserName.Password = "2f34fc7f817274efd4ecd5a51b2ffd5817b08146";
          ////  AirlineFlightSchedulesRequest req = client.AirlineFlightSchedules();

          //  EnrouteStruct r = client.Enroute("KHOU", 10, "", 0);
          //  foreach (EnrouteFlightStruct de in r.enroute)
          //  {
          //      Console.WriteLine(de.ident);
          //  }

            //Console.WriteLine(client.Metar("KAUS"));

            if(startOrgDate.Text == "" || endDestDate.Text == "")
            {
                Response.Write("<script>alert('Please Select Date');</script>");
            }
            else
            {
                DateTime start = Convert.ToDateTime(startOrgDate.Text);
                Int32 unixTimestampStart = (Int32)(start.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

                DateTime end = Convert.ToDateTime(endDestDate.Text);
                Int32 unixTimestampEnd = (Int32)(end.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);


                string home = origin.SelectedValue.ToString();
                string dest = destination.SelectedValue.ToString();


                WebClient wb = new WebClient();

                wb.Headers.Add("User-Agent: Other");
                //http://tayyab.oursolutionz.com/umair.php?start_date=123&end_date=321&destination=2012&origin=20
                string url = @"http://tayyab.oursolutionz.com/flightaware.php?start_date=" + unixTimestampStart + "&end_date=" + unixTimestampEnd + "&destination=" + dest + "&origin=" + home + "";
                //var json = wb.DownloadString("http://tayyab.oursolutionz.com/umair.php?start_date=1534204800&end_date=1534550400&destination=JFK&origin=PIT");
                var json = wb.DownloadString(url);

                //dynamic magic = JsonConvert.DeserializeObject(json);

                LiteralControl result = new LiteralControl();
                result.Text = json;

                this.tabResult.Controls.Add(result);
            }
           


           


            //http://asafonov:2f34fc7f817274efd4ecd5a51b2ffd5817b08146@flightxml.flightaware.com/json/FlightXML2/AirlineFlightSchedules?startDate=1545415916&endDate=1545761516&origin=JFK&destination=PIT&howMany=15





        }
    }
}