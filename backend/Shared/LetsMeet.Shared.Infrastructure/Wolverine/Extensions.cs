using System.Reflection;
using LetsMeet.Shared.Infrastructure.Validation;
using Microsoft.AspNetCore.Builder;
using Wolverine;

namespace LetsMeet.Shared.Infrastructure.Wolverine;

internal static class Extensions
{
    public static void UseCustomWolverine(this ConfigureHostBuilder host, 
        Assembly applicationAssembly, 
        IList<Assembly> assemblies)
    {
        host.UseWolverine((context, options) =>
        {
            options.ApplicationAssembly = applicationAssembly;
            foreach (var assembly in assemblies)
            {
                options.Discovery.IncludeAssembly(assembly);
            }

            options.UseCustomValidation();
            options.Policies.AddMiddlewares();
        });
    }

    private static void AddMiddlewares(this IPolicies policies)
    {
    }
}