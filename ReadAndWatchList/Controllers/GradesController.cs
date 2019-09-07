using ReadAndWatchList.Classes;
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
    public class GradesController : Controller
    {
        public GradesRepository _gradesRepo = new GradesRepository();

        // GET: Categories
        public ActionResult Index()
        {
            var model = _gradesRepo.GetAll();
            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades _grades = _gradesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_grades == null)
            {
                return HttpNotFound();
            }
            return View(_grades);

        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Grades Grades)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _gradesRepo.Create(Grades);
                    return RedirectToAction("Index");
                }

                return View(Grades);
            }
            catch
            {
                return View(Grades);
            }
        }

        [HttpPost]
        public ActionResult CreateGrade(string name, string desc)
        {
            Grades grade = new Grades { Name = name, Description = desc };
            try
            {
                _gradesRepo.Create(grade);
                return ApiResult.Success(null);
            }
            catch(Exception ex)
            {

                return ApiResult.Fail(ex.Message);
            }
           
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades _grades = _gradesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_grades == null)
            {
                return HttpNotFound();
            }
            return View(_grades);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Grades Grades)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _gradesRepo.Edit(Grades);
                    return RedirectToAction("Index");
                }
                return View(Grades);

            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grades _grades = _gradesRepo.GetSpecifik(id);
            if (_grades == null)
            {
                return HttpNotFound();
            }
            return View(_grades);

        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _gradesRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}