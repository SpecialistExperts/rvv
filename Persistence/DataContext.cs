using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Owner> Values {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Owner>().HasData(
                new Owner { Id = 5, Name = "naam1", Adress = "Adres1", Email = "Email1", VacationAdress = "Vakantieadres1", PhoneNumber = "telefoonnummer1", ValidInfo = true, created_at = DateTime.Now, updated_at = DateTime.Now},
                new Owner { Id = 6, Name = "naam2", Adress = "Adres2", Email = "Email2", VacationAdress = "Vakantieadres2", PhoneNumber = "telefoonnummer2", ValidInfo = true, created_at = DateTime.Now, updated_at = DateTime.Now}
            );
        }
    }
}
