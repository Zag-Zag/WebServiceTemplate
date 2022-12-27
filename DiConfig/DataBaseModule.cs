using AbstractDependencies.DiConfig;
using DataBaseEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiConfig;

internal class DataBaseModule : IDiModuleBase
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services
            .AddDbContext<DbContext, ContextEf>();
}