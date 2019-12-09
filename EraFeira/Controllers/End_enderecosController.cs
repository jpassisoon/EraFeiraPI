using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EraFeira.Models;

namespace EraFeira.Controllers
{
    public class End_enderecosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: End_enderecos
        public ActionResult Index()
        {
            return View(db.End_Endereco.ToList());
        }

        // GET: End_enderecos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            End_endereco end_endereco = db.End_Endereco.Find(id);
            if (end_endereco == null)
            {
                return HttpNotFound();
            }
            return View(end_endereco);
        }

        // GET: End_enderecos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: End_enderecos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "End_id,End_cep,End_logradouro,End_numero,End_bairro,End_complemento,End_cidade,End_estado")] End_endereco end_endereco)
        {
            if (ModelState.IsValid)
            {
                db.End_Endereco.Add(end_endereco);
                db.SaveChanges();
                return RedirectToAction("Entregas", "Usu_usuarios");
            }

            return View(end_endereco);
        }

        // GET: End_enderecos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            End_endereco end_endereco = db.End_Endereco.Find(id);
            if (end_endereco == null)
            {
                return HttpNotFound();
            }
            return View(end_endereco);
        }

        // POST: End_enderecos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "End_id,End_cep,End_logradouro,End_numero,End_bairro,End_complemento,End_cidade,End_estado")] End_endereco end_endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(end_endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(end_endereco);
        }

        // GET: End_enderecos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            End_endereco end_endereco = db.End_Endereco.Find(id);
            if (end_endereco == null)
            {
                return HttpNotFound();
            }
            return View(end_endereco);
        }

        // POST: End_enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            End_endereco end_endereco = db.End_Endereco.Find(id);
            db.End_Endereco.Remove(end_endereco);
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
