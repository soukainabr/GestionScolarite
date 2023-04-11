using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GestionScolarite.Models;

namespace GestionScolarite
{
    public class ScolariteDbContext : DbContext
    {
        public ScolariteDbContext() : base("name=GestionScolarite")
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Directeur> Directeurs { get; set; }

        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Affectation> Affectations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enseignant>()
                .HasMany(e => e.Matieres)
                .WithMany(m => m.Enseignants)
                .Map(em =>
                {
                    em.MapLeftKey("EnseignantId");
                    em.MapRightKey("MatiereId");
                    em.ToTable("EnseignantMatiere");
                });
        }
    }
   
}