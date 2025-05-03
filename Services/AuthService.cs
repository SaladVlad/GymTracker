using GymTrackerAPI.DTOs.Auth;
using GymTrackerAPI.Models;
using GymTrackerAPI.Repositories.Interfaces;
using GymTrackerAPI.Services.Interfaces;
using GymTrackerAPI.Utils.Interfaces;
using GymTrackerAPI.Utils.Services;
using System.Diagnostics;

namespace GymTrackerAPI.Services
{

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenGenerator _jwt;


        public AuthService(IUserRepository userRepo, IJwtTokenGenerator jwt, IPasswordHasher hasher)
        {
            _userRepo = userRepo;
            _jwt = jwt;
            _hasher = hasher;
        }


        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetUserByUsernameAsync(dto.Username);
            if (user == null) return null;
            var valid = _hasher.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt);
            if (!valid) return null;

            return _jwt.GenerateToken(user);
        }


        public async Task<string?> RegisterAsync(RegisterDto dto)
        {
            if(await _userRepo.UserExistsAsync(dto.Username))
            {
                return null;
            }
            _hasher.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = hash,
                PasswordSalt = salt,
                Workouts = []
            };

            await _userRepo.CreateUserAsync(user);
            return _jwt.GenerateToken(user);
        }

        public async Task<bool?> RemoveUserAsync(Guid userId)
        {
            var user = _userRepo.GetUserByUsernameAsync(userId.ToString());
            if (user == null) return null;
            var result = await _userRepo.RemoveUserAsync(userId);
            return result;

        }
    }
}
