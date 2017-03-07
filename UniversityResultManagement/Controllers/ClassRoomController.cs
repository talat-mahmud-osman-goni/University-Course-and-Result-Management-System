using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultManagement.Manager;
using UniversityResultManagement.Models;
using UniversityResultManagement.Models.ViewModel;

namespace UniversityResultManagement.Controllers
{
    public class ClassRoomController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        ClassRoomManager aClassRoomManager=new ClassRoomManager();
        CourseManager aCourseManager=new CourseManager();
        //
        // GET: /ClassRoom/
        [HttpGet]
        public ActionResult Allocate()
        {
            List<SelectListItem> getSelectDepartment = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartment = getSelectDepartment;

            List<SelectListItem> getSelectDay = aClassRoomManager.GetSelectDay();
            ViewBag.GetSelectDay = getSelectDay;

            List<SelectListItem> getSelectRoom = aClassRoomManager.GetSelectRoom();
            ViewBag.GetSelectRoom = getSelectRoom;
            return View();
        }
        [HttpPost]
        public ActionResult Allocate(AllocateClassroom aClassroom)
        {
            List<SelectListItem> getSelectDepartment = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartment = getSelectDepartment;
            List<SelectListItem> getSelectDay = aClassRoomManager.GetSelectDay();
            ViewBag.GetSelectDay = getSelectDay;
            List<SelectListItem> getSelectRoom = aClassRoomManager.GetSelectRoom();
            ViewBag.GetSelectRoom = getSelectRoom;
            ViewBag.Message = aClassRoomManager.SaveAllocation(aClassroom);  
         
            ModelState.Clear();            
            return View();
        }
        public JsonResult GetCoursebyDepartmentId(int departmentId)
        {
            List<Course> aList = aCourseManager.GetAllCourses();
            var aCourseList = aList.Where(m => m.DepartmentId == departmentId).ToList();
            return Json(aCourseList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewClass()
        {
            List<SelectListItem> getSelectDepartment = aDepartmentManager.GetSelectDepartments();
            ViewBag.GetSelectDepartment = getSelectDepartment;
            return View();
        }
        public JsonResult GetClassScheduleByDeptId(int departmentId)
        {
            List<ViewClassSchedule> aList = aClassRoomManager.GetClassScheduleByDeptId(departmentId);
            var aScheduleList = aList.Where(m => m.DepartmentId == departmentId).ToList();
            return Json(aScheduleList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UnallocateClassRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnallocateClassRoom(int ?id)
        {
            ViewBag.Message = aClassRoomManager.UnallocateAllClassRoom();
            return View();
        }
	}
}