namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Matieres", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matieres", "IsSelected", c => c.Boolean(nullable: false));
        }
    }
}
