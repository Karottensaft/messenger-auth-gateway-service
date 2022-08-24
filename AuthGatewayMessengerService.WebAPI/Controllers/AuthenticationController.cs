using AuthGatewayMessengerService.Application.Services;
using AuthGatewayMessengerService.Domain.Dto;
using AuthGatewayMessengerService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthGatewayMessengerService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<TokenModel> Login([FromBody] AuthDto user)
        {
            return await _authService.ValidateUser(user);
        }

        [HttpPost("registration")]
        public async Task PostUser([FromBody] RegistrationDto user)
        {
            await _authService.CreateUser(user);
        }
    }
}
