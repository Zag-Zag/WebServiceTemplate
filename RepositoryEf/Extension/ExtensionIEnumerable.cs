
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseEf.Extension;

internal static class ExtensionIEnumerable
{
    internal static async Task<bool> AnyAsync<T>(this IEnumerable<T> values) => await values.FirstOrDefaultAsync() == null;

    internal static async Task<T> FirstOrDefaultAsync<T>(this IEnumerable<T> values)
    {
        return await Task.Run(() =>
        {
            T result = default;
            foreach (var value in values)
            {
                result = value;
                break;
            }
            return result;
        });
    }
}
