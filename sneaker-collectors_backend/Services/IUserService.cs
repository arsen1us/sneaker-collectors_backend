using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models.Database;

namespace sneaker_collectors_backend.Services
{
    public interface IUserService
    {
        public Task<User> GetAsync(string id);
        public Task<User> GetAsync(string id, string login);
        public Task AddAsync(User user);
        public bool UserExists(string userId);
        public bool LoginIsTaken(string login);
        public bool EmailIsTaken(string email);
    }
}
