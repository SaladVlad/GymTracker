using GymTrackerAPI.Models;

namespace GymTrackerAPI.Utils.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
