using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WifiAnalyzer.Core.Models;

namespace WifiAnalyzer.Core
{
    public interface INetworkInfo
    {
        Task<List<NetworkInfoModel>> ScanNetworks();

    }
}
