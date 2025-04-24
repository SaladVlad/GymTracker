using GymTrackerAPI.Models;
using GymTrackerAPI.Utils;

namespace GymTrackerAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                PasswordHasher.CreatePasswordHash("password", out var hash, out var salt);
                var user = new User {
                    Username = "demo" ,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    Workouts = new List<Workout>()
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
