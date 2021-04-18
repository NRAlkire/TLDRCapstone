using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TLDR_Capstone.Classes
{
	public class Section
	{
        //Constructor
        public Section(String pDeptID, int pCourseID, String pSection, String pInstructor, int pBeginTime, int pEndTime, List<Boolean> pMeetDays)
        {
            courseID = pCourseID;
            section = pSection;
            instructor = pInstructor;
            beginTime = pBeginTime;
            endTime = pEndTime;
            meetDays = pMeetDays;
        }

        //Members
        public String deptID, section, instructor;
        public int courseID, beginTime, endTime;
        public List<Boolean> meetDays;

        //Getters and Setters
        public String getDeptID()
        {
            return deptID;
        }

        public void setDeptID(String pDeptID)
        {
            deptID = pDeptID;
            return;
        }
        public int getCourseNum()
        {
            return courseID;
        }

        public void setCourseNum(int courseNum)
        {
            this.courseID = courseNum;
        }

        public String getSection()
        {
            return section;
        }

        public void setSection(String section)
        {
            this.section = section;
        }

        public String getInstructor()
        {
            return instructor;
        }

        public void setInstructor(String instructor)
        {
            this.instructor = instructor;
        }

        public List<Boolean> getMeetDays()
        {
            return meetDays;
        }

        public void setMeetDays(List<Boolean> meetDays)
        {
            this.meetDays = meetDays;
        }

        public int getBeginTime()
        {
            return beginTime;
        }

        public void setBeginTime(int beginTime)
        {
            this.beginTime = beginTime;
        }

        public int getEndTime()
        {
            return endTime;
        }

        public void setEndTime(int endTime)
        {
            this.endTime = endTime;
        }

        public void insertSections()
        {
            SqlConnection con = new SqlConnection();
            string query = "INSERT INTO Sections(Instructor,Section) VALUES(@Instructor,@Section)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Instructor", getInstructor());
            cmd.Parameters.AddWithValue("@Section", getSection());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}