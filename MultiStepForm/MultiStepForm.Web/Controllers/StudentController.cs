using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiStepForm.Domain.Interface;

namespace MultiStepForm.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _iStudent;

        public StudentController(IStudent iStudent)
        {
            _iStudent = iStudent;
        }



    }
}