using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using WiFiAnalyzer.Adapters;
using WiFiAnalyzer.Core.Models;
using WiFiAnalyzer.Services;
using Xamarin.Essentials;
using static Android.Support.V7.Widget.RecyclerView;

namespace WiFiAnalyzer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private readonly NetworkInfoProvider _networkInfoProvider;
        private List<SsidModel> _items = new List<SsidModel>();
        private RecyclerView _recyclerView;
        private RecyclerView.Adapter _viewAdapter;
        private LayoutManager _viewManager;

        public MainActivity()
        {
            _networkInfoProvider = new NetworkInfoProvider(this);
            _networkInfoProvider.WifiReceiver.ScanFinished += WifiReceiver_ScanFinished;
        }

        private TextView EmptyWifiPlaceHolder { get; set; }
        private Button RetryButton { get; set; }

        private GridLayout EmptyGrid { get; set; }

        private ProgressBar ProgressBar { get; set; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            EmptyWifiPlaceHolder = FindViewById<TextView>(Resource.Id.NoItemsPlaceholder);
            RetryButton = FindViewById<Button>(Resource.Id.tryAgainBtn);
            EmptyGrid = FindViewById<GridLayout>(Resource.Id.emptyGrid);
            ProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            _items = _networkInfoProvider.GetAvailableNetworks();
            if (!_items.Any())
            {
                EmptyWifiPlaceHolder.Visibility = ViewStates.Invisible;
                RetryButton.Visibility = ViewStates.Invisible;
                EmptyGrid.Visibility = ViewStates.Visible;
                RetryButton.Click += RetryButton_Click;
            }

            _viewManager = new LinearLayoutManager(this);
            _viewAdapter = new SsidAdapter(_items);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.WifiListRecyclerView);
            _recyclerView.SetLayoutManager(_viewManager);
            _recyclerView.SetAdapter(_viewAdapter);
        }

        private void RetryButton_Click(object sender, EventArgs e)
        {
            _items = _networkInfoProvider.GetAvailableNetworks();

            if (_items.Any())
            {
                EmptyGrid.Visibility = ViewStates.Invisible;
                ProgressBar.Visibility = ViewStates.Invisible;
            }
            else
            {
                EmptyWifiPlaceHolder.Visibility = ViewStates.Visible;
                RetryButton.Visibility = ViewStates.Visible;
                ProgressBar.Visibility = ViewStates.Invisible;
            }

            _viewAdapter.NotifyDataSetChanged();
        }

        private void WifiReceiver_ScanFinished(object sender, EventArgs e)
        {
            RetryButton_Click(sender, e);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}