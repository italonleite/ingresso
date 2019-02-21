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
                        Cvv = c.String(),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        Sexo = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
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
                "dbo.Pagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Numero = c.String(nullable: false),
                        EventoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evento", t => t.EventoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.EventoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamento", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Pagamento", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Cartao", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Pagamento", new[] { "EventoId" });
            DropIndex("dbo.Pagamento", new[] { "UsuarioId" });
            DropIndex("dbo.Cartao", new[] { "UsuarioId" });
            DropTable("dbo.Pagamento");
            DropTable("dbo.Evento");
            DropTable("dbo.Usuario");
            DropTable("dbo.Cartao");
        }
    }
}
