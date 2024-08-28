using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models.Database;
using sneaker_collectors_backend.Services;

namespace sneaker_collectors_backend.Controllers
{
    [ApiController]
    [Route("api/tech")]
    public class TechnologyController : Controller
    {
        ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }
        // POST: api/tech/add

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] AddSneakerTech technology)
        {
            if (technology is null)
                return BadRequest();
            else
            {
                SneakerTechnology tech = new SneakerTechnology
                {
                    Id = Guid.NewGuid().ToString(),
                    Technology = technology.Technology
                };

                await _technologyService.AddAsync(tech);
                return Ok();
            }
        }
        // GET: api/tech/get-all

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var allColors = await _technologyService.GetAllAsync();
            return Ok(allColors);
        }

        // GET: api/tech/get-by-id

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            else
            {
                var color = await _technologyService.GetByIdAsync(id);
                if (color is null)
                {
                    // Добавить обработку данной ситуации
                    return Ok(color);
                }
                else
                {
                    return Ok(color);
                }
            }
        }
        // POST: api/tech/remove

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            else
            {
                await _technologyService.RemoveAsync(id);
                return Ok();
            }
        }
        // POST: api/tech/update

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] AddSneakerTech technology)
        {
            if (technology is null)
                return BadRequest();
            else
            {
                var tech = new SneakerTechnology { Id = id, Technology = technology.Technology };
                await _technologyService.UpdateAsync(tech);
                return Ok();
            }
        }
    }
}
