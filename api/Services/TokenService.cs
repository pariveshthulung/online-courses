using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace api;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration)
    {
        _config = configuration;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
    }
    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
        };

        // encription
        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        // Token
        var tokenDiscriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = cred,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDiscriptor);

        //  returning token in string i.e obj to string
        return tokenHandler.WriteToken(token);

    }
}
