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
    public class CategoriesController : Controller
    {
        private MultiStepFormAppDbContext db = new MultiStepFormAppDbContext();

        private readonly ICategory _iCategory;

        public CategoriesController(ICategory iCategory)
        {
            _iCategory = iCategory;
        }



        // GET: Categories
        public ActionResult Index()
        {
            return View(_iCategory.GetCategoryList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _iCategory.GetCategoryDetails(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _iCategory.Insert(category);
                _iCategory.Commit();
                return RedirectToAction("Index");
            }

            return View(category);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _iCategory.GetCategoryDetails(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _iCategory.Update(category);
                _iCategory.Commit();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _iCategory.GetCategoryDetails(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _iCategory.GetCategoryDetails(id);
            _iCategory.Remove(category);
            _iCategory.Commit();
            return RedirectToAction("Index");
        }
        
    }
}
