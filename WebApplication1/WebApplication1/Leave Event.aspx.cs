using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Leave_Event : System.Web.UI.Page
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
            command.CommandText = string.Format("DELETE FROM EVENT{0} WHERE CID={1};", Request.Form["EId"], Session["UserId"]);
            try
            {
                command.ExecuteNonQuery();
                message = "Entry removed";
            }
            catch
            {
                message = "Event Doesn't exist, or you havn't signed up for it yet.";
            }
        }
    }
}