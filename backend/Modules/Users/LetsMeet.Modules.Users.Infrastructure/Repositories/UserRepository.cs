using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Modules.Users.Domain.Repositories;
using LetsMeet.Modules.Users.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace LetsMeet.Modules.Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _dbContext;

    public UserRepository(UsersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User?> GetById(UserId userId) => _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
    
    public Task<User?> GetByEmail(Email email) => _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

    public Task Create(User user)
    {
        _dbContext.Users.Add(user);
        return _dbContext.SaveChangesAsync();
    }
}