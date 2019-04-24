using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using WiFiAnalyzer.Core;
using System.Collections.Generic;
using WiFiAnalyzer.Adapters;
using System.Linq;
using Android.Content;
using System;
using Android.Views;

namespace WiFiAnalyzer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView recyclerView;
        private RecyclerView.Adapter viewAdapter;
        private RecyclerView.LayoutManager viewManager;
        private readonly NetworkInfoProvider _networkInfoProvider;
        private List<SSIDModel> _items = new List<SSIDModel>();

        private TextView EmptyWifiPlaceHolder { get; set; }
        private Button RetryButton { get; set; }

        private GridLayout EmptyGrid { get; set; }

        private ProgressBar progressBar { get; set; }

        public MainActivity()
        {
            _networkInfoProvider = new NetworkInfoProvider(this);
            _networkInfoProvider.WifiReceiver.ScanFinished += WifiReceiver_ScanFinished;
        }

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            EmptyWifiPlaceHolder = FindViewById<TextView>(Resource.Id.NoItemsPlaceholder);
            RetryButton = FindViewById<Button>(Resource.Id.tryAgainBtn);
            EmptyGrid = FindViewById<GridLayout>(Resource.Id.emptyGrid);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            _items = _networkInfoProvider.GetAvailableNetworks();
            if (!_items.Any())
            {
                EmptyWifiPlaceHolder.Visibility = ViewStates.Invisible;
                RetryButton.Visibility = ViewStates.Invisible;
                EmptyGrid.Visibility = ViewStates.Visible;
                RetryButton.Click += RetryButton_Click;

            }

            viewManager = new LinearLayoutManager(this);
            viewAdapter = new SSIDAdapter(_items);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.WifiListRecyclerView);
            recyclerView.SetLayoutManager(viewManager);
            recyclerView.SetAdapter(viewAdapter);


        }

        private void RetryButton_Click(object sender, EventArgs e)
        {
            _items = _networkInfoProvider.GetAvailableNetworks();

            if (_items.Any())
            {
                EmptyGrid.Visibility = ViewStates.Invisible;
                progressBar.Visibility = ViewStates.Invisible;
            }
            else
            {
                EmptyWifiPlaceHolder.Visibility = ViewStates.Visible;
                RetryButton.Visibility = ViewStates.Visible;
                progressBar.Visibility = ViewStates.Invisible;
            }

            viewAdapter.NotifyDataSetChanged();
        }

        private void WifiReceiver_ScanFinished(object sender, EventArgs e)
        {
            RetryButton_Click(sender, e);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}