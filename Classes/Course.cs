using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TLDR_Capstone.Classes
{
	public class Course
	{
        //Constructor
        public Course(String pDeptID, int pCourseID, String pName, String pInstructor, List<Section> pSections)
        {
            deptID = pDeptID;
            name = pName;
            courseID = pCourseID;
            instructor = pInstructor;
            sections = pSections;
        }

        //Members
        public String deptID, name, instructor;
        public int courseID;
        public List<Section> sections;

        //Add a section to the course sections
        public void addSection(Section pSection)
        {
            sections.Add(pSection);
        }

        public void removeSection(Section pSection)
        {
            sections.Remove(pSection);
        }

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
        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public int getCourseID()
        {
            return courseID;
        }

        public void setCourseID(int courseID)
        {
            this.courseID = courseID;
        }

        public String getInstructor()
        {
            return instructor;
        }

        public void setInstructor(String instructor)
        {
            this.instructor = instructor;
        }

        public List<Section> getSections()
        {
            return sections;
        }

        public void setSections(List<Section> sections)
        {
            this.sections = sections;
        }

        public void insertCourses()
        {
            SqlConnection con = new SqlConnection();
            string query = "INSERT INTO Courses(DeptID,CourseID,Name) VALUES(@DeptID,@CourseID,@Name)";

            SqlCommand cmd = new SqlCommand(query, con);
            
            cmd.Parameters.AddWithValue("@DeptID", getDeptID());
            cmd.Parameters.AddWithValue("@CourseID", getCourseID());
            cmd.Parameters.AddWithValue("@Name", getName());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}