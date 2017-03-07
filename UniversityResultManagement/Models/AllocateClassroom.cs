using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        [DisplayName("Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select Room")]
        [DisplayName("Room No.")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please Select Day")]
        [DisplayName("Day")]
        public int DayId { get; set; }
        [Required(ErrorMessage = "Please Select Time From")]
        [DisplayName("From")]
        public TimeSpan FromTime { get; set; }
        [Required(ErrorMessage = "Please Select Time To")]
        [DisplayName("To")]
        public TimeSpan ToTime { get; set; }

    }
}