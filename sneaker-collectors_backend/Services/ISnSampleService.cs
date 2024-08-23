using sneaker_collectors_backend.Models;

namespace sneaker_collectors_backend.Services
{
    public interface ISnSampleService
    {
        public Task<List<SneakerOverviewLite>> GetByPageAsync(string page);

        public Task<SneakerOverview> GetByIdAsync(string id);

        public Task<SneakerSample> AddAsync(SneakerSample snSample);

        public Task<bool> ExistsAsync(string id);
    }
}
