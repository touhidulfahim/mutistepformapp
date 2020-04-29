using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultiStepForm.Data.Context;
using MultiStepForm.Domain.Entities;
using MultiStepForm.Domain.Interface;

namespace MultiStepForm.Web.Controllers
{
    public class CourseInfoController : Controller
    {
        private readonly ICourse _iCourse;
        
        public CourseInfoController(ICourse iCourse)
        {
            _iCourse = iCourse;
        }


        // GET: CourseInfo
        public ActionResult Index()
        {
            return View(_iCourse.GetCourseList());
        }

        // GET: CourseInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInfoModel courseInfoModel = _iCourse.GetCourseDetails(id);
            if (courseInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(courseInfoModel);
        }

        // GET: CourseInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseInfoModel courseInfoModel)
        {
            if (ModelState.IsValid)
            {
                _iCourse.Insert(courseInfoModel);
                _iCourse.Commit();
                return RedirectToAction("Index");
            }

            return View(courseInfoModel);
        }

        // GET: CourseInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInfoModel courseInfoModel = _iCourse.GetCourseDetails(id);
            if (courseInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(courseInfoModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseInfoModel courseInfoModel)
        {
            if (ModelState.IsValid)
            {
                _iCourse.Update(courseInfoModel);
                _iCourse.Commit();
                return RedirectToAction("Index");
            }
            return View(courseInfoModel);
        }

        // GET: CourseInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInfoModel courseInfoModel = _iCourse.GetCourseDetails(id);
            if (courseInfoModel == null)
            {
                return HttpNotFound();
            }
            return View(courseInfoModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseInfoModel courseInfoModel = _iCourse.GetCourseDetails(id);
            _iCourse.Remove(courseInfoModel);
            _iCourse.Commit();
            return RedirectToAction("Index");
        }

    }
}
