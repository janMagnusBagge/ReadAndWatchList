using ReadAndWatchList.Models;
using ReadAndWatchList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ReadAndWatchList.Controllers
{
    public class SubCategoriesController : Controller
    {
        public SubCategoriesRepository _subCategoriesRepo = new SubCategoriesRepository();

        // GET: SubCategories
        public ActionResult Index()
        {
            var model = _subCategoriesRepo.GetAll();
            return View(model);
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategories _subCategory = _subCategoriesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_subCategory == null)
            {
                return HttpNotFound();
            }
            return View(_subCategory);

        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] SubCategories SubCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subCategoriesRepo.Create(SubCategory);
                    return RedirectToAction("Index");
                }

                return View(SubCategory);
            }
            catch
            {
                return View(SubCategory);
            }
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategories _subCategory = _subCategoriesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_subCategory == null)
            {
                return HttpNotFound();
            }
            return View(_subCategory);
        }

        // POST: SubCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] SubCategories SubCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subCategoriesRepo.Edit(SubCategory);
                    return RedirectToAction("Index");
                }
                return View(SubCategory);

            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategories _subCategory = _subCategoriesRepo.GetSpecifik(ID);
            if (_subCategory == null)
            {
                return HttpNotFound();
            }
            return View(_subCategory);

        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID)
        {
            try
            {
                _subCategoriesRepo.Delete(ID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}