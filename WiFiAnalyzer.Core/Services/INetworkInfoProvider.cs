using System.Collections.Generic;
using WiFiAnalyzer.Core.Models;

namespace WiFiAnalyzer.Core.Services
{
    public interface INetworkInfoProvider
    {
        List<SsidModel> GetAvailableNetworks();
    }
}