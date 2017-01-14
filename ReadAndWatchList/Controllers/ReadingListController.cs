using ReadAndWatchList.Classes;
using ReadAndWatchList.Repositories;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReadingListData()
        {

            var readingList = _ReadingListRepo.GetAll()
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Description
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