using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EraFeira.Models;
using EraFeira.ViewModels; // biblioteca importada para pegar os dados da pasta ViewModel

namespace EraFeira.Controllers
{
    public class Usu_usuariosController : Controller
    {
        private Contexto db = new Contexto();

        //[Authorize(Roles = "Comum")]
        [AcceptVerbs(HttpVerbs.Post)]


        public JsonResult CadastrarAssinatura(ConfigCesta configCesta)
        {

            Ass_assinatura ass = new Ass_assinatura();

            ass.Ass_qtd_cesta = configCesta.QtdCesta;
            ass.Ass_tempo = configCesta.Tempo;
            ass.Ass_status = true;
            ass.Ass_tipo_cesta = configCesta.Status;
            ass.Usu_id = 1;
            db.Ass_Assinatura.Add(ass);
            db.SaveChanges();


            return Json("ok");

        }
        public JsonResult CadastrarProdutos(List<getItens> dados, ConfigCesta config)
        {


       
            string nomecesta = "";
            int cont = 0;
            double cont2 = 0;
            foreach (getItens gi in dados)
            {
                if (Convert.ToInt32(gi.Qtd) > 0)
                {
                    if (nomecesta != gi.Identificacao)
                    {
                        nomecesta = gi.Identificacao;
                        Ces_cesta cesta = new Ces_cesta();
                        cesta.Ces_nome = gi.Identificacao;
                        cesta.Ces_criacao = DateTime.Now;
                        cesta.Usu_id = 1;
                        cesta.Ces_valor = Convert.ToDouble(gi.Total);
                        cesta.Ass_id = 1;
                        db.Ces_Cesta.Add(cesta);
                        db.SaveChanges();
                        cont = cesta.Ces_id;
                    }


                    Cxp_cesta_produto a = new Cxp_cesta_produto();
                    a.Cxp_quantidade = Convert.ToInt32(gi.Qtd);
                    a.Cxp_valor = Convert.ToDouble(gi.Valor);
                    cont2 = Convert.ToDouble(gi.Valor);
                    a.Pro_id = Convert.ToInt32(gi.Id);
                    a.Ces_id = cont;
                    db.Cxp_Cesta_Produto.Add(a);
                    db.SaveChanges();
                }
            }
            


            return Json("ok");
        }

        // GET: Usu_usuarios
        //[Authorize(Roles = "Adm")]
        public ActionResult Index()
        {
            return View(db.Usu_Usuario.ToList());
        }

        // GET: Usu_usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usu_usuario usu_usuario = db.Usu_Usuario.Find(id);
            if (usu_usuario == null)
            {
                return HttpNotFound();
            }
            return View(usu_usuario);
        }

        // GET: Usu_usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usu_usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usu_id,Email,Cpf,Senha,ConfirmarSenha")] CadastroViewModel cuvm)
        {
            if (ModelState.IsValid)
            {
                Usu_usuario usuario = new Usu_usuario();
                usuario.Usu_email = cuvm.Email;
                usuario.Usu_Cpf = cuvm.Cpf;
                //usuario.Usu_Cpf = Cpf.validaCPF(cuvm.Cpf);
                usuario.Usu_senha = Criptografia.Encrypt(cuvm.Senha);
                db.Usu_Usuario.Add(usuario);
                db.SaveChanges();
                TempData["MSG"] = "success|Cadastro realizado";
                return RedirectToAction("Login","Home");
               
            }
            
            return View(cuvm);
        }

       

        public ActionResult EsqueceuSenha()
        {
            return View();
        }
        public ActionResult Pagamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EsqueceuSenha(EsqueceuSenhaViewModel xes)
        {
            Usu_usuario usu = db.Usu_Usuario.Where(t => t.Usu_email == xes.Email).FirstOrDefault();
            if (usu != null)
            {
                //string novasenha = "12345678@";
                string novasenha = "Mt358@sd1e";

                //Random ran = new Random();
                //string novasenha = ran.Next(1,100);

                usu.Usu_senha = Criptografia.Encrypt(novasenha);
                db.Entry(usu).State = EntityState.Modified;
                db.SaveChanges();
                Email.EnviarEmail(usu.Usu_email, "Lembrete de Senha", "Sua nova senha é: " + novasenha);
                TempData["MSG"] = "success|E-mail enviado";
            }
            else
            {
                TempData["MSG"] = "error|Erro ao enviar o e-mail";
            }
            return View();
        }

        //[Authorize(Roles = "Comum")]
        public ActionResult ResumoCompletoPedido()
        {
            return View(db.Pro_Produto.ToList());
        }

        //[Authorize(Roles = "Comum")]
        public ActionResult Cidade()
        {
            return View();
        }

        //[Authorize(Roles = "Comum")]
        public ActionResult Entregas()
        {
            return View();
        }
        
        //[Authorize(Roles = "Comum")]
        public ActionResult AreaUsuario()
        {
            return View();
        }

       // [Authorize(Roles = "Comum")]
        public ActionResult Carrinho()
        {
            return View(db.Pro_Produto.ToList());
        }
        public ActionResult Carrinho2()
        {
            return View(db.Pro_Produto.ToList());
        }
        public ActionResult Carrinho3()
        {
            return View(db.Pro_Produto.ToList());
        }
        public ActionResult Carrinho4()
        {
            return View(db.Pro_Produto.ToList());
        }

        //[Authorize(Roles = "Comum")]
        // GET: Usu_usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usu_usuario usu_usuario = db.Usu_Usuario.Find(id);
            if (usu_usuario == null)
            {
                return HttpNotFound();
            }
            return View(usu_usuario);
        }

        // POST: Usu_usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Comum")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usu_id,Usu_nome,Usu_sobrenome,Usu_email,Usu_senha,Usu_data_nascimento,Usu_Cpf,Usu_sexo,Usu_telefone,Usu_celular")] Usu_usuario usu_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usu_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usu_usuario);
        }

        // GET: Usu_usuarios/Delete/5
        //[Authorize(Roles = "Adm")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usu_usuario usu_usuario = db.Usu_Usuario.Find(id);
            if (usu_usuario == null)
            {
                return HttpNotFound();
            }
            return View(usu_usuario);
        }

        // POST: Usu_usuarios/Delete/5
        //[Authorize(Roles = "Adm")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usu_usuario usu_usuario = db.Usu_Usuario.Find(id);
            db.Usu_Usuario.Remove(usu_usuario);
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
