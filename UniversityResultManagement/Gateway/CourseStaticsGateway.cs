using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Gateway
{
    public class CourseStaticsGateway:CommonGateway
    {
        public List<CourseStatics> GetAllCourseStatics()
        {
            Query = "SELECT * FROM CourseStatics";
            Command=new SqlCommand(Query,Connection);
            List<CourseStatics> aList=new List<CourseStatics>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                CourseStatics aCourseStatics = new CourseStatics();               
                aCourseStatics.Code = Reader["Code"].ToString();
                aCourseStatics.Name = Reader["Name"].ToString();
                aCourseStatics.DepartmentId = (int) Reader["DepartmentId"];
                aCourseStatics.Semester = Reader["Semester"].ToString();
                aList.RemoveAll(m => m.Code == aCourseStatics.Code);

                if (Reader["Valid"].ToString() == "True")
                {
                    aCourseStatics.AssignedTo = Reader["AssignedTo"].ToString();
                }
                else
                {
                    aCourseStatics.AssignedTo ="Not Assigned Yet";
                } 
                aList.Add(aCourseStatics);
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }

    }
}