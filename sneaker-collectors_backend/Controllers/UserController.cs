using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Models;
using sneaker_collectors_backend.Services;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace sneaker_collectors_backend.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService _userService;
        IJwtTokenService _jwtTokenService;
        //SneakerCollectorsContext _database;
        HttpClient _client;

        public UserController(IUserService userService /*, SneakerCollectorsContext database*/, IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            //_database = database;
            _jwtTokenService = jwtTokenService;
            _client = HttpClientSingleton.Client;
        }
        //POST: api/user/reg

        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegUser regUser)
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Login = regUser.Login,
                Email = regUser.Email,
                Password = regUser.Password,
            };

            // Добавить jwt-token в заголовок Authorization
            string jwtToken = _jwtTokenService.GenerateJwtToken(user);
            Response.Headers.Add("Authorization", $"Bearer {jwtToken}");

            // Добавить refresh-token в HttpOnly Cookie
            string refreshToken = _jwtTokenService.GenerateRefreshToken();
            Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            await _userService.AddAsync(user);

            return Ok();
        }
        //POST: api/user/check-login

        [HttpPost]
        [Route("check-login")]
        public async Task<IActionResult> CheckLoginAsync([FromBody] LoginModel login)
        {
            if (!_userService.LoginIsTaken(login.Login))
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        //POST: api/user/check-email

        [HttpPost]
        [Route("check-email")]
        public async Task<IActionResult> CheckEmailAsync([FromBody] EmailModel email)
        {
            if (_userService.EmailIsTaken(email.Email))
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        [Route("check-regex-email")]
        public async Task<IActionResult> CheckEmailRegexAsync([FromBody] EmailModel email)
        {
            Regex regexForEmails = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            if (regexForEmails.IsMatch(email.Email))
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthUser authUser)
        {
            User user;

            if (!await _userService.UserExists(authUser))
            {
                return Json("User with email or login doesnt exist");
            }
            else
            {
                user = await _userService.GetAsync(authUser);

                // Добавить jwt-token в заголовок Authorization
                string jwtToken = _jwtTokenService.GenerateJwtToken(user);
                Response.Headers.Add("Authorization", $"Bearer {jwtToken}");

                // Добавить refresh-token в HttpOnly Cookie
                string refreshToken = _jwtTokenService.GenerateRefreshToken();
                Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
                });
                string jsonUser = JsonSerializer.Serialize(user);
                return Json(jsonUser);

            }
        }
    }
}
