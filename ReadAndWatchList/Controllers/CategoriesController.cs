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
    public class CategoriesController : Controller
    {
        public CategoriesRepository _categoriesRepo = new CategoriesRepository();

        // GET: Categories
        public ActionResult Index()
        {
            var model = _categoriesRepo.GetAll();
            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories _category = _categoriesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_category == null)
            {
                return HttpNotFound();
            }
            return View(_category);

        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Categories Category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriesRepo.Create(Category);
                    return RedirectToAction("Index");
                }

                return View(Category);
            }
            catch
            {
                return View(Category);
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories _category = _categoriesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_category == null)
            {
                return HttpNotFound();
            }
            return View(_category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Categories Category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriesRepo.Edit(Category);
                    return RedirectToAction("Index");
                }
                return View(Category);

            }
            catch
            {
                return View(Category);
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories _category = _categoriesRepo.GetSpecifik(id);
            if (_category == null)
            {
                return HttpNotFound();
            }
            return View(_category);

        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoriesRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
