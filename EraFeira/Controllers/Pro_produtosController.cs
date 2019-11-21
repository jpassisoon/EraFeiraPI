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
    public class Pro_produtosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pro_produtos
        //[Authorize(Roles = "Adm")]
        public ActionResult Index()
        {
            var pro_Produto = db.Pro_Produto.Include(p => p.Cat_Categoria);
            return View(pro_Produto.ToList());
        }

        // GET: Pro_produtos/Details/5
        //[Authorize(Roles = "Adm")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pro_produto pro_produto = db.Pro_Produto.Find(id);
            if (pro_produto == null)
            {
                return HttpNotFound();
            }
            return View(pro_produto);
        }

        // GET: Pro_produtos/Create
        //[Authorize(Roles = "Adm")]
        public ActionResult Create()
        {
            ViewBag.Cat_id = new SelectList(db.Cat_Categoria, "Cat_id", "Cat_nome");
            return View();
        }

        // POST: Pro_produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Adm")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pro_id,Pro_descricao,Pro_valor_venda,Pro_desconto,Cat_id")] Pro_produto pro_produto, HttpPostedFileBase arq)
        {
            string valor = "";
            if (ModelState.IsValid)
            {
                if (arq != null)
                {
                    Upload.CriarDiretorio();
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                    valor = Upload.UploadArquivo(arq, nomearq);
                    if (valor == "Sucesso")
                    {
                        pro_produto.Pro_foto = nomearq;
                        db.Pro_Produto.Add(pro_produto);
                        db.SaveChanges();
                        TempData["MSG"] = "success|Cadastro realizado";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", valor);
                    }
                }
                else
                {
                    pro_produto.Pro_foto = "foto.png";
                    db.Pro_Produto.Add(pro_produto);
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Cat_id = new SelectList(db.Cat_Categoria, "Cat_id", "Cat_nome", pro_produto.Cat_id);
            return View(pro_produto);
        }

        // GET: Pro_produtos/Edit/5
        //[Authorize(Roles = "Adm")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pro_produto pro_produto = db.Pro_Produto.Find(id);
            if (pro_produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_id = new SelectList(db.Cat_Categoria, "Cat_id", "Cat_nome", pro_produto.Cat_id);
            return View(pro_produto);
        }

        // POST: Pro_produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Adm")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pro_id,Pro_descricao,Pro_valor_venda,Pro_desconto,Pro_foto,Cat_id")] Pro_produto pro_produto, HttpPostedFileBase arq)
        {
            string valor = "";
            if (ModelState.IsValid)
            {
                if (arq != null)
                {
                    Upload.CriarDiretorio();
                    string nomearq = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arq.FileName);
                    valor = Upload.UploadArquivo(arq, nomearq);
                    if (valor == "Sucesso")
                    {
                        Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" + pro_produto.Pro_foto);
                        pro_produto.Pro_foto = nomearq;
                        db.Entry(pro_produto).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    Pro_produto pro = db.Pro_Produto.Find(pro_produto.Pro_foto);
                    pro_produto.Pro_foto = pro_produto.Pro_foto;
                    db.Entry(pro_produto).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.Cat_id = new SelectList(db.Cat_Categoria, "Cat_id", "Cat_nome", pro_produto.Cat_id);
            return View(pro_produto);
        }

        // GET: Pro_produtos/Delete/5
        //[Authorize(Roles = "Adm")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pro_produto pro_produto = db.Pro_Produto.Find(id);
            if (pro_produto == null)
            {
                return HttpNotFound();
            }
            return View(pro_produto);
        }

        // POST: Pro_produtos/Delete/5
        //[Authorize(Roles = "Adm")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pro_produto pro_produto = db.Pro_Produto.Find(id);
            if(pro_produto.Pro_foto != "foto.png")
                Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" + pro_produto.Pro_foto);
            db.Pro_Produto.Remove(pro_produto);
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
