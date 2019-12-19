namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2012 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            CreateIndex("dbo.Tandas", "Sala_Cantidad_ID_SCantidad");
            AddForeignKey("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropIndex("dbo.Tandas", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropColumn("dbo.Tandas", "Sala_Cantidad_ID_SCantidad");
        }
    }
}
