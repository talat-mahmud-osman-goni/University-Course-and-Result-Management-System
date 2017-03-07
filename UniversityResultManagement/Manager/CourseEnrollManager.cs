using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Manager
{
    public class CourseEnrollManager
    {
        CourseEnrollGateway aEnrollGateway=new CourseEnrollGateway();

        public string SaveCourseEnroll(CourseEnroll aCourseEnroll)
        {
            if (aEnrollGateway.IsStudentInCourseExist(aCourseEnroll.StudentId,aCourseEnroll.CourseId)!=null)
            {
                return "enroll not unique";
            }
            if (aEnrollGateway.SaveCourseEnroll(aCourseEnroll)>0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }

        public List<SelectListItem> GetSelectGrade()
        {
            return aEnrollGateway.GetSelectGrade();
        }

        public List<CourseEnroll> GetCourseByStudentId()
        {
            return aEnrollGateway.GetCourseByStudentId();
        }
    }
}