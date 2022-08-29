using AuthGatewayMessengerService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthGatewayMessengerService.Infrastructure.Data;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<UserModel> Users => Set<UserModel>();
}