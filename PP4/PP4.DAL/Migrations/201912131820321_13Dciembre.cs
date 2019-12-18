namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13Dciembre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropForeignKey("dbo.Salas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropForeignKey("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad");
            DropIndex("dbo.Asientos", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropIndex("dbo.Tandas", new[] { "Sala_Cantidad_ID_SCantidad" });
            DropIndex("dbo.Salas", new[] { "Sala_Cantidad_ID_SCantidad" });
            AddColumn("dbo.Sala_Cantidad", "Asientos_ID_Asientos", c => c.Int());
            CreateIndex("dbo.Sala_Cantidad", "ID_Sala");
            CreateIndex("dbo.Sala_Cantidad", "Asientos_ID_Asientos");
            AddForeignKey("dbo.Sala_Cantidad", "Asientos_ID_Asientos", "dbo.Asientos", "ID_Asientos");
            AddForeignKey("dbo.Sala_Cantidad", "ID_Sala", "dbo.Salas", "ID_Sala", cascadeDelete: true);
            DropColumn("dbo.Asientos", "Sala_Cantidad_ID_SCantidad");
            DropColumn("dbo.Tandas", "Sala_Cantidad_ID_SCantidad");
            DropColumn("dbo.Salas", "Sala_Cantidad_ID_SCantidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salas", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            AddColumn("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            AddColumn("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", c => c.Int());
            DropForeignKey("dbo.Sala_Cantidad", "ID_Sala", "dbo.Salas");
            DropForeignKey("dbo.Sala_Cantidad", "Asientos_ID_Asientos", "dbo.Asientos");
            DropIndex("dbo.Sala_Cantidad", new[] { "Asientos_ID_Asientos" });
            DropIndex("dbo.Sala_Cantidad", new[] { "ID_Sala" });
            DropColumn("dbo.Sala_Cantidad", "Asientos_ID_Asientos");
            CreateIndex("dbo.Salas", "Sala_Cantidad_ID_SCantidad");
            CreateIndex("dbo.Tandas", "Sala_Cantidad_ID_SCantidad");
            CreateIndex("dbo.Asientos", "Sala_Cantidad_ID_SCantidad");
            AddForeignKey("dbo.Tandas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
            AddForeignKey("dbo.Salas", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
            AddForeignKey("dbo.Asientos", "Sala_Cantidad_ID_SCantidad", "dbo.Sala_Cantidad", "ID_SCantidad");
        }
    }
}
