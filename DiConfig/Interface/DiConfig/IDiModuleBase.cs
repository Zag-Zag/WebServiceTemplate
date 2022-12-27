using Microsoft.Extensions.DependencyInjection;

namespace AbstractDependencies.DiConfig;

public interface IDiModuleBase
{
    IServiceCollection Registration(IServiceCollection services);
}
