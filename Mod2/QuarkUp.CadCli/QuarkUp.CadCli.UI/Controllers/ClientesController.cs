using QuarkUp.CadCli.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuarkUp.CadCli.UI.Controllers
{
    [Authorize] //Todos os métodos precisa estar autorizado - Exibe uma página de NOT FOUND
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

        [AllowAnonymous]//Só este não precisa de autenticação
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
            return View("AddEdit",new Cliente());//Não é o nome padrão, que no caso é "Novo"
        }

        public ActionResult Editar(int id)
        {
            //Acessar a base
            //var cliente = (from c in _ctx.Clientes where c.id == id select c).FirstOrDefault();
            //ou
            var cliente = _ctx.Clientes.Find(id); //.FirstOrDefault(x => x.codigo == id); //FInd é do Entity framework

            if (cliente == null)
                return HttpNotFound();

            return View("AddEdit",cliente);
        }

        [HttpPost]
        public ActionResult Salvar(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                if (cli.Id == 0)
                {
                    _ctx.Clientes.Add(cli);
                }
                else
                {
                    _ctx.Entry(cli).State = System.Data.Entity.EntityState.Modified;
                }

                _ctx.SaveChanges();
                //Retorna uma string na actionresult
                //return Content("Dados salvos!");
                return RedirectToAction("Index");
            }

            return View("AddEdit");
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            //throw new Exception("Erro no acesso à base de dados!"); //Para testes

            var msg = "Erro na exclusão!";
            var status = false;

            try
            {
                var cli = _ctx.Clientes.Find(id);
                if (cli != null)
                {
                    _ctx.Clientes.Remove(cli);
                    _ctx.SaveChanges();
                    msg = "Excluído com sucesso!";
                    status = true;
                }
            }
            catch (Exception ex)
            {
                
                //Gravar log
                msg = ex.Message;
            }

            //Status foi inventado
            return Json(new { status = status, msg = msg });
        }



        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

    }
}
