using DataBaseEf.Configurations;
using DataBaseEf.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataBaseEf;

public partial class ContextEf : DbContext
{
    public ContextEf(IOptions<DbConfiguration> config)
        : base(new DbContextOptionsBuilder()
            .UseSqlServer(config.Value.ConnectionStrings).Options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder
            .AddTableLinkStorage();
}