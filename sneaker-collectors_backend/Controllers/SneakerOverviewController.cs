using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Services;
using System.Text.Json;

namespace sneaker_collectors_backend.Controllers
{
    [ApiController]
    [Route("/api/sn-overview")]
    public class SneakerOverviewController : Controller
    {
        ISneakerOverviewService _snOverviewService;

        public SneakerOverviewController(ISneakerOverviewService snOverviewService)
        {
            _snOverviewService = snOverviewService;
        }
        // GET: api/sn-overview/{pageId}

        [HttpGet]
        [Route("{pageId}")]
        public async Task<IActionResult> GetPeaceOfSneakerSamples(string pageId)
        {
            if(!string.IsNullOrEmpty(pageId))
            {
                var sneakerSamples = await _snOverviewService.GetAsync(pageId);
                if(sneakerSamples != null)
                {
                    string jsonSnSamples = JsonSerializer.Serialize(sneakerSamples);
                    return Ok(jsonSnSamples);
                }
                return Ok("Loading Error!");
            }
            return BadRequest();
        }
    }
}
