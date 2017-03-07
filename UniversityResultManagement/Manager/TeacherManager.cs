using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway=new TeacherGateway();
        public List<SelectListItem> GetSelectDesignations()
        {
            return aTeacherGateway.GetSelectDesignations();
        }


        public string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacherGateway.IsEmailExist(aTeacher.Email)!=null)
            {
                return "email not unique";
            }
            if (aTeacherGateway.SaveTeacher(aTeacher)>0)
            {
                return "yes";
            }
            else
            {
                return "no";

            }
        }
    }
}