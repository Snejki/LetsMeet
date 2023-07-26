using LetsMeet.Modules.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LetsMeet.Modules.Users.Infrastructure.DAL;

public class UsersDbContext: DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public DbSet<User> Users { get; set; }
}