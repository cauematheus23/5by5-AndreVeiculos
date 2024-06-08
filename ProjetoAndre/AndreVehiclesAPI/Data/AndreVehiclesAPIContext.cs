using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesAPI.Data
{
    public class AndreVehiclesAPIContext : DbContext
    {
        public AndreVehiclesAPIContext (DbContextOptions<AndreVehiclesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
        public DbSet<Models.Person> Person { get; set; } = default!;
        public DbSet<Models.Employee> Employee { get; set; } = default!;
        public DbSet<Models.Client> Client { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Person>().ToTable("Person");
            modelBuilder.Entity<Models.Client>().ToTable("Client");
            modelBuilder.Entity<Models.Employee>().ToTable("Employee");
            modelBuilder.Entity<Models.Person>().HasKey(p => p.Document);
        }

        public DbSet<Models.Adress>? Adress { get; set; }

        public DbSet<Models.Boleto>? Boleto { get; set; }

        public DbSet<Models.Card>? Card { get; set; }

        public DbSet<Models.CarJob>? CarJob { get; set; }

        public DbSet<Models.Job>? Job { get; set; }

        public DbSet<Models.Payment>? Payment { get; set; }

        public DbSet<Models.Pix>? Pix { get; set; }

        public DbSet<Models.PixType>? PixType { get; set; }

        public DbSet<Models.Position>? Position { get; set; }

        public DbSet<Models.Purchase>? Purchase { get; set; }

        public DbSet<Models.Sale>? Sale { get; set; }

    }
}
