using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Gateway
{
    public class CourseEnrollGateway:CommonGateway
    {
        public int SaveCourseEnroll(CourseEnroll aCourseEnroll)
        {
            Query = "INSERT INTO CourseEnroll VALUES('" + aCourseEnroll.StudentId + "','" + aCourseEnroll.CourseId +
                    "','" + aCourseEnroll.Date + "')";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public CourseEnroll IsStudentInCourseExist(int studentId, int courseId)
        {
            Query = "SELECT * FROM CourseEnroll WHERE StudentId='" + studentId + "' AND CourseId=" + courseId;
            Command=new SqlCommand(Query,Connection);
            CourseEnroll aCourseEnroll=new CourseEnroll();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                aCourseEnroll = null;
            }
            Reader.Close();
            Connection.Close();
            return aCourseEnroll;
        }

        public List<SelectListItem> GetSelectGrade()
        {
            Query = "SELECT * FROM GradeLetter";
            Command = new SqlCommand(Query, Connection);
            List<SelectListItem> aList = new List<SelectListItem>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aList.Add(new SelectListItem()
                {
                    Value = Reader["Id"].ToString(),
                    Text = Reader["Name"].ToString()
                });
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }

        public List<CourseEnroll> GetCourseByStudentId()
        {
            Query = "SELECT * FROM CourseEnroll";
            Command=new SqlCommand(Query,Connection);
            List<CourseEnroll> aList=new List<CourseEnroll>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                CourseEnroll aCourseEnroll = new CourseEnroll()
                {
                    Id = (int) Reader["Id"],
                    StudentId = (int) Reader["StudentId"],
                    CourseId = (int) Reader["CourseId"]
                };
                aList.Add(aCourseEnroll);
            }
            Reader.Close();
            Connection.Close();
            foreach (CourseEnroll t in aList)
            {
                Query = "SELECT Code FROM Course WHERE Id=" + t.CourseId;
                Command=new SqlCommand(Query,Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    t.CourseCode = Reader["Code"].ToString();
                }
                Reader.Close();
                Connection.Close();
            }
            return aList;

        }
    }
}