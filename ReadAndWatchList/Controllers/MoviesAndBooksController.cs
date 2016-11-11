using ReadAndWatchList.Classes;
using ReadAndWatchList.Models;
using ReadAndWatchList.Repositories;
using ReadAndWatchList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ReadAndWatchList.Controllers
{
    public class MoviesAndBooksController : Controller
    {
        //// GET: MoviesAndBooks
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public MoviesAndBooksRepository _moviesAndBooksRepo = new MoviesAndBooksRepository();

        // GET: MoviesAndBooks
        public ActionResult Index()
        {
            var model = _moviesAndBooksRepo.GetAll();
            return View(model);
        }

        // GET: MoviesAndBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesAndBooks _moviesAndBooks = _moviesAndBooksRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_moviesAndBooks == null)
            {
                return HttpNotFound();
            }
            return View(_moviesAndBooks);

        }
        
        // GET: MoviesAndBooks/Create
        public ActionResult Create()
        {
			//ViewBag.GradeIdChoices = GradeSelectList();
			//ViewBag.MainCategoryIdChoices = CategorySelectList();

			//ViewBag.SubCategoryIdChoices = SubCategorySelectList();
			//ViewBag.SeriesIdChoices = SeriesSelectList();
			MoviesAndBooksViewModel model = new MoviesAndBooksViewModel();
			model.Grade = GradeSelectList();
			model.MainCategory = CategorySelectList();
			model.Series = SeriesSelectList();
			model.SubCategory = SubCategorySelectList();
			return View(model);
        }

        // POST: MoviesAndBooks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Name,Description,OtherPlatforms,GradeId,PartOffSerie,SerieId,MainCategoryId,SubCategoriId")] MoviesAndBooks MoviesAndBooks)
        public ActionResult Create(string Name = "", string Description = "",string OtherPlatforms = "",int? GradeId = null,bool PartOffSerie = false,int? SerieId = null,int? MainCategoryId = null,int? SubCategoryId = null)
        {
			ViewBag.GradeIdChoices = GradeSelectList();
			ViewBag.MainCategoryIdChoices = CategorySelectList();

			ViewBag.SubCategoryIdChoices = SubCategorySelectList();
			ViewBag.SeriesIdChoices = SeriesSelectList();
            
            if (ModelState.IsValid)
                {
                    _moviesAndBooksRepo.Create(Name, Description, OtherPlatforms, GradeId, PartOffSerie, SerieId, MainCategoryId, SubCategoryId);
                    return RedirectToAction("Index");
                }

                return View();
            
        }

        // GET: MoviesAndBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesAndBooks _moviesAndBooks = _moviesAndBooksRepo.GetSpecifik(id); //= bookRepo.GetSpecifikBook(id);
            if (_moviesAndBooks == null)
            {
                return HttpNotFound();
            }

			ViewBag.GradeIdChoices = GradeSelectList();
			ViewBag.MainCategoryIdChoices = CategorySelectList();

			ViewBag.SubCategoryIdChoices = SubCategorySelectList();
			ViewBag.SeriesIdChoices = SeriesSelectList();
            return View(_moviesAndBooks);
        }

        // POST: MoviesAndBooks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id,string Name = "", string Description = "", string OtherPlatforms = "", int? GradeId = null, bool PartOffSerie = false, int? SerieId = null, int? MainCategoryId = null, int? SubCategoriId = null)
        {
			//GradesRepository _gradeRepo = new GradesRepository();
			//ViewBag.GradeIdChoices = new SelectList(_gradeRepo.GetAll().Select(g => new { GradeId = g.Id, Name = g.Name }), "GradeId", "Name");
			//CategoriesRepository _categoryRepo = new CategoriesRepository();
			//ViewBag.MainCategoryIdChoices = new SelectList(_categoryRepo.GetAll().Select(g => new { MainCategoryId = g.Id, Name = g.Name }), "MainCategoryId", "Name");
			//SubCategoriesRepository _subCategoryRepo = new SubCategoriesRepository();
			//ViewBag.SubCategoryIdChoices = new SelectList(_subCategoryRepo.GetAll().Select(g => new { SubCategoriId = g.Id, Name = g.Name }), "SubCategoriId", "Name");
			//SeriesRepository _seriesRepo = new SeriesRepository();
			//ViewBag.SeriesIdChoices = new SelectList(_seriesRepo.GetAll().Select(g => new { SerieId = g.Id, Name = g.SerieName }), "SerieId", "Name");
			ViewBag.GradeIdChoices = GradeSelectList();
			ViewBag.MainCategoryIdChoices = CategorySelectList();

			ViewBag.SubCategoryIdChoices = SubCategorySelectList();
			ViewBag.SeriesIdChoices = SeriesSelectList();
                if (ModelState.IsValid)
                {
                    _moviesAndBooksRepo.Edit(Id,Name, Description, OtherPlatforms, GradeId, PartOffSerie, SerieId, MainCategoryId, SubCategoriId);
                    return RedirectToAction("Index");
                }
                return View();

        }

        // GET: MoviesAndBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviesAndBooks _moviesAndBooks = _moviesAndBooksRepo.GetSpecifik(id);
            if (_moviesAndBooks == null)
            {
                return HttpNotFound();
            }
            return View(_moviesAndBooks);

        }

        // POST: MoviesAndBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _moviesAndBooksRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult MultipleUpdate()
        {
            var model = _moviesAndBooksRepo.GetAllMultipleUpdateViewModel().ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult MultipleUpdate(List<MultipleUpdateMoviesAndBooksViewModel> model)
        {
            //var model = _moviesAndBooksRepo.GetAllMultipleUpdateViewModel();
            //return View(model);
            var selected = model.Where(m => m.UpdateThis == true).ToList();
            return RedirectToAction("MultipleUpdate");
        }

		public ActionResult SeveralUpdate()
		{
			return View();
		}

		public ActionResult GetSeveralUpdateData()
		{
			
			var MnBs = _moviesAndBooksRepo.GetAllMultipleUpdateViewModel()
				.Select(a => new
				{
					a.Id,
					a.Name,
					a.GradeId,
					a.Grade, //grade.Name,
					a.SerieId,
					a.SerieName,//serie.SerieName,
					a.MainCategoryId,
					a.MainCategoryName,//main.Name,
					a.SubCategoriId,
					a.SubCategoryName,//sub.Name,
					a.UpdateThis
				}
				);
			var Grade = GradeSelectList();
			var MainCategory = CategorySelectList();
			var Series = SeriesSelectList();
			var SubCategory = SubCategorySelectList();
			return ApiResult.Success(new { 
				MnBs = MnBs,
				Grade = Grade,
				MainCategory = MainCategory,
				Series = Series,
				SubCategory = SubCategory
			}
			);
		}

		public ActionResult UpdateMeny(List<int> ToUpdate, int? Grade, int? Serie, int? MainCategory = null, int? SubCategory = null)
		{

            if(_moviesAndBooksRepo.UpdateMeny(ToUpdate, Grade, Serie, MainCategory, SubCategory) == true)
            {
                return GetSeveralUpdateData();
            }

            return ApiResult.Fail("Could not update");
		}

		#region SelectLists
		private SelectList GradeSelectList(int? id = null)
		{
			GradesRepository _gradeRepo = new GradesRepository();
            return _gradeRepo.GetAllForSelectList();

        }
		private SelectList CategorySelectList(int? id = null)
		{
			CategoriesRepository _categoryRepo = new CategoriesRepository();
            return _categoryRepo.GetAllForSelectList();
        }

		private SelectList SubCategorySelectList(int? id = null)
		{
			SubCategoriesRepository _subCategoryRepo = new SubCategoriesRepository();
			var items = _subCategoryRepo.GetAll();
            return _subCategoryRepo.GetAllForSelectList();
        }
		private SelectList SeriesSelectList(int? id = null)
		{
			SeriesRepository _seriesRepo = new SeriesRepository();
            return _seriesRepo.GetAllForSelectList();
        }
		#endregion
    }
}