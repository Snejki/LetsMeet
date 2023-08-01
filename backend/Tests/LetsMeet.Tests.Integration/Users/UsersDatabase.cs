using LetsMeet.Modules.Users.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace LetsMeet.Tests.Integration.Users;

public class UsersDatabase : IDisposable
{
    public UsersDbContext Context { get; }

    public UsersDatabase()
    {
        Context = new UsersDbContext(new DbContextOptionsBuilder<UsersDbContext>().UseInMemoryDatabase("Users")
            .Options);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}