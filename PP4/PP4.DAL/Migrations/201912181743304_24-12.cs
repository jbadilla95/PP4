namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2412 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropIndex("dbo.Peliculas", new[] { "Sala_Cantidad_ID_SCantidad" });
            AddColumn("dbo.Sala_Cantidad", "ID_pelicula", c => c.Int(nullable: false));
            DropColumn("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            DropColumn("dbo.Sala_Cantidad", "ID_pelicula");
            CreateIndex("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad");
            AddForeignKey("dbo.Peliculas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
        }
    }
}
