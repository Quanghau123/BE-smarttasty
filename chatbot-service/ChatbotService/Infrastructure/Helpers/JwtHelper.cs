using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

public class JwtHelper
{
    private readonly string _secret;

    public JwtHelper(string secret)
    {
        _secret = secret;
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        var key = Encoding.ASCII.GetBytes(_secret);
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParams = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };

        return tokenHandler.ValidateToken(token, validationParams, out _);
    }
}
