using AbstractDependencies.DiConfig;
using Microsoft.Extensions.DependencyInjection;

namespace DiConfig;

internal class ServicesModule : IDiModuleBase
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services/*.AddScoped<TService, TImplementation>()*/;
}
