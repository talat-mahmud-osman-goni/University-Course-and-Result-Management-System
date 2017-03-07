using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Manager;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        //
        // GET: /Department/
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            ViewBag.message = aDepartmentManager.SaveDepartment(aDepartment);
            ViewBag.name = aDepartment.Name;
            ViewBag.code = aDepartment.Code;
            if (ViewBag.message=="yes")
            {
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult ViewAllDepartment()
        {
            List<Department> aList = aDepartmentManager.GetAllDepartments();
            ViewBag.allDepartment = aList;
            return View();
        }
	}
}