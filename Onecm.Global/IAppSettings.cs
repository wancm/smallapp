using Onecm.Global.Sessions;
using System;

namespace Onecm.Global
{
    public interface IAppSettings
    {
        TimeSpan DefaultCacheTimeSpan { get; }

        IClientSettings GetClientSettings(ISessionToken session);
    }
}