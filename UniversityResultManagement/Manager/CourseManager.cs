using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway=new CourseGateway();
        public string SaveCourse(Course aCourse)
        {
            if (aCourseGateway.IsCodeUnique(aCourse.Code)!=null)
            {
                return "code not unique";
            }
            if (aCourseGateway.IsNameUnique(aCourse.Name)!=null)
            {
                return "name not unique";
            }
            if (aCourseGateway.SaveCourse(aCourse)>0)
            {
                return "yes";

            }
            else
            {
                return "no";
            }
        }

        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }

        
    }
}