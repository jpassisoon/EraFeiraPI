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
    public class Cxp_cesta_produtosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Cxp_cesta_produtos
        public ActionResult Index()
        {
            var cxp_Cesta_Produto = db.Cxp_Cesta_Produto.Include(c => c.Ces_Cesta).Include(c => c.Pro_Produto);
            return View(cxp_Cesta_Produto.ToList());
        }

        // GET: Cxp_cesta_produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cxp_cesta_produto cxp_cesta_produto = db.Cxp_Cesta_Produto.Find(id);
            if (cxp_cesta_produto == null)
            {
                return HttpNotFound();
            }
            return View(cxp_cesta_produto);
        }

        // GET: Cxp_cesta_produtos/Create
        public ActionResult Create()
        {
            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome");
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao");
            return View();
        }

        // POST: Cxp_cesta_produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cxp_id,Cxp_valor,Cxp_quantidade,Ces_id,Pro_id")] Cxp_cesta_produto cxp_cesta_produto)
        {
            if (ModelState.IsValid)
            {
                db.Cxp_Cesta_Produto.Add(cxp_cesta_produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome", cxp_cesta_produto.Ces_id);
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", cxp_cesta_produto.Pro_id);
            return View(cxp_cesta_produto);
        }

        // GET: Cxp_cesta_produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cxp_cesta_produto cxp_cesta_produto = db.Cxp_Cesta_Produto.Find(id);
            if (cxp_cesta_produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome", cxp_cesta_produto.Ces_id);
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", cxp_cesta_produto.Pro_id);
            return View(cxp_cesta_produto);
        }

        // POST: Cxp_cesta_produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cxp_id,Cxp_valor,Cxp_quantidade,Ces_id,Pro_id")] Cxp_cesta_produto cxp_cesta_produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cxp_cesta_produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ces_id = new SelectList(db.Ces_Cesta, "Ces_id", "Ces_nome", cxp_cesta_produto.Ces_id);
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", cxp_cesta_produto.Pro_id);
            return View(cxp_cesta_produto);
        }

        // GET: Cxp_cesta_produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cxp_cesta_produto cxp_cesta_produto = db.Cxp_Cesta_Produto.Find(id);
            if (cxp_cesta_produto == null)
            {
                return HttpNotFound();
            }
            return View(cxp_cesta_produto);
        }

        // POST: Cxp_cesta_produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cxp_cesta_produto cxp_cesta_produto = db.Cxp_Cesta_Produto.Find(id);
            db.Cxp_Cesta_Produto.Remove(cxp_cesta_produto);
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
