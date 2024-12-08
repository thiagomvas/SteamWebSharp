using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public class SteamApiClientDefaultCacheProvider : ISteamApiClientCacheProvider
{
    private readonly ConcurrentDictionary<string, CacheItem> _cache = new();
    public T? Get<T>(string key)
    {
        if (_cache.TryGetValue(key, out var item))
        {
            if (item.Expiration > DateTime.UtcNow)
            {
                return (T)item.Value;
            }
            else
            {
                _cache.TryRemove(key, out _);
            }
        }
        return default;
    }

    public void Remove(string key)
    {
        _cache.TryRemove(key, out _);
    }

    public void Set<T>(string key, T value, TimeSpan expiration)
    {
        _cache[key] = new CacheItem
        {
            Value = value,
            Expiration = DateTime.UtcNow + expiration
        };
    }

    private class CacheItem
    {
        public object Value { get; set; }
        public DateTime Expiration { get; set; }
    }
}
