using AbstractDependencies.DiConfig;
using Microsoft.Extensions.DependencyInjection;
using ServiseLogger;

namespace DiConfig;

internal class LoggerModule : IDiModuleBase
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services.AddScoped<IManagerLogger, ManagerLogger>();
}