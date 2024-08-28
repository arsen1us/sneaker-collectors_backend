
using Microsoft.EntityFrameworkCore;

namespace sneaker_collectors_backend.Services
{
    public class SneakerOverviewService : ISneakerOverviewService
    {
        private const int limit = 10;
        SneakerCollectorsContext _database;

        public SneakerOverviewService(SneakerCollectorsContext database)
        {
            _database = database;
        }

        public async Task<List<SneakerSample>> GetAsync(string pageId)
        {
            int offset = Int32.Parse(pageId) - 10;

            if (offset == 0)
            {
                var sneakerSamples = _database.SneakerSamples.Take(limit);

                return await sneakerSamples.ToListAsync();
            }
            else
            {
                var sneakerSamples = _database.SneakerSamples.Skip(offset).Take(limit);
                return await sneakerSamples.ToListAsync();
            }
        }
    }
}
