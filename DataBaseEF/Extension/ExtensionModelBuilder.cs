using Microsoft.EntityFrameworkCore;

namespace DataBaseEf.Extension;

internal static class ExtensionModelBuilder
{
    internal static ModelBuilder AddTableLinkStorage(this ModelBuilder builder) => builder;
}
