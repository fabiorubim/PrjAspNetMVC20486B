using QuarkUp.CadCli.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuarkUp.CadCli.UI.Controllers
{
    public class ClientesController : Controller
    {
        //
        // GET: /Clientes/

         /*public ActionResult Index()
        {
            var _ctx = new CadCliContext();
            var clientes = _ctx.Clientes.ToList();
            return View(clientes);
        }
           */

        private readonly CadCliContext _ctx = new CadCliContext();

        public ActionResult Index()
        {
            var clientes = new List<Cliente>();
            {
                clientes = _ctx.Clientes.ToList();
            }

            return View(clientes);
        }

        public ActionResult Novo()
        {
            return View("AddEdit");//Não é o nome padrão, que no caso é "Novo"
        }

        public ActionResult Editar(int id)
        {
            //Acessar a base
            //var cliente = (from c in _ctx.Clientes where c.id == id select c).FirstOrDefault();
            //ou
            var cliente = _ctx.Clientes.Find(id); //.FirstOrDefault(x => x.codigo == id); //FInd é do Entity framework

            return View("AddEdit",cliente);
        }

        public ActionResult Salvar(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                _ctx.Clientes.Add(cli);
                _ctx.SaveChanges();
                //Retorna uma string na actionresult
                //return Content("Dados salvos!");
                return RedirectToAction("Index");
            }

            return View("Novo");
        }


        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

    }
}
