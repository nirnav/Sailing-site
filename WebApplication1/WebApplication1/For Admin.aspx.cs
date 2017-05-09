using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Front.aspx");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SiteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString); ;
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = String.Format("SELECT * FROM Users WHERE Id={0} AND IsAdmin=1;", Session["UserId"]);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == false)
            {
                reader.Close();
                connection.Close();
                Response.Redirect("Home.aspx");
            }
            reader.Close();
            connection.Close();
        }
    }
}