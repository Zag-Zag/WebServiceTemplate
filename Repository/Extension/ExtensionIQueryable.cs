using Microsoft.EntityFrameworkCore;

namespace Repository.Extension;

internal static class ExtensionIQueryable
{
    internal static IList<T> ExtractList<T>(this IQueryable<T> queryable) 
    {
        var result = queryable.ToList();
        result.TrimExcess();
        return result;
    }

    internal static async Task<IList<T>> ExtractListAsync<T>(this IQueryable<T> queryable)
    {
        var result = await queryable.ToListAsync();
        result.TrimExcess();
        return result;
    }

}
