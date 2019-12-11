namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioBD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Horarios", "Tanda_ID_tanda", "dbo.Tandas");
            DropForeignKey("dbo.Peliculas", "Tanda_ID_tanda", "dbo.Tandas");
            DropForeignKey("dbo.Salas", "Tanda_ID_tanda", "dbo.Tandas");
            DropIndex("dbo.Horarios", new[] { "Tanda_ID_tanda" });
            DropIndex("dbo.Peliculas", new[] { "Tanda_ID_tanda" });
            DropIndex("dbo.Salas", new[] { "Tanda_ID_tanda" });
            AddColumn("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            CreateIndex("dbo.Tandas", "ID_horario");
            CreateIndex("dbo.Tandas", "ID_pelicula");
            CreateIndex("dbo.Tandas", "Sala_Cantidad_ID_SCantidad");
            AddForeignKey("dbo.Tandas", "ID_horario", "dbo.Horarios", "ID_Horario", cascadeDelete: true);
            AddForeignKey("dbo.Tandas", "ID_pelicula", "dbo.Peliculas", "ID_Pelicula", cascadeDelete: true);
            AddForeignKey("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
            DropColumn("dbo.Horarios", "Tanda_ID_tanda");
            DropColumn("dbo.Peliculas", "Tanda_ID_tanda");
            DropColumn("dbo.Salas", "Tanda_ID_tanda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salas", "Tanda_ID_tanda", c => c.Int());
            AddColumn("dbo.Peliculas", "Tanda_ID_tanda", c => c.Int());
            AddColumn("dbo.Horarios", "Tanda_ID_tanda", c => c.Int());
            DropForeignKey("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropForeignKey("dbo.Tandas", "ID_pelicula", "dbo.Peliculas");
            DropForeignKey("dbo.Tandas", "ID_horario", "dbo.Horarios");
            DropIndex("dbo.Tandas", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropIndex("dbo.Tandas", new[] { "ID_pelicula" });
            DropIndex("dbo.Tandas", new[] { "ID_horario" });
            DropColumn("dbo.Tandas", "Sala_Cantidad_ID_SCantidad");
            CreateIndex("dbo.Salas", "Tanda_ID_tanda");
            CreateIndex("dbo.Peliculas", "Tanda_ID_tanda");
            CreateIndex("dbo.Horarios", "Tanda_ID_tanda");
            AddForeignKey("dbo.Salas", "Tanda_ID_tanda", "dbo.Tandas", "ID_tanda");
            AddForeignKey("dbo.Peliculas", "Tanda_ID_tanda", "dbo.Tandas", "ID_tanda");
            AddForeignKey("dbo.Horarios", "Tanda_ID_tanda", "dbo.Tandas", "ID_tanda");
        }
    }
}
