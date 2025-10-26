using System.Collections.Concurrent;

namespace M.A.G.U.S.Assistant.Services;

internal static class NavigationParameterStore
{
    private static readonly ConcurrentDictionary<string, object> store = new();

    public static string Put(object value)
    {
        var id = Guid.NewGuid().ToString("N");
        store[id] = value;
        return id;
    }

    public static T? Get<T>(string id) where T : class
    {
        if (id == null)
        {
            return null;
        }

        if (store.TryRemove(id, out var value))
        {
            return value as T;
        }
        return null;
    }
}
