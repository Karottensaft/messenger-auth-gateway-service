namespace AuthGatewayMessengerService.Infrastructure.Repositories
{
    public interface IAuthRepository<T> : IDisposable
        where T : class
    {
        Task<T> GerEntityByUsername(string username);
        void PostEntity(T entity);
    }
}
