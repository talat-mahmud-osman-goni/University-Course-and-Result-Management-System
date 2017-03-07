using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Department Code")]
        [StringLength(7,MinimumLength = 2, ErrorMessage = "Department Code Must be 2 to 7 Character's Long")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        public string Name { get; set; }
        

    }
}