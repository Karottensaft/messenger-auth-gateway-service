namespace AuthGatewayMessengerService.Application.Middlewares
{
    public interface ITokenBuilder<T> where T : class
    {
        T BuildToken(string username);
    }
}
