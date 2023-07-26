using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
namespace LetsMeet.Shared.Abstractions.Modules;

public interface IModule
{
    void AddModule(IServiceCollection services);

    void UseModule(WebApplication app);
}