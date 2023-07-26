using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LetsMeet.Shared.Infrastructure.Swagger;

public static class Extensions
{
    public static void AddCustomSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void UseCustomSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {   
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}