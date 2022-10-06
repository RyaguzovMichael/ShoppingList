using CommonRepository.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization.API.Extensions;

public static class CookieExtensions
{
    public static void SetJwtToken(this IResponseCookies cookies, List<Claim> claims, JWTSettings jwtSettings)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

        var jwt = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        cookies.Append("jwt", new JwtSecurityTokenHandler().WriteToken(jwt), new CookieOptions { MaxAge = TimeSpan.FromMinutes(10) });
    }
}
