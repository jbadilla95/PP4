namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2112 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tandas", "Compra_ID_Compra", "dbo.Compras");
            DropIndex("dbo.Tandas", new[] { "Compra_ID_Compra" });
            DropColumn("dbo.Compras", "ID_tanda");
            DropColumn("dbo.Tandas", "Compra_ID_Compra");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tandas", "Compra_ID_Compra", c => c.Int());
            AddColumn("dbo.Compras", "ID_tanda", c => c.Int(nullable: false));
            CreateIndex("dbo.Tandas", "Compra_ID_Compra");
            AddForeignKey("dbo.Tandas", "Compra_ID_Compra", "dbo.Compras", "ID_Compra");
        }
    }
}
