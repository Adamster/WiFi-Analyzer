using Android.Content;
using Android.Net.Wifi;
using System;
using System.Collections.Generic;
using System.Text;

namespace WiFiAnalyzer.Core
{
    public class NetworkInfoProvider : INetworkInfoProvider
    {
        private readonly Context _context;
        public WifiReceiver WifiReceiver { get; private set; }
        private WifiManager _wifiManager;
        private IList<ScanResult> _scanResults = new List<ScanResult>();
        private List<SSIDModel> _wifiItems = new List<SSIDModel>();

        public NetworkInfoProvider(Context context)
        {
            _context = context;
            WifiReceiver = new WifiReceiver();
            WifiReceiver.ScanFinished += WifiReceiver_ScanFinished;
        }

       

        public List<SSIDModel> GetAvailableNetworks()
        {
            _context.RegisterReceiver(WifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            _wifiManager = _context.GetSystemService(Context.WifiService) as WifiManager;
            var res = _wifiManager.StartScan();
            return _wifiItems;
        }

        private void WifiReceiver_ScanFinished(object sender, EventArgs e)
        {

            _scanResults = _wifiManager.ScanResults;

            _wifiItems.Clear();
            foreach (var item in _scanResults)
            {
                var wifi = new SSIDModel
                {
                    Name = item.Ssid,
                    Channel = item.Frequency.ieee80211_frequency_to_channel(),
                    Frequency = item.Frequency,
                    SignalStrenght = item.Level
                };

                _wifiItems.Add(wifi);
            }
        }
    }

    public static class Converter
    {
        public static int ieee80211_frequency_to_channel(this int freq)
        {
            if (freq == 2484)
                return 14;

            if (freq < 2484)
                return (freq - 2407) / 5;

            return freq / 5 - 1000;
        }
    }

    public class WifiReceiver : BroadcastReceiver
    {
        public event EventHandler ScanFinished;

        public override void OnReceive(Context context, Intent intent)
        {

            var success = intent.GetBooleanExtra(WifiManager.ExtraResultsUpdated, false);

            if (success)
            {
                ScanFinished?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
