using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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

        [OutputCache(Duration = 10, VaryByParam="id")]
        public PartialViewResult GetPartial()
        {
            ViewBag.Msg = "Texto da Partial";
            return PartialView();
        }

        public ActionResult TesteMemCache(string nome)
        {
            var saudacao = string.Format("Olá {0} - Agora são {1:dd/MM/yy HH:mm:ss}",nome,DateTime.Now);

            var dataMem = MemoryCache.Default.AddOrGetExisting("nomeuser", saudacao, DateTime.Now.AddSeconds(10));

            ViewBag.Saudacao = dataMem ?? saudacao;

            return View();

        }

        

    }
}
