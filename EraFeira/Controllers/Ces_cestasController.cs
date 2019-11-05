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
    public class Ces_cestasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Ces_cestas
        public ActionResult Index()
        {
            var ces_Cesta = db.Ces_Cesta.Include(c => c.Ass_Assinatura).Include(c => c.Usu_Usuario);
            return View(ces_Cesta.ToList());
        }

        // GET: Ces_cestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ces_cesta ces_cesta = db.Ces_Cesta.Find(id);
            if (ces_cesta == null)
            {
                return HttpNotFound();
            }
            return View(ces_cesta);
        }

        // GET: Ces_cestas/Create
        public ActionResult Create()
        {
            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao");
            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome");
            return View();
        }

        // POST: Ces_cestas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ces_id,Ces_nome,Ces_criacao,Ces_valor_total,Usu_id,Ass_id")] Ces_cesta ces_cesta)
        {
            if (ModelState.IsValid)
            {
                db.Ces_Cesta.Add(ces_cesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao", ces_cesta.Ass_id);
            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome", ces_cesta.Usu_id);
            return View(ces_cesta);
        }

        // GET: Ces_cestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ces_cesta ces_cesta = db.Ces_Cesta.Find(id);
            if (ces_cesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao", ces_cesta.Ass_id);
            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome", ces_cesta.Usu_id);
            return View(ces_cesta);
        }

        // POST: Ces_cestas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ces_id,Ces_nome,Ces_criacao,Ces_valor_total,Usu_id,Ass_id")] Ces_cesta ces_cesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ces_cesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao", ces_cesta.Ass_id);
            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome", ces_cesta.Usu_id);
            return View(ces_cesta);
        }

        // GET: Ces_cestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ces_cesta ces_cesta = db.Ces_Cesta.Find(id);
            if (ces_cesta == null)
            {
                return HttpNotFound();
            }
            return View(ces_cesta);
        }

        // POST: Ces_cestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ces_cesta ces_cesta = db.Ces_Cesta.Find(id);
            db.Ces_Cesta.Remove(ces_cesta);
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
