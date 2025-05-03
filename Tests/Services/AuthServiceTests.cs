using GymTrackerAPI.DTOs.Auth;
using GymTrackerAPI.Models;
using GymTrackerAPI.Repositories.Interfaces;
using GymTrackerAPI.Services;
using GymTrackerAPI.Utils.Interfaces;
using Moq;
using NUnit.Framework;

namespace GymTrackerAPI.Tests.Services
{
    [TestFixture]
    public class AuthServiceTests
    {
        private Mock<IUserRepository>? _userRepoMock;
        private Mock<IJwtTokenGenerator>? _jwtMock;
        private Mock<IPasswordHasher>? _hasherMock;
        private AuthService? _authService;

        [SetUp]
        public void Setup()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _jwtMock = new Mock<IJwtTokenGenerator>();
            _hasherMock = new Mock<IPasswordHasher>();
            _authService = new AuthService(_userRepoMock.Object, _jwtMock.Object, _hasherMock.Object);


        }

        [Test]
        public async Task RegisterAsync_ShouldReturnToken_WhenUserIsNew()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                Username = "testuser",
                Password = "password"
            };

            _userRepoMock.Setup(r => r.UserExistsAsync("testuser")).ReturnsAsync(false);
            _jwtMock.Setup(j => j.GenerateToken(It.IsAny<User>())).Returns("fake-jwt-token");

            // Act
            var result = await _authService.RegisterAsync(registerDto);

            // Assert
            Assert.That(result, Is.EqualTo("fake-jwt-token"));
            _userRepoMock.Verify(r => r.CreateUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public async Task RegisterAsync_ShouldReturnNull_WhenUserExists()
        {
            _userRepoMock.Setup(r => r.UserExistsAsync("existing")).ReturnsAsync(true);
            var result = await _authService.RegisterAsync(new RegisterDto { Username = "existing", Password = "pw" });
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public async Task LoginAsync_ShouldReturnToken_WhenCredentialsAreCorrect()
        {
            var loginDto = new LoginDto { Username = "test", Password = "password" };
            var user = new User
            {
                Username = "test",
                PasswordHash = new byte[0],
                PasswordSalt = new byte[0],
                Workouts = new List<Workout>()
            };

            _userRepoMock.Setup(r => r.GetUserByUsernameAsync("test")).ReturnsAsync(user);
            _jwtMock.Setup(j => j.GenerateToken(user)).Returns("jwt-token");

            _hasherMock.Setup(h => h.VerifyPasswordHash("password", It.IsAny<byte[]>(), It.IsAny<byte[]>())).Returns(true);


            var result = await _authService.LoginAsync(loginDto);
            Assert.That(result, Is.EqualTo("jwt-token"));
        }

        [Test]
        public async Task RemoveUserAsync_ShouldReturnFalse_WhenUserNotFound()
        {
            var userId = Guid.NewGuid();
            _userRepoMock.Setup(r => r.GetUserByUsernameAsync(userId.ToString())).ReturnsAsync((User)null);

            var result = await _authService.RemoveUserAsync(userId);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task RemoveUserAsync_ShouldCallRemoveUserAsync_WhenUserFound()
        {
            var userId = Guid.NewGuid();

            _userRepoMock.Setup(r => r.GetUserByUsernameAsync(userId.ToString()));
            _userRepoMock.Setup(r => r.RemoveUserAsync(userId)).ReturnsAsync(true);

            var result = await _authService.RemoveUserAsync(userId);
            Assert.That(result.Value, Is.EqualTo(true));
        }

        [TearDown]
        public void Cleanup()
        {
            _userRepoMock.Reset();
            _jwtMock.Reset();
        }
    }
}
