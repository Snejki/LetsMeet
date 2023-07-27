namespace LetsMeet.Shared.Abstractions.Kernel;

public record ValueObject<T>
{
    protected ValueObject(T value)
    {
        Value = value;
    }

    public T Value { get; protected set; }
    
    public static explicit operator ValueObject<T>(T value) => new(value);
    public static implicit operator T(ValueObject<T> value) => value.Value;
}