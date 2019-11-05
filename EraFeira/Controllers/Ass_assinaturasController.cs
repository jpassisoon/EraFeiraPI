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
    public class Ass_assinaturasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Ass_assinaturas
        public ActionResult Index()
        {
            var ass_Assinatura = db.Ass_Assinatura.Include(a => a.Usu_Usuario);
            return View(ass_Assinatura.ToList());
        }

        // GET: Ass_assinaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ass_assinatura ass_assinatura = db.Ass_Assinatura.Find(id);
            if (ass_assinatura == null)
            {
                return HttpNotFound();
            }
            return View(ass_assinatura);
        }

        // GET: Ass_assinaturas/Create
        public ActionResult Create()
        {
            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome");
            return View();
        }

        // POST: Ass_assinaturas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ass_id,Ass_tempo,Ass_descricao,Ass_status,Ass_tipo_cesta,Usu_id")] Ass_assinatura ass_assinatura)
        {
            if (ModelState.IsValid)
            {
                db.Ass_Assinatura.Add(ass_assinatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome", ass_assinatura.Usu_id);
            return View(ass_assinatura);
        }

        // GET: Ass_assinaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ass_assinatura ass_assinatura = db.Ass_Assinatura.Find(id);
            if (ass_assinatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome", ass_assinatura.Usu_id);
            return View(ass_assinatura);
        }

        // POST: Ass_assinaturas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ass_id,Ass_tempo,Ass_descricao,Ass_status,Ass_tipo_cesta,Usu_id")] Ass_assinatura ass_assinatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ass_assinatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Usu_id = new SelectList(db.Usu_Usuario, "Usu_id", "Usu_nome", ass_assinatura.Usu_id);
            return View(ass_assinatura);
        }

        // GET: Ass_assinaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ass_assinatura ass_assinatura = db.Ass_Assinatura.Find(id);
            if (ass_assinatura == null)
            {
                return HttpNotFound();
            }
            return View(ass_assinatura);
        }

        // POST: Ass_assinaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ass_assinatura ass_assinatura = db.Ass_Assinatura.Find(id);
            db.Ass_Assinatura.Remove(ass_assinatura);
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
