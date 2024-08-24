using Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.JwtTokenFactories;

public interface IJwtTokenFactory
{
    public Task<string?> GetJwtTokenAsync(User user, IConfiguration configuration);
}