using System;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace TLDR_Capstone
{
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void regBtn_Click1(object sender, EventArgs e)
		{
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;

			SqlConnection conn = new SqlConnection(constr);


			if (passTB.Text.Equals(passConfTB.Text))
			{

				SqlCommand command = new SqlCommand("select username from Users where " +
					"exists (select username from Users where username = '" + userTB.Text + "')");
				command.Connection = conn;
				conn.Open();
				if (command.ExecuteScalar() == null)
				{
					
					string to = emailTB.Text; //To address    
					string from = "scheduleplannerdonotreply@gmail.com"; //From address   
					MailMessage message = new MailMessage(from, to);

					String mailbody = "";
					//Student request
					if (accessLvlDD.SelectedIndex == 0)
					{
						//Body of message
						mailbody = "Please enter your email at /*insert link*/ to verify your account.";
					}
					//Admin or Root request
					else
                    {
						mailbody = "You will receive an email when your account has been reviewed by a root user.";
                    }

					//Subject of message
					message.Subject = "Registration Verification";  
					message.Body = mailbody;  
					message.BodyEncoding = Encoding.UTF8;  
					message.IsBodyHtml = true;  
					SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
					System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("scheduleplannerdonotreply@gmail.com", "TLDRCapstone0=");  
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
					}  ;

					conn.Close();
					command = new SqlCommand("INSERT INTO Users (username, password, authlevel, email) " +
						"VALUES(@username, @password, @authlevel, @email)", conn);

					command.Parameters.AddWithValue("@username", userTB.Text);
					command.Parameters.AddWithValue("@password", passTB.Text);
					command.Parameters.AddWithValue("@authlevel", accessLvlDD.SelectedIndex);
					command.Parameters.AddWithValue("@email", emailTB.Text);

					debug.Text = userTB.Text + passTB.Text + accessLvlDD.SelectedIndex + emailTB.Text;

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