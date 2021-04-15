﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLDR_Capstone.Classes
{
	public class Section
	{
        //Constructor
        public Section(String pCourseID, String pSection, int pBeginTime, int pEndTime, List<Boolean> pMeetDays)
        {
            courseID = pCourseID;
            section = pSection;
            beginTime = pBeginTime;
            endTime = pEndTime;
            meetDays = pMeetDays;
        }

        //Members
        public String courseID, section;
        public int beginTime, endTime;
        public List<Boolean> meetDays;

        //Getters and Setters
        public String getCourseNum()
        {
            return courseID;
        }

        public void setCourseNum(String courseNum)
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
    }
}