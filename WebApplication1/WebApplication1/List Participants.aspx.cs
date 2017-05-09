using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class List_Events : System.Web.UI.Page
    {
        public string table;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Front.aspx");
            if (Request.HttpMethod == "POST")
            {
                string eventID = Request.Form["EId"];
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SiteDB.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection connection = new SqlConnection(connectionString); ;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = string.Format("SELECT * FROM Event{0};", eventID);
                SqlDataReader reader = command.ExecuteReader();
                table = "<tr><th>ID</th><th>Name</th><th>Sail Number</th></tr>";
                string template;
                while (reader.Read())
                {
                    template = string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", reader.GetInt32(3), reader.GetString(2), reader.GetInt32(1));
                    table = table + template;
                }
                reader.Close();
                connection.Close();
            }
        }
    }
}