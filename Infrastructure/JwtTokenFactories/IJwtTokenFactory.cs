using AnytourApi.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace AnytourApi.Infrastructure.JwtTokenFactories;

public interface IJwtTokenFactory
{
    public Task<string?> GetJwtTokenAsync(User user, IConfiguration configuration);
}