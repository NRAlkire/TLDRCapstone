using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLDR_Capstone.Classes
{
	public class Catalog
	{
        //Constructor
        public Catalog(List<Course> pCourses)
        {
            courses = pCourses;
        }

        //Members
        public List<Course> courses;

        //Add a single course
        public void addCourse(Course pCourse)
        {
            courses.Add(pCourse);
        }

        //Getters and Setters
        public List<Course> getCourses()
        {
            return courses;
        }

        public void setCourses(List<Course> courses)
        {
            this.courses = courses;
        }
    }
}