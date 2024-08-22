using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using sneaker_collectors_backend.Services;

namespace sneaker_collectors_backend.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class TokenController : Controller
    {
        IJwtTokenService _tokenService;
        IUserService _userService;
        IConfiguration _configuration;

        public TokenController(IJwtTokenService tokenService, IUserService userService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _userService = userService;
            _configuration = configuration;
        }

        // GET: api/token/update
        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> UpdateJwtToken()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

            string jwtToken = token.ToString();

            string newToken = await _tokenService.UpdateAsync(jwtToken);

            HttpContext.Response.Headers.Add("Authorization", $"Bearer {newToken}");
            return Ok();
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRefreshToken()
        {
            throw new Exception();
        }
    }
}
