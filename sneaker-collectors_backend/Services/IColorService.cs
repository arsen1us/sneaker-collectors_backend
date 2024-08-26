using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using sneaker_collectors_backend.Models.Database;

namespace sneaker_collectors_backend.Services
{
    public interface IColorService : IService<SneakerColor>
    {
        public Task AddAsync(SneakerColor color);

        public Task<SneakerColor> GetByIdAsync(string id);

        public Task<List<SneakerColor>> GetAllAsync();

        public Task RemoveAsync(string id);

        public Task UpdateAsync(SneakerColor color);

        public Task<bool> IsExists(string id);
    }
}
