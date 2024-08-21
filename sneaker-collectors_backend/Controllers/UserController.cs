using Microsoft.AspNetCore.Mvc;
using sneaker_collectors_backend.Services;
using sneaker_collectors_backend.Models.Database;
using System.Text.Json;
using System.Text.RegularExpressions;
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
        //POST: api/user/reg

        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegUser regUser)
        {
            //if(regUser is null) 
            //    BadRequest();

            // Проверка доступности Login и Email
            //if (_userService.LoginIsTaken(regUser.Login))
            //{
            //    return Json($"Login {regUser.Login} already taken");
            //}

            //if (_userService.EmailIsTaken(regUser.Email))
            //{
            //    return Json($"Email {regUser.Email} already taken");
            //}

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
    }
}
