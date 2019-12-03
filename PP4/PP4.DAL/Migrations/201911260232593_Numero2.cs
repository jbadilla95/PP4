namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Numero2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Asientos", "Id_Sala_Id_Sala", "dbo.Salas");
            DropForeignKey("dbo.Salas", "Pelicula_Id_Pelicula", "dbo.Peliculas");
            DropForeignKey("dbo.Peliculas", new[] { "Horario_Id_horario", "Horario_ID_pelicula", "Horario_ID_sala" }, "dbo.Horarios");
            DropForeignKey("dbo.Horarios", "Compra_Id_Compra", "dbo.Compras");
            DropIndex("dbo.Asientos", new[] { "Id_Sala_Id_Sala" });
            DropIndex("dbo.Salas", new[] { "Pelicula_Id_Pelicula" });
            DropIndex("dbo.Horarios", new[] { "Compra_Id_Compra" });
            DropIndex("dbo.Peliculas", new[] { "Horario_Id_horario", "Horario_ID_pelicula", "Horario_ID_sala" });
            DropIndex("dbo.Personas", new[] { "Compra_Id_Compra" });
            DropPrimaryKey("dbo.Horarios");
            CreateTable(
                "dbo.Tandas",
                c => new
                    {
                        ID_tanda = c.Int(nullable: false, identity: true),
                        ID_sala = c.Int(nullable: false),
                        ID_horario = c.Int(nullable: false),
                        ID_pelicula = c.Int(nullable: false),
                        Compra_ID_Compra = c.Int(),
                    })
                .PrimaryKey(t => t.ID_tanda)
                .ForeignKey("dbo.Compras", t => t.Compra_ID_Compra)
                .Index(t => t.Compra_ID_Compra);
            
            AddColumn("dbo.Asientos", "Desc_Asientos", c => c.String());
            AddColumn("dbo.Asientos", "Precio", c => c.Int(nullable: false));
            AddColumn("dbo.Salas", "Desc_sala", c => c.String());
            AddColumn("dbo.Salas", "Tanda_ID_tanda", c => c.Int());
            AddColumn("dbo.Compras", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.Compras", "ID_tanda", c => c.Int(nullable: false));
            AddColumn("dbo.Compras", "Total_Pagar", c => c.Int(nullable: false));
            AddColumn("dbo.Compras", "ID_persona", c => c.Int(nullable: false));
            AddColumn("dbo.Horarios", "Hora_Inicial", c => c.Int(nullable: false));
            AddColumn("dbo.Horarios", "Hora_Final", c => c.Int(nullable: false));
            AddColumn("dbo.Horarios", "Tanda_ID_tanda", c => c.Int());
            AddColumn("dbo.Peliculas", "Descripcion_Pelicula", c => c.String());
            AddColumn("dbo.Peliculas", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Peliculas", "Tanda_ID_tanda", c => c.Int());
            AlterColumn("dbo.Horarios", "ID_Horario", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Horarios", "ID_Horario");
            CreateIndex("dbo.Personas", "Compra_ID_Compra");
            CreateIndex("dbo.Horarios", "Tanda_ID_tanda");
            CreateIndex("dbo.Peliculas", "Tanda_ID_tanda");
            CreateIndex("dbo.Salas", "Tanda_ID_tanda");
            AddForeignKey("dbo.Horarios", "Tanda_ID_tanda", "dbo.Tandas", "ID_tanda");
            AddForeignKey("dbo.Peliculas", "Tanda_ID_tanda", "dbo.Tandas", "ID_tanda");
            AddForeignKey("dbo.Salas", "Tanda_ID_tanda", "dbo.Tandas", "ID_tanda");
            DropColumn("dbo.Asientos", "numero");
            DropColumn("dbo.Asientos", "estado");
            DropColumn("dbo.Asientos", "Id_Sala_Id_Sala");
            DropColumn("dbo.Salas", "capacidad");
            DropColumn("dbo.Salas", "Estado");
            DropColumn("dbo.Salas", "Pelicula_Id_Pelicula");
            DropColumn("dbo.Horarios", "ID_pelicula");
            DropColumn("dbo.Horarios", "ID_sala");
            DropColumn("dbo.Horarios", "Hora");
            DropColumn("dbo.Horarios", "Dia");
            DropColumn("dbo.Horarios", "Compra_Id_Compra");
            DropColumn("dbo.Peliculas", "Titulo");
            DropColumn("dbo.Peliculas", "Precio");
            DropColumn("dbo.Peliculas", "Horario_Id_horario");
            DropColumn("dbo.Peliculas", "Horario_ID_pelicula");
            DropColumn("dbo.Peliculas", "Horario_ID_sala");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peliculas", "Horario_ID_sala", c => c.Int());
            AddColumn("dbo.Peliculas", "Horario_ID_pelicula", c => c.Int());
            AddColumn("dbo.Peliculas", "Horario_Id_horario", c => c.Int());
            AddColumn("dbo.Peliculas", "Precio", c => c.Int(nullable: false));
            AddColumn("dbo.Peliculas", "Titulo", c => c.String());
            AddColumn("dbo.Horarios", "Compra_Id_Compra", c => c.Int());
            AddColumn("dbo.Horarios", "Dia", c => c.DateTime(nullable: false));
            AddColumn("dbo.Horarios", "Hora", c => c.DateTime(nullable: false));
            AddColumn("dbo.Horarios", "ID_sala", c => c.Int(nullable: false));
            AddColumn("dbo.Horarios", "ID_pelicula", c => c.Int(nullable: false));
            AddColumn("dbo.Salas", "Pelicula_Id_Pelicula", c => c.Int());
            AddColumn("dbo.Salas", "Estado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Salas", "capacidad", c => c.Int(nullable: false));
            AddColumn("dbo.Asientos", "Id_Sala_Id_Sala", c => c.Int());
            AddColumn("dbo.Asientos", "estado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Asientos", "numero", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tandas", "Compra_ID_Compra", "dbo.Compras");
            DropForeignKey("dbo.Salas", "Tanda_ID_tanda", "dbo.Tandas");
            DropForeignKey("dbo.Peliculas", "Tanda_ID_tanda", "dbo.Tandas");
            DropForeignKey("dbo.Horarios", "Tanda_ID_tanda", "dbo.Tandas");
            DropIndex("dbo.Salas", new[] { "Tanda_ID_tanda" });
            DropIndex("dbo.Peliculas", new[] { "Tanda_ID_tanda" });
            DropIndex("dbo.Horarios", new[] { "Tanda_ID_tanda" });
            DropIndex("dbo.Tandas", new[] { "Compra_ID_Compra" });
            DropIndex("dbo.Personas", new[] { "Compra_ID_Compra" });
            DropPrimaryKey("dbo.Horarios");
            AlterColumn("dbo.Horarios", "ID_Horario", c => c.Int(nullable: false));
            DropColumn("dbo.Peliculas", "Tanda_ID_tanda");
            DropColumn("dbo.Peliculas", "Estado");
            DropColumn("dbo.Peliculas", "Descripcion_Pelicula");
            DropColumn("dbo.Horarios", "Tanda_ID_tanda");
            DropColumn("dbo.Horarios", "Hora_Final");
            DropColumn("dbo.Horarios", "Hora_Inicial");
            DropColumn("dbo.Compras", "ID_persona");
            DropColumn("dbo.Compras", "Total_Pagar");
            DropColumn("dbo.Compras", "ID_tanda");
            DropColumn("dbo.Compras", "Fecha");
            DropColumn("dbo.Salas", "Tanda_ID_tanda");
            DropColumn("dbo.Salas", "Desc_sala");
            DropColumn("dbo.Asientos", "Precio");
            DropColumn("dbo.Asientos", "Desc_Asientos");
            DropTable("dbo.Tandas");
            AddPrimaryKey("dbo.Horarios", new[] { "Id_horario", "ID_pelicula", "ID_sala" });
            CreateIndex("dbo.Personas", "Compra_Id_Compra");
            CreateIndex("dbo.Peliculas", new[] { "Horario_Id_horario", "Horario_ID_pelicula", "Horario_ID_sala" });
            CreateIndex("dbo.Horarios", "Compra_Id_Compra");
            CreateIndex("dbo.Salas", "Pelicula_Id_Pelicula");
            CreateIndex("dbo.Asientos", "Id_Sala_Id_Sala");
            AddForeignKey("dbo.Horarios", "Compra_Id_Compra", "dbo.Compras", "Id_Compra");
            AddForeignKey("dbo.Peliculas", new[] { "Horario_Id_horario", "Horario_ID_pelicula", "Horario_ID_sala" }, "dbo.Horarios", new[] { "Id_horario", "ID_pelicula", "ID_sala" });
            AddForeignKey("dbo.Salas", "Pelicula_Id_Pelicula", "dbo.Peliculas", "Id_Pelicula");
            AddForeignKey("dbo.Asientos", "Id_Sala_Id_Sala", "dbo.Salas", "Id_Sala");
        }
    }
}
