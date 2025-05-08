using FitnessAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using FitnessAppAPI.Data.Seeder;

namespace FitnessAppAPI.Data
    {
    public class AppDbContext : DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                //apply seeder
                MainSeeder.SeedAll(modelBuilder);
            }
        }
    }
