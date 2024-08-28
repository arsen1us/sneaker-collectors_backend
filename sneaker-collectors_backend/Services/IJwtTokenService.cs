using sneaker_collectors_backend.Models;

namespace sneaker_collectors_backend.Services
{
    public interface IJwtTokenService
    {
        public string GenerateJwtToken(User user);
        public string GenerateRefreshToken();
        public Task<string> UpdateAsync(string jwtToken);

    }
}
