﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

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

			if ((student.getAuthLvl() != 1) || (student.getAuthLvl() != 2))
			{
				AddSection.Visible = false;
			}
		}

		protected void deleteBtn_Click(object sender, EventArgs e)
		{
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			SqlConnection conn = new SqlConnection(constr);
			SqlCommand command = new SqlCommand();


			foreach (GridViewRow row in scheduleGridview.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						command = new SqlCommand("DELETE FROM Schedule WHERE " +
							"deptID = '" + row.Cells[1].Text.ToString()
							+ "' AND courseNumber = '" + row.Cells[2].Text.ToString()
							+ "' AND courseTitle = '" + HttpUtility.HtmlDecode(row.Cells[3].Text.ToString())
							+ "' AND sectionID = '" + row.Cells[4].Text
							+ "' AND instructor = '" + row.Cells[5].Text
							+ "' AND days = '" + row.Cells[6].Text
							+ "' AND startTime = '" + row.Cells[7].Text
							+ "' AND endTime = '" + row.Cells[8].Text + "'");

						command.Connection = conn;

						conn.Open();
						command.ExecuteNonQuery();
						conn.Close();
					}
				}
			}
			scheduleGridview.DataBind();
		}

		protected void refresh_Click(object sender, EventArgs e)
		{
			scheduleGridview.DataBind();
		}
	}
}