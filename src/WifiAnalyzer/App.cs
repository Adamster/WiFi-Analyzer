using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using WifiAnalyzer.Core.Services;
using WifiAnalyzer.Core.ViewModels;

namespace WifiAnalyzer.Core
{
    public class App : MvxApplication
    {

        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<INetworkInfo, NetworkInfo>();

            RegisterAppStart<NetworkViewModel>();
        }

    }
}
