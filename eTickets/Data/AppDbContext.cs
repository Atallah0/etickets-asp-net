using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors_Movies>().HasKey(am => new
            {
                am.actorId,
                am.movieId
            });

            modelBuilder.Entity<Actors_Movies>().HasOne(m => m.movies).WithMany(am => am.actors_Movies).HasForeignKey(m => m.movieId);
            modelBuilder.Entity<Actors_Movies>().HasOne(a => a.actors).WithMany(am => am.actors_Movies).HasForeignKey(a => a.actorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actors_Movies> Actors_Movies { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<Producers> Producers { get; set; }

        //Orders related tables
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersItems> OrdersItems { get; set; }
        public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
    }
}