using System;
using System.Collections.Generic;
using System.Text;

namespace WiFiAnalyzer.Core
{
    public interface INetworkInfoProvider
    {
        List<SSIDModel> GetAvailableNetworks();
    }
}
