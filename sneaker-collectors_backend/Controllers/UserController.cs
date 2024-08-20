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
        IJwtTokenService _jwtTokenService;
        SneakerCollectorsContext _database;
        HttpClient _client;

        public UserController(IUserService userService, SneakerCollectorsContext database, IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            _database = database;
            _jwtTokenService = jwtTokenService;
            _client = HttpClientSingleton.Client;
        }

        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegUser regUser)
        {
            if(regUser is null) 
                BadRequest();

            if (_userService.LoginIsTaken(regUser.Login))
                //return Json($"Login {user.Login} already taken");
                return StatusCode(200, $"Login {regUser.Login} already taken");

            if (_userService.EmailIsTaken(regUser.Email))
                //return Json($"Email {user.Email} already taken");
                return StatusCode(200, $"Login {regUser.Login} already taken");

            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Login = regUser.Login,
                Email = regUser.Email,
                Password = regUser.Password,
            };

            // Добавить jwt-token в заголовок Authorization
            string jwtToken = _jwtTokenService.GenerateJwtToken(user);
            HttpContext.Response.Headers.Add("Authorization", $"Bearer {jwtToken}");

            // Добавить refresh-token в HttpOnly Cookie
            string refreshToken = _jwtTokenService.GenerateRefreshToken();
            HttpContext.Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            await _userService.AddAsync(user);

            return Json(JsonSerializer.Serialize(regUser));
        }


    }
}
