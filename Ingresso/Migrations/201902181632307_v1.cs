namespace Ingresso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Nome = c.String(),
                        Cvv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Imagem = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Local = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(nullable: false),
                        Evento_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evento", t => t.Evento_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Evento_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        Sexo = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Login_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Login", t => t.Login_Id, cascadeDelete: true)
                .Index(t => t.Login_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamento", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Login_Id", "dbo.Login");
            DropForeignKey("dbo.Pagamento", "Evento_Id", "dbo.Evento");
            DropIndex("dbo.Usuario", new[] { "Login_Id" });
            DropIndex("dbo.Pagamento", new[] { "Usuario_Id" });
            DropIndex("dbo.Pagamento", new[] { "Evento_Id" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Pagamento");
            DropTable("dbo.Login");
            DropTable("dbo.Evento");
            DropTable("dbo.Cartao");
        }
    }
}
