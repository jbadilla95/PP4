namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Numero4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personas", "Compra_ID_Compra", "dbo.Compras");
            DropIndex("dbo.Personas", new[] { "Compra_ID_Compra" });
            DropColumn("dbo.Personas", "Compra_ID_Compra");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personas", "Compra_ID_Compra", c => c.Int());
            CreateIndex("dbo.Personas", "Compra_ID_Compra");
            AddForeignKey("dbo.Personas", "Compra_ID_Compra", "dbo.Compras", "ID_Compra");
        }
    }
}
