using ReadAndWatchList.Classes;
using ReadAndWatchList.Models;
using ReadAndWatchList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReadAndWatchList.ViewModels;

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
        [HttpGet]
        public ActionResult DetailsForGrade(int id)
        {
            var modelData = new GradesViewModel( _gradesRepo.GetSpecifik(id));
            
            var propAndDisplayName = typeof(GradesViewModel).DisplayNameForAllPropertiesInClass();

            //var modalContent = this.RenderViewToString("~/GradeModals/GradeDetailsModal", null);
            var modalContent = this.RenderViewToString("GradeModals/GradeDetailsModal");
            string sBuilder = "";
            foreach(var prop in modelData.GetType().GetProperties())
            {
                var propDict = propAndDisplayName.FirstOrDefault(x => x.Key == prop.Name);
                if(prop.Name != "Id")
                {
                    //string tempFormGroupStart = "<div class=\"form-group col-md-12\">";
                    //string tempFormGroupEnd = "</div>";
                    string tempLable = "<div class=\"col-md-2\"><label for=\"txtGrade" + propDict.Key + "\">" + propDict.Value + "</label></div>";
                    string tempValue = "<div class=\"col-md-10\"><div id=\"txtGrade" + propDict.Key + "\">" + prop.GetValue(modelData) + "</div></div>";

                    //sBuilder += tempFormGroupStart + tempLable + tempValue + tempFormGroupEnd;
                    sBuilder += tempLable + tempValue;
                }
            }
            //foreach(var prop in propAndDisplayName)
            //{
            //    string tempLable = "<div class=\"col-md-2\"><label for=\"txtGrade"+ prop.Key+ "\">" + prop.Value + "</label></div>";
            //    string tempValue = "<div class=\"col-md-10\"><label id=\"txtGrade" + prop.Key + "\">" + modelData. + "</label></div>";
            //}
            var returnData = new
            {
                modalContent = modalContent,
                modelData = modelData,
                propAndDisplayName = propAndDisplayName,
                modalDivsAndData = sBuilder
            };
            return ApiResult.Success(returnData);
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