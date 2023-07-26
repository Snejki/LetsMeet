using LetsMeet.Shared.Infrastructure;
using LetsMeet.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
var assemblies = ModulesLoader.LoadAssemblies(builder.Configuration);
var modules = ModulesLoader.LoadModules(assemblies);

builder.AddInfrastructure(assemblies);
foreach (var module in modules)
{
    module.AddModule(builder.Services);
}

var app = builder.Build();
app.UseInfrastructure();
foreach (var module in modules)
{
    module.UseModule(app);
}

app.Run();

