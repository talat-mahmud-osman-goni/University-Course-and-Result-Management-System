using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Manager
{
    public class CourseStaticsManager
    {
        CourseStaticsGateway aCourseStaticsGateway=new CourseStaticsGateway();

        public List<CourseStatics> GetAllCourseStatics()
        {
            return aCourseStaticsGateway.GetAllCourseStatics();
        }
    }
}