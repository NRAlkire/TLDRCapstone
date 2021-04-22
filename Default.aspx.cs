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
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
			
			SqlConnection conn = new SqlConnection(constr);
			SqlCommand command = new SqlCommand("select password from Users where username = '" + Login.UserName + "'");
			
			command.Connection = conn;
			conn.Open();
			string value = (string)command.ExecuteScalar();
			conn.Close();

			if (value.Trim().Equals(Login.Password))
			{
				e.Authenticated = true;
				Response.Redirect("~/html_css/student-dashboard.html");

			}

		}

		protected void gotoRegBtn_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Register");
		}
	}
}