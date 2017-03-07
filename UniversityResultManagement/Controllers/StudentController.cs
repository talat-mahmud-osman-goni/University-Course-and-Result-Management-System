using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Manager;
using UniversityResultManagement.Models;

namespace UniversityResultManagement.Controllers
{
    public class StudentController : Controller
    {
        DepartmentGateway aDepartmentGateway=new DepartmentGateway();
        StudentManager aStudentManager=new StudentManager();
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult Registration()
        {
            List<SelectListItem> getSelectDepartment = aDepartmentGateway.GetSelectDepartments();
            ViewBag.GetSelectDepartment = getSelectDepartment;
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Student aStudent)
        {
            List<SelectListItem> getSelectDepartment = aDepartmentGateway.GetSelectDepartments();
            ViewBag.GetSelectDepartment = getSelectDepartment;

            ViewBag.Message = aStudentManager.SaveStudent(aStudent);

            ViewBag.Name = aStudent.Name;
            ViewBag.Email = aStudent.Email;
            ViewBag.ContactNo = aStudent.ContactNo;
            ViewBag.Date = aStudent.Date.ToString("yyyy-MM-dd");
            ViewBag.Address = aStudent.Address;
            ViewBag.DeptName = aStudent.DepartmentName;
            ViewBag.RegistrationNo = aStudent.RegistrationNo;

            if (ViewBag.Message=="yes")
            {
                ModelState.Clear();
            }
            return View();
        }
	}
}