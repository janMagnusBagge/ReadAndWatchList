using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReadAndWatchList.Models;
using ReadAndWatchList.Repositories;

namespace ReadAndWatchList.Controllers
{
    public class BetweenSubMainCategoryController : Controller
    {
        public BetweenSubMainRepository betweenSubMainRepo = new BetweenSubMainRepository();
        // GET: BetweenSubMainCategory
        public ActionResult Index()
        {
            return View(betweenSubMainRepo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,SubCategoryId")] BetweenSubMainCategory subMain)
        {

            if (ModelState.IsValid)
            {
                betweenSubMainRepo.Create(subMain);
                return RedirectToAction("Index");
            }

            return View(subMain);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BetweenSubMainCategory _subMain = betweenSubMainRepo.GetSpecifik(id);
            if (_subMain == null)
            {
                return HttpNotFound();
            }
            return View(_subMain);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            betweenSubMainRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BetweenSubMainCategory _subMain = betweenSubMainRepo.GetSpecifik(id);
            if (_subMain == null)
            {
                return HttpNotFound();
            }
            return View(_subMain);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BetweenSubMainCategory _subMain = betweenSubMainRepo.GetSpecifik(id);
            if (_subMain == null)
            {
                return HttpNotFound();
            }
            return View(_subMain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,SubCategoryId")] BetweenSubMainCategory subMain)
        {
            if (ModelState.IsValid)
            {
                betweenSubMainRepo.Edit(subMain);
                return RedirectToAction("Index");
            }
            return View(subMain);
        }

    }
}