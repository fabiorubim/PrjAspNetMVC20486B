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
        public readonly CadCliContext _ctx = new CadCliContext();

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

                var usuario = _ctx.Usuarios.FirstOrDefault(u=>u.Email.ToLower()==login.UserName.ToLower());

                if (usuario != null) {
                    if (usuario.Senha == StringHelper.Encrypt(login.Password))
                    {
                        FormsAuthentication.SetAuthCookie(login.UserName, false);
                        //return RedirectToAction("Index", "Clientes");
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectPermanent(returnUrl);
                        }

                    }
                    else
                    {
                      ModelState.AddModelError("Password", "Senha incorreta");
                    }
                }
                else {
                    ModelState.AddModelError("UserName","E-mail não localizado");
                }

                //Autenticação
                //if (login.UserName == "fabio@gmail.com" && login.Password == 123456)
                //{
                //    FormsAuthentication.SetAuthCookie(login.UserName, false);
                //    //return RedirectToAction("Index", "Clientes");
                //    if (string.IsNullOrEmpty(returnUrl))
                //    {
                //        return RedirectToAction("Index","Home");
                //    }
                //    else
                //    {
                //        return RedirectPermanent(returnUrl);
                //    }
                //}
                //else{
                //    ModelState.AddModelError("","Usuário não autenticado");
                //}
            }

            //Se não der refaça o login
            return View(login);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }
    
    }
}