using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCache.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {            
            return View();
        }

        [OutputCache(Duration = 10)]
        public PartialViewResult GetPartial()
        {
            ViewBag.Msg = "Texto da Partial";
            return PartialView();
        }

        

    }
}
