using GymTrackerAPI.Utils.Interfaces;

namespace GymTrackerAPI.Utils.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        public bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
            => PasswordHasher.VerifyPasswordHash(password, hash, salt);

        public void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
            => PasswordHasher.CreatePasswordHash(password, out hash, out salt);
    }

}
