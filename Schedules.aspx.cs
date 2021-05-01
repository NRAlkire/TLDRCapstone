using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLDR_Capstone.Classes;

namespace TLDR_Capstone
{
	public partial class Schedules : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void GenerateSchedules_Click(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			if (student.selectedCourses.Count() >= 2 && student.selectedCourses.Count() <= 4)
			{
				student.generateValidSchedules();
			}

			schedules.Text = "";

			foreach (var schedule in student.allValidSchedules)
			{
				foreach (var section in schedule)
				{
					schedules.Text += section.getCourseTitle() + ": " 
						+ section.getMeetDays() +
						" Begin:" + section.getBeginTime() + 
						", End:" + section.getEndTime() + "<br/>";
				}
				schedules.Text += "<br/>";
			}
		}
	}
}