using System;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace TLDR_Capstone
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
		{
            string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			
			SqlConnection conn = new SqlConnection(constr);
			SqlCommand command = new SqlCommand("select password from Users where username = '" + Login.UserName + "'");
			
			command.Connection = conn;

			conn.Open();
			string value = (string)command.ExecuteScalar();
			conn.Close();

			if (value == null) Login.FailureText = "User not found";

			else if (value.Trim().Equals(Login.Password))
			{
				e.Authenticated = true;
				Student student = new Student();
				student.setUsername(Login.UserName);
				command = new SqlCommand("select authlevel from users where username = " +
					"'" + student.getUsername() + "'");

				command.Connection = conn;
				conn.Open();
				student.setAuthLvl((int)command.ExecuteScalar());
				conn.Close();

				Session["Student"] = student;

				Response.Redirect("~/Dashboard");

			}

		}

		protected void gotoRegBtn_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Register");
		}
	}
}