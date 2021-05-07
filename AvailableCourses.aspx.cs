using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TLDR_Capstone.Classes;

namespace TLDR_Capstone
{
	public partial class AvailableCourses : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Student student = Session["Student"] as Student;

				if (student == null) student = new Student();

				DataTable dt = new DataTable();
				dt.Columns.Add("chkbox", typeof(bool));

				DataColumn dc = new DataColumn("Course");
				dt.Columns.Add(dc);

				if (student.potentialCourses.Count != 0)
				{
					foreach (Course course in student.potentialCourses)
					{
						DataRow dr = dt.NewRow();
						dr["Course"] = course.getName();
						dt.Rows.Add(dr);
					}

					availableCoursesGV.DataSource = dt;
					availableCoursesGV.DataBind();
				}
			}
		}

		protected void select_Click(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			student.selectedCourses.Clear();

			foreach (GridViewRow row in availableCoursesGV.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						student.addSelectedCourse(student.potentialCourses[row.RowIndex]);
					}
				}
			}

			Session["Student"] = student;

			//this last bit is deletable
			selectedcourses.Text = "";

			foreach (var section in student.selectedCourses[0].getSections())
			{
				selectedcourses.Text += "title " + section.getCourseTitle() + "<br/>";
				selectedcourses.Text += "instructor " + section.getInstructor() + "<br/>";
				selectedcourses.Text += "meetdays " + section.getMeetDays() + "<br/>";
				selectedcourses.Text += "begin " + section.getBeginTime() + "<br/>";
				selectedcourses.Text += "end " + section.getEndTime() + "<br/>";
			}
		}
	}
}