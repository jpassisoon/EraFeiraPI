using EraFeira.Models; // biblioteca importada para acesso das models
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // biblioteca importada para autenticação

namespace EraFeira.Controllers
{
    public class HomeController : Controller
    {
        private Contexto db = new Contexto();
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha, string ReturnUrl)
        {
            senha = Criptografia.Encrypt(senha);
            Usu_usuario usu = db.Usu_Usuario.Where(t => t.Usu_email == email && t.Usu_senha == senha).ToList().FirstOrDefault();
            Adm_Administrador adm_Administrador = db.Adm_Administrador.Where(x => x.Email == email && x.Senha == senha).ToList().FirstOrDefault();

            if (usu != null)
            {
                TempData["MSG"] = "success|Login efetuado com sucesso";
                string permissoes = "";
                if (permissoes.Length > 0)
                    permissoes = permissoes.Substring(0, permissoes.Length - 1); // o -1 é usado para tirar a vírgula

                FormsAuthentication.SetAuthCookie(usu.Usu_email, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usu.Usu_email, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                    cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                if (String.IsNullOrEmpty(ReturnUrl))
                    return RedirectToAction("Dashboard","Usu_usuarios");
                else
                {
                    var decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                        return Redirect(decodedUrl);
                    else
                        return RedirectToAction("Index");
                }
            }
            else if (adm_Administrador != null)
            {
                TempData["MSG"] = "info|Login efetuado com sucesso";
                string permissoes = "";
                if (permissoes.Length > 0)
                    permissoes = permissoes.Substring(0, permissoes.Length - 1); // o -1 é usado para tirar a vírgula

                FormsAuthentication.SetAuthCookie(adm_Administrador.Email, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, adm_Administrador.Email + "|" + adm_Administrador.Id, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                    cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                if (String.IsNullOrEmpty(ReturnUrl))
                    return RedirectToAction("DashboardAdministrador", "Adm_administradores");
                else
                {
                    var decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                        return Redirect(decodedUrl);
                    else
                        return RedirectToAction("Index");
                }
            }


            else
            {
                //ModelState.AddModelError("", "Usuário/Senha inválidos");
                TempData["MSG"] = "error|Login incorreto";
                return View();
            }


        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}