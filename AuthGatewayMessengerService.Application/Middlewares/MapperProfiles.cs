using AuthGatewayMessengerService.Domain.Dto;
using AuthGatewayMessengerService.Domain.Models;
using AutoMapper;

namespace AuthGatewayMessengerService.Application.Middlewares
{
    public class UserRegistrationProfile : Profile
    {
        public UserRegistrationProfile()
        {
            CreateMap<RegistrationDto, UserModel>();
        }
    }
}
