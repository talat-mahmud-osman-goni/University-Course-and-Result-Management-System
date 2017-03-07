using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Course Code")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Code Must be at Least 5 Characters Long")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Enter Course Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Credit")]
        [Range(0.5,5.0, ErrorMessage = "Credit Can Not be Less then 0.5 and More Than 5.0")]
        public double Credit { get; set; }
        
        [Required(ErrorMessage = "Please Enter Course Code")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Semester")]
        public int SemesterId { get; set; }

    }
}