using System.Threading.Tasks;

namespace Onecm.Global.Sessions
{
    public interface ISessionTokenService
    {
        Task<ISessionToken> GenerateSessionTokenAsync();
    }
}