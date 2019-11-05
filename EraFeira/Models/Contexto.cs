using System;
using System.Collections.Generic;
using System.Data.Entity; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Contexto: DbContext
    {
        public Contexto() : base(nameOrConnectionString: "strConexao") { }
        public DbSet<Usu_usuario> Usu_Usuario { get; set; }
        public DbSet<End_endereco> End_Endereco { get; set; }
        public DbSet<Adm_Administrador> Adm_Administrador { get; set; }
        public DbSet<Cat_categoria> Cat_Categoria { get; set; }
        public DbSet<Pro_produto> Pro_Produto { get; set; }
        public DbSet<Img_imagem> Img_Imagem { get; set; }
        public DbSet<Ass_assinatura> Ass_Assinatura { get; set; }
        public DbSet<Ces_cesta> Ces_Cesta { get; set; }
        public DbSet<For_fornecedor> For_Fornecedor { get; set; }
    }
}