using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models.ViewModel
{
    public class ViewClassSchedule
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string RoomNo { get; set; }
        public string Days { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Valid { get; set; }
        public string ScheduleInfo { get; set; }


    }
}