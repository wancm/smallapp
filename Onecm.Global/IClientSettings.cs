using System;
using System.Collections.Generic;
using System.Text;

namespace Onecm.Global
{
    public interface IClientSettings
    {
        TimeSpan SessionTimeSpan { get; set; }
    }
}
