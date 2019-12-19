namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1912 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sala_Cantidad", "ID_Sala", "dbo.Salas");
            DropIndex("dbo.Sala_Cantidad", new[] { "ID_Sala" });
            DropColumn("dbo.Sala_Cantidad", "ID_Sala");
            DropTable("dbo.Salas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        ID_Sala = c.Int(nullable: false, identity: true),
                        Desc_sala = c.String(),
                    })
                .PrimaryKey(t => t.ID_Sala);
            
            AddColumn("dbo.Sala_Cantidad", "ID_Sala", c => c.Int(nullable: false));
            CreateIndex("dbo.Sala_Cantidad", "ID_Sala");
            AddForeignKey("dbo.Sala_Cantidad", "ID_Sala", "dbo.Salas", "ID_Sala", cascadeDelete: true);
        }
    }
}
