using GymTrackerAPI.Models;

namespace GymTrackerAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> UserExistsAsync(string username);
        Task CreateUserAsync(User user);
    }
}
