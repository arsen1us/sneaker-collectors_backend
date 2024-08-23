using Microsoft.EntityFrameworkCore;
using sneaker_collectors_backend.Models;

namespace sneaker_collectors_backend.Services
{
    public class SnSampleService : ISnSampleService
    {
        SneakerCollectorsContext _database;

        public SnSampleService(SneakerCollectorsContext database)
        {
            _database = database;
        }

        public async Task<SneakerSample> AddAsync(SneakerSample snSample)
        {
            throw new Exception();
        }
        // Получить краткую информацию о sneaker samples по id страницы 

        public async Task<List<SneakerOverviewLite>> GetByPageAsync(string pageId)
        {

            var sneakerOverview = from sn in _database.SneakerSamples
                                  join p in _database.SneakerSamplesPhotos on sn.Id equals p.SneakerSampleId
                                  join b in _database.Brands on sn.BrandId equals b.Id
                                  join sp in _database.SneakerPurposes on sn.Id equals sp.SneakerSampleId

                                  group new { sn, p, b, sp }
                                  by new
                                  {
                                      sn.Id,
                                      sn.Model,
                                      b.LogoSrc,
                                      b.Title,
                                      sn.Color,
                                      sp.Purpose,
                                  } into grouped

                                  select new SneakerOverviewLite
                                  {
                                      Id = grouped.Key.Id,
                                      Model = grouped.Key.Model,
                                      BrandTitle = grouped.Key.Title,
                                      BrandLogo = grouped.Key.LogoSrc,
                                      Color = grouped.Key.Color,
                                      Purpose = grouped.Key.Purpose,
                                      PhotoSrc = grouped.Select(g => g.p.PhotoSrc).ToList()
                                  };

            return await sneakerOverview.ToListAsync();
        }
        // Получить полную информацию о sneaker sample по его id 

        public async Task<SneakerOverview> GetByIdAsync(string id)
        {
            if(await ExistsAsync(id))
            {
                var sneakerOverview = from sn in _database.SneakerSamples
                                      where sn.Id == id
                                      join p in _database.SneakerSamplesPhotos on sn.Id equals p.SneakerSampleId
                                      join b in _database.Brands on sn.BrandId equals b.Id
                                      join m in _database.SneakerMaterials on sn.Id equals m.SneakerId
                                      join sp in _database.SneakerPurposes on sn.Id equals sp.SneakerSampleId

                                      group new { sn, p, b, m, sp }
                                      by new
                                      {
                                          sn.Id,
                                          sn.Model,
                                          b.Title,
                                          sn.Discription,
                                          sn.Color,
                                          sp.Purpose,
                                          sn.Gender,
                                          m.UpMaterial,
                                          m.InsideMaterial,
                                          m.SoleMaterial,
                                          m.InsoleMaterial
                                      } into grouped

                                      select new SneakerOverview
                                      {
                                          Id = grouped.Key.Id,
                                          Model = grouped.Key.Model,
                                          BrandTitle = grouped.Key.Title,
                                          Discription = grouped.Key.Discription,
                                          Color = grouped.Key.Color,
                                          Purpose = grouped.Key.Purpose,
                                          Gender = grouped.Key.Gender,
                                          UpMaterial = grouped.Key.UpMaterial,
                                          InsideMaterial = grouped.Key.InsideMaterial,
                                          SoleMaterial = grouped.Key.SoleMaterial,
                                          IsSoleMaterial = grouped.Key.InsideMaterial,
                                          PhotoSrc = grouped.Select(g => g.p.PhotoSrc).ToList()
                                      };
            }
            return null;
        }
        // Проверка, если такой sneaker sample в бд по id

        public async Task<bool> ExistsAsync(string id)
        {
            if (await _database.SneakerSamples.AnyAsync(sn => sn.Id == id))
                return true;
            return false;
        }
    }
}
