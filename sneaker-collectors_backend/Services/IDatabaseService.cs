using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models.Database;
using Microsoft.AspNetCore.JsonPatch;

namespace sneaker_collectors_backend.Services
{
    public interface IDatabaseService<T> where T : class
    {
        public Task AddAsync(T obj);

        public Task<T> GetByIdAsync(string id);

        public Task<List<T>> GetAllAsync();

        public Task RemoveAsync(string id);

        public Task UpdateAsync(T obj);

        public Task<bool> IsExists(string id);
    }
}
