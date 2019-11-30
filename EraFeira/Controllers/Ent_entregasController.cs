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
    public class Ent_entregasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Ent_entregas
        public ActionResult Index()
        {
            var ent_Entrega = db.Ent_Entrega.Include(e => e.Ces_Cesta);
            return View(ent_Entrega.ToList());
        }

        // GET: Ent_entregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ent_entrega ent_entrega = db.Ent_Entrega.Find(id);
            if (ent_entrega == null)
            {
                return HttpNotFound();
            }
            return View(ent_entrega);
        }

        // GET: Ent_entregas/Create
        public ActionResult Create()
        {
            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome");
            return View();
        }

        // POST: Ent_entregas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ent_id,Ent_data,Ent_anotacao,Ent_entregue,Ces_id")] Ent_entrega ent_entrega)
        {
            if (ModelState.IsValid)
            {
                db.Ent_Entrega.Add(ent_entrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome", ent_entrega.Ces_id);
            return View(ent_entrega);
        }

        // GET: Ent_entregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ent_entrega ent_entrega = db.Ent_Entrega.Find(id);
            if (ent_entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome", ent_entrega.Ces_id);
            return View(ent_entrega);
        }

        // POST: Ent_entregas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ent_id,Ent_data,Ent_anotacao,Ent_entregue,Ces_id")] Ent_entrega ent_entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ent_entrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome", ent_entrega.Ces_id);
            return View(ent_entrega);
        }

        // GET: Ent_entregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ent_entrega ent_entrega = db.Ent_Entrega.Find(id);
            if (ent_entrega == null)
            {
                return HttpNotFound();
            }
            return View(ent_entrega);
        }

        // POST: Ent_entregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ent_entrega ent_entrega = db.Ent_Entrega.Find(id);
            db.Ent_Entrega.Remove(ent_entrega);
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
