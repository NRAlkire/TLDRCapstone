using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLDR_Capstone
{
	public partial class ShowSections : System.Web.UI.Page
	{

		protected void Page_Init()
		{
			scheduleGridview.DataBind();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			scheduleGridview.DataBind();

			if ((student.getAuthLvl() != 1) || (student.getAuthLvl() != 2))
			{
				AddSection.Visible = false;
			}
		}
	}
}