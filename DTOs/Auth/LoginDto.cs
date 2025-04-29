using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        public required string Username { get; set; } = string.Empty;
        [Required, MinLength(6), MaxLength(20)]
        public required string Password { get; set; } = string.Empty;
    }
}
