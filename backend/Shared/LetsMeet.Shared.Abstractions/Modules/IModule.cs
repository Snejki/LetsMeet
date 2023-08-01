using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace LetsMeet.Shared.Abstractions.Modules;

public interface IModule
{
    void AddModule(IServiceCollection services, IConfiguration configuration);

    void UseModule(WebApplication app);
}