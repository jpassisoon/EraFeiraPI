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
    public class Stp_status_pedidosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Stp_status_pedidos
        public ActionResult Index()
        {
            return View(db.Stp_Status_Pedido.ToList());
        }

        // GET: Stp_status_pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stp_status_pedido stp_status_pedido = db.Stp_Status_Pedido.Find(id);
            if (stp_status_pedido == null)
            {
                return HttpNotFound();
            }
            return View(stp_status_pedido);
        }

        // GET: Stp_status_pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stp_status_pedidos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stp_id,Descricao")] Stp_status_pedido stp_status_pedido)
        {
            if (ModelState.IsValid)
            {
                db.Stp_Status_Pedido.Add(stp_status_pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stp_status_pedido);
        }

        // GET: Stp_status_pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stp_status_pedido stp_status_pedido = db.Stp_Status_Pedido.Find(id);
            if (stp_status_pedido == null)
            {
                return HttpNotFound();
            }
            return View(stp_status_pedido);
        }

        // POST: Stp_status_pedidos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stp_id,Descricao")] Stp_status_pedido stp_status_pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stp_status_pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stp_status_pedido);
        }

        // GET: Stp_status_pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stp_status_pedido stp_status_pedido = db.Stp_Status_Pedido.Find(id);
            if (stp_status_pedido == null)
            {
                return HttpNotFound();
            }
            return View(stp_status_pedido);
        }

        // POST: Stp_status_pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stp_status_pedido stp_status_pedido = db.Stp_Status_Pedido.Find(id);
            db.Stp_Status_Pedido.Remove(stp_status_pedido);
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
