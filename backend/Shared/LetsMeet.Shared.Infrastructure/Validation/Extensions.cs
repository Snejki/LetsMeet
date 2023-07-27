using Wolverine;
using Wolverine.FluentValidation;

namespace LetsMeet.Shared.Infrastructure.Validation;

internal static class Extensions
{
    public static void UseCustomValidation(this WolverineOptions options)
    {
        options.UseFluentValidation();
    }
}