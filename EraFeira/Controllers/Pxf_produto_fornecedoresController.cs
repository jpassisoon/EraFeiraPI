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
    public class Pxf_produto_fornecedoresController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pxf_produto_fornecedores
        public ActionResult Index()
        {
            var pxf_Produto_Fornecedor = db.Pxf_Produto_Fornecedor.Include(p => p.Est_Estoque).Include(p => p.For_Fornecedor).Include(p => p.Pro_Produto);
            return View(pxf_Produto_Fornecedor.ToList());
        }

        // GET: Pxf_produto_fornecedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pxf_produto_fornecedor pxf_produto_fornecedor = db.Pxf_Produto_Fornecedor.Find(id);
            if (pxf_produto_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(pxf_produto_fornecedor);
        }

        // GET: Pxf_produto_fornecedores/Create
        public ActionResult Create()
        {
            ViewBag.Est_id = new SelectList(db.Est_Estoque, "Est_id", "Est_motivo_saida");
            ViewBag.For_id = new SelectList(db.For_Fornecedor, "For_id", "For_nome");
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao");
            return View();
        }

        // POST: Pxf_produto_fornecedores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pxf_id,Pro_id,For_id,Est_id")] Pxf_produto_fornecedor pxf_produto_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Pxf_Produto_Fornecedor.Add(pxf_produto_fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Est_id = new SelectList(db.Est_Estoque, "Est_id", "Est_motivo_saida", pxf_produto_fornecedor.Est_id);
            ViewBag.For_id = new SelectList(db.For_Fornecedor, "For_id", "For_nome", pxf_produto_fornecedor.For_id);
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", pxf_produto_fornecedor.Pro_id);
            return View(pxf_produto_fornecedor);
        }

        // GET: Pxf_produto_fornecedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pxf_produto_fornecedor pxf_produto_fornecedor = db.Pxf_Produto_Fornecedor.Find(id);
            if (pxf_produto_fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Est_id = new SelectList(db.Est_Estoque, "Est_id", "Est_motivo_saida", pxf_produto_fornecedor.Est_id);
            ViewBag.For_id = new SelectList(db.For_Fornecedor, "For_id", "For_nome", pxf_produto_fornecedor.For_id);
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", pxf_produto_fornecedor.Pro_id);
            return View(pxf_produto_fornecedor);
        }

        // POST: Pxf_produto_fornecedores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pxf_id,Pro_id,For_id,Est_id")] Pxf_produto_fornecedor pxf_produto_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pxf_produto_fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Est_id = new SelectList(db.Est_Estoque, "Est_id", "Est_motivo_saida", pxf_produto_fornecedor.Est_id);
            ViewBag.For_id = new SelectList(db.For_Fornecedor, "For_id", "For_nome", pxf_produto_fornecedor.For_id);
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_descricao", pxf_produto_fornecedor.Pro_id);
            return View(pxf_produto_fornecedor);
        }

        // GET: Pxf_produto_fornecedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pxf_produto_fornecedor pxf_produto_fornecedor = db.Pxf_Produto_Fornecedor.Find(id);
            if (pxf_produto_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(pxf_produto_fornecedor);
        }

        // POST: Pxf_produto_fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pxf_produto_fornecedor pxf_produto_fornecedor = db.Pxf_Produto_Fornecedor.Find(id);
            db.Pxf_Produto_Fornecedor.Remove(pxf_produto_fornecedor);
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
