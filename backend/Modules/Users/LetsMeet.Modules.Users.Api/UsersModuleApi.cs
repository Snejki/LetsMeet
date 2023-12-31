﻿using LetsMeet.Modules.Users.Infrastructure;
using LetsMeet.Shared.Abstractions.Modules;
using LetsMeet.Shared.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.Modules.Users.Api;

public class UsersModuleApi : IModule
{
    public void AddModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
    }

    public void UseModule(WebApplication app)
    {
        app.UseCustomEndpoints(typeof(UsersModuleApi).Assembly);
        app.UseInfrastructure();
    }
}