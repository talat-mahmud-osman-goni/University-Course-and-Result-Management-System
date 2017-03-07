using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Number")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Contact number must be between 6 to 15 digit")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please Select Designation")]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Enter Credit to be Taken")]
        [DisplayName("Credit to be Taken")]
        [Range(0,double.MaxValue,ErrorMessage = "Credit to be taken must contains non negative value")]
        public double CreditTaken { get; set; }
        public double RemainingCredit { get; set; }

    }
}