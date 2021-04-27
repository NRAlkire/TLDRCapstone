using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace TLDR_Capstone
{
	public partial class About : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void importBtn_Click(object sender, EventArgs e)
		{
			Classes.Catalog catalog = new Classes.Catalog();
			catalog.import("C:/Brad School/Spring 2021/Capstone Project/TLDR Capstone/WU_CourseScheduleTrim.csv");
		}
	}
}