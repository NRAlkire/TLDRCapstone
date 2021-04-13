using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;

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


			Label1.Text = value + " " + Login.Password.ToString() + " " + (value.Trim() == Login.Password.Trim());
			if (Object.Equals(value.Trim(), Login.Password.Trim()))
			{
				e.Authenticated = true;
				Response.Redirect("~/About");

			}

		}
	}
}