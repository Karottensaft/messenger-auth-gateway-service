using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthGatewayMessengerService.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthGatewayMessengerService.Application.Middlewares
{
    public class TokenBuilder : ITokenBuilder<TokenModel>
    {
        public TokenModel BuildToken(string username)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("placeholder-key-that-is-long-enough-for-sha256"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
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
}
