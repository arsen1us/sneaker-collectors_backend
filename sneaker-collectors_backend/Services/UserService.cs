using sneaker_collectors_backend;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models.Database;

namespace sneaker_collectors_backend.Services
{
    public class UserService : IUserService
    {
        SneakerCollectorsContext _database;

        public UserService(SneakerCollectorsContext database)
        {
            _database = database;
        }

        public async Task AddAsync(RegUser regUser)
        {
            var user = new User
            {
                Id =  Guid.NewGuid().ToString(),
                Login = regUser.Login,
                Email = regUser.Email,
                Password = regUser.Password,
            };

            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(string userId)
        {
            if(UserExists(userId))
            {
                return await _database.Users.FindAsync(userId);
            }
            return null;
        }

        public bool UserExists(string userId)
        {
            return _database.Users.Any(u => u.Id == userId);
        }
    }
}
