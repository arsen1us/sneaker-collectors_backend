using Microsoft.EntityFrameworkCore;
using sneaker_collectors_backend.Models.Database;
using System.Drawing;

namespace sneaker_collectors_backend.Services
{
    public class TechnologyService : ITechnologyService
    {
        SneakerCollectorsContext _database;

        public TechnologyService(SneakerCollectorsContext database)
        {
            _database = database;
        }
        // Получить все технологии

        public async Task AddAsync(SneakerTechnology technology)
        {
            await _database.SneakerTechnologies.AddAsync(technology);
            await _database.SaveChangesAsync();
        }

        public async Task<List<SneakerTechnology>> GetAllAsync()
        {
            var allTechnology = await _database.SneakerTechnologies.ToListAsync();
            return allTechnology;
        }
        // Получить технологию по id

        public async Task<SneakerTechnology> GetByIdAsync(string id)
        {
            if (await IsExists(id))
            {
                var technology = await _database.SneakerTechnologies.FirstOrDefaultAsync(t => t.Id == id);
                return technology;
            }
            // Добавить обработку данной ситуации
            return null;
        }
        // Удалить технологию по id

        public async Task RemoveAsync(string id)
        {
            var technology = await GetByIdAsync(id);
            if (technology != null)
            {
                _database.SneakerTechnologies.Remove(technology);
                await _database.SaveChangesAsync();
            }
            else
            {
                // Обработать ошибку
            }
        }
        // Обновить технологию

        public async Task UpdateAsync(SneakerTechnology technology)
        {
            var existingTechnology = await _database.SneakerTechnologies.FindAsync(technology.Id);
            if (existingTechnology == null)
            {
                // Добавить обработку данной ситуэйшон
            }
            else
            {
                existingTechnology.Technology = technology.Technology;
                await _database.SaveChangesAsync();
            }
        }
        // Проверить, существует ли технология по её id

        public async Task<bool> IsExists(string id)
        {
            if (await _database.SneakerTechnologies.AnyAsync(t => t.Id == id))
                return true;
            return false;
        }
    }
}
