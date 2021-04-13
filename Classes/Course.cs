using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLDR_Capstone.Classes
{
	public class Course
	{
        //Constructor
        public Course(String pName, String pCourseID, String pInstructor, List<Section> pSections)
        {
            name = pName;
            courseID = pCourseID;
            instructor = pInstructor;
            sections = pSections;
        }

        //Members
        public String name, courseID, instructor;
        public List<Section> sections;

        //Add a section to the course sections
        public void addSection(Section pSection)
        {
            sections.Add(pSection);
        }

        //Getters and Setters
        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getCourseID()
        {
            return courseID;
        }

        public void setCourseID(String courseID)
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