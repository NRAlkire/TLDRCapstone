﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using TLDR_Capstone.Classes;
using System.Configuration;
using System.Data.SqlClient;


namespace TLDR_Capstone
{
	public partial class ShowCatalog : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			string authlevel = null;

			if (student == null) userandlvl.Text = "Unknown user";
			else if (student.getAuthLvl() == 0) authlevel = "Student";
			else if (student.getAuthLvl() == 1) authlevel = "Administrator";
			else if (student.getAuthLvl() == 2) authlevel = "Root User";
			else authlevel = "Unknown";

			if (student != null) userandlvl.Text = student.getUsername() + ", " + authlevel;
		}

		protected void selectBtn_Click(object sender, EventArgs e)
		{
			List<string> coursesList = new List<string>();
			//Grab Student from Session
			Student student = Session["Student"] as Student;

			if (student == null) student = new Student();

			student.selectedCourses.Clear();
			selected.Text = "";
			//int i = 0;

			foreach (GridViewRow row in catalogGridview.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						coursesList.Add(row.Cells[3].Text);
					}
				}
			}

			Course myCourse = null;
			Section mySection = null;


			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;

			SqlConnection conn = new SqlConnection(constr);

			foreach (string course in coursesList)
			{
				myCourse = null;
				SqlCommand command = new SqlCommand("SELECT * FROM Schedule WHERE courseTitle = '" + HttpUtility.HtmlDecode(course) + "'");
				command.Connection = conn;

				DataTable dataTable = new DataTable();

				using (SqlDataAdapter da = new SqlDataAdapter(command))
				{
					da.Fill(dataTable);
				}

				myCourse = new Course(dataTable.Rows[0][1].ToString(), int.Parse(dataTable.Rows[0][2].ToString()),
					dataTable.Rows[0][3].ToString(), null); 

				//da now has all sections
				foreach (DataRow dataRow in dataTable.Rows)
				{
					mySection = null;
					mySection = new Section(dataRow[1].ToString(), int.Parse(dataRow[2].ToString()), dataRow[3].ToString(),
						dataRow[4].ToString(), dataRow[5].ToString(),
						int.Parse(dataRow[7].ToString()), int.Parse(dataRow[8].ToString()), dataRow[6].ToString());
					//String pDeptID, int pCourseNumber, String pCourseTitle, String pSection, String pInstructor, int pBeginTime, int pEndTime, string pMeetDays
					myCourse.addSection(mySection);
				}
				student.addPotentialCourse(myCourse);
			}

			//test to see if it worked
			for (int i = 0; i < student.potentialCourses.Count(); i++)
			{
				selected.Text += student.potentialCourses[i].getName() + "<br/>";
			}

			Session["Student"] = student;
		}
	}
}