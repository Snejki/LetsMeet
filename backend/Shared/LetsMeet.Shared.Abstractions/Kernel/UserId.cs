namespace LetsMeet.Shared.Abstractions.Kernel;

public record UserId
{
    public Guid Id { get; }

    private UserId(Guid id)
    {
        Id = id;
    }

    public static UserId Create(Guid guid) => new (guid);

    public static explicit operator UserId(Guid guid) => new (guid);
    public static implicit operator Guid(UserId userId) => userId.Id;
}