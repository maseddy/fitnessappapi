namespace FitnessAppAPI.Models
{
        public class User
        {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Token-related fields
        public string? RefreshToken { get; set; }  // stored token
        public DateTime? RefreshTokenExpiryTime { get; set; }

        //Audit
        // New audit fields
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        }
    }
