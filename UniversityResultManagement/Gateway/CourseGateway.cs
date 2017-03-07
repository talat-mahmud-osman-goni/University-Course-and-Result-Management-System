using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Gateway
{
    public class CourseGateway:CommonGateway
    {
        public int SaveCourse(Course aCourse)
        {
            Query = "INSERT INTO Course VALUES ('" + aCourse.Code + "','" + aCourse.Name + "','" + aCourse.Credit + "','" +
                    aCourse.Description + "','" + aCourse.DepartmentId + "','" + aCourse.SemesterId + "')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public Course IsCodeUnique(string code)
        {
            Query = "SELECT * FROM Course WHERE Code='" + code + "'";
            Command=new SqlCommand(Query,Connection);
            Course aCourse=new Course();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                aCourse = null;
            }
            Reader.Close();
            Connection.Close();
            return aCourse;
        }
        public Course IsNameUnique(string name)
        {
            Query = "SELECT * FROM Course WHERE Name='" + name + "'";
            Command = new SqlCommand(Query, Connection);
            Course aCourse = new Course();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                aCourse = null;
            }
            Reader.Close();
            Connection.Close();
            return aCourse;
        }

        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM Course ORDER BY Code ASC";
            Command=new SqlCommand(Query,Connection);
            List<Course> aList=new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course aCourse = new Course()
                {
                    Id = (int) Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Credit = Convert.ToDouble(Reader["Credit"]),
                    Description = Reader["Description"].ToString(),
                    DepartmentId = (int) Reader["DepartmentId"],
                    SemesterId = (int)Reader["SemesterId"]
                };
                aList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }

        
    }
}