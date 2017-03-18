using QuarkUp.CadCli.Data.EF;
using QuarkUp.CadCli.Data.EF.Repositories;
using QuarkUp.CadCli.Domain.Entities;
using QuarkUp.CadCli.Domain.Repositories;
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

        //private readonly CadCliContext _ctx = new CadCliContext();
        private readonly IClienteRepository _cliRepo;

        //public ClientesController()
        //{
        //    _cliRepo = new ClienteRepository(); //É quando não temos injeção de dependência
        //}

        public ClientesController(IClienteRepository cliRepo)
        {
            _cliRepo = cliRepo;//É com injeção de dependência mais com Inversão de Controle
        }

        [AllowAnonymous]//Só este não precisa de autenticação
        public ActionResult Index()
        {
            //var clientes = new List<ClienteVM>();
            
                var clientes = 
                   //_ctx.Clientes
                   //.Skip(10).Take(20) --> paginação antes do ToList
                    //.ToList()
                    _cliRepo.Obter()
                    .Select(cli => obterVM(cli));
            

            return View(clientes);
        }

        public ActionResult Novo()
        {
            return View("AddEdit",new ClienteVM());//Não é o nome padrão, que no caso é "Novo"
        }

        public ActionResult Editar(int id)
        {
            //AutoMapper - veja

            //Acessar a base
            //var cliente = (from c in _ctx.Clientes where c.id == id select c).FirstOrDefault();
            //ou
            var cliente =
                //_ctx.Clientes.Find(id); //.FirstOrDefault(x => x.codigo == id); //FInd é do Entity framework

                _cliRepo.Obter(id);
            
            if (cliente == null)
                return HttpNotFound();

            return View("AddEdit", obterVM(cliente));               
        }

        private ClienteVM obterVM(Cliente cliente)
        {
            return new ClienteVM //AutoMapper==> recomendo para fazer o d=>para
                { Id= cliente.Id, 
                  Nome = cliente.Nome, 
                  Idade= cliente.Idade
                };
        }

        [HttpPost]
        public ActionResult Salvar(ClienteVM cliVM)
        {
            if (ModelState.IsValid)
            {
                var clienteDB = new Cliente { Id = cliVM.Id, Nome = cliVM.Nome, Idade = (byte) cliVM.Idade };
                if (cliVM.Id == 0)
                {
                   // _ctx.Clientes.Add(clienteDB);
                    _cliRepo.Adicionar(clienteDB);
                }
                else
                {
                    //_ctx.Entry(clienteDB).State = System.Data.Entity.EntityState.Modified;
                    _cliRepo.Editar(clienteDB);
                }

                //_ctx.SaveChanges();
                //Retorna uma string na actionresult
                //return Content("Dados salvos!");
                return RedirectToAction("Index");
            }

            return View("AddEdit",cliVM);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            //throw new Exception("Erro no acesso à base de dados!"); //Para testes

            var msg = "Erro na exclusão!";
            var status = false;

            try
            {
                var cli = //_ctx.Clientes.Find(id);
                    _cliRepo.Obter(id);
                if (cli != null)
                {
                    //_ctx.Clientes.Remove(cli);
                    //_ctx.SaveChanges();
                    _cliRepo.Excluir(cli);
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
            //_ctx.Dispose();
            _cliRepo.Dispose();
        }

    }
}
