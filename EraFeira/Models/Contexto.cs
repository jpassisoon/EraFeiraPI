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
        public DbSet<Est_estoque> Est_Estoque { get; set; }
        public DbSet<Pxf_produto_fornecedor> Pxf_Produto_Fornecedor { get; set; }
        public DbSet<Cxp_cesta_produto> Cxp_Cesta_Produto { get; set; }
        public DbSet<Stp_status_pedido> Stp_Status_Pedido { set; get; }
        public DbSet<Fdp_forma_pagamento> Fdp_Forma_Pagamento { set; get; }
        public DbSet<Ent_entrega> Ent_Entrega { set; get; }
    }
}