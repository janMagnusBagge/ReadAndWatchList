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
    public class SeriesController : Controller
    {
        public SeriesRepository _seriesRepo = new SeriesRepository();

        // GET: Series
        public ActionResult Index()
        {
            var model = _seriesRepo.GetAll();
            return View(model);
        }

        // GET: Series/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series _series = _seriesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_series == null)
            {
                return HttpNotFound();
            }
            return View(_series);

        }

        // GET: Series/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SerieName,Description")] Series Series)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _seriesRepo.Create(Series);
                    return RedirectToAction("Index");
                }

                return View(Series);
            }
            catch
            {
                return View(Series);
            }
        }

        // GET: Series/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series _series = _seriesRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_series == null)
            {
                return HttpNotFound();
            }
            return View(_series);
        }

        // POST: Series/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SerieName,Description")] Series Series)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _seriesRepo.Edit(Series);
                    return RedirectToAction("Index");
                }
                return View(Series);

            }
            catch
            {
                return View(Series);
            }
        }

        // GET: Series/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series _series = _seriesRepo.GetSpecifik(id);
            if (_series == null)
            {
                return HttpNotFound();
            }
            return View(_series);

        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _seriesRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}