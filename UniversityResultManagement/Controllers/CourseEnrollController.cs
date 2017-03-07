using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Manager;
using UniversityResultManagement.Models;
using ViewResult = System.Web.Mvc.ViewResult;

namespace UniversityResultManagement.Controllers
{
    public class CourseEnrollController : Controller
    {
        CourseEnrollManager aCourseEnrollManager=new CourseEnrollManager();
        StudentManager aStudentManager=new StudentManager();
        CourseManager aCourseManager=new CourseManager();
        StudentResultManager aStudentResultManager=new StudentResultManager();
        //
        // GET: /CourseEnroll/
        [HttpGet]
        public ActionResult Enroll()
        {
            List<SelectListItem> getSelectRegNo = aStudentManager.GetSelectRegNo();
            ViewBag.GetSelectRegNo = getSelectRegNo;
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(CourseEnroll aCourseEnroll)
        {
            List<SelectListItem> getSelectRegNo = aStudentManager.GetSelectRegNo();
            ViewBag.GetSelectRegNo = getSelectRegNo;
            ViewBag.Message = aCourseEnrollManager.SaveCourseEnroll(aCourseEnroll);
            
            if (ViewBag.Message=="yes")
            {
                ModelState.Clear();
            }
            return View();
        }
        public JsonResult GetStudentByRegNo(int studentId)
        {
            List<Student> aList = aStudentManager.GetAllStudents(studentId);
            var aStudentList = aList.Where(m => m.Id == studentId).ToList();
            return Json(aStudentList, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetCoursebyDepartmentId(int studentId)
        {
            List<Student> students = aStudentManager.GetAllStudents(studentId);
            int deptId = students[0].DepartmentId;
            List<Course> courses = aCourseManager.GetAllCourses();
            List<Course> courseList = courses.Where(a => a.DepartmentId == deptId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        ////Save Student Result
        [HttpGet]
        public ActionResult SaveResult()
        {
            List<SelectListItem> getSelectRegNo = aStudentManager.GetSelectRegNo();
            ViewBag.GetSelectRegNo = getSelectRegNo;
            List<SelectListItem> getSelectGrade = aCourseEnrollManager.GetSelectGrade();
            ViewBag.GetSelectGrade = getSelectGrade;
            return View();
        }
        [HttpPost]
        public ActionResult SaveResult(StudentResult aStudentResult)
        {
            List<SelectListItem> getSelectRegNo = aStudentManager.GetSelectRegNo();
            ViewBag.GetSelectRegNo = getSelectRegNo;

            List<SelectListItem> getSelectGrade = aCourseEnrollManager.GetSelectGrade();
            ViewBag.GetSelectGrade = getSelectGrade;
            ViewBag.Message = aStudentResultManager.SaveStudentResult(aStudentResult);
            
            ModelState.Clear();
            return View();
        }
        
        public JsonResult GetCourseByStudentId(int studentId)
        {
            List<CourseEnroll> aList = aCourseEnrollManager.GetCourseByStudentId();
            var aCourseList = aList.Where(m => m.StudentId == studentId).ToList();
            return Json(aCourseList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ViewStudentResult()
        {
            List<SelectListItem> getSelectRegNo = aStudentManager.GetSelectRegNo();
            ViewBag.GetSelectRegNo = getSelectRegNo;
            return View();
        }
        public JsonResult GetResultByStudentId(int studentId)
        {
            List<Models.ViewModel.ViewResult> aList = aStudentResultManager.GetResultByStudentId(studentId);
            var aResultList = aList.Where(m => m.StudentId == studentId).ToList();
            return Json(aResultList, JsonRequestBehavior.AllowGet);
        }
        
	}
}