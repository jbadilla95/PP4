namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Propuesta1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asientos",
                c => new
                    {
                        Id_asientos = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                        Id_Sala_Id_Sala = c.Int(),
                    })
                .PrimaryKey(t => t.Id_asientos)
                .ForeignKey("dbo.Salas", t => t.Id_Sala_Id_Sala)
                .Index(t => t.Id_Sala_Id_Sala);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id_Sala = c.Int(nullable: false, identity: true),
                        capacidad = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Pelicula_Id_Pelicula = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Sala)
                .ForeignKey("dbo.Peliculas", t => t.Pelicula_Id_Pelicula)
                .Index(t => t.Pelicula_Id_Pelicula);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id_Compra = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id_Compra);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        Id_horario = c.Int(nullable: false),
                        ID_pelicula = c.Int(nullable: false),
                        ID_sala = c.Int(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Dia = c.DateTime(nullable: false),
                        Compra_Id_Compra = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id_horario, t.ID_pelicula, t.ID_sala })
                .ForeignKey("dbo.Compras", t => t.Compra_Id_Compra)
                .Index(t => t.Compra_Id_Compra);
            
            CreateTable(
                "dbo.Peliculas",
                c => new
                    {
                        Id_Pelicula = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Duracion = c.Int(nullable: false),
                        Precio = c.Int(nullable: false),
                        Horario_Id_horario = c.Int(),
                        Horario_ID_pelicula = c.Int(),
                        Horario_ID_sala = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Pelicula)
                .ForeignKey("dbo.Horarios", t => new { t.Horario_Id_horario, t.Horario_ID_pelicula, t.Horario_ID_sala })
                .Index(t => new { t.Horario_Id_horario, t.Horario_ID_pelicula, t.Horario_ID_sala });
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id_Persona = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Cedula = c.Int(nullable: false),
                        correo = c.String(),
                        contraseña = c.String(),
                        tipo_perfil = c.Boolean(nullable: false),
                        Compra_Id_Compra = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Persona)
                .ForeignKey("dbo.Compras", t => t.Compra_Id_Compra)
                .Index(t => t.Compra_Id_Compra);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personas", "Compra_Id_Compra", "dbo.Compras");
            DropForeignKey("dbo.Horarios", "Compra_Id_Compra", "dbo.Compras");
            DropForeignKey("dbo.Peliculas", new[] { "Horario_Id_horario", "Horario_ID_pelicula", "Horario_ID_sala" }, "dbo.Horarios");
            DropForeignKey("dbo.Salas", "Pelicula_Id_Pelicula", "dbo.Peliculas");
            DropForeignKey("dbo.Asientos", "Id_Sala_Id_Sala", "dbo.Salas");
            DropIndex("dbo.Personas", new[] { "Compra_Id_Compra" });
            DropIndex("dbo.Peliculas", new[] { "Horario_Id_horario", "Horario_ID_pelicula", "Horario_ID_sala" });
            DropIndex("dbo.Horarios", new[] { "Compra_Id_Compra" });
            DropIndex("dbo.Salas", new[] { "Pelicula_Id_Pelicula" });
            DropIndex("dbo.Asientos", new[] { "Id_Sala_Id_Sala" });
            DropTable("dbo.Personas");
            DropTable("dbo.Peliculas");
            DropTable("dbo.Horarios");
            DropTable("dbo.Compras");
            DropTable("dbo.Salas");
            DropTable("dbo.Asientos");
        }
    }
}
