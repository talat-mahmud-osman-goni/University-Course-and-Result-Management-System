using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class CourseAssignTeacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Teacher")]
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }
        [DisplayName("Credit to be Taken")]
        public string CreditTaken { get; set; }
        [DisplayName("Remaining Credit")]
        public string RemainingCredit { get; set; }

        [Required(ErrorMessage = "Please Select Course Code")]
        [DisplayName("Course Code")]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }

    }
}