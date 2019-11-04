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
    public class For_fornecedoresController : Controller
    {
        private Contexto db = new Contexto();

        // GET: For_fornecedores
        
        public ActionResult Index()
        {
            var for_Fornecedor = db.For_Fornecedor.Include(f => f.End_Endereco);
            return View(for_Fornecedor.ToList());
        }

        // GET: For_fornecedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            For_fornecedor for_fornecedor = db.For_Fornecedor.Find(id);
            if (for_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(for_fornecedor);
        }
       
        // GET: For_fornecedores/Create
        public ActionResult Create()
        {
            ViewBag.End_id = new SelectList(db.End_Endereco, "End_id", "End_cep");
            return View();
        }

        // POST: For_fornecedores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "For_id,For_nome,For_telefone,For_documento,End_id")] For_fornecedor for_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.For_Fornecedor.Add(for_fornecedor);
                db.SaveChanges();
                TempData["MSG"] = "success|Cadastro realizado";
                return RedirectToAction("Index");
            }

            ViewBag.End_id = new SelectList(db.End_Endereco, "End_id", "End_cep", for_fornecedor.End_id);
            return View(for_fornecedor);
        }

        
        // GET: For_fornecedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            For_fornecedor for_fornecedor = db.For_Fornecedor.Find(id);
            if (for_fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.End_id = new SelectList(db.End_Endereco, "End_id", "End_cep", for_fornecedor.End_id);
            return View(for_fornecedor);
        }

        // POST: For_fornecedores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "For_id,For_nome,For_telefone,For_documento,End_id")] For_fornecedor for_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(for_fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.End_id = new SelectList(db.End_Endereco, "End_id", "End_cep", for_fornecedor.End_id);
            return View(for_fornecedor);
        }
        
        // GET: For_fornecedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            For_fornecedor for_fornecedor = db.For_Fornecedor.Find(id);
            if (for_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(for_fornecedor);
        }

        
        // POST: For_fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            For_fornecedor for_fornecedor = db.For_Fornecedor.Find(id);
            db.For_Fornecedor.Remove(for_fornecedor);
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
