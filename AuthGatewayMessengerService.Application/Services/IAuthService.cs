using AuthGatewayMessengerService.Domain.Dto;
using AuthGatewayMessengerService.Domain.Models;

namespace AuthGatewayMessengerService.Application.Services
{
    public interface IAuthService
    {
        Task<TokenModel> ValidateUser(AuthDto user);
        Task CreateUser(RegistrationDto userToMap);
    }
}
