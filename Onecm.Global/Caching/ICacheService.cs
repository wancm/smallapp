using System;
using System.Threading.Tasks;

namespace Onecm.Global.Caching
{
    public interface ICacheService
    {
        Task<T> TryGetValueAsync<T>(string key);

        Task SetValueAsync<T>(string key, T value, TimeSpan expiredTimeSpan = default);

        Task SetValueAsync<T>(string key, T value, DateTimeOffset absoluteExpiration);

        Task RemoveValueAsync(string key);
    }
}