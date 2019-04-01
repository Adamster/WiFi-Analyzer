using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using WifiAnalyzer.Core.ViewModels;

namespace WifiAnalyzer.Droid.Views
{
    [Activity(Label = "NetworkView", MainLauncher = true)]
    public class NetworkView : MvxActivity<NetworkViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NetworkView);
            // Create your application here
        }
    }
}