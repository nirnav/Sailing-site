using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ReFroEve : System.Web.UI.Page
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


            if (Request.HttpMethod == "POST")
            {
                string UserID = Request.Form["UId"];
                string eventID = Request.Form["EId"];
                command.CommandText = String.Format("SELECT * FROM Users WHERE Id={0} AND IsAdmin=1;", Session["UserId"]);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    command.CommandText = String.Format("SELECT * FROM SEvents WHERE OrganizerId={0} AND Id={1};", Session["UserId"], eventID);
                    reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        reader.Close();
                        connection.Close();
                        Response.Redirect("Failed.aspx");
                    }
                }
                command.CommandText = String.Format("DELETE FROM Event{0} WHERE CID={1};", eventID, UserID);
                try
                {
                    command.ExecuteNonQuery();
                    message = "Entry deleted";
                }
                catch
                {
                    message = "Event doesn't exist or the user specified doesn't participate.";
                }
                connection.Close();

            }
        }
    }
}