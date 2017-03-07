using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Manager
{
    public class ClassRoomManager
    {
        ClassRoomGateway aClassRoomGateway=new ClassRoomGateway();
        public List<SelectListItem> GetSelectDay()
        {
            return aClassRoomGateway.GetSelectDay();
        }

        public List<SelectListItem> GetSelectRoom()
        {
            return aClassRoomGateway.GetSelectRoom();
        }

        public string SaveAllocation(AllocateClassroom aClassroom)
        {
            if (aClassRoomGateway.IsSameCourseRoomDayExist(aClassroom.FromTime,aClassroom.ToTime,aClassroom.DayId,aClassroom.RoomId)!=null)
            {
                return "allocation not unique";
            }
            if (aClassRoomGateway.SaveAllocation(aClassroom)>0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }

        public List<ViewClassSchedule> GetClassScheduleByDeptId(int departmentId)
        {
            //return aClassRoomGateway.GetClassScheduleByDeptId(departmentId);

            
            List<ViewClassSchedule> aList = new List<ViewClassSchedule>(); 
                
            var allocate = aClassRoomGateway.GetClassScheduleByDeptId(departmentId).OrderBy(m => m.Code).ThenBy(m => m.Days).ThenBy(m => m.FromTime).ToList();
            var aDistinctCode = allocate.DistinctBy(m => m.Code).ToList();
            string str = "";
            foreach (var a in aDistinctCode)
            {
                ViewClassSchedule aSchedule = new ViewClassSchedule();
                aSchedule.Code = a.Code;
                aSchedule.Name = a.Name;
                aSchedule.DepartmentId = a.DepartmentId;
                foreach (var v in allocate)
                {                                     
                    if (a.Code==v.Code)
                    {
                        str += "Room No.: " + v.RoomNo + ", " +v.Days + ", " + v.FromTime + " - " +
                    v.ToTime + ";<br/>";
                    }                                                                                   
                }
                if (a.Valid!="True")
                {
                    str = "Not Scheduled Yet" + "<br/>";
                }
                aSchedule.ScheduleInfo = str;
                str = "";
                aList.Add(aSchedule);
            }

            return aList;
        }

        public string UnallocateAllClassRoom()
        {
            if (aClassRoomGateway.UnallocateAllClassRoom()>0)
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