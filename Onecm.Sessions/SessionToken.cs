using Onecm.Global.Sessions;

namespace Onecm.Sessions
{
    internal sealed class SessionToken : ISessionToken
    {
        public string Token { get; }

        public SessionToken(string token)
        {
            Token = token;
        }
    }
}