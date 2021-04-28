using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLDR_Capstone
{
	public partial class Contact : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void verBtn_Click1(object sender, EventArgs e)
        {
			string inputEmail = emailVerTB.Text;

			//connection string
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			SqlConnection conn = new SqlConnection(constr);

			//select the requested authlevel for the specified email
			SqlCommand command = new SqlCommand("SELECT authlevel FROM Users WHERE email = @inputEmail", conn);
			command.Parameters.AddWithValue("@inputEmail", inputEmail);

			conn.Open();
			//if the user exists and if the requested authlevel is student
			if (!(command.ExecuteScalar() == null) && (int) command.ExecuteScalar() == 0)
			{
				conn.Close();

				//Get the username to use as key for registration table
				command = new SqlCommand("SELECT username FROM Users WHERE email = @inputEmail", conn);
				command.Parameters.AddWithValue("@inputEmail", inputEmail);

				conn.Open();
				String userName = (String) command.ExecuteScalar();
				conn.Close();

				//update verified value to true
				command = new SqlCommand("UPDATE Registration SET verified = @Verified WHERE registrationColumnID = @username", conn);
				command.Parameters.AddWithValue("@username", userName);
				command.Parameters.AddWithValue("@Verified", true);

				conn.Open();
				command.ExecuteNonQuery();

				string to = inputEmail; //To address    
				string from = "scheduleplannerdonotreply@gmail.com"; //From address   
				MailMessage message = new MailMessage(from, to);

				string mailbody = "Your email has now been verified. You may now login to the Schedule Planner.";
				message.Subject = "Registration Verification";
				message.Body = mailbody;
				message.BodyEncoding = Encoding.UTF8;
				message.IsBodyHtml = true;
				SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
				System.Net.NetworkCredential basicCredential1 = new
				System.Net.NetworkCredential("scheduleplannerdonotreply@gmail.com", "TLDRCapstone0=");
				client.EnableSsl = true;
				client.UseDefaultCredentials = false;
				client.Credentials = basicCredential1;
				try
				{
					client.Send(message);
				}

				catch (Exception ex)
				{
					throw ex;
				};
			}
			else
			{
				debug.Text = "No username with that email address exists or requested authorization level too high.";
			}
			conn.Close();

			return;
		}
	}
}