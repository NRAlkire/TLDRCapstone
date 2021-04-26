using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLDR_Capstone.Classes;

namespace TLDR_Capstone
{
    public class Student
    {
        //Members
        public List<Course> potentialCourses, selectedCourses, validSchedule;
        public List<List<Section>> allValidSchedules;
        public string username;
        public int authLvl;

        public void setUsername(string pUser)
        {
            username = pUser;
        }

        public string getUsername()
        {
            return username;
        }

        public void setAuthLvl(int pLvl)
        {
            authLvl = pLvl;
        }

        public int getAuthLvl()
        {
            return authLvl;
        }
        //Add a single course to the list of potential courses
        public void addPotentialCourse(Course pCourse)
        {
            potentialCourses.Add(pCourse);
        }

        //Add a single course to the list of selected courses that a schedule will be generated from
        public void addSelectedCourse(Course pCourse)
        {
            selectedCourses.Add(pCourse);
        }

        //Function to determine if a combination of course sections has any scheduling overlaps
        public Boolean hasOverlap(List<Section> pSections)
        {
            Boolean hasOverlap = false;

            //Here we compare start and end times of all the sections in the provided potential schedule
            //We use nested loops to iterate through all the sections

            //Check all but last section because it has already been checked against the proceeding sections
            for (int i = 0; i < pSections.Count() - 1; i++)
            {
                //j = i + 1 because no need to recheck first section or itself
                for (int j = i + 1; j < pSections.Count(); j++)
                {

                    //Checking for overlap. If the begin or end time of section i falls within
                    //begin and end time of section j, there is overlap



                    //First check to see if course is same day
                    if ((pSections[i].getBMeetDays()[0] && pSections[j].getBMeetDays()[0])    //Monday
                    || (pSections[i].getBMeetDays()[1] && pSections[j].getBMeetDays()[1])     //Tuesday
                    || (pSections[i].getBMeetDays()[2] && pSections[j].getBMeetDays()[2])     //Wednesday
                    || (pSections[i].getBMeetDays()[3] && pSections[j].getBMeetDays()[3])     //Thursday
                    || (pSections[i].getBMeetDays()[4] && pSections[j].getBMeetDays()[4]))
                    {  //Friday
                        if (((pSections[i].getBeginTime() > pSections[j].getBeginTime()) &&
                            (pSections[i].getBeginTime() < pSections[j].getEndTime())) ||
                            ((pSections[i].getEndTime() > pSections[j].getBeginTime()) &&
                                (pSections[i].getEndTime() < pSections[j].getEndTime())))
                        {
                            hasOverlap = true;
                        }
                    }
                }
            }
            return hasOverlap;
        }

        public List<List<Section>> generateValidSchedules(List<Course> pCourses)
        {
            //Initialize return value
            List<List<Section>> validSchedules = new List<List<Section>>();

            //Temporary variable to store schedule being evaluated
            List<Section> beingEvaluated = new List<Section>();

            //Here we switch on the number of courses selected
            switch (pCourses.Count())
            {
                //2 Courses
                case 2:
                    for (int i = 0; i < pCourses[0].getSections().Count(); i++)
                    {
                        for (int j = 0; j < pCourses[1].getSections().Count(); j++)
                        {
                            beingEvaluated.Add(pCourses[0].getSections()[i]);
                            beingEvaluated.Add(pCourses[1].getSections()[j]);
                            if (!hasOverlap(beingEvaluated))
                            {
                                validSchedules.Add(beingEvaluated);
                            }
                            beingEvaluated.Clear();
                        }
                    }
                    break;
                //3 Courses
                case 3:
                    for (int i = 0; i < pCourses[0].getSections().Count(); i++)
                    {
                        for (int j = 0; j < pCourses[1].getSections().Count(); j++)
                        {
                            for (int k = 0; k < pCourses[2].getSections().Count(); k++)
                            {
                                beingEvaluated.Add(pCourses[0].getSections()[i]);
                                beingEvaluated.Add(pCourses[1].getSections()[j]);
                                beingEvaluated.Add(pCourses[2].getSections()[k]);
                                if (!hasOverlap(beingEvaluated))
                                {
                                    validSchedules.Add(beingEvaluated);
                                }
                                beingEvaluated.Clear();
                            }
                        }
                    }
                    break;
                //4 Courses
                case 4:
                    for (int i = 0; i < pCourses[0].getSections().Count(); i++)
                    {
                        for (int j = 0; j < pCourses[1].getSections().Count(); j++)
                        {
                            for (int k = 0; k < pCourses[2].getSections().Count(); k++)
                            {
                                for (int l = 0; l < pCourses[3].getSections().Count(); l++)
                                {
                                    beingEvaluated.Add(pCourses[0].getSections()[i]);
                                    beingEvaluated.Add(pCourses[1].getSections()[j]);
                                    beingEvaluated.Add(pCourses[2].getSections()[k]);
                                    beingEvaluated.Add(pCourses[3].getSections()[l]);
                                    if (!hasOverlap(beingEvaluated))
                                    {
                                        validSchedules.Add(beingEvaluated);
                                    }
                                    beingEvaluated.Clear();
                                }
                            }
                        }
                    }
                    break;
                default:
                    beingEvaluated.Clear();
                    break;
            }

            return validSchedules;
        }
        /*public List<Boolean> convDays2Bool(String pDays)
        {
            //create a boolean list for Monday to Friday, with Monday as 0 and all days as false
            List<Boolean> MeetDays = new List<Boolean> { false, false, false, false, false };

            //if the days are in the string, set the day true in the list
            if (pDays.Contains("M"))
            {
                MeetDays[0] = true;
            }
            if (pDays.Contains("T"))
            {
                MeetDays[1] = true;
            }
            if (pDays.Contains("W"))
            {
                MeetDays[2] = true;
            }
            if (pDays.Contains("R"))
            {
                MeetDays[3] = true;
            }
            if (pDays.Contains("F"))
            {
                MeetDays[4] = true;
            }

            return MeetDays;
        }*/
    }
}