using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AwesomeRequestTracker.Models;
using Microsoft.IdentityModel.Tokens;

namespace AwesomeRequestTracker.Serivces;

public class TokenService : ITokenService
{
    private readonly string _secretKey;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration)
    {
        _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
    }

    public string GenerateToken(Person person)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, person.Email),
            new Claim(ClaimTypes.Role, person.Role.ToString()),
            new Claim(ClaimTypes.Email, person.Email)
        };
        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
        var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2),
            signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(myToken);
        return token;
    }
}