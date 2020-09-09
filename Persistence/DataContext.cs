using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Gemeente> Gemeentes {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .HasOne(a => a.Owner)
                .WithMany(b => b.Registrations)
                .HasForeignKey(a => a.OwnerId);

            modelBuilder.Entity<Gemeente>().HasData(
                new Gemeente { Id = 1, Code = "0503", GemeenteNaam = "Delft" },
                new Gemeente { Id = 2, Code = "0599", GemeenteNaam = "Rotterdam" }
            );   
        }
    }
}

