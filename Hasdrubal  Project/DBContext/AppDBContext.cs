
using Hasdrubal__Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hasdrubal__Project.DBConnection
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Oeuvre>()
                .HasOne<Artiste>(s => s.Artiste)
                .WithMany(g => g.Oeuvres)
                .HasForeignKey(s => s.ArtisteId).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Image>()
                .HasOne<Oeuvre>(s => s.Oeuvre)
                .WithMany(g => g.Images)
                .HasForeignKey(s => s.OeuvreId).OnDelete(DeleteBehavior.Restrict); ;
            // configures one-to-one relationship
            modelBuilder.Entity<Oeuvre>()
               .HasOne(s => s.Acquisation) // Mark Address property optional in Student entity
               .WithOne(ad => ad.Oeuvre) // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
               .HasForeignKey<Acquisation>(ad => ad.Id).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Oeuvre>()
               .HasOne(s => s.Bibliographie) 
               .WithOne(ad => ad.Oeuvre)
               .HasForeignKey<Bibliographie>(ad => ad.Id).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Oeuvre>()
               .HasOne(s => s.ConservationLocation)
               .WithOne(ad => ad.Oeuvre)
               .HasForeignKey<ConservationLocation>(ad => ad.Id).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Oeuvre>()
               .HasOne(s => s.Redaction)
               .WithOne(ad => ad.Oeuvre)
               .HasForeignKey<Redaction>(ad => ad.Id).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Oeuvre>()
               .HasOne(s => s.Restauration)
               .WithOne(ad => ad.Oeuvre)
               .HasForeignKey<Restauration>(ad => ad.Id).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Oeuvre>()
               .HasOne(s => s.Signature)
               .WithOne(ad => ad.Oeuvre)
               .HasForeignKey<Signature>(ad => ad.Id).OnDelete(DeleteBehavior.Restrict); ;
            // configures many-to-many relationship
            modelBuilder.Entity<Pret>()
            .HasOne<Oeuvre>(sc => sc.Oeuvre)
            .WithMany(s => s.Prets)
            .HasForeignKey(sc => sc.OeuvreId).OnDelete(DeleteBehavior.Restrict); ;


             modelBuilder.Entity<Pret>()
             .HasOne<Exposition>(sc => sc.Exposition)
             .WithMany(s => s.Prets)
              .HasForeignKey(sc => sc.ExpositionId).OnDelete(DeleteBehavior.Restrict); ; 
        }
        public DbSet<Oeuvre> Oeuvres { get; set; }
        public DbSet<Artiste> Artistes { get; set; }
        public DbSet<Acquisation> Acquisations { get; set; }
        public DbSet<Bibliographie> Bibliographies { get; set; }
        public DbSet<ConservationLocation> ConservationLocations { get; set; }
        public DbSet<Exposition> Expositions { get; set; }
        public DbSet<Pret> Prets { get; set; }
        public DbSet<Redaction> Redactions { get; set; }
        public DbSet<Restauration> Restaurations { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
