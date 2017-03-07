using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway=new DepartmentGateway();

        public string SaveDepartment(Department aDepartment)
        {
            if (aDepartmentGateway.IsCodeUnique(aDepartment.Code)!=null)
            {
                return "code not unique";
            }
            if (aDepartmentGateway.IsNameUnique(aDepartment.Name)!=null)
            {
                return "name not unique";
            }
            if (aDepartmentGateway.SaveDepartment(aDepartment)>0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }

        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }

        public List<SelectListItem> GetSelectDepartments()
        {
            return aDepartmentGateway.GetSelectDepartments();
        }
    }
}