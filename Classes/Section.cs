using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLDR_Capstone.Classes
{
	public class Section
	{
        //Constructor
        public Section(String pDeptID, int pCourseID, int pSection, int pBeginTime, int pEndTime, List<Boolean> pMeetDays)
        {
            courseID = pCourseID;
            section = pSection;
            beginTime = pBeginTime;
            endTime = pEndTime;
            meetDays = pMeetDays;
        }

        //Members
        public String deptID;
        public int courseID, section, beginTime, endTime;
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

        public int getSection()
        {
            return section;
        }

        public void setSection(int section)
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