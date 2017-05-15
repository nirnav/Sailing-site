using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Confirm : System.Web.UI.Page
    {
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
                Response.Redirect("Front.aspx");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|SiteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString); ;
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = String.Format("SELECT * FROM Users WHERE Id='{0}' AND Password='{1}';", Session["UserId"], Request.Form["pass"]);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                command.CommandText = String.Format("DELETE FROM Users WHERE Id={0};", Session["UserID"]);
                command.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("deleted.aspx");
            }
            else
                message = "Incorrect password";
        }
    }
}