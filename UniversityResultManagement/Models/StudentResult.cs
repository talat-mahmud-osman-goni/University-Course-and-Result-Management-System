using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Student Reg. No.")]
        [DisplayName("Student Reg. No.")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Select Course Code")]
        [DisplayName("Select Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select Grade Letter")]
        [DisplayName("Select Grade Letter")]
        public int GradeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }

    }
}