using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AwesomeRequestTracker.DTO;
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
            new Claim(ClaimTypes.Name, person.Id.ToString()),
            new Claim(ClaimTypes.Role, person.Role.ToString()),
            new Claim(ClaimTypes.Email, person.Email)
        };
        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
        var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2),
            signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(myToken);
        return token;
    }

    public PayloadDTO GetPayload(string token)
    {
        var tokenHandeler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = _key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
        tokenHandeler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        var jwtToken = (JwtSecurityToken)validatedToken;
        var claims = jwtToken.Claims;
        var payload = new PayloadDTO
        (
            int.Parse(claims.First(x => x.Type == ClaimTypes.Name).Value),
            claims.First(x => x.Type == ClaimTypes.Email).Value,
            (Role)Enum.Parse(typeof(Role), claims.First(x => x.Type == ClaimTypes.Role).Value)
        );

        return payload;
    }
}