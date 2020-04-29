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
    public class DepartmentController : Controller
    {
       
        private readonly IDepartment _iDepartment;

        public DepartmentController(IDepartment iDepartment)
        {
            _iDepartment = iDepartment;
        }
        
        public ActionResult Index()
        {
            return View(_iDepartment.GetDepartmentList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DepartmentModel departmentModel = _iDepartment.DepartmentDetails(id);
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                _iDepartment.Insert(departmentModel);
                _iDepartment.Commit();
                return RedirectToAction("Index");
            }

            return View(departmentModel);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModel departmentModel = _iDepartment.DepartmentDetails(id);
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                _iDepartment.Update(departmentModel);
                _iDepartment.Commit();
                return RedirectToAction("Index");
            }
            return View(departmentModel);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModel departmentModel = _iDepartment.DepartmentDetails(id);
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentModel departmentModel = _iDepartment.DepartmentDetails(id);
            _iDepartment.Remove(departmentModel);
            _iDepartment.Commit();
            return RedirectToAction("Index");
        }

    }
}
