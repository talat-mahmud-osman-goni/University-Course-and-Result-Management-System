using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Manager;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        TeacherManager aTeacherManager=new TeacherManager();
        //
        // GET: /Teacher/
        [HttpGet]
        public ActionResult Save()
        {
            List<SelectListItem> getSelectDepartments = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartments = getSelectDepartments;
            List<SelectListItem> getSelectDesignations = aTeacherManager.GetSelectDesignations();
            ViewBag.GetSelectDesignations = getSelectDesignations;
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher aTeacher)
        {
            List<SelectListItem> getSelectDepartments = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartments = getSelectDepartments;
            List<SelectListItem> getSelectDesignations = aTeacherManager.GetSelectDesignations();
            ViewBag.GetSelectDesignations = getSelectDesignations;

            ViewBag.Message = aTeacherManager.SaveTeacher(aTeacher);
            ViewBag.Email = aTeacher.Email;
            if (ViewBag.Message=="yes")
            {
                ModelState.Clear();
            }
            return View();
        }
	}
}