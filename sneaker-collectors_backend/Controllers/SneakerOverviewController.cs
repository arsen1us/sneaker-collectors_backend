using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Services;
using System.Text.Json;

namespace sneaker_collectors_backend.Controllers
{
    [ApiController]
    [Route("api/sn-overview")]
    public class SneakerOverviewController : Controller
    {
        ISneakerOverviewService _snOverviewService;
        ISnSampleService _snSampleService;

        public SneakerOverviewController(ISneakerOverviewService snOverviewService, ISnSampleService snSampleService)
        {
            _snOverviewService = snOverviewService;
            _snSampleService = snSampleService;
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
        // GET: api/sn-overview/get-all

        [Authorize]
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Get(string id)
        {
            var sneakerOverview = await _snSampleService.GetByPageAsync("");
            return Ok(sneakerOverview);
        }
        // GET: api/sn-overview/get-by-id/{id}

        [Authorize]
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                var sneakerOverview = await _snSampleService.GetByIdAsync(id);
                return Ok(sneakerOverview);
            }
            return BadRequest();
            
        }
    }
}
