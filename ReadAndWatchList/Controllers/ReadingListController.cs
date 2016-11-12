using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadAndWatchList.Controllers
{
    public class ReadingListController : Controller
    {
        // GET: ReadingList
        public ActionResult Index()
        {
            return View();
        }
    }
}