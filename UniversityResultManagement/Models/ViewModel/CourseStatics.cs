using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;

namespace UniversityResultManagement.Models.ViewModel
{
    public class CourseStatics
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Semester { get; set; }        
        public string AssignedTo { get; set; }

    }
}