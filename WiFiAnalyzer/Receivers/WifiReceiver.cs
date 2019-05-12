using System;
using Android.Content;
using Android.Net.Wifi;

namespace WiFiAnalyzer.Receivers
{
    public class WifiReceiver : BroadcastReceiver
    {
        public event EventHandler ScanFinished;

        public override void OnReceive(Context context, Intent intent)
        {
            var success = intent.GetBooleanExtra(WifiManager.ExtraResultsUpdated, false);

            if (success)
                ScanFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}