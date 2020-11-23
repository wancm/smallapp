using Onecm.Global.Caching;
using Onecm.Global.Sessions;
using System;
using System.Threading.Tasks;

namespace Onecm.Sessions
{
    /// <summary>
    /// Helper class of SessionService
    /// </summary>
    public class SessionTokenServiceHelper
    {
        private readonly ICacheService cacheService;

        public SessionTokenServiceHelper(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public async Task<ISessionToken> CreateAsync()
        {
            var token = Guid.NewGuid().ToString();
            var session = new SessionToken(token);

            await cacheService
                .SetValueAsync<ISessionToken>(token, session)
                .ConfigureAwait(false);

            return session;
        }

        public async Task<ISessionToken> GetAsync(string token)
        {
            return await cacheService
                .TryGetValueAsync<ISessionToken>(token)
                .ConfigureAwait(false);
        }
    }
}