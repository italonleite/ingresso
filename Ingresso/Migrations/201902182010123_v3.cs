namespace Ingresso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pagamento", name: "Evento_Id", newName: "EventoId");
            RenameColumn(table: "dbo.Pagamento", name: "Usuario_Id", newName: "UsuarioId");
            RenameColumn(table: "dbo.Usuario", name: "Login_Id", newName: "LoginId");
            RenameIndex(table: "dbo.Usuario", name: "IX_Login_Id", newName: "IX_LoginId");
            RenameIndex(table: "dbo.Pagamento", name: "IX_Usuario_Id", newName: "IX_UsuarioId");
            RenameIndex(table: "dbo.Pagamento", name: "IX_Evento_Id", newName: "IX_EventoId");
            AddColumn("dbo.Cartao", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cartao", "Cvv", c => c.String());
            CreateIndex("dbo.Cartao", "UsuarioId");
            AddForeignKey("dbo.Cartao", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cartao", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Cartao", new[] { "UsuarioId" });
            AlterColumn("dbo.Cartao", "Cvv", c => c.String(nullable: false));
            DropColumn("dbo.Cartao", "UsuarioId");
            RenameIndex(table: "dbo.Pagamento", name: "IX_EventoId", newName: "IX_Evento_Id");
            RenameIndex(table: "dbo.Pagamento", name: "IX_UsuarioId", newName: "IX_Usuario_Id");
            RenameIndex(table: "dbo.Usuario", name: "IX_LoginId", newName: "IX_Login_Id");
            RenameColumn(table: "dbo.Usuario", name: "LoginId", newName: "Login_Id");
            RenameColumn(table: "dbo.Pagamento", name: "UsuarioId", newName: "Usuario_Id");
            RenameColumn(table: "dbo.Pagamento", name: "EventoId", newName: "Evento_Id");
        }
    }
}
