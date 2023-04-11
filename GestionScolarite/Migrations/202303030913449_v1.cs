namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matieres", "Affectation_Id", "dbo.Affectations");
            DropIndex("dbo.Matieres", new[] { "Affectation_Id" });
            CreateTable(
                "dbo.MatiereEnseignants",
                c => new
                    {
                        Matiere_MatiereId = c.Int(nullable: false),
                        Enseignant_EnseignantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Matiere_MatiereId, t.Enseignant_EnseignantId })
                .ForeignKey("dbo.Matieres", t => t.Matiere_MatiereId, cascadeDelete: true)
                .ForeignKey("dbo.Enseignants", t => t.Enseignant_EnseignantId, cascadeDelete: true)
                .Index(t => t.Matiere_MatiereId)
                .Index(t => t.Enseignant_EnseignantId);
            
            AddColumn("dbo.Affectations", "Name", c => c.String());
            DropColumn("dbo.Affectations", "MatiereId");
            DropColumn("dbo.Affectations", "EnseignantId");
            DropColumn("dbo.Affectations", "selectedOptions");
            DropColumn("dbo.Matieres", "Affectation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matieres", "Affectation_Id", c => c.Int());
            AddColumn("dbo.Affectations", "selectedOptions", c => c.Boolean(nullable: false));
            AddColumn("dbo.Affectations", "EnseignantId", c => c.Int(nullable: false));
            AddColumn("dbo.Affectations", "MatiereId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MatiereEnseignants", "Enseignant_EnseignantId", "dbo.Enseignants");
            DropForeignKey("dbo.MatiereEnseignants", "Matiere_MatiereId", "dbo.Matieres");
            DropIndex("dbo.MatiereEnseignants", new[] { "Enseignant_EnseignantId" });
            DropIndex("dbo.MatiereEnseignants", new[] { "Matiere_MatiereId" });
            DropColumn("dbo.Affectations", "Name");
            DropTable("dbo.MatiereEnseignants");
            CreateIndex("dbo.Matieres", "Affectation_Id");
            AddForeignKey("dbo.Matieres", "Affectation_Id", "dbo.Affectations", "Id");
        }
    }
}
