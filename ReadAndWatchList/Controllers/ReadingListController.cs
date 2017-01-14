using ReadAndWatchList.Classes;
using ReadAndWatchList.Repositories;
using ReadAndWatchList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadAndWatchList.Controllers
{
    public class ReadingListController : Controller
    {
        private ReadingListRepository _ReadingListRepo = new ReadingListRepository();
        private MoviesAndBooksRepository _moviesAndBooksRepo = new MoviesAndBooksRepository();

        public ActionResult Index()
        {
            var modelRowsForCreate = _moviesAndBooksRepo.GetAll()
                .Select(x => new ReadingListSelectMoviesAndBooksRowViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CategoryName = x.MainCategorie.Name + " / " + x.SubCategori.Name,
                    SerieName = x.Series.SerieName,
                    AuthorName = "" //Ej implementerat än
                });
            var model = _ReadingListRepo.GetAll()
                .Select(a => new ReadingListViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    ReadingListRowsForCreate = modelRowsForCreate
                }
                );
            return View(model);
        }

        public ActionResult GetReadingListData()
        {

            var readingList = _ReadingListRepo.GetAll()
                .Select(a => new ReadingListViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                }
                );

            return ApiResult.Success(new
            {
                readingList = readingList,

            }
            );
        }
    }
}