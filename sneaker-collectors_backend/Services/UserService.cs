using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(User user)
        {
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
        }

        public async Task<User> GetAsync(string id)
        {
            if(UserExists(id))
            {
                return await _database.Users.FindAsync(id);
            }
            return null;
        }

        public async Task<User> GetAsync(string id, string login)
        {
            if (UserExists(id))
                return await _database.Users.FirstOrDefaultAsync(u => u.Id == id && u.Login == login);
            return null;
        }



        // Проверка, есть ли пользователь с данным id в бд
        public bool UserExists(string id)
        {
            return _database.Users.Any(u => u.Id == id);
        }

        // Проверка, есть ли уже пользователь с таким Login
        public bool LoginIsTaken(string login)
        {
            if(_database.Users.Any(u => u.Login == login))
                return true;
            return false;
        }

        // Проверка, есть ли уже пользователь с таким Email
        public bool EmailIsTaken(string email)
        {
            if (_database.Users.Any(u => u.Email == email))
                return true;
            return false;
        }

    }
}
