using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models.Database;
using sneaker_collectors_backend.Services;

namespace sneaker_collectors_backend.Controllers
{
    [ApiController]
    [Route("api/sneaker-color")]
    public class ColorController : Controller
    {
        IDatabaseService<SneakerColor> _colorService;

        public ColorController(IDatabaseService<SneakerColor> colorService)
        {
            _colorService = colorService;
        }
        // POST: api/sneaker-color/add

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] AddSneakerColor addColor)
        {
            if (addColor is null)
                return BadRequest();
            else
            {
                var color = new SneakerColor
                {
                    Id = Guid.NewGuid().ToString(),
                    Color = addColor.Color,
                };

                await _colorService.AddAsync(color);
                return Ok();
            }
        }
        // GET: api/sneaker-color/get-all
        
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var allColors = await _colorService.GetAllAsync();
            return Ok(allColors);
        }

        // GET: api/sneaker-color/get-by-id

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest();
            else
            {
                var color = await _colorService.GetByIdAsync(id);
                if(color is null)
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
        // POST: api/sneaker-color/remove

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest();
            else
            {
                await _colorService.RemoveAsync(id);
                return Ok();
            }
        }
        // POST: api/sneaker-color/update/{id}

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] AddSneakerColor color)
        {
            if(color is null)
                return BadRequest();
            else
            {
                var col = new SneakerColor { Id = id, Color = color.Color };
                await _colorService.UpdateAsync(col);
                return Ok();
            }
        }
    }
}
