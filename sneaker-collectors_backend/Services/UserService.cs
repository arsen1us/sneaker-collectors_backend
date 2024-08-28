using Microsoft.EntityFrameworkCore;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models;

namespace sneaker_collectors_backend.Services
{
    //public class UserService : IUserService
    //{
    //    SneakerCollectorsContext _database;

    //    public UserService(SneakerCollectorsContext database)
    //    {
    //        _database = database;
    //    }

    //    public async Task AddAsync(User user)
    //    {
    //        await _database.Users.AddAsync(user);
    //        await _database.SaveChangesAsync();
    //    }
    //    // Получить пользователя по id

    //    public async Task<User> GetAsync(string id)
    //    {
    //        if (UserExists(id))
    //        {
    //            return await _database.Users.FindAsync(id);
    //        }
    //        return null;
    //    }
    //    // Получить пользователя по id и login

    //    public async Task<User> GetAsync(string id, string login)
    //    {
    //        if (UserExists(id))
    //        {
    //            var user = await _database.Users.FirstOrDefaultAsync(u => u.Id == id && u.Login == login);
    //            return user;
    //        }
    //        return null;
    //    }
    //    // Получить пользователя по login/email и password

    //    public async Task<User> GetAsync(AuthUser authUser)
    //    {
    //        return await _database.Users.FirstOrDefaultAsync(u => (u.Email == authUser.LoginOrEmail || u.Login == authUser.LoginOrEmail) && u.Password == authUser.Password);
    //    }

    //    // Проверка, есть ли пользователь с данным id в бд

    //    public bool UserExists(string id)
    //    {
    //        return _database.Users.Any(u => u.Id == id);
    //    }
    //    // Проверка, есть ли пользователь с данным email или login

    //    public async Task<bool> UserExists(AuthUser authUser)
    //    {
    //        if (await _database.Users.AnyAsync(u => (u.Login == authUser.LoginOrEmail || u.Email == authUser.LoginOrEmail) && u.Password == authUser.Password))
    //            return true;
    //        return false;
    //    }

    //    // Проверка, есть ли уже пользователь с таким Login

    //    public bool LoginIsTaken(string login)
    //    {
    //        if (_database.Users.Any(u => u.Login == login))
    //            return true;
    //        return false;
    //    }
    //    // Проверка, есть ли уже пользователь с таким Email

    //    public bool EmailIsTaken(string email)
    //    {
    //        if (_database.Users.Any(u => u.Email == email))
    //            return true;
    //        return false;
    //    }

    //}
}
