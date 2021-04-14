using System;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace TLDR_Capstone
{
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void regBtn_Click1(object sender, EventArgs e)
		{
			string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

			SqlConnection conn = new SqlConnection(constr);


			if (passTB.Text.Equals(passConfTB.Text))
			{

				SqlCommand command = new SqlCommand("select username from Users where " +
					"exists (select username from Users where username = '" + userTB.Text + "')");
				command.Connection = conn;
				conn.Open();
				if (command.ExecuteScalar() == null)
				{
					conn.Close();
					command = new SqlCommand("insert into Users (username, password, authlevel) " +
						"VALUES('" + userTB.Text + "', '" + passTB.Text + "', '" + accessLvlDD.SelectedIndex + "')", conn);

					debug.Text = userTB.Text + passTB.Text + accessLvlDD.SelectedIndex;

					conn.Open();
					command.ExecuteNonQuery();
					debug.Text = "User successfully added.";
				}
				else
				{
					debug.Text = "Username already exists.";
				}
				conn.Close();
			}
			else
			{
				debug.Text = "Passwords do not match.";
			}
		}
	}
}