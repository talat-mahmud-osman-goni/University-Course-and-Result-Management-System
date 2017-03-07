using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Manager
{
    public class StudentResultManager
    {
        StudentResultGateway aStudentResultGateway=new StudentResultGateway();
        public string SaveStudentResult(StudentResult aStudentResult)
        {
            if (aStudentResultGateway.IsStudentCodeExists(aStudentResult.StudentId, aStudentResult.CourseId) != null)
            {
                if (aStudentResultGateway.UpdateResult(aStudentResult) > 0)
                {
                    return "updated";
                }               
            }
            if (aStudentResultGateway.SaveStudentResult(aStudentResult) > 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }

        public List<ViewResult> GetResultByStudentId(int studentId)
        {
            return aStudentResultGateway.GetResultByStudentId(studentId);
        }
    }
}