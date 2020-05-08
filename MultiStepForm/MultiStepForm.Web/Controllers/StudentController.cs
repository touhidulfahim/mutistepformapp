using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiStepForm.Domain.Entities;
using MultiStepForm.Domain.Interface;

namespace MultiStepForm.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _iStudent;
        private readonly IDepartment _iDepartment;


        public StudentController(IStudent iStudent, IDepartment iDepartment)
        {
            _iStudent = iStudent;
            _iDepartment = iDepartment;
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartmentList = _iDepartment.GetDepartmentList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel student)
        {
            ViewBag.DepartmentList = _iDepartment.GetDepartmentList();
            return View();
        }
    }
}