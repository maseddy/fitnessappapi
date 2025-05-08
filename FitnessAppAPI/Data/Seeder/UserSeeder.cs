using FitnessAppAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace FitnessAppAPI.Data.Seeder
    {
    public static class UserSeeder
        {
        public static void SeedUsers(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<User>().HasData(
                new User
                    {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@fitness.com",
                    //PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    PasswordHash = "$2a$11$LLiVX3PdwodaRiGrUaw8ousvozP8RKLNBSl5BeV3AOlDS0WLlNpOy",
                    CreatedAt = new DateTime(2025, 5, 8, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "system",
                    CreateDate = new DateTime(2025, 5, 8, 0, 0, 0, DateTimeKind.Utc)
                    },
                new User
                    {
                    Id = 2,
                    Username = "trainer1",
                    Email = "trainer@fitness.com",
                    //PasswordHash = BCrypt.Net.BCrypt.HashPassword("Trainer@123"),
                    PasswordHash = "$2a$11$LLiVX3PdwodaRiGrUaw8ousvozP8RKLNBSl5BeV3AOlDS0WLlNpOy",
                    CreatedAt = new DateTime(2025, 5, 8, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "system",
                    CreateDate = new DateTime(2025, 5, 8, 0, 0, 0, DateTimeKind.Utc)
                    }
            );
            }
        }
    }
