using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Services;
using sneaker_collectors_backend.Models.Database;
using System.Text.Json;
using sneaker_collectors_backend.Models;

namespace sneaker_collectors_backend.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService _userService;
        SneakerCollectorsContext _database;

        public UserController(IUserService userService, SneakerCollectorsContext database)
        {
            _userService = userService;
            _database = database;
        }

        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegUser user)
        {
            if(user is null) 
                BadRequest();


            await _userService.AddAsync(user);

            return Json(JsonSerializer.Serialize(user));
        }


    }
}
