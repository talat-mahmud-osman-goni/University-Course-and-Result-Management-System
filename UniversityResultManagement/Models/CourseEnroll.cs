using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class CourseEnroll
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Student Reg. No.")]
        [DisplayName("Student Reg. No.")]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
        [DisplayName("Select Course")]
        [Required(ErrorMessage = "Please Select Course Code")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime Date { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }


    }
}