using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoGlobal.Controllers
{
    public class CadastroController : Controller
    {
        //
        // GET: /Cadastro/

        public ActionResult Index()
        {
            return View();
        }

        public string Salvar(string nome, string sobrenome, string idade)
        {
            return
                string.Format("Nome: {0} - Sobrenome: {1} - Idade: {2}", nome, sobrenome, idade);

        }

    }
}
