using System;
using System.Collections.Generic;
using Android.Content;
using Android.Net.Wifi;
using WiFiAnalyzer.Core.Models;
using WiFiAnalyzer.Core.Services;
using WiFiAnalyzer.Receivers;
using WiFiAnalyzer.Utils;

namespace WiFiAnalyzer.Services
{
    public class NetworkInfoProvider : INetworkInfoProvider
    {
        private readonly Context _context;
        private readonly List<SsidModel> _wifiItems = new List<SsidModel>();
        private IList<ScanResult> _scanResults = new List<ScanResult>();
        private WifiManager _wifiManager;

        public NetworkInfoProvider(Context context)
        {
            _context = context;
            WifiReceiver = new WifiReceiver();
            WifiReceiver.ScanFinished += WifiReceiver_ScanFinished;
        }

        public WifiReceiver WifiReceiver { get; }

        public List<SsidModel> GetAvailableNetworks()
        {
            _context.RegisterReceiver(WifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            _wifiManager = _context.GetSystemService(Context.WifiService) as WifiManager;
            var res = _wifiManager?.StartScan();
            return _wifiItems;
        }

        private void WifiReceiver_ScanFinished(object sender, EventArgs e)
        {
            _scanResults = _wifiManager.ScanResults;

            _wifiItems.Clear();
            foreach (var item in _scanResults)
            {
                var wifi = new SsidModel
                {
                    Name = item.Ssid,
                    Channel = item.Frequency.FrequencyToChannel(),
                    Frequency = item.Frequency,
                    SignalStrength = item.Level
                };

                _wifiItems.Add(wifi);
            }
        }
    }
}