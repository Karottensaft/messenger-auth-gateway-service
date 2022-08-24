using AuthGatewayMessengerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthGatewayMessengerService.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly AuthDbContext _context;

        private bool _disposed;

        public UnitOfWork(DbContextOptions<AuthDbContext> options)
        {
            _context = new AuthDbContext(options);
            AuthRepository = new AuthRepository(_context);
        }

        public AuthRepository AuthRepository { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
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