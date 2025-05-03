namespace GymTrackerAPI.Utils.Interfaces
{
    public interface IPasswordHasher
    {
        bool VerifyPasswordHash(string password, byte[] hash, byte[] salt);
        void CreatePasswordHash(string password, out byte[] hash, out byte[] salt);
    }

}
