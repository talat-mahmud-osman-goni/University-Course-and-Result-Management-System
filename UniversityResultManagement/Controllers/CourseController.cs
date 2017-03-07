using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Gateway;
using UniversityResultManagement.Manager;
using UniversityResultManagement.Models;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        SemesterGateway aSemesterGateway=new SemesterGateway();
        CourseManager aCourseManager=new CourseManager();
        CourseAssignTeacherManager aCourseAssignTeacherManager=new CourseAssignTeacherManager();
        CourseStaticsManager aCourseStaticsManager=new CourseStaticsManager();
        //
        // GET: /Course/
        [HttpGet]
        public ActionResult Save()
        {
            List<SelectListItem> getSelectDepartments = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartments = getSelectDepartments;

            List<SelectListItem> getSelectSemester = aSemesterGateway.GetSelectSemester();
            ViewBag.GetSelectSemester = getSelectSemester;
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course aCourse)
        {
            List<SelectListItem> getSelectDepartments = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartments = getSelectDepartments;

            List<SelectListItem> getSelectSemester = aSemesterGateway.GetSelectSemester();
            ViewBag.GetSelectSemester = getSelectSemester;

            ViewBag.Message = aCourseManager.SaveCourse(aCourse);
            ViewBag.Name = aCourse.Name;
            ViewBag.Code = aCourse.Code;
            if (ViewBag.Message=="yes")
            {
                ModelState.Clear();
            }

            return View();
        }
        [HttpGet]
        public ActionResult CourseAssignTeacher()
        {
            List<SelectListItem> getSelectDepartments = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartments = getSelectDepartments;
            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignTeacher(CourseAssignTeacher aCourseAssignTeacher)
        {
            List<SelectListItem> getSelectDepartments = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartments = getSelectDepartments;
            ViewBag.Message = aCourseAssignTeacherManager.SaveCourseAssignTeacher(aCourseAssignTeacher);
            ViewBag.Course = aCourseAssignTeacher.Name;
            
            ModelState.Clear();
            
            return View();
        }

        public JsonResult GetTeacherbyDepartmentId(int departmentId)
        {
            List<Teacher> aList = aCourseAssignTeacherManager.GetAllTeachers();
            var aTeacherList = aList.Where(m => m.DepartmentId == departmentId).ToList();
            return Json(aTeacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursebyDepartmentId(int departmentId)
        {
            List<Course> aList = aCourseAssignTeacherManager.GetAllCourses();
            var aCourseList = aList.Where(m => m.DepartmentId == departmentId).ToList();
            return Json(aCourseList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherbyTeacherId(int teacherId)
        {
            List<Teacher> aList = aCourseAssignTeacherManager.GetAllTeachers();
            var aTeacherList = aList.Where(m => m.Id == teacherId).ToList();
            return Json(aTeacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursebyCourseId(int courseId)
        {
            List<Course> aList = aCourseAssignTeacherManager.GetAllCourses();
            var aCourseList = aList.Where(m => m.Id == courseId).ToList();
            return Json(aCourseList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CourseStatics()
        {
            List<SelectListItem> getSelectDepartments = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartments = getSelectDepartments;
            return View();
        }
        public JsonResult GetAllCourseStatics(int departmentId)
        {
            List<CourseStatics> aList = aCourseStaticsManager.GetAllCourseStatics();
            var aCourseList = aList.Where(m => m.DepartmentId == departmentId).ToList();
            return Json(aCourseList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UnAssignCourse()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult UnAssignCourse(int? id)
        {
            ViewBag.Message = aCourseAssignTeacherManager.UnassignCourses();
            return View();
        }
        

    }
}