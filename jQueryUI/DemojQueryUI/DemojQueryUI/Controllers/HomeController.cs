using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemojQueryUI.Models;

namespace DemojQueryUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        { 
            IList<Linguagem> linguagens = null;
            using (var ctx = new LinguagemDB())
            {
                linguagens = ctx.Linguagens.ToList();
            }

            return Json(linguagens.Select(x => x.Nome),JsonRequestBehavior.AllowGet);
        }

    }
}
