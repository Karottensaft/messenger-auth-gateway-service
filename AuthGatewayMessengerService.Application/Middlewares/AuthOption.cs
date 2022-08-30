using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthGatewayMessengerService.Application.Middlewares;

public class AuthOptions
{
    public const string Issuer = "Karottensaft";
    public const string Audience = "Sweater";
    private const string Key = "placeholder-key-that-is-long-enough-for-sha256";
    public const int Lifetime = 30;

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}