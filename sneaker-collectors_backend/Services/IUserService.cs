using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models.Database;

namespace sneaker_collectors_backend.Services
{
    public interface IUserService
    {
        public Task<User> GetByIdAsync(string userId);
        public Task AddAsync(RegUser user);
        public bool UserExists(string userId);
    }
}
