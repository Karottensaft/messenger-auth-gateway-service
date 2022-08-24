using AutoMapper;
using AuthGatewayMessengerService.Application.Middlewares;
using AuthGatewayMessengerService.Domain.Dto;
using AuthGatewayMessengerService.Domain.Models;
using AuthGatewayMessengerService.Infrastructure.Repositories;

namespace AuthGatewayMessengerService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly ITokenBuilder<TokenModel> _tokenBuilder;

        public AuthService(UnitOfWork unitOfWork, IMapper mapper, ITokenBuilder<TokenModel> tokenBuilder)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<TokenModel> ValidateUser(AuthDto userToValidate)
        {
            var userToMap = await _unitOfWork.AuthRepository.GerEntityByUsername(userToValidate.Username);
            if (userToMap == null) throw new InvalidDataException("Wrong username or password");
            if (HashPasswordMiddleware.VerifyPassword(userToValidate.Password, userToMap.Password))
            {
                return _tokenBuilder.BuildToken(userToValidate.Username);
            }
            else
            {
                throw new InvalidDataException("Wrong username or password");
            }
        }

        public async Task CreateUser(RegistrationDto userToMap)
        {
            var userToValidate = await _unitOfWork.AuthRepository.GerEntityByUsername(userToMap.Username);

            if (userToValidate == null)
            {
                userToMap.Password = HashPasswordMiddleware.CreatePasswordHash(userToMap.Password);
                var user = _mapper.Map<UserModel>(userToMap);
                _unitOfWork.AuthRepository.PostEntity(user);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new ArgumentException("User already exist.");
            }
        }
    }
}
