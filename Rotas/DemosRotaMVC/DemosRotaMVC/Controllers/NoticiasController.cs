using DemosRotaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemosRotaMVC.Controllers
{
    public class NoticiasController : Controller
    {

        public static IList<Noticia> _noticias = new List<Noticia> 
        { 
                new Noticia
                    {
                        Id = Guid.NewGuid(),
                        Data = new DateTime(2016, 12, 1),
                        Titulo = "Rombo no orçamento",
                        Conteudo = "Foi detectado um rombo...",
                        Categoria = "Política"
                    },

                    new Noticia
                    {
                        Id = Guid.NewGuid(),
                        Data = new DateTime(2016, 12, 2),
                        Titulo = "Prisão do Fulano",
                        Conteudo = "Na manhã de hoje foi...",
                        Categoria = "Política"
                    },

                    new Noticia
                    {
                        Id = Guid.NewGuid(),
                        Data = new DateTime(2017, 3, 23),
                        Titulo = "Show de corinthianos na seleção",
                        Conteudo = "Com 3 do Paulino...",
                        Categoria = "Esporte"
                    },

                     new Noticia
                    {
                        Id = Guid.NewGuid(),
                        Data = DateTime.Now,
                        Titulo = "Chacina em Osasco",
                        Conteudo = "Com 3 corpos no Rochdalle...",
                        Categoria = "Policial"
                    }

            };

        public ActionResult Index()
        {
            ViewBag.Categorias = _noticias.Select(n => n.Categoria).Distinct().OrderBy(x => x);
            var noticias = _noticias.OrderByDescending(d => d.Data).Take(3);
            return View(noticias);
        }

        public ActionResult MostrarNoticia(Guid id)
        {
            var noticia = _noticias.FirstOrDefault(x => x.Id == id);

            if (noticia == null)
                return HttpNotFound();

            return View(noticia);
        }

        public ActionResult Todas()
        {
            return View(_noticias);
        }

        public ActionResult NoticiasDaCategoria(string cat)
        {
            var noticias = _noticias.Where(x=>x.Categoria == cat);

            return View(noticias);
        }

    }
}
