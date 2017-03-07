using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityResultManagement.Models;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Gateway
{
    public class ClassRoomGateway : CommonGateway
    {
        public List<SelectListItem> GetSelectDay()
        {
            Query = "SELECT * FROM Day ";
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

        public List<SelectListItem> GetSelectRoom()
        {
            Query = "SELECT * FROM RoomNo ORDER BY Name ASC";
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

        public int SaveAllocation(AllocateClassroom aClassroom)
        {
            Query = "INSERT INTO AllocateClassroom VALUES ('" + aClassroom.DepartmentId + "','" + aClassroom.CourseId +
                    "','" + aClassroom.RoomId + "','" + aClassroom.DayId + "','" + aClassroom.FromTime + "','" +
                    aClassroom.ToTime + "','True')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public AllocateClassroom IsSameCourseRoomDayExist(TimeSpan fromTime, TimeSpan toTime, int dayId, int roomId)
        {

            Query = "SELECT * FROM AllocateClassroom WHERE DayId='" + dayId + "' AND RoomId='" + roomId +
                    "' AND ((FromTime <='" + fromTime + "' AND ToTime <= '" + toTime + "' AND ToTime>'" + fromTime +
                    "') OR (FromTime>='" + fromTime + "' AND ToTime<='" + toTime + "') OR ('" + fromTime +
                    "'>=FromTime AND '" + toTime + "'<=ToTime) OR ('" + fromTime + "'<=FromTime AND '" + toTime +
                    "'<=ToTime AND FromTime<='" + toTime + "')) AND Valid='True'";
            Command = new SqlCommand(Query, Connection);
            AllocateClassroom allocate = new AllocateClassroom();
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (!Reader.HasRows)
            {
                allocate = null;
            }
            Reader.Close();
            Connection.Close();
            return allocate;
        }

        public List<ViewClassSchedule> GetClassScheduleByDeptId(int departmentId)
        {
            List<ViewClassSchedule> aList = new List<ViewClassSchedule>();
            Query = "SELECT Code, Name, DepartmentId, RoomNumber, Days, CONVERT(varchar,FromTime,100) AS FromTime, CONVERT(varchar,ToTime,100) AS ToTime, Valid FROM ViewClassSchedule WHERE DepartmentId=" + departmentId;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewClassSchedule s = new ViewClassSchedule
                {
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    DepartmentId = (int) Reader["DepartmentId"],
                    RoomNo = Reader["RoomNumber"].ToString(),
                    Days = Reader["Days"].ToString(),
                    FromTime = Reader["FromTime"].ToString(),
                    ToTime = Reader["ToTime"].ToString(),
                    Valid = Reader["Valid"].ToString()
                };

                //if (Reader["Valid"].ToString()=="True")
                //{
                //    string str = "";
                //    s.RoomNo = Reader["RoomNumber"].ToString();
                //    s.Days = Reader["Days"].ToString();
                //    s.FromTime = Reader["FromTime"].ToString();
                //    s.ToTime = Reader["ToTime"].ToString();                   
                //    str += "Room No.: " + s.RoomNo + ", " + s.Days + ", " + s.FromTime + " - " +s.ToTime + ";<br/>";
                //    s.ScheduleInfo = str;
                //}
                //else
                //{
                //    s.ScheduleInfo = "Not Scheduled Yet <br/>";
                //}
                                               
                aList.Add(s);
            }          
            Reader.Close();
            Connection.Close();            
            return aList;            
        }
        public int UnallocateAllClassRoom()
        {
            Query = "UPDATE AllocateClassroom SET Valid='False' WHERE Valid='True'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}