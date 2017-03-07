using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Gateway
{
    public class CourseAssignTeacherGateway:CommonGateway
    {
        public int SaveCourseAssignTeacher(CourseAssignTeacher aCourseAssignTeacher)
        {
            Query = "INSERT INTO CourseAssignTeacher VALUES ('" + aCourseAssignTeacher.DepartmentId + "','" +
                    aCourseAssignTeacher.TeacherId + "','" + aCourseAssignTeacher.CourseId + "','True')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            UpdateTeacherRemainingCredit(aCourseAssignTeacher);
            return rowAffected;
        }

        public int UpdateTeacherRemainingCredit(CourseAssignTeacher aCourseAssignTeacher)
        {
            double courseCredit = 0;
            Query = "SELECT Credit FROM Course Where Id = '" + aCourseAssignTeacher.CourseId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courseCredit = Convert.ToDouble(Reader["Credit"]);
            }
            Reader.Close();
            Connection.Close();
            Query = "UPDATE Teacher SET RemainingCredit=RemainingCredit-'" + courseCredit +
                    "' WHERE Id='" + aCourseAssignTeacher.TeacherId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public CourseAssignTeacher IsCourseAssigned(int courseId)
        {
            Query = "SELECT * FROM CourseAssignTeacher WHERE CourseId='" + courseId + "' AND Valid='True'";
            Command=new SqlCommand(Query,Connection);
            CourseAssignTeacher assignTeacher=new CourseAssignTeacher();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                assignTeacher = null;
            }
            Reader.Close();
            Connection.Close();
            return assignTeacher;
        }

        public int UnassignCourses()
        {
            Query = "UPDATE CourseAssignTeacher SET Valid='False' Where Valid='True'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            UpdateTeacher();           
            return rowAffected;
        }
        public int UpdateTeacher()
        {
            Query = "UPDATE Teacher SET RemainingCredit = CreditTaken";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();          
            return rowAffected;
        }       
    }
}