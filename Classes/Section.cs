using System;
using System.Collections.Generic;
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

        public void insertCourses(String con)
        {
            string query = "INSERT INTO Sections(DeptID,CourseID,Instructor,Section,BeginTime,EndTime,MeetDays) VALUES(@DeptID,@CourseID,@Instructor,@Section,@BeginTime,@EndTime,@MeetDays)";

            SQLCommand cmd = new SQLCommand(query, con);


            cmd.Paramenters.AddWithValue("@DeptID", getDeptID());
            cmd.Paramenters.AddWithValue("@CourseID", getCourseNum());
            cmd.Paramenters.AddWithValue("@Instructor", getInstructor());
            cmd.Paramenters.AddWithValue("@Section", getSection());
            cmd.Paramenters.AddWithValue("@BeginTime", getBeginTime());
            cmd.Paramenters.AddWithValue("@EndTime", getEndTime());
            cmd.Paramenters.AddWithValue("@MeetDays", getMeetDays());

            cmd.ExecuteNonQuery();
        }
    }
}