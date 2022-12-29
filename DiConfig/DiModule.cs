using AbstractDependencies.DiConfig;
using Microsoft.Extensions.DependencyInjection;

namespace DiConfig;

public class DiModule : IDiModule
{
    private Action<Type, object> _configureOptions;

    public IServiceCollection Registration(IServiceCollection services) =>
        services
            .AddModule<ConfigurationsModule>(_configureOptions)
            .AddModule<RepositoriesModule>()
            .AddModule<ServicesModule>()
            .AddModule<AutomapperModule>()
            .AddModule<RepositoriesModule>()
            .AddModule<LoggerModule>();

    public IDiModule SetCreaterConfigurationSection(Action<Type, object> configureOptions)
    {
        _configureOptions = configureOptions;
        return this;
    }
}
