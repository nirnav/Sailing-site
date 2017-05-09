using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Delete_User : System.Web.UI.Page
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
            command.CommandText = String.Format("SELECT * FROM Users WHERE Id={0} AND IsAdmin=1;", Session["UserId"]);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                connection.Close();
                Response.Redirect("Home.aspx");
            }
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["UId"] != null)
                {
                    try
                    {
                        command.CommandText = String.Format("DELETE FROM Users WHERE Id={0};", Request.Form["UId"]);
                        command.ExecuteNonQuery();
                        message = "Entry deleted.";
                    }
                    catch
                    {
                        message = "This ID does not exist in the database";
                    }
                }
                else if (Request.Form["UserN"] != null)
                {
                    try
                    {
                        command.CommandText = String.Format("DELETE FROM Users WHERE Username={0};", Request.Form["UserN"]);
                        command.ExecuteNonQuery();
                        message = "Entry deleted.";
                    }
                    catch
                    {
                        message = "This Username does not exist in the database";
                    }
                }
                else
                    message = "Please enter an ID or a username";
                connection.Close();
            }
        }
    }
}