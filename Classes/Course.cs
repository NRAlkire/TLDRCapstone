using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLDR_Capstone.Classes
{
	public class Course
	{
        //Constructor
        public Course(String pDeptID, String pName, int pCourseID, String pInstructor, List<Section> pSections)
        {
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
    }
}