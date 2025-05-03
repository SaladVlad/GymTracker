using GymTrackerAPI.DTOs.Auth;

namespace GymTrackerAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);

        Task<bool?> RemoveUserAsync(Guid userId);

    }
}
