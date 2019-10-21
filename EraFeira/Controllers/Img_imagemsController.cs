using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO; // biblioteca importada
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EraFeira.Models;

namespace EraFeira.Controllers
{
    public class Img_imagemsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Img_imagems
        public ActionResult Index()
        {
            var img_Imagem = db.Img_Imagem.Include(i => i.Pro_Produto);
            return View(img_Imagem.ToList());
        }

        // GET: Img_imagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Img_imagem img_imagem = db.Img_Imagem.Find(id);
            if (img_imagem == null)
            {
                return HttpNotFound();
            }
            return View(img_imagem);
        }

        // GET: Img_imagems/Create
        public ActionResult Create()
        {
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_nome");
            return View();
        }

        // POST: Img_imagems/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Img_id,Pro_id,Img_nome")] Img_imagem img_imagem, HttpPostedFileBase[] arq)
        {
            string nomearq, valor;
            if (ModelState.IsValid)
            {
                if (arq != null)
                {
                    Upload.CriarDiretorio();
                    foreach (HttpPostedFileBase flb in arq)
                    {
                        nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(flb.FileName);
                        valor = Upload.UploadArquivo(flb, nomearq);
                        if (valor == "Sucesso")
                        {
                            img_imagem.Img_foto = nomearq;
                            db.Img_Imagem.Add(img_imagem);
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_nome", img_imagem.Pro_id);
            return View(img_imagem);
        }

        // GET: Img_imagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Img_imagem img_imagem = db.Img_Imagem.Find(id);
            if (img_imagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_nome", img_imagem.Pro_id);
            return View(img_imagem);
        }

        // POST: Img_imagems/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Img_id,Pro_id,Img_nome,Img_foto")] Img_imagem img_imagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(img_imagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pro_id = new SelectList(db.Pro_Produto, "Pro_id", "Pro_nome", img_imagem.Pro_id);
            return View(img_imagem);
        }

        // GET: Img_imagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Img_imagem img_imagem = db.Img_Imagem.Find(id);
            if (img_imagem == null)
            {
                return HttpNotFound();
            }
            return View(img_imagem);
        }

        // POST: Img_imagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Img_imagem img_imagem = db.Img_Imagem.Find(id);
            Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" + img_imagem.Img_foto);
            db.Img_Imagem.Remove(img_imagem);
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
