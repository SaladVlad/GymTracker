using GymTrackerAPI.DTOs.Auth;
using GymTrackerAPI.Models;
using GymTrackerAPI.Repositories.Interfaces;
using GymTrackerAPI.Services.Interfaces;
using GymTrackerAPI.Utils;
using System.Diagnostics;

namespace GymTrackerAPI.Services
{

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtTokenGenerator _jwt;


        public AuthService(IUserRepository userRepo, JwtTokenGenerator jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }


        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetUserByUsernameAsync(dto.Username);
            if (user == null) return null;
            var valid = PasswordHasher.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt);
            if (!valid) return null;

            return _jwt.GenerateToken(user);
        }


        public async Task<string?> RegisterAsync(RegisterDto dto)
        {
            if(await _userRepo.UserExistsAsync(dto.Username))
            {
                return null;
            }
            PasswordHasher.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = hash,
                PasswordSalt = salt,
                Workouts = new List<Workout>()
            };

            await _userRepo.CreateUserAsync(user);
            return _jwt.GenerateToken(user);
        }


    }


}
