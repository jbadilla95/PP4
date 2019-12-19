namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2512 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compras", "Descripcion_peli", c => c.String());
            AddColumn("dbo.Compras", "ID_sala", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compras", "ID_sala");
            DropColumn("dbo.Compras", "Descripcion_peli");
        }
    }
}
