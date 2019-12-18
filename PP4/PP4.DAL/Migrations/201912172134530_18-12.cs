namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1812 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tandas", "ID_horario", "dbo.Horarios");
            DropIndex("dbo.Tandas", new[] { "ID_horario" });
            AddColumn("dbo.Peliculas", "horario", c => c.Int(nullable: false));
            DropColumn("dbo.Tandas", "ID_horario");
            DropTable("dbo.Horarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        ID_Horario = c.Int(nullable: false, identity: true),
                        Hora_Inicial = c.Int(nullable: false),
                        Hora_Final = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Horario);
            
            AddColumn("dbo.Tandas", "ID_horario", c => c.Int(nullable: false));
            DropColumn("dbo.Peliculas", "horario");
            CreateIndex("dbo.Tandas", "ID_horario");
            AddForeignKey("dbo.Tandas", "ID_horario", "dbo.Horarios", "ID_Horario", cascadeDelete: true);
        }
    }
}
