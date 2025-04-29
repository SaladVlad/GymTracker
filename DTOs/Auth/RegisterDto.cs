using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required, MinLength(6), MaxLength(20)]
        public string Password { get; set; } = string.Empty;
    }
}
