using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthGatewayMessengerService.Application.Middlewares;
using AuthGatewayMessengerService.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthGatewayMessengerService.Application.Middlewares;

public class TokenBuilder : ITokenBuilder<TokenModel>
{
    public TokenModel BuildToken(string username)
    {
        var signingKey = AuthOptions.GetSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username)
        };
        var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new TokenModel
        {
            AccessToken = encodedJwt
        };

        return response;
    }
}