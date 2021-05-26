using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJS_AspNetCoreWebAPI.Repository
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=personsdb;Trusted_Connection=True;");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=personsdb;Username=postgres;");

        }
    }
}
