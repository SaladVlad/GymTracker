using GymTrackerAPI.DTOs.Auth;
using GymTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return token == null ? BadRequest("User already exists") : Ok(new { token });
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            return token == null ? Unauthorized("Invalid credentials") : Ok(new { token });
        }
    }
}
