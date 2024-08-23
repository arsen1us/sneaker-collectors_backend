using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sneaker_collectors_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/admin-panel")]
    public class AdminController : Controller
    {
        // POST: api/admin-panel/add

        [HttpPost]
        [Route("sn-sample/add")]
        public async Task<IActionResult> AddSnSampleAsync([FromBody] SneakerSample sneaker)
        {
            throw new Exception();
        }
        // POST: api/admin-panel/get

        [HttpGet]
        [Route("sn-sample/get/{sneakerId}")]
        public async Task<IActionResult> GetSnSampleAsync(string sneakerId)
        {
            throw new Exception();
        }
        // POST: api/admin-panel/ch

        [HttpPost]
        [Route("sn-sample/ch")]
        public async Task<IActionResult> ChangeSnSampleAsync()
        {
            throw new Exception();
        }
        // POST: api/admin-panel/del

        [HttpPost]
        [Route("sn-sample/del")]
        public async Task<IActionResult> DeleteSnSampleAsync()
        {
            throw new Exception();
        }
    }
}
