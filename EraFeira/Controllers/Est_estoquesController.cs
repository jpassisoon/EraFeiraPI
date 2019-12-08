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
    public class Est_estoquesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Est_estoques
        public ActionResult Index()
        {
            var est_Estoque = db.Est_Estoque.Include(e => e.Pro_Produto);
            return View(est_Estoque.ToList());
        }

        // GET: Est_estoques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Est_estoque est_estoque = db.Est_Estoque.Find(id);
            if (est_estoque == null)
            {
                return HttpNotFound();
            }
            return View(est_estoque);
        }

        // GET: Est_estoques/Create
        public ActionResult Create()
        {
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao");
            return View();
        }

        // entrada 
        public ActionResult Entrada()
        {
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entrada([Bind(Include = "Est_id,Est_quantidade_entrada,Est_entrada,Est_valor_entrada,Est_data_vencimento,Pro_id")] Est_estoque est_estoque)
        {
            if (ModelState.IsValid)
            {
                db.Est_Estoque.Add(est_estoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", est_estoque.Pro_id);
            return View(est_estoque);
        }

        // Saída

        public ActionResult Saida()
        {
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Saida([Bind(Include = "Est_id,Est_quantidade_saida,Est_saida,Est_motivo_saida,Pro_id")] Est_estoque est_estoque)
        {
            if (ModelState.IsValid)
            {
                db.Est_Estoque.Add(est_estoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", est_estoque.Pro_id);
            return View(est_estoque);
        }

        // POST: Est_estoques/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Est_id,Est_quantidade_entrada,Est_quantidade_saida,Est_entrada,Est_saida,Est_motivo_saida,Est_valor_entrada,Est_data_vencimento,Pro_id")] Est_estoque est_estoque)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Est_Estoque.Add(est_estoque);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", est_estoque.Pro_id);
        //    return View(est_estoque);
        //}

        // GET: Est_estoques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Est_estoque est_estoque = db.Est_Estoque.Find(id);
            if (est_estoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", est_estoque.Pro_id);
            return View(est_estoque);
        }

        // POST: Est_estoques/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Est_id,Est_quantidade_entrada,Est_quantidade_saida,Est_entrada,Est_saida,Est_motivo_saida,Est_valor_entrada,Est_data_vencimento,Pro_id")] Est_estoque est_estoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(est_estoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", est_estoque.Pro_id);
            return View(est_estoque);
        }

        // GET: Est_estoques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Est_estoque est_estoque = db.Est_Estoque.Find(id);
            if (est_estoque == null)
            {
                return HttpNotFound();
            }
            return View(est_estoque);
        }

        // POST: Est_estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Est_estoque est_estoque = db.Est_Estoque.Find(id);
            db.Est_Estoque.Remove(est_estoque);
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
