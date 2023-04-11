namespace GestionScolarite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MatiereEnseignants", newName: "EnseignantMatiere");
            RenameColumn(table: "dbo.EnseignantMatiere", name: "Matiere_MatiereId", newName: "MatiereId");
            RenameColumn(table: "dbo.EnseignantMatiere", name: "Enseignant_EnseignantId", newName: "EnseignantId");
            RenameIndex(table: "dbo.EnseignantMatiere", name: "IX_Enseignant_EnseignantId", newName: "IX_EnseignantId");
            RenameIndex(table: "dbo.EnseignantMatiere", name: "IX_Matiere_MatiereId", newName: "IX_MatiereId");
            DropPrimaryKey("dbo.EnseignantMatiere");
            AddPrimaryKey("dbo.EnseignantMatiere", new[] { "EnseignantId", "MatiereId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EnseignantMatiere");
            AddPrimaryKey("dbo.EnseignantMatiere", new[] { "Matiere_MatiereId", "Enseignant_EnseignantId" });
            RenameIndex(table: "dbo.EnseignantMatiere", name: "IX_MatiereId", newName: "IX_Matiere_MatiereId");
            RenameIndex(table: "dbo.EnseignantMatiere", name: "IX_EnseignantId", newName: "IX_Enseignant_EnseignantId");
            RenameColumn(table: "dbo.EnseignantMatiere", name: "EnseignantId", newName: "Enseignant_EnseignantId");
            RenameColumn(table: "dbo.EnseignantMatiere", name: "MatiereId", newName: "Matiere_MatiereId");
            RenameTable(name: "dbo.EnseignantMatiere", newName: "MatiereEnseignants");
        }
    }
}
