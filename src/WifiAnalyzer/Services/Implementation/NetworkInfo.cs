using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WifiAnalyzer.Core.Models;

namespace WifiAnalyzer.Core.Services
{
    public class NetworkInfo : INetworkInfo
    {
        public async Task<List<NetworkInfoModel>> ScanNetworks()
        {

            var networks = new List<NetworkInfoModel>
            {
                new NetworkInfoModel()
                {
                    Channel = new Random().Next(1,13),
                    IsProtected = false,
                    SSID = "Holy WiFi"
                },

                new NetworkInfoModel()
                {
                    Channel = new Random().Next(1,13),
                    IsProtected = false,
                    SSID = "Holy WiFi 5Ghz"
                },

                new NetworkInfoModel()
                {
                    Channel = new Random().Next(1,13),
                    IsProtected = false,
                    SSID = "Amdaris Guest"
                },

                new NetworkInfoModel()
                {
                    Channel = new Random().Next(1,13),
                    IsProtected = false,
                    SSID = "Amdaris Pro"
                }
            };

           return await Task.FromResult(networks);

           
        }
    }
}
