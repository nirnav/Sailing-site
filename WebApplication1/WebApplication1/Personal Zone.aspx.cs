using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public string pm;
        public string nm;
        public string um;
        public string em;
        public string npm;
        public string cm;
        public string admin;
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
            if (reader.Read() == true)
            {
                reader.Close();
                admin = "<a href = \"For Admin.aspx\"><u>Admin Interface</u></a>";
            }
            else
                reader.Close();
            if (Request.HttpMethod == "POST")
            {
                string fullname = Request.Form["FullName"];
                string username = Request.Form["Username"];
                string email = Request.Form["Email"];
                string password = Request.Form["Password"];
                string npassword = Request.Form["Password2"];
                string sclass = Request.Form["Sclass"];

                command.CommandText = String.Format("SELECT * FROM Users WHERE Id='{0}' AND Password='{1}'", Session["UserId"], password);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    um = "not updated";
                    em = "not updated";
                    reader.Close();

                    if (fullname.Length==0)
                        nm = "not updated";
                    else
                    {
                        command.CommandText = String.Format("UPDATE Users SET FullName='{0}' WHERE Id={1};", fullname, Session["UserId"]);
                        command.ExecuteNonQuery();
                        nm = "updated";
                        Session["Name"] = fullname;
                    }

                    command.CommandText = String.Format("SELECT Email FROM Users WHERE Email='{0}' ", email);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        em = "A member with this E-mail already exists.</br>";
                        reader.Close();
                    }
                    else if (email.Length != 0)
                    {
                        reader.Close();
                        command.CommandText = String.Format("UPDATE Users SET Email='{0}' WHERE Id={1};", email, Session["UserId"]);
                        command.ExecuteNonQuery();
                        em = "updated";
                    }
                    reader.Close();

                    command.CommandText = String.Format("SELECT Username FROM Users WHERE Username='{0}' ", username);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        um = "A member with this username already exists.";
                    }
                    else if (username.Length != 0)
                    {
                        reader.Close();
                        command.CommandText = String.Format("UPDATE Users SET Username='{0}' WHERE Id={1};", username, Session["UserId"]);
                        command.ExecuteNonQuery();
                        um = "updated";
                        Session["Username"] = username;
                    }
                    reader.Close();

                    if (npassword.Length == 0)
                        npm = "not updated";
                    else
                    {
                        command.CommandText = String.Format("UPDATE Users SET Password='{0}' WHERE Id={1};", npassword, Session["UserId"]);
                        command.ExecuteNonQuery();
                        npm = "updated";
                    }

                    if (sclass == "NA")
                        cm = "not updated";
                    else
                    {
                        command.CommandText = String.Format("UPDATE Users SET Class='{0}' WHERE Id={1};", sclass, Session["UserId"]);
                        command.ExecuteNonQuery();
                        cm = "updated";
                    }

                }
                else
                {
                    pm = "Incorrect password";
                    reader.Close();
                }
                connection.Close();

            }
        }
    }
}