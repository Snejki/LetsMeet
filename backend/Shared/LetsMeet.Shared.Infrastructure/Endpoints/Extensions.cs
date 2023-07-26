using System.Reflection;
using LetsMeet.Shared.Abstractions.Endpoints;
using Microsoft.AspNetCore.Builder;

namespace LetsMeet.Shared.Infrastructure.Endpoints;

public static class Extensions
{
    public static void UseCustomEndpoints(this WebApplication app, Assembly assembly)
    {
        var endpointModules = LoadEndpoints(assembly);

        foreach (var endpointModule in endpointModules)
        {
            endpointModule.MapEndpoints(app);
        }
    }
    
    private static IList<IEndpoints> LoadEndpoints(Assembly assembly)
     => assembly
         .GetTypes()
         .Where(x => typeof(IEndpoints).IsAssignableFrom(x) && !x.IsInterface)
         .Select(Activator.CreateInstance)
         .Cast<IEndpoints>()
         .ToList();
    
}