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
    public class Cat_categoriasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Cat_categorias
        [Authorize(Roles = "Adm")]
        public ActionResult Index()
        {
            return View(db.Cat_Categoria.ToList());
        }

        // GET: Cat_categorias/Details/5
        [Authorize(Roles = "Adm")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_categoria cat_categoria = db.Cat_Categoria.Find(id);
            if (cat_categoria == null)
            {
                return HttpNotFound();
            }
            return View(cat_categoria);
        }

        // GET: Cat_categorias/Create
        [Authorize(Roles = "Adm")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat_categorias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Adm")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cat_id,Cat_nome,Cat_descricao,Cat_status")] Cat_categoria cat_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Cat_Categoria.Add(cat_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_categoria);
        }

        // GET: Cat_categorias/Edit/5
        [Authorize(Roles = "Adm")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_categoria cat_categoria = db.Cat_Categoria.Find(id);
            if (cat_categoria == null)
            {
                return HttpNotFound();
            }
            return View(cat_categoria);
        }

        // POST: Cat_categorias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Adm")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cat_id,Cat_nome,Cat_descricao,Cat_status")] Cat_categoria cat_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_categoria);
        }

        // GET: Cat_categorias/Delete/5
        [Authorize(Roles = "Adm")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_categoria cat_categoria = db.Cat_Categoria.Find(id);
            if (cat_categoria == null)
            {
                return HttpNotFound();
            }
            return View(cat_categoria);
        }

        // POST: Cat_categorias/Delete/5
        [Authorize(Roles = "Adm")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_categoria cat_categoria = db.Cat_Categoria.Find(id);
            db.Cat_Categoria.Remove(cat_categoria);
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
