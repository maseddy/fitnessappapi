using Microsoft.EntityFrameworkCore;

namespace FitnessAppAPI.Data.Seeder
    {
    public static class MainSeeder
        {
        public static void SeedAll(ModelBuilder modelBuilder)
            {
                // Execute all individual seeders
                UserSeeder.SeedUsers(modelBuilder);

            }
        }
    }
