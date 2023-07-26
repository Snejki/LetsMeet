namespace LetsMeet.Modules.Users.Domain.Entities;

public record UserId
{
    public Guid Id { get; }

    private UserId(Guid id)
    {
        Id = id;
    }

    public static UserId Create(Guid guid) => new UserId(guid);
}