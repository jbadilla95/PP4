namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peliculas", "ID_sala", c => c.Int(nullable: false));
            AddColumn("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            CreateIndex("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad");
            AddForeignKey("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropIndex("dbo.Peliculas", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropColumn("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad");
            DropColumn("dbo.Peliculas", "ID_sala");
        }
    }
}
