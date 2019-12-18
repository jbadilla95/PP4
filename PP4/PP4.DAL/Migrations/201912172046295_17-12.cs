namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1712 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sala_Cantidad", "Asientos_ID_Asientos", "dbo.Asientos");
            DropIndex("dbo.Sala_Cantidad", new[] { "Asientos_ID_Asientos" });
            AddColumn("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            CreateIndex("dbo.Asientos", "Sala_Cantidad_ID_SCantidad");
            AddForeignKey("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
            DropColumn("dbo.Sala_Cantidad", "Asientos_ID_Asientos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sala_Cantidad", "Asientos_ID_Asientos", c => c.Int());
            DropForeignKey("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropIndex("dbo.Asientos", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropColumn("dbo.Asientos", "Sala_Cantidad_ID_SCantidad");
            CreateIndex("dbo.Sala_Cantidad", "Asientos_ID_Asientos");
            AddForeignKey("dbo.Sala_Cantidad", "Asientos_ID_Asientos", "dbo.Asientos", "ID_Asientos");
        }
    }
}
