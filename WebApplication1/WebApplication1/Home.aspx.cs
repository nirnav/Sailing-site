using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        public string table= "<tr><th>Event ID</th><th>Event Name</th><th>Location</th><th>Date</th><th>Description</th><th>Creator ID</th><th>Checkbox</th></tr>";
        public string message;
        public string sclass;
        public string success;
        public string fail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Front.aspx");
            else
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SiteDB.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                {
                    message = "Hello " + Session["Username"];
                }
                SqlCommand command = connection.CreateCommand();
                command.CommandText = string.Format("SELECT * FROM Users WHERE Id={0};", Session["UserId"]);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                sclass = reader.GetString(5);
                reader.Close();
                command.CommandText = string.Format("SELECT * FROM SEvents WHERE Class='{0}';", sclass);
                reader = command.ExecuteReader();
                string template;
                int i = 1;
                while (reader.Read())
                {
                    template = string.Format("<tr><td> {0} </td><td> {1} </td><td> {2} </td><td> {3} </td><td> {4} </td><td> {5} </td><td><input type=\"checkbox\" name=\"{6}\" value=\"{0}\"/></td></tr>"
                        , reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(5), reader.GetString(4), reader.GetInt32(1), i);
                    table = table + template;
                    i++;
                }
                reader.Close();
                if(Request.HttpMethod == "POST")
                {
                    string a;
                    for (int j = 1; j <= i; j++)
                    {
                        //try
                        //{
                            a = Request.Form[j.ToString()];
                            if (a != null)
                            {
                                command.CommandText = string.Format("INSERT INTO Event{0} (SailNumber, Name, CID) VALUES ('{1}', '{2}', '{3}');", a, Request.Form["sailn"], Session["Name"], Session["UserId"]);
                            command.ExecuteNonQuery();
                                if (success == null)
                                    success = string.Format("Signed up successfully to event {0}", a);
                                else
                                    success = success + string.Format(" ,", a);
                            }
                        //}
                        /*catch
                        {
                            if (fail == null)
                                fail = string.Format("Your sail number is taken or you are already signed up to event {0}", j);
                            else
                                fail = string.Format(" ,{0}", j);
                        }*/
                    }
                }
                connection.Close();
            }
        }
    }
}