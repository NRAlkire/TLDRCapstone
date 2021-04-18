using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.FileIO;

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

        public void import(String path)
        {
            List<Course> courses = new List<Course>();
            //open the file using TextFieldParser
            using (var reader = new TextFieldParser(path))
            {
                ///parse the .csv file along commass
                reader.SetDelimiters(",");
                //handle commas inside quotes
                reader.HasFieldsEnclosedInQuotes = true;
                //skip the first line
                reader.ReadFields();

                while (!reader.EndOfData)
                {
                    //read the entire line
                    var temp = reader.ReadFields();

                    //If the list is empty, the new course has a different department, or a different course number
                    if (courses.Count == 0 || !courses[courses.Count - 1].getDeptID().Equals(temp[0]) || courses[courses.Count - 1].getCourseID() != Int32.Parse(temp[1]))
                    {
                        //add the new course
                        courses.Add(new Course(temp[0], Int32.Parse(temp[1]), temp[2], temp[4], new List<Section>()));
                    }

                    String stringStartTime, stringEndTime;

                    //get the string start and end time
                    if (temp[5].Contains(","))
                    {
                        stringStartTime = temp[5].Substring(temp[5].IndexOf(" ") + 1, temp[5].IndexOf("-") - temp[5].IndexOf(" ") - 3);
                        stringEndTime = temp[5].Substring(temp[5].IndexOf("-") + 1, temp[5].IndexOf(",") - temp[5].IndexOf("-") - 3);
                    }
                    else
                    {
                        stringStartTime = temp[5].Substring(temp[5].IndexOf(" ") + 1, temp[5].IndexOf("-") - temp[5].IndexOf(" ") - 3);
                        stringEndTime = temp[5].Substring(temp[5].IndexOf("-") + 1, temp[5].Length - temp[5].IndexOf("-") - 3);
                    }

                    //parse the strings into ints
                    int beginTime = Int32.Parse(stringStartTime.Substring(0, stringStartTime.IndexOf(":")) + stringStartTime.Substring(stringStartTime.IndexOf(":") + 1));
                    int endTime = Int32.Parse(stringEndTime.Substring(0, stringEndTime.IndexOf(":")) + stringEndTime.Substring(stringEndTime.IndexOf(":") + 1));

                    //convert to military time
                    if ((stringStartTime.Contains("P") || stringStartTime.Contains("P")) && beginTime > 1259)
                    {
                        beginTime += 1200;
                    }
                    if ((stringEndTime.Contains("P") || stringEndTime.Contains("P")) && endTime > 1259)
                    {
                        endTime += 1200;
                    }

                    //get the days the class meets on
                    String Days = temp[5].Substring(0, temp[5].IndexOf(" "));

                    //create a boolean list for Monday to Friday, with Monday as 0 and all days as false
                    List<Boolean> MeetDays = new List<Boolean> { false, false, false, false, false };

                    //if the days are in the string, set the day true in the list
                    if (Days.Contains("M"))
                    {
                        MeetDays[0] = true;
                    }
                    if (Days.Contains("T"))
                    {
                        MeetDays[1] = true;
                    }
                    if (Days.Contains("W"))
                    {
                        MeetDays[2] = true;
                    }
                    if (Days.Contains("R"))
                    {
                        MeetDays[3] = true;
                    }
                    if (Days.Contains("F"))
                    {
                        MeetDays[4] = true;
                    }

                    //add the section to the course
                    courses[courses.Count - 1].addSection(new Section(temp[0], Int32.Parse(temp[1]), temp[3], beginTime, endTime, MeetDays));

                }
            }

            setCourses(courses);

            string connection;

            con.Open();
            courses.ForEach(insertCourses(connection));
            courses.ForEach(getSections().ForEach(insertSections(con)));
            con.Close();

            return;
        }
    }
}