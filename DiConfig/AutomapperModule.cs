using AbstractDependencies.DiConfig;
using Microsoft.Extensions.DependencyInjection;


namespace DiConfig;

internal class AutomapperModule : IDiModuleBase
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services
            /*.AddAutoMapper(typeof(BaseMapProfile<TSource, TDestination>))*/;
}
