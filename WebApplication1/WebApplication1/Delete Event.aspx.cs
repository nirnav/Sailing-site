using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Delete_Event : System.Web.UI.Page
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
                string eventID = Request.Form["EId"];
                command.CommandText = String.Format("SELECT * FROM Users WHERE Id={0} AND IsAdmin=1;", Session["UserId"]);
                SqlDataReader reader = command.ExecuteReader();
                bool IsAdmin = reader.Read();
                reader.Close();
                command.CommandText = String.Format("SELECT * FROM SEvents WHERE Id={0} AND OrganizerID={1};", eventID, Session["UserId"]);
                reader = command.ExecuteReader();
                bool IsOrg = reader.Read();
                reader.Close();
                if (IsAdmin || IsOrg)
                {
                    try
                    {
                        command.CommandText = String.Format("DELETE FROM SEvents WHERE Id={0}; DROP TABLE Event{0}", Request.Form["EId"]);
                        command.ExecuteNonQuery();
                        message = "Entry deleted.";
                    }
                    catch
                    {
                        message = "This ID does not exist in the database";
                    }

                }
                connection.Close();
            }
        }
    }
}