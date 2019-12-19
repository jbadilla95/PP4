namespace PP4.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3012 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sala_Cantidad", "ID_pelicula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sala_Cantidad", "ID_pelicula", c => c.Int(nullable: false));
        }
    }
}
