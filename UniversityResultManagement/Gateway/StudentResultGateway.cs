using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityResultManagement.Models;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Gateway
{
    public class StudentResultGateway:CommonGateway
    {
        public int SaveStudentResult(StudentResult aStudentResult)
        {
            Query = "INSERT INTO StudentResult VALUES ('" + aStudentResult.StudentId + "','" + aStudentResult.CourseId +
                    "','" + aStudentResult.GradeId + "')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public StudentResult IsStudentCodeExists(int studentId, int courseId)
        {
            Query = "SELECT * FROM StudentResult WHERE StudentId='" + studentId + "' AND CourseId =" + courseId;
            Command = new SqlCommand(Query, Connection);
            StudentResult aStudentResult = new StudentResult();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                aStudentResult = null;
            }
            Reader.Close();
            Connection.Close();
            return aStudentResult;
        }

        public int UpdateResult(StudentResult aStudentResult)
        {
            Query = "UPDATE StudentResult SET GradeLetterId='" + aStudentResult.GradeId + "' WHERE StudentId='" +
                    aStudentResult.StudentId + "' AND CourseId=" + aStudentResult.CourseId;
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }


        public List<ViewResult> GetResultByStudentId(int studentId)
        {
            Query = "SELECT * FROM ViewResult WHERE StudentId='"+studentId+"' ORDER BY Code ASC";
            Command=new SqlCommand(Query,Connection);
            List<ViewResult> aList=new List<ViewResult>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewResult aViewResult = new ViewResult
                {
                    
                    StudentId = (int) Reader["StudentId"],
                    CourseName = Reader["Name"].ToString(),
                    CourseCode = Reader["Code"].ToString(),
                    //Grade = (string) Reader["Valid"] == "True" ? Reader["Grade"].ToString() : "Not Graded Yet"
                };
                //aViewResult.Grade = (string) Reader["Valid"] == "True" ? Reader["Grade"].ToString() : "Not Graded Yet";

                // Instead of if statement "?" Can be Use
                if (Reader["Grade"].ToString()!= "")
                {
                    aViewResult.Grade = Reader["Grade"].ToString();
                }
                else
                {
                    aViewResult.Grade = "Not Graded Yet";
                }
                
                aList.Add(aViewResult);
               
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }
    }
}