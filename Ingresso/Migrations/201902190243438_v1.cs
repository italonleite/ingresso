namespace Ingresso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "Login_Id", "dbo.Login");
            DropIndex("dbo.Usuario", new[] { "Login_Id" });
            RenameColumn(table: "dbo.Pagamento", name: "Evento_Id", newName: "EventoId");
            RenameColumn(table: "dbo.Pagamento", name: "Usuario_Id", newName: "UsuarioId");
            RenameIndex(table: "dbo.Pagamento", name: "IX_Usuario_Id", newName: "IX_UsuarioId");
            RenameIndex(table: "dbo.Pagamento", name: "IX_Evento_Id", newName: "IX_EventoId");
            AddColumn("dbo.Cartao", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "Login", c => c.String(nullable: false));
            AddColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Cartao", "Cvv", c => c.String());
            CreateIndex("dbo.Cartao", "UsuarioId");
            AddForeignKey("dbo.Cartao", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
            DropColumn("dbo.Usuario", "Login_Id");
            DropTable("dbo.Login");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuario", "Login_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cartao", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Cartao", new[] { "UsuarioId" });
            AlterColumn("dbo.Cartao", "Cvv", c => c.String(nullable: false));
            DropColumn("dbo.Usuario", "Senha");
            DropColumn("dbo.Usuario", "Login");
            DropColumn("dbo.Cartao", "UsuarioId");
            RenameIndex(table: "dbo.Pagamento", name: "IX_EventoId", newName: "IX_Evento_Id");
            RenameIndex(table: "dbo.Pagamento", name: "IX_UsuarioId", newName: "IX_Usuario_Id");
            RenameColumn(table: "dbo.Pagamento", name: "UsuarioId", newName: "Usuario_Id");
            RenameColumn(table: "dbo.Pagamento", name: "EventoId", newName: "Evento_Id");
            CreateIndex("dbo.Usuario", "Login_Id");
            AddForeignKey("dbo.Usuario", "Login_Id", "dbo.Login", "Id", cascadeDelete: true);
        }
    }
}
