using AuthGatewayMessengerService.Domain.Models;
using AuthGatewayMessengerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthGatewayMessengerService.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository<UserModel>
    {

        private readonly AuthDbContext _context;

        private bool _disposed;

        public AuthRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GerEntityByUsername(string username)
        {
            var userToValidate = await _context
                .Users
                .SingleOrDefaultAsync(u => u.Username == username);
            return userToValidate;
        }

        public void PostEntity(UserModel user)
        {
            _context.Users.Add(user);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}
