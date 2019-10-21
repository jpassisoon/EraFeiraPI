namespace EraFeira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adm_Administrador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Senha = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cat_categoria",
                c => new
                    {
                        Cat_id = c.Int(nullable: false, identity: true),
                        Cat_nome = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Cat_descricao = c.String(nullable: false, unicode: false),
                        Cat_status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Cat_id);
            
            CreateTable(
                "dbo.End_endereco",
                c => new
                    {
                        End_id = c.Int(nullable: false, identity: true),
                        End_cep = c.String(nullable: false, unicode: false),
                        End_logradouro = c.String(nullable: false, unicode: false),
                        End_numero = c.String(nullable: false, unicode: false),
                        End_bairro = c.String(nullable: false, unicode: false),
                        End_complemento = c.String(unicode: false),
                        End_cidade = c.String(nullable: false, unicode: false),
                        End_estado = c.String(nullable: false, unicode: false),
                        End_instrucao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.End_id);
            
            CreateTable(
                "dbo.Img_imagem",
                c => new
                    {
                        Img_id = c.Int(nullable: false, identity: true),
                        Img_nome = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Img_foto = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Pro_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Img_id)
                .ForeignKey("dbo.Pro_produto", t => t.Pro_id, cascadeDelete: true)
                .Index(t => t.Pro_id);
            
            CreateTable(
                "dbo.Pro_produto",
                c => new
                    {
                        Pro_id = c.Int(nullable: false, identity: true),
                        Pro_nome = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Pro_descricao = c.String(nullable: false, unicode: false),
                        Pro_valor_venda = c.Double(nullable: false),
                        Pro_data_chegada = c.DateTime(nullable: false, precision: 0),
                        Pro_data_vencimento = c.DateTime(nullable: false, precision: 0),
                        Pro_desconto = c.Int(nullable: false),
                        Pro_quantidade = c.Int(nullable: false),
                        Cat_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pro_id)
                .ForeignKey("dbo.Cat_categoria", t => t.Cat_id, cascadeDelete: true)
                .Index(t => t.Cat_id);
            
            CreateTable(
                "dbo.Usu_usuario",
                c => new
                    {
                        Usu_id = c.Int(nullable: false, identity: true),
                        Usu_nome = c.String(maxLength: 15, storeType: "nvarchar"),
                        Usu_sobrenome = c.String(maxLength: 15, storeType: "nvarchar"),
                        Usu_email = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Usu_senha = c.String(nullable: false, unicode: false),
                        Usu_data_nascimento = c.DateTime(nullable: false, precision: 0),
                        Usu_Cpf = c.String(nullable: false, unicode: false),
                        Usu_sexo = c.Int(nullable: false),
                        Usu_telefone = c.String(unicode: false),
                        Usu_celular = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Usu_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Img_imagem", "Pro_id", "dbo.Pro_produto");
            DropForeignKey("dbo.Pro_produto", "Cat_id", "dbo.Cat_categoria");
            DropIndex("dbo.Pro_produto", new[] { "Cat_id" });
            DropIndex("dbo.Img_imagem", new[] { "Pro_id" });
            DropTable("dbo.Usu_usuario");
            DropTable("dbo.Pro_produto");
            DropTable("dbo.Img_imagem");
            DropTable("dbo.End_endereco");
            DropTable("dbo.Cat_categoria");
            DropTable("dbo.Adm_Administrador");
        }
    }
}
