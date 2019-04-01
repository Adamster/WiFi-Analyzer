using System.Threading.Tasks;
using MvvmCross.ViewModels;
using WifiAnalyzer.Core.Models;

namespace WifiAnalyzer.Core.ViewModels
{
    public class NetworkViewModel : MvxViewModel
    {
        private readonly INetworkInfo _networkInfo;

        public MvxObservableCollection<NetworkInfoModel> Networks { get; set; } = new MvxObservableCollection<NetworkInfoModel>();

        public NetworkViewModel(INetworkInfo networkInfo)
        {
            _networkInfo = networkInfo;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            var scanResult = await _networkInfo.ScanNetworks();
            Networks.AddRange(scanResult);

        }
    }
}
