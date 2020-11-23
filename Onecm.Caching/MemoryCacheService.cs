using Microsoft.Extensions.Caching.Memory;
using Onecm.Global;
using Onecm.Global.Caching;
using System;
using System.Threading.Tasks;

namespace Onecm.Caching
{
    internal sealed class MemoryCacheService : ICacheService
    {
        private readonly IAppSettings appSettings;
        private readonly IMemoryCache memoryCache;

        public MemoryCacheService(IAppSettings appSettings, IMemoryCache memoryCache)
        {
            this.appSettings = appSettings;
            this.memoryCache = memoryCache;
        }

        public async Task<T> TryGetValueAsync<T>(string key)
        {
            return await Task.Run(() =>
            {
                if (memoryCache == null)
                {
                    return default;
                }

                if (memoryCache.TryGetValue(key, out T returnValue))
                {
                    return returnValue;
                }
                else
                {
                    return default;
                }
            }).ConfigureAwait(false);
        }

        public async Task SetValueAsync<T>(string key, T value, TimeSpan expiredTimeSpan = default)
        {
            await Task.Run(() =>
            {
                if (expiredTimeSpan == default)
                {
                    memoryCache.Set(key, value, appSettings.DefaultCacheTimeSpan);
                }
                else
                {
                    memoryCache.Set(key, value, expiredTimeSpan);
                }
            }).ConfigureAwait(false);
        }

        public async Task SetValueAsync<T>(string key, T value, DateTimeOffset absoluteExpiration)
        {
            await Task.Run(() =>
            {
                memoryCache.Set(key, value, absoluteExpiration);
            }).ConfigureAwait(false);
        }

        public async Task RemoveValueAsync(string key)
        {
            await Task.Run(() =>
            {
                memoryCache.Remove(key);
            }).ConfigureAwait(false);
        }
    }
}