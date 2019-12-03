namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Numero3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sala_Cantidad",
                c => new
                    {
                        ID_SCantidad = c.Int(nullable: false, identity: true),
                        ID_Sala = c.Int(nullable: false),
                        ID_Asiento = c.Int(nullable: false),
                        Cantidad_total = c.Int(nullable: false),
                        Cantidad_disponible = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_SCantidad);
            
            AddColumn("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            AddColumn("dbo.Salas", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            CreateIndex("dbo.Asientos", "Sala_Cantidad_ID_SCantidad");
            CreateIndex("dbo.Salas", "Sala_Cantidad_ID_SCantidad");
            AddForeignKey("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
            AddForeignKey("dbo.Salas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropForeignKey("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropIndex("dbo.Salas", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropIndex("dbo.Asientos", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropColumn("dbo.Salas", "Sala_Cantidad_ID_SCantidad");
            DropColumn("dbo.Asientos", "Sala_Cantidad_ID_SCantidad");
            DropTable("dbo.Sala_Cantidad");
        }
    }
}
