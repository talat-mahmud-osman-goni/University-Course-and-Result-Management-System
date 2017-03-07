using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Contact Number")]
        [StringLength(15,MinimumLength = 6,ErrorMessage = "Contact Number Must be Between 6 to 15 Digits")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string RegistrationNo { get; set; }

    }
}