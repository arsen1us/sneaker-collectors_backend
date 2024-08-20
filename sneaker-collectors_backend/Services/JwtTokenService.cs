using Microsoft.IdentityModel.Tokens;
using sneaker_collectors_backend.Models.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace sneaker_collectors_backend.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        IConfiguration _configuration;
        IUserService _userService;

        public JwtTokenService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;

        }

        // Создать Jwt-токен
        public string GenerateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim("Login", user.Login)
            };

            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"])), SecurityAlgorithms.HmacSha256Signature)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        // Обновить истёкший jwt-token
        public async Task<string> UpdateAsync(string jwtToken)
        {
            var principal = GetPrincipalExpiredToken(jwtToken);

            string id = principal.FindFirst("Id").Value;
            string login = principal.FindFirst("Login").Value;

            var user = await _userService.GetAsync(id, login);
            if (user is null)
                return string.Empty;
            var token = GenerateJwtToken(user);
            return token;

        }

        // Создать Refresh token
        // Получается токен вида: RA2Isc+d/w51Y1vttEk2/rx1DUuOi7CLCvHu41rjbpI=
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        // Проверить истёкший jwt-token
        private ClaimsPrincipal GetPrincipalExpiredToken(string expiredToken)
        {
            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(expiredToken, tokenValidationParameter, out SecurityToken securityToken);

            var jwtSecureToken = securityToken as JwtSecurityToken;

            if (jwtSecureToken == null || !jwtSecureToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
            {
                // Если равен null - jwt-token is invalid
                // Логика обработки данного момента
                return null;
            }
            return principal;
        }
    }
}
