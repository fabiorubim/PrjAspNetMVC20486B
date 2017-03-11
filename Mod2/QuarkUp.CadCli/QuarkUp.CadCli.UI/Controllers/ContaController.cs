using QuarkUp.CadCli.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuarkUp.CadCli.UI.Controllers
{
    public class ContaController:Controller
    {
        public ActionResult Login(string returnUrl){
            ViewBag.isValid = true;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM login, string returnUrl)
        {
            ViewBag.isValid = false;

            if (ModelState.IsValid){
                //Autenticação
                if (login.UserName == "fabio@gmail.com" && login.Password == 123456)
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, false);
                    //return RedirectToAction("Index", "Clientes");
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        return RedirectPermanent(returnUrl);
                    }
                }
                else{
                    ModelState.AddModelError("","Usuário não autenticado");
                }
            }

            //Se não der refaça o login
            return View(login);
        }
    }
}