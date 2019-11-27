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
    public class Fdp_forma_pagamentosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Fdp_forma_pagamentos
        public ActionResult Index()
        {
            var fdp_Forma_Pagamento = db.Fdp_Forma_Pagamento.Include(f => f.Ass_Assinatura).Include(f => f.Stp_Status_Pedido);
            return View(fdp_Forma_Pagamento.ToList());
        }

        // GET: Fdp_forma_pagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fdp_forma_pagamento fdp_forma_pagamento = db.Fdp_Forma_Pagamento.Find(id);
            if (fdp_forma_pagamento == null)
            {
                return HttpNotFound();
            }
            return View(fdp_forma_pagamento);
        }

        // GET: Fdp_forma_pagamentos/Create
        public ActionResult Create()
        {
            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao");
            ViewBag.Stp_id = new SelectList(db.Stp_Status_Pedido, "Stp_id", "Descricao");
            return View();
        }

        // POST: Fdp_forma_pagamentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fpd_id,Fpd_nome_titular,Fdp_numero_cartao,Fdp_validade_cartao,Fdp_cvv_cartao,Fpd_data_compra,Ass_id,Stp_id")] Fdp_forma_pagamento fdp_forma_pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Fdp_Forma_Pagamento.Add(fdp_forma_pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao", fdp_forma_pagamento.Ass_id);
            ViewBag.Stp_id = new SelectList(db.Stp_Status_Pedido, "Stp_id", "Descricao", fdp_forma_pagamento.Stp_id);
            return View(fdp_forma_pagamento);
        }

        // GET: Fdp_forma_pagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fdp_forma_pagamento fdp_forma_pagamento = db.Fdp_Forma_Pagamento.Find(id);
            if (fdp_forma_pagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao", fdp_forma_pagamento.Ass_id);
            ViewBag.Stp_id = new SelectList(db.Stp_Status_Pedido, "Stp_id", "Descricao", fdp_forma_pagamento.Stp_id);
            return View(fdp_forma_pagamento);
        }

        // POST: Fdp_forma_pagamentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fpd_id,Fpd_nome_titular,Fdp_numero_cartao,Fdp_validade_cartao,Fdp_cvv_cartao,Fpd_data_compra,Ass_id,Stp_id")] Fdp_forma_pagamento fdp_forma_pagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fdp_forma_pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ass_id = new SelectList(db.Ass_Assinatura, "Ass_id", "Ass_descricao", fdp_forma_pagamento.Ass_id);
            ViewBag.Stp_id = new SelectList(db.Stp_Status_Pedido, "Stp_id", "Descricao", fdp_forma_pagamento.Stp_id);
            return View(fdp_forma_pagamento);
        }

        // GET: Fdp_forma_pagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fdp_forma_pagamento fdp_forma_pagamento = db.Fdp_Forma_Pagamento.Find(id);
            if (fdp_forma_pagamento == null)
            {
                return HttpNotFound();
            }
            return View(fdp_forma_pagamento);
        }

        // POST: Fdp_forma_pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fdp_forma_pagamento fdp_forma_pagamento = db.Fdp_Forma_Pagamento.Find(id);
            db.Fdp_Forma_Pagamento.Remove(fdp_forma_pagamento);
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
