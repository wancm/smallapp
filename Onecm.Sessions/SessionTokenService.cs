using Onecm.Global.Caching;
using Onecm.Global.Sessions;
using System.Threading.Tasks;

namespace Onecm.Sessions
{
    internal sealed class SessionTokenService : ISessionTokenService
    {
        private readonly SessionTokenServiceHelper sessionTokenServiceHelper;

        public SessionTokenService(ICacheService cacheService)
        {
            sessionTokenServiceHelper = new SessionTokenServiceHelper(cacheService);
        }

        public async Task<ISessionToken> GenerateSessionTokenAsync()
        {
            return await sessionTokenServiceHelper
                .CreateAsync()
                .ConfigureAwait(false);
        }
    }
}