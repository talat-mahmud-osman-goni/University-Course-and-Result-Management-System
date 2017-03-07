using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway=new StudentGateway();
        public string SaveStudent(Student aStudent)
        {
            if (aStudentGateway.IsEmailExists(aStudent.Email) != null)
            {
                return "email not unique";
            }
            if (aStudentGateway.SaveStudent(aStudent)>0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }
        public List<SelectListItem> GetSelectRegNo()
        {
            List<SelectListItem> getSelectRegNo = aStudentGateway.GetSelectRegNo();
            return getSelectRegNo;

        }

        public List<Student> GetAllStudents(int studentId)
        {
            return aStudentGateway.GetAllStudents(studentId);
        }
    }
}