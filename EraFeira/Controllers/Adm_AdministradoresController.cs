using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EraFeira.Models;
using EraFeira.ViewModels; // biblioteca importada para pegar os dados da pasta ViewModel

namespace EraFeira.Controllers
{
    public class Adm_AdministradoresController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Adm_Administradores
        [Authorize(Roles = "Adm")]
        public ActionResult Index()
        {
            return View(db.Adm_Administrador.ToList());
        }

        // GET: Adm_Administradores/Details/5
        [Authorize(Roles = "Adm")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm_Administrador adm_Administrador = db.Adm_Administrador.Find(id);
            if (adm_Administrador == null)
            {
                return HttpNotFound();
            }
            return View(adm_Administrador);
        }

        [Authorize(Roles = "Adm")]
        public ActionResult DashboardAdministrador()
        {
            return View();
        }

        // GET: Adm_Administradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adm_Administradores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Senha")] CadastroAdministradorViewModel cavm)
        {
            if (ModelState.IsValid)
            {
                Adm_Administrador administrador = new Adm_Administrador();
                administrador.Nome = cavm.Nome;
                administrador.Email = cavm.Email;
                administrador.Senha = Criptografia.Encrypt(cavm.Senha);
                db.Adm_Administrador.Add(administrador);
                db.SaveChanges();
                TempData["MSG"] = "success|Cadastro realizado";
                return RedirectToAction("Login","Home");
            }

            return View(cavm);
        }

        // GET: Adm_Administradores/Edit/5
        [Authorize(Roles = "Adm")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm_Administrador adm_Administrador = db.Adm_Administrador.Find(id);
            if (adm_Administrador == null)
            {
                return HttpNotFound();
            }
            return View(adm_Administrador);
        }

        // POST: Adm_Administradores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Adm")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Senha")] Adm_Administrador adm_Administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adm_Administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adm_Administrador);
        }

        // GET: Adm_Administradores/Delete/5
        [Authorize(Roles = "Adm")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm_Administrador adm_Administrador = db.Adm_Administrador.Find(id);
            if (adm_Administrador == null)
            {
                return HttpNotFound();
            }
            return View(adm_Administrador);
        }

        // POST: Adm_Administradores/Delete/5
        [Authorize(Roles = "Adm")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adm_Administrador adm_Administrador = db.Adm_Administrador.Find(id);
            db.Adm_Administrador.Remove(adm_Administrador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
