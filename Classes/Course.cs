using System;
using System.Collections.Generic;
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

        public void insertCourses(String con)
        {
            string query = "INSERT INTO Courses(DeptID,CourseID,Name,Instructor) VALUES(@DeptID,@CourseID,@Name,@Instructor)";

            SQLCommand cmd = new SQLCommand(query, con);


            cmd.Paramenters.AddWithValue("@DeptID", getDeptID());
            cmd.Paramenters.AddWithValue("@CourseID", getCourseID());
            cmd.Paramenters.AddWithValue("@Name", getName());
            cmd.Paramenters.AddWithValue("@Instructor", getInstructor());

            cmd.ExecuteNonQuery();
        }
    }
}