using GymTrackerAPI.DTOs.Auth;
using GymTrackerAPI.Models;

namespace GymTrackerAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);

    }
}
