using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Manager
{
    public class CourseAssignTeacherManager
    {
        TeacherGateway aTeacherGateway=new TeacherGateway();
        CourseGateway aCourseGateway=new CourseGateway();
        CourseAssignTeacherGateway aCourseAssignTeacherGateway=new CourseAssignTeacherGateway();

        public List<Teacher> GetAllTeachers()
        {
            return aTeacherGateway.GetAllTeachers();
        }

        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }

        public string SaveCourseAssignTeacher(CourseAssignTeacher aCourseAssignTeacher)
        {
            if (aCourseAssignTeacherGateway.IsCourseAssigned(aCourseAssignTeacher.CourseId)!=null)
            {
                return "course already assigned";
            }
            if (aCourseAssignTeacherGateway.SaveCourseAssignTeacher(aCourseAssignTeacher)>0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }

        public string UnassignCourses()
        {
            if (aCourseAssignTeacherGateway.UnassignCourses()>0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }
    }
}