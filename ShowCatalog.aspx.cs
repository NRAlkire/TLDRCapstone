using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;


namespace TLDR_Capstone
{
	public partial class ShowCatalog : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			string authlevel = null;

			if (student.getAuthLvl() == 0) authlevel = "Student";
			else if (student.getAuthLvl() == 1) authlevel = "Administrator";
			else if (student.getAuthLvl() == 2) authlevel = "Root User";
			else authlevel = "Unknown";

			userandlvl.Text = student.getUsername() + ", " + authlevel;
		}

		protected void catalogGridview_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
	}
}